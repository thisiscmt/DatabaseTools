using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Smo;

namespace DBTools
{
    public partial class frmRestoreJob : JobForm
    {
        private string m_key;
        private string m_path;
        private int m_restorePosition;

        #region Form event handlers
        public frmRestoreJob()
        {
            InitializeComponent();

            try
            {
                this.Action = JobFormActions.Add;
                this.Text = JobFormActions.Add.ToString() + " Restore Job";
                this.m_path = "";
                cmbRestoreTask.Items.AddRange(Job.GetTaskDescriptions(Job.JobTypes.Restore).ToArray());

                if (!Utility.RunningOnServer())
                {
                    cmbRestoreTask.Items.Remove(Job.JobTasks.ZipFile.TaskDescription());
                }

                cmbRestoreTask.SelectedIndex = 0;
                txtRestoreFrom.Text = Program.CurrentServer.Settings.BackupDirectory;
                cmbDatabase.Select();

                this.Unload = false;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }

        public frmRestoreJob(RestoreJob job)
        {
            InitializeComponent();

            try
            {
                this.Action = JobFormActions.Edit;
                this.Text = JobFormActions.Edit.ToString() + " Restore Job";
                this.m_key = job.Key;
                this.m_path = job.Path;
                this.m_restorePosition = job.RestorePosition;
                cmbRestoreTask.Items.AddRange(Job.GetTaskDescriptions(Job.JobTypes.Restore).ToArray());

                if (!Utility.RunningOnServer())
                {
                    cmbRestoreTask.Items.Remove(Job.JobTasks.ZipFile.TaskDescription());
                }

                cmbRestoreTask.SelectedItem = job.Task.TaskDescription();
                txtRestoreFrom.Text = job.Path;
                chkUpdate.Enabled = false;
                chkClearUsers.Checked = job.ClearUsers;

                switch (job.Task)
                {
                    case Job.JobTasks.SingleDatabase:
                        cmbDatabase.Text = job.Database;
                        txtExt.Enabled = false;
                        BuildContents();

                        break;
                    case Job.JobTasks.ByDirectory:
                        cmbDatabase.Enabled = false;
                        txtExt.Text = job.FileExtension;

                        break;
                }

                cmbDatabase.Select();
                this.Unload = false;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }
        #endregion

        #region Command button event handlers
        private void cmdOK_Click(object sender, EventArgs e)
        {
            RestoreJob job;
            Job.JobTasks task;

            try
            {
                if (ValidInput())
                {
                    task = Job.GetTaskValue(cmbRestoreTask.Text);
                    job = new RestoreJob();
                    job.Key = this.m_key;
                    job.Task = task;
                    job.Path = txtRestoreFrom.Text;
                    job.ClearUsers = chkClearUsers.Checked;

                    switch (task)
                    {
                        case Job.JobTasks.SingleDatabase:
                            job.Database = cmbDatabase.Text;
                            break;
                        case Job.JobTasks.ByDirectory:
                        case Job.JobTasks.ZipFile:
                            job.Database = "N/A";
                            job.FileExtension = txtExt.Text;
                            break;
                    }

                    if (lvwContents.Items.Count == 0)
                    {
                        job.RestorePosition = 1;
                    }
                    else
                    {
                        job.RestorePosition = int.Parse(lvwContents.CheckedItems[0].Tag.ToString());
                    }

                    if (Program.MainForm.SaveJobToList(job, this.Action))
                    {
                        if (chkUpdate.Checked)
                        {
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        else
                        {
                            cmbDatabase.Text = "";
                            cmbDatabase.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            frmBrowse browseForm = null;
            Job.JobTasks task;
            bool includeFiles;

            try
            {
                task = Job.GetTaskValue(cmbRestoreTask.Text);

                if (task == Job.JobTasks.SingleDatabase || task == Job.JobTasks.ZipFile)
                {
                    includeFiles = true;
                }
                else
                {
                    includeFiles = false;
                }

                browseForm = new frmBrowse(txtRestoreFrom.Text, includeFiles);

                if (!browseForm.Unload)
                {
                    if (browseForm.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        txtRestoreFrom.Text = browseForm.SelectedPath;
                        BuildContents();
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "cmdBrowse_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc event handlers
        private void cmbRestoreTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            Job.JobTasks task;

            try
            {
                task = Job.GetTaskValue(cmbRestoreTask.Text);

                if (task == Job.JobTasks.SingleDatabase)
                {
                    cmbDatabase.Enabled = true;
                    txtExt.Enabled = false;
                    cmbDatabase.Items.Clear();
                }
                else
                {
                    cmbDatabase.Enabled = false;

                    if (task == Job.JobTasks.ByDirectory)
                    {
                        txtExt.Enabled = true;
                    }
                    else
                    {
                        txtExt.Enabled = false;
                    }

                    lvwContents.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "cmbRestoreTask_SelectedIndexChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (Job.GetTaskValue(cmbRestoreTask.Text) == Job.JobTasks.SingleDatabase)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ServerUtility.InitDatabaseList(cmbDatabase);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "cmbDatabase_DropDown", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmbDatabase_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    cmbDatabase_DropDown(sender, e);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "cmbDatabase_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void txtRestoreFrom_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Job.GetTaskValue(cmbRestoreTask.Text) == Job.JobTasks.SingleDatabase && txtRestoreFrom.Text.ToLower() != this.m_path.ToLower())
                {
                    m_path = txtRestoreFrom.Text;
                    BuildContents();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "txtRestoreFrom_Leave", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void lvwContents_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            try
            {
                foreach (ListViewItem li in lvwContents.Items)
                {
                    if (li.Index != e.Index)
                    {
                        li.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "lvwContents_ItemCheck", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc functions
        private bool ValidInput()
        {
            Job.JobTasks task;

            try
            {
                task = Job.GetTaskValue(cmbRestoreTask.Text);

                if (task == Job.JobTasks.SingleDatabase)
                {
                    if (string.IsNullOrEmpty(cmbDatabase.Text.Trim()))
                    {
                        Utility.ShowError("You must select a database to restore.");
                        cmbDatabase.Select();
                        return false;
                    }

                    if (txtRestoreFrom.Text == "" || txtRestoreFrom.Text.EndsWith("\\"))
                    {
                        Utility.ShowError("You must select a backup file to restore from.");
                        txtRestoreFrom.Select();
                        return false;
                    }

                    if (lvwContents.Items.Count > 0 && lvwContents.CheckedItems.Count == 0)
                    {
                        Utility.ShowError("Put a check mark next to the backup you wish to restore.");
                        lvwContents.Select();
                        return false;
                    }
                }
                else if (task == Job.JobTasks.ByDirectory)
                {
                    if (!Directory.Exists(txtRestoreFrom.Text))
                    {
                        Utility.ShowError("You must select an existing source directory for the backup files.");
                        txtRestoreFrom.Select();
                        return false;
                    }

                    if (txtExt.Text.Contains('.'))
                    {
                        Utility.ShowError("You must supply a file extension without a dot.");
                        txtExt.Select();
                        return false;
                    }
                }
                else if (task == Job.JobTasks.ZipFile)
                {
                    if (!File.Exists(txtRestoreFrom.Text))
                    {
                        Utility.ShowError("You must select an existing Zip file.");
                        txtRestoreFrom.Select();
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "ValidInput", ex.Source, ex.Message, ex.InnerException);
                return false;
            }
        }

        private void BuildContents()
        {
            Restore res;
            DataTable dt = null;
            ListViewItem li;
            DateTime backupDate;

            try
            {
                lvwContents.Items.Clear();
                res = new Restore();
                res.Devices.AddDevice(txtRestoreFrom.Text, DeviceType.File);

                // If reading the backup header fails, we just exit. the user might 
                // have selected a Zip file, or typed in the name of a file that 
                // doesn't exist yet but will from a backup job that runs earlier
                try
                {
                    dt = res.ReadBackupHeader(Program.CurrentServer);
                }
                catch
                {
                    return;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        li = lvwContents.Items.Add(dr["DatabaseName"].ToString(), "Database");
                        li.SubItems.Add(Utility.FormatSize((long) dr["BackupSize"]));
                        backupDate = (DateTime) dr["BackupFinishDate"];
                        li.SubItems.Add(backupDate.ToString("M/d/yyyy h:mm:ss tt"));
                        li.SubItems.Add(dr["ServerName"].ToString());
                        li.Tag = dr["Position"].ToString();
                    }

                    if (this.Action == JobFormActions.Add)
                    {
                        lvwContents.Items[lvwContents.Items.Count - 1].Checked = true;
                    }
                    else if (this.Action == JobFormActions.Edit)
                    {
                        foreach (ListViewItem item in lvwContents.Items)
                        {
                            if (int.Parse(item.Tag.ToString()) == this.m_restorePosition)
                            {
                                item.Checked = true;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmRestoreJob", "BuildContents", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }
        #endregion
    }
}
