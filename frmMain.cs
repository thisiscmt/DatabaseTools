using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Xml.Serialization;
using Nini.Config;

namespace DBTools
{
    public enum MainFormColumns
    {
        JobType = 1,
        Task = 2,
        Path = 3,
        Details = 4
    }

    public partial class frmMain : Form
    {
        private JobEngine m_jobEngine;

        private BackgroundWorkerExt m_bw;

        private bool m_firstLogin;  // Indicates the user is logging in for the first time

        private bool m_working;  // Indicates jobs are currently being run

        private bool m_cancel;  // Indicates job execution has been cancelled

        private const string DEFAULT_JOB_FILE = "dbjobs.xml";

        private const int MRU_START_INDEX = 5;  // The starting point of the MRU section 
                                                // in the File menu

        private const int MRU_ITEM_MAX_LENGTH = 60;  // The max number of characters in 
                                                     // an MRU file path that will be shown 
                                                     // before it is abbreviated

        private const int MRU_DEFAULT_LIST_MAX_LENGTH = 8;

        #region Form event handlers
        public frmMain()
        {
            try
            {
                InitializeComponent();

                this.m_firstLogin = true;
                this.m_working = false;
                lblCancel.Visible = false;
                pbrMain.Visible = false;
                this.Unload = false;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.m_working)
                {
                    this.m_bw.PauseWork();

                    if (MessageBox.Show("Do you wish to end job execution and close the application?", Program.ERROR_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        this.m_cancel = true;
                        this.m_bw.CancelAsync();
                        this.m_bw.ResumeWork();
                        lblStatus.Text = "Exiting ...";

                        // Wait until the current job has completed
                        while (!this.m_working)
                        {
                            System.Threading.Thread.Sleep(300);
                        }
                    }
                    else
                    {
                        e.Cancel = true;
                        this.m_bw.ResumeWork();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "frmMain_FormClosing", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            string saveOnExit;

            try
            {
                if (Program.CurrentServer != null)
                {
                    Program.CurrentServer.ConnectionContext.Disconnect();
                }

                if (!File.Exists(Program.ConfigFile.SavePath))
                {
                    File.CreateText(Program.ConfigFile.SavePath).Close();
                }

                if (Program.ConfigFile.Configs["MRU"] == null)
                {
                    Program.ConfigFile.Configs.Add("MRU");
                }

                if (mnuSaveOnExit.Checked)
                {
                    saveOnExit = "On";
                }
                else
                {
                    saveOnExit = "Off";
                }

                Program.ConfigFile.Configs["MRU"].Set("SaveOnExit", saveOnExit);
                Program.ConfigFile.Save();

                if (mnuSaveOnExit.Checked)
                {
                    mnuSave_Click("FormClosed", null);
                }

                // We need to run this after the current file is saved, if it needs 
                // to be saved, so that file can be included in the MRU list
                SaveMRUFileEntries();
            }
            catch
            {
            }
        }
        #endregion

        #region Menustrip event handlers
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            string fileName;
            string filePath;
            string filter;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                filter = "Job Files (*.xml)|*.xml|All Files (*.*)|*.*";

                if (string.IsNullOrEmpty(Program.CurrentJobFile))
                {
                    fileName = DEFAULT_JOB_FILE;
                }
                else
                {
                    fileName = "";
                }

                filePath = Utility.BrowseForFileOpen("xml", filter, fileName);

                if (LoadJobs(filePath))
                {
                    Program.CurrentJobFile = filePath;
                    this.Text = Program.MAIN_CAPTION + " - " + Path.GetFileName(filePath);
                    AddMRUFileEntry(filePath);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuOpen_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e)
        {
            string filePath;
            string filter;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                if (lvwMain.Items.Count > 0)
                {
                    if (string.IsNullOrEmpty(Program.CurrentJobFile))
                    {
                        filePath = Path.Combine(Program.UserDataPath, DEFAULT_JOB_FILE);

                        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                        }
                    }
                    else
                    {
                        filePath = Program.CurrentJobFile;
                    }

                    // If the Save toolstrip button invoked this handler, prompt 
                    // the user for where they want to save the file. Otherwise we 
                    // assume the FormClosed event is the caller, so skip the prompt
                    if (sender.ToString() == "Save")
                    {
                        filter = "Job Files (*.xml)|*.xml|All Files (*.*)|*.*";
                        filePath = Utility.BrowseForFileSave("xml", filter, Path.GetFileName(filePath));
                    }

                    if (SaveJobs(filePath))
                    {
                        Program.CurrentJobFile = filePath;
                        this.Text = Program.MAIN_CAPTION + " - " + Path.GetFileName(filePath);
                        AddMRUFileEntry(filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuSave_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuFileMRU_Click(object sender, EventArgs e)
        {
            string filePath;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                filePath = ((ToolStripMenuItem) sender).Name;

                if (File.Exists(filePath))
                {
                    if (LoadJobs(filePath))
                    {
                        Program.CurrentJobFile = filePath;
                        this.Text = Program.MAIN_CAPTION + " - " + Path.GetFileName(filePath);
                        AddMRUFileEntry(filePath);
                    }
                }
                else
                {
                    mnuFile.DropDownItems.RemoveByKey(filePath);

                    if (mnuFile.DropDownItems.Count == MRU_START_INDEX + 2)
                    {
                        mnuFile.DropDownItems.RemoveByKey("MRUSeparator");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuFileMRU_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mnuAddBackupJob_Click(object sender, EventArgs e)
        {
            frmBackupJob backupForm = null;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                backupForm = new frmBackupJob();

                if (!backupForm.Unload)
                {
                    backupForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuAddBackupJob_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (backupForm != null)
                {
                    backupForm.Dispose();
                }
            }
        }

        private void mnuAddRestoreJob_Click(object sender, EventArgs e)
        {
            frmRestoreJob restoreForm = null;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                restoreForm = new frmRestoreJob();

                if (!restoreForm.Unload)
                {
                    restoreForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuAddRestoreJob_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (restoreForm != null)
                {
                    restoreForm.Dispose();
                }
            }
        }

        private void mnuAddShrinkJob_Click(object sender, EventArgs e)
        {
            frmShrinkJob shrinkForm = null;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                shrinkForm = new frmShrinkJob();

                if (!shrinkForm.Unload)
                {
                    shrinkForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuAddShrinkJob_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (shrinkForm != null)
                {
                    shrinkForm.Dispose();
                }
            }
        }

        private void mnuAddCopyJob_Click(object sender, EventArgs e)
        {
            frmCopyJob copyForm = null;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                copyForm = new frmCopyJob();

                if (!copyForm.Unload)
                {
                    copyForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuAddCopyJob_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (copyForm != null)
                {
                    copyForm.Dispose();
                }
            }
        }

        private void mnuSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem li in lvwMain.Items)
                {
                    li.Selected = true;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuSelectAll_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                lvwMain.SelectedItems.Clear();
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuClearAll_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuEditJob_Click(object sender, EventArgs e)
        {
            frmBackupJob backupForm;
            frmRestoreJob restoreForm;
            frmShrinkJob shrinkForm;
            frmCopyJob copyForm;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                foreach (ListViewItem li in lvwMain.SelectedItems)
                {
                    switch (((Job) li.Tag).Type)
                    {
                        case Job.JobTypes.Backup:
                            backupForm = new frmBackupJob((BackupJob) li.Tag);

                            if (!backupForm.Unload)
                            {
                                backupForm.ShowDialog();
                            }

                            backupForm.Close();
                            backupForm.Dispose();

                            break;
                        case Job.JobTypes.Restore:
                            restoreForm = new frmRestoreJob((RestoreJob) li.Tag);

                            if (!restoreForm.Unload)
                            {
                                restoreForm.ShowDialog();
                            }

                            restoreForm.Close();
                            restoreForm.Dispose();

                            break;
                        case Job.JobTypes.Shrink:
                            shrinkForm = new frmShrinkJob((ShrinkJob) li.Tag);

                            if (!shrinkForm.Unload)
                            {
                                shrinkForm.ShowDialog();
                            }

                            shrinkForm.Close();
                            shrinkForm.Dispose();
                            
                            break;
                        case Job.JobTypes.Copy:
                            copyForm = new frmCopyJob((CopyJob) li.Tag);

                            if (!copyForm.Unload)
                            {
                                copyForm.ShowDialog();
                            }

                            copyForm.Close();
                            copyForm.Dispose();

                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuEditJob_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuDeleteJob_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_working)
                {
                    return;
                }

                foreach (ListViewItem li in lvwMain.SelectedItems)
                {
                    lvwMain.Items.Remove(li);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuDeleteJob_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuStartJobs_Click(object sender, EventArgs e)
        {
            JobEngineParameters parms;
            List<Job> jobs;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                if (lvwMain.Items.Count == 0)
                {
                    Utility.ShowError("You must add at least one job to the list.");
                    return;
                }

                jobs = new List<Job>();
                foreach (ListViewItem li in lvwMain.Items)
                {
                    jobs.Add((Job) li.Tag);
                }

                pbrMain.Value = 0;
                pbrMain.Visible = true;
                lblStatus.Text = "Initializing ...";
                lblCancel.Visible = true;
                this.m_working = true;
                this.m_cancel = false;
    
                parms = new JobEngineParameters(jobs, Program.CurrentServer, Program.CurrentUser);
                this.m_bw = new BackgroundWorkerExt();
                this.m_bw.DoWork += new DoWorkEventHandler(m_bw_DoWork);
                this.m_bw.ProgressChanged += new ProgressChangedEventHandler(m_bw_ProgressChanged);
                this.m_bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(m_bw_RunWorkerCompleted);
                m_bw.RunWorkerAsync(parms);
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuStartJobs_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuCreateBackupScript_Click(object sender, EventArgs e)
        {
            frmCreateBackupScript createBackupScriptForm = null;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                createBackupScriptForm = new frmCreateBackupScript();

                if (!createBackupScriptForm.Unload)
                {
                    createBackupScriptForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuCreateBackupScript_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (createBackupScriptForm != null)
                {
                    createBackupScriptForm.Dispose();
                }
            }
        }

        private void mnuSystemLog_Click(object sender, EventArgs e)
        {
            frmSystemLog logForm = null;

            try
            {
                logForm = new frmSystemLog(Program.UserDataPath + "\\" + Program.SYSTEM_LOG_FILE);

                if (!logForm.Unload)
                {
                    logForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuSystemLog_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (logForm != null)
                {
                    logForm.Dispose();
                }
            }
        }

        private void mnuLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_working)
                {
                    return;
                }

                if (Program.ShowLoginForm())
                {
                    SetStatusBarServerName(Program.CurrentServer.Name);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuLogin_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuOptions_Click(object sender, EventArgs e)
        {
            frmOptions optionsForm = null;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                optionsForm = new frmOptions();

                if (!optionsForm.Unload)
                {
                    optionsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuOptions_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (optionsForm != null)
                {
                    optionsForm.Dispose();
                }
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAbout aboutForm = null;

            try
            {
                if (this.m_working)
                {
                    return;
                }

                aboutForm = new frmAbout();
                aboutForm.ShowDialog();
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "mnuAbout_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (aboutForm != null)
                {
                    aboutForm.Dispose();
                }
            }
        }
        #endregion

        #region Toolstrip event handlers
        private void tsbOpen_Click(object sender, EventArgs e)
        {
            mnuOpen_Click(sender, e);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            mnuSave_Click(sender, e);
        }

        private void tsbAddBackupJob_Click(object sender, EventArgs e)
        {
            mnuAddBackupJob_Click(sender, e);
        }

        private void tsbAddRestoreJob_Click(object sender, EventArgs e)
        {
            mnuAddRestoreJob_Click(sender, e);
        }

        private void tsbAddShrinkJob_Click(object sender, EventArgs e)
        {
            mnuAddShrinkJob_Click(sender, e);
        }

        private void tsbAddCopyJob_Click(object sender, EventArgs e)
        {
            mnuAddCopyJob_Click(sender, e);
        }

        private void tsbEditJob_Click(object sender, EventArgs e)
        {
            mnuEditJob_Click(sender, e);
        }

        private void tsbDeleteJob_Click(object sender, EventArgs e)
        {
            mnuDeleteJob_Click(sender, e);
        }

        private void tsbStartJobs_Click(object sender, EventArgs e)
        {
            mnuStartJobs_Click(sender, e);
        }

        private void tsbBackupScript_Click(object sender, EventArgs e)
        {
            mnuCreateBackupScript_Click(sender, e);
        }

        private void tsbSystemLog_Click(object sender, EventArgs e)
        {
            mnuSystemLog_Click(sender, e);
        }

        private void tsbLogin_Click(object sender, EventArgs e)
        {
            mnuLogin_Click(sender, e);
        }
        #endregion

        #region ListView event handlers
        private void lvwMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (lvwMain.GetItemAt(e.X, e.Y) != null)
                {
                    mnuEditJob_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "lvwMain_MouseDoubleClick", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void lvwMain_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    mnuEditJob_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    mnuDeleteJob_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "lvwMain_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void lvwMain_ItemDrag(object sender, ItemDragEventArgs e)
        {
            ListViewItem[] items;
            int i = 0;

            try
            {
                items = new ListViewItem[lvwMain.Items.Count - 1];

                foreach (ListViewItem li in lvwMain.SelectedItems)
                {
                    items[i] = li;
                    i += 1;
                }

                ((ListView) sender).DoDragDrop(new DataObject("System.Windows.Forms.ListViewItem()", items), DragDropEffects.Move);
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "lvwMain_ItemDrag", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void lvwMain_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.ListViewItem()"))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "lvwMain_DragEnter", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void lvwMain_DragDrop(object sender, DragEventArgs e)
        {
            ListViewItem[] items;
            ListViewItem li;
            int index;

            try
            {
                items = (ListViewItem[]) e.Data.GetData("System.Windows.Forms.ListViewItem()");

                li = lvwMain.GetItemAt(lvwMain.PointToClient(new Point(e.X, e.Y)).X,
                                       lvwMain.PointToClient(new Point(e.X, e.Y)).Y);

                if (li == null)
                {
                    return;
                }
        
                index = li.Index;

                if (index > items[0].Index)
                {
                    index += 1;
                }

                for (int i = items.Length - 1; i > -1; i--)
                {
                    if (items[i] != null)
                    {
                        lvwMain.Items.Insert(index, (ListViewItem)items[i].Clone());
                    }
                }

                foreach (ListViewItem itemToRemove in items)
                {
                    if (itemToRemove != null)
                    {
                        lvwMain.Items.Remove(itemToRemove);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "lvwMain_DragDrop", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Background worker event handlers
        private void m_bw_DoWork(object sender, DoWorkEventArgs e)
        {
            JobEngineParameters parms;
            BackgroundWorkerExt bw;
            string msg;
            bool success = false;

            try
            {
                bw = (BackgroundWorkerExt)sender;
                parms = (JobEngineParameters)e.Argument;
                this.m_jobEngine = new JobEngine(parms.CurrentServer, parms.CurrentUser);
                this.m_jobEngine.JobProgress += new JobEngine.JobProgressEventHandler(m_jobEngine_JobProgress);

                foreach (Job job in parms.JobList)
                {
                    // If we are paused, wait until execution should resume. It
                    // will likely be after some sort of input from the user
                    while (bw.Paused)
                    {
                        System.Threading.Thread.Sleep(300);
                    }

                    if (bw.CancellationPending)
                    {
                        return;
                    }

                    switch (job.Type)
                    {
                        case Job.JobTypes.Backup:
                            success = this.m_jobEngine.RunBackupJob((BackupJob)job);
                            break;
                        case Job.JobTypes.Restore:
                            success = this.m_jobEngine.RunRestoreJob((RestoreJob)job);
                            break;
                        case Job.JobTypes.Shrink:
                            success = this.m_jobEngine.RunShrinkJob((ShrinkJob)job);
                            break;
                        case Job.JobTypes.Copy:
                            success = this.m_jobEngine.RunCopyJob((CopyJob)job);
                            break;
                    }

                    if (success)
                    {
                        if (job.Type == Job.JobTypes.Copy)
                        {
                            msg = job.Type.ToString() + " job for database '" + job.Database + "' was completed successfully.";
                        }
                        else
                        {
                            msg = job.Type.ToString() + " job with task '" + job.Task.TaskDescription() + "' for database '" + job.Database + "' was completed successfully.";
                        }

                        this.m_jobEngine.AddToJobTracker(msg);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                if (!this.m_cancel)
                {
                    this.m_jobEngine.SetErrorFlag();
                    Utility.ShowError(ex.Message);
                    msg = Utility.BuildMessage(ex);
                    Utility.WriteToSystemLog(this.m_jobEngine.CurrentDatabase, msg);
                }
            }
            finally
            {
                if (this.m_jobEngine != null)
                {
                    this.m_jobEngine.JobProgress -= m_jobEngine_JobProgress;
                }
            }
        }

        private void m_bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            JobEventArgs jobEventArgs = (JobEventArgs)e.UserState;

            try
            {
                switch (jobEventArgs.Action)
                {
                    case JobEventArgs.StatusAction.MessageOnly:
                        lblStatus.Text = jobEventArgs.Message;
                        break;
                    case JobEventArgs.StatusAction.MessageAndClearProgress:
                        lblStatus.Text = jobEventArgs.Message;
                        pbrMain.Value = 0;
                        break;
                    case JobEventArgs.StatusAction.ClearProgress:
                        pbrMain.Value = 0;
                        break;
                    case JobEventArgs.StatusAction.SetProgressMax:
                        pbrMain.Maximum = jobEventArgs.Maximum;
                        break;
                    case JobEventArgs.StatusAction.IncrementProgress:
                        if (jobEventArgs.Percent >= pbrMain.Minimum && jobEventArgs.Percent <= pbrMain.Maximum)
                        {
                            pbrMain.Value = jobEventArgs.Percent;
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "m_bw_ProgressChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void m_bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                // Refreshing the connection will clear any remaining locks after 
                // an operation that requires exclusive access (e.g. a restore)
                ServerUtility.RefreshServerConnection();

                pbrMain.Visible = false;
                lblCancel.Visible = false;

                if (this.m_cancel)
                {
                    lblStatus.Text = "The operation has been cancelled.";
                    Utility.WriteToSystemLog("", this.m_jobEngine.GetJobTracker());
                }
                else
                {
                    if (this.m_jobEngine.Error)
                    {
                        lblStatus.Text = "Errors occurred during job execution, see the system log for details.";
                        Utility.WriteToSystemLog("", this.m_jobEngine.GetJobTracker());
                    }
                    else
                    {
                        lblStatus.Text = "Ready";
                        Utility.ShowMessage("Database jobs completed successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "m_bw_RunWorkerCompleted", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                this.m_working = false;
            }
        }

        private void m_jobEngine_JobProgress(Object sender, JobEventArgs e)
        {
            if (this.m_bw.CancellationPending)
            {
                ((JobEngine)sender).Cancel = true;
            }
            else
            {
                this.m_bw.ReportProgress(0, e);
            }
        }
        #endregion

        #region Misc event handlers
        private void lblCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_bw.PauseWork();

                if (MessageBox.Show("Do you wish to cancel job execution?", Program.ERROR_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.m_cancel = true;
                    this.m_bw.CancelAsync();
                    this.m_bw.ResumeWork();
                    lblStatus.Text = "Cancelling ...";
                }
                else
                {
                    this.m_bw.ResumeWork();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "lblCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc functions
        public void Initialize(string server)
        {
            IConfig mruSection;

            try
            {
                if (this.m_firstLogin)
                {
                    lblStatus.Text = "Ready";
                    mruSection = Program.ConfigFile.Configs["MRU"];

                    if (mruSection != null)
                    {
                        if (mruSection.GetString("SaveOnExit") != null && mruSection.GetString("SaveOnExit") == "On")
                        {
                            mnuSaveOnExit.Checked = true;
                        }
                    }

                    SetStatusBarServerName(server);
                    LoadMRUFileEntries();
                    this.m_firstLogin = false;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "Initialize", ex.Source, ex.Message, ex.InnerException);
            }
        }

        public void SetStatusBarServerName(string server)
        {
            lblServer.Text = " " + server + " ";
        }

        public bool SaveJobToList(Job job, JobForm.JobFormActions action)
        {
            ListViewItem li;
            string details = "";
            string key;
            bool retVal = false;

            try
            {
                foreach (ListViewItem item in lvwMain.Items)
                {
                    if (((Job)item.Tag).Type == Job.JobTypes.Backup && 
                        ((Job)item.Tag).Task == Job.JobTasks.SingleDatabase &&
                        item.Text.ToLower() == job.Database.ToLower() &&
                        action == JobForm.JobFormActions.Add)
                    {
                        Utility.ShowError("A backup job for database '" + job.Database + "' has already been added.");
                        return false;
                    }

                    if (((Job)item.Tag).Type == Job.JobTypes.Restore &&
                        ((Job)item.Tag).Task == Job.JobTasks.SingleDatabase &&
                        item.Text.ToLower() == job.Database.ToLower() &&
                        action == JobForm.JobFormActions.Add)
                    {
                        Utility.ShowError("A restore job for database '" + job.Database + "' has already been added.");
                        return false;
                    }

                    if (((Job)item.Tag).Type == Job.JobTypes.Shrink &&
                        ((Job)item.Tag).Task == Job.JobTasks.SingleDatabase &&
                        item.Text.ToLower() == job.Database.ToLower() &&
                        action == JobForm.JobFormActions.Add)
                    {
                        Utility.ShowError("A shrink job for database '" + job.Database + "' has already been added.");
                        return false;
                    }
                }

                details = BuildDetailsValue(job);

                if (action == JobForm.JobFormActions.Add)
                {
                    key = Utility.GenerateListItemKey();
                    job.Key = key;

                    li = lvwMain.Items.Add(job.Database, "Job");
                    li.Name = key;
                    li.SubItems.Add(job.Type.ToString());

                    if (job.Type == Job.JobTypes.Copy)
                    {
                        li.SubItems.Add("");
                    }
                    else
                    {
                        li.SubItems.Add(job.Task.TaskDescription());
                    }

                    li.SubItems.Add(job.Path);
                    li.SubItems.Add(details);
                    li.Tag = job;
                }
                else if (action == JobForm.JobFormActions.Edit)
                {
                    li = lvwMain.Items[job.Key];
                    li.Text = job.Database;
                    li.SubItems[(int) MainFormColumns.JobType].Text = job.Type.ToString();

                    if (job.Type != Job.JobTypes.Copy)
                    {
                        li.SubItems[(int)MainFormColumns.Task].Text = job.Task.TaskDescription();
                    }

                    li.SubItems[(int) MainFormColumns.Path].Text = job.Path;
                    li.SubItems[(int) MainFormColumns.Details].Text = details;
                    li.Tag = job;
                }

                retVal = true;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "SaveJobToList", ex.Source, ex.Message, ex.InnerException);
            }

            return retVal;
        }

        private bool LoadJobs(string filePath)
        {
            JobList jobList;
            ListViewItem li;
            string details;
            bool retVal = false;

            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    lvwMain.Items.Clear();
                    jobList = Utility.GetJobList(filePath);

                    if (jobList != null)
                    {
                        foreach (Job job in jobList.Jobs)
                        {
                            details = BuildDetailsValue(job);

                            li = lvwMain.Items.Add(job.Database, "Job");
                            li.Name = job.Key;
                            li.SubItems.Add(job.Type.ToString());
                            li.SubItems.Add(job.Task.TaskDescription());
                            li.SubItems.Add(job.Path);
                            li.SubItems.Add(details);
                            li.Tag = job;
                        }

                        this.Text = "DB Tools - " + Path.GetFileName(filePath);
                    }

                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "LoadJobs", ex.Source, ex.Message, ex.InnerException);
            }

            return retVal;
        }

        private bool SaveJobs(string filePath)
        {
            StreamWriter sw = null;
            XmlSerializer xs;
            JobList jobList;
            bool retVal = false;

            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    jobList = new JobList();

                    foreach (ListViewItem li in lvwMain.Items)
                    {
                        jobList.Jobs.Add((Job)li.Tag);
                    }

                    sw = new StreamWriter(filePath, false);
                    xs = new XmlSerializer(typeof(JobList), new Type[] { typeof(BackupJob), typeof(RestoreJob), typeof(ShrinkJob), typeof(CopyJob) });
                    xs.Serialize(sw, jobList);

                    retVal = true;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "SaveJobs", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Dispose();
                }
            }

            return retVal;
        }

        private string BuildDetailsValue(Job job)
        {
            string details = "";

            try
            {
                switch (job.Type)
                {
                    case Job.JobTypes.Backup:
                        BackupJob backupJob = (BackupJob) job;

                        if (backupJob.BackupType == BackupJob.BackupTypes.Complete)
                        {
                            details = "Backup type: Complete";
                        }
                        else
                        {
                            details = "Backup type: Transaction Log";
                        }

                        if (backupJob.BackupOption == BackupJob.BackupOverwriteOptions.Overwrite)
                        {
                            details = details + ", Overwrite: Overwrite File";
                        }
                        else
                        {
                            details = details + ", Overwrite: Append to File";
                        }

                        break;
                    case Job.JobTypes.Restore:
                        RestoreJob restoreJob = (RestoreJob)job;
                        details = "Position: " + restoreJob.RestorePosition.ToString();

                        if (restoreJob.ClearUsers)
                        {
                            details = details + ", Clear users: Yes";
                        }
                        else
                        {
                            details = details + ", Clear users: No";
                        }

                        if (restoreJob.Task == Job.JobTasks.ByDirectory)
                        {
                            details = details + ", File extension: " + restoreJob.FileExtension;
                        }

                        break;
                    case Job.JobTypes.Shrink:
                        ShrinkJob shrinkJob = (ShrinkJob) job;

                        if (!string.IsNullOrEmpty(shrinkJob.RecoveryModel))
                        {
                            details = "Recovery model: " + shrinkJob.RecoveryModel;
                        }

                        if (shrinkJob.SetToSimple)
                        {
                            if (details == "")
                            {
                                details = "Set to simple: Yes";
                            }
                            else
                            {
                                details = details + ", Set to simple: Yes";
                            }
                        }

                        if (shrinkJob.UpdateIndexes)
                        {
                            if (details == "")
                            {
                                details = "Update indexes: Yes";
                            }
                            else
                            {
                                details = details + ", Update indexes: Yes";
                            }
                        }

                        if (shrinkJob.ShrinkFile)
                        {
                            if (details == "")
                            {
                                details = "File to shrink: " + shrinkJob.FileToShrink;
                            }
                            else
                            {
                                details = details + ", File to shrink: " + shrinkJob.FileToShrink;
                            }
                        }

                        break;
                    case Job.JobTypes.Copy:
                        CopyJob copyJob = (CopyJob) job;
                        details = "New database: " + copyJob.NewDatabase;

                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "BuildDetailsValue", ex.Source, ex.Message, ex.InnerException);
            }

            return details;
        }

        private void LoadMRUFileEntries()
        {
            ToolStripMenuItem mnuMRUFile;
            ToolStripSeparator mnuSeparator;
            string filePath;
            int insertPoint = 0;
            int maxMRULength;
            bool separatorAdded = false;

            try
            {
                if (Program.ConfigFile.Configs["Options"] == null)
                {
                    maxMRULength = MRU_DEFAULT_LIST_MAX_LENGTH;
                }
                else
                {
                    maxMRULength = int.Parse(Program.ConfigFile.Configs["Options"].GetString("MaxMRULength", MRU_DEFAULT_LIST_MAX_LENGTH.ToString()));
                }

                for (int i = 1; i < maxMRULength + 1; i++)
                {
                    if (Program.ConfigFile.Configs["File" + i.ToString()] != null)
                    {
                        if (!separatorAdded)
                        {
                            mnuSeparator = new ToolStripSeparator();
                            mnuSeparator.Name = "MRUSeparator";
                            mnuFile.DropDownItems.Insert(MRU_START_INDEX - 1, mnuSeparator);
                            separatorAdded = true;
                        }

                        filePath = Program.ConfigFile.Configs["File" + i.ToString()].GetString("Path");
                        mnuMRUFile = new ToolStripMenuItem(Utility.AbbreviatePath(filePath, MRU_ITEM_MAX_LENGTH), 
                                                           null, 
                                                           new EventHandler(mnuFileMRU_Click), 
                                                           filePath);
                        mnuMRUFile.ToolTipText = filePath;

                        mnuFile.DropDownItems.Insert(MRU_START_INDEX + insertPoint, mnuMRUFile);
                        insertPoint += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "LoadMRUFileEntries", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void SaveMRUFileEntries()
        {
            IConfig section;
            string itemName;
            bool done = false;
            int count;
            int id = 1;
            int index = MRU_START_INDEX;

            try
            {
                count = Program.ConfigFile.Configs.Count;

                // Looping through the config section in reverse order is the 
                // cleanest way to remove entries
                for (int i = count - 1; i > -1; i--)
                {
                    if (Program.ConfigFile.Configs[i].Name.StartsWith("File"))
                    {
                        Program.ConfigFile.Configs.RemoveAt(i);
                        Program.ConfigFile.Save();
                    }
                }

                while (!done)
                {
                    itemName = mnuFile.DropDownItems[index].Name;

                    if (itemName != "ExitSeparator" && itemName != "mnuExit")
                    {
                        section = Program.ConfigFile.Configs.Add("File" + id.ToString());
                        section.Set("Path", itemName);
                        id += 1;
                        index += 1;

                        Program.ConfigFile.Save();
                    }
                    else
                    {
                        done = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "SaveMRUFileEntries", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void AddMRUFileEntry(string filePath)
        {
            ToolStripMenuItem mnuMRUFile;
            ToolStripSeparator mnuSeparator;
            int maxMRULength;
            int exitSeperatorIndex;
            int mruCount = 0;

            try
            {
                if (Program.ConfigFile.Configs["Options"] == null)
                {
                    maxMRULength = MRU_DEFAULT_LIST_MAX_LENGTH;
                }
                else
                {
                    maxMRULength = int.Parse(Program.ConfigFile.Configs["Options"].GetString("MaxMRULength", MRU_DEFAULT_LIST_MAX_LENGTH.ToString()));
                }

                mnuMRUFile = new ToolStripMenuItem(Utility.AbbreviatePath(filePath, MRU_ITEM_MAX_LENGTH),
                                                   null,
                                                   new EventHandler(mnuFileMRU_Click), 
                                                   filePath);
                mnuMRUFile.ToolTipText = filePath;

                if (mnuFile.DropDownItems[filePath] == null)
                {
                    if (mnuFile.DropDownItems["MRUSeparator"] == null)
                    {
                        mnuSeparator = new ToolStripSeparator();
                        mnuSeparator.Name = "MRUSeparator";
                        mnuFile.DropDownItems.Insert(MRU_START_INDEX - 1, mnuSeparator);
                    }

                    mnuFile.DropDownItems.Insert(MRU_START_INDEX, mnuMRUFile);
                    exitSeperatorIndex = mnuFile.DropDownItems.IndexOfKey("ExitSeparator");

                    for (int i = MRU_START_INDEX; i < exitSeperatorIndex; i++)
                    {
                        mruCount += 1;
                    }

                    if (mruCount > maxMRULength)
                    {
                        mnuFile.DropDownItems.RemoveAt(exitSeperatorIndex - 1);
                    }
                }
                else
                {
                    // We don't need to remove and re-add the given file if it's 
                    // already at the top of the list
                    if (mnuFile.DropDownItems.IndexOfKey(filePath) != MRU_START_INDEX)
                    {
                        mnuFile.DropDownItems.RemoveByKey(filePath);
                        mnuFile.DropDownItems.Insert(MRU_START_INDEX, mnuMRUFile);
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmMain", "AddMRUFileEntry", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Properties
        public bool Unload { get; set; }
        #endregion
    }
}
