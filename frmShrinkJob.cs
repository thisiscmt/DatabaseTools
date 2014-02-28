using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;

namespace DBTools
{
    public partial class frmShrinkJob : JobForm
    {
        private string m_key;
        private string m_dbName;

        #region Form event handlers
        public frmShrinkJob()
        {
            InitializeComponent();

            try
            {
                this.Action = JobFormActions.Add;
                this.Text = JobFormActions.Add.ToString() + " Shrink Job";
                this.m_dbName = "";
                cmbShrinkTask.Items.AddRange(Job.GetTaskDescriptions(Job.JobTypes.Shrink).ToArray());
                cmbShrinkTask.SelectedIndex = 0;
                Utility.LockControl(cmbDiskFile);
                cmbDatabase.Select();

                this.Unload = false;
            }
            catch (Exception ex)
            {
                this.Unload = true;
                Utility.HandleException("frmShrinkJob", "New", ex.Source, ex.Message, ex.InnerException);
            }
        }

        public frmShrinkJob(ShrinkJob  job)
        {
            InitializeComponent();

            try
            {
                this.Action = JobFormActions.Edit;
                this.Text = JobFormActions.Edit.ToString() + " Shrink Job";
                this.m_key = job.Key;
                this.m_dbName = "";
                cmbShrinkTask.Items.AddRange(Job.GetTaskDescriptions(Job.JobTypes.Shrink).ToArray());
                cmbShrinkTask.SelectedItem = job.Task.TaskDescription();

                cmbShrinkTask_SelectedIndexChanged(null, null);
                cmbDatabase.Text = job.Database;
                cmbDatabase_SelectedIndexChanged(null, null);
                chkSetToSimple.Checked = job.SetToSimple;
                chkUpdateIndexes.Checked = job.UpdateIndexes;
                chkShrinkFile.Checked = job.ShrinkFile;

                if (job.ShrinkFile)
                {
                    foreach (Object o in cmbDiskFile.Items)
                    {
                        if (((ItemData) o).Name == job.FileToShrink)
                        {
                            cmbDiskFile.SelectedIndex = cmbDiskFile.Items.IndexOf(o);
                            break;
                        }
                    }
                }
                else
                {
                    Utility.LockControl(cmbDiskFile);
                }

                lblRecoveryModel.Text = GetRecoveryModel();
                cmbDatabase.Select();

                // We don't store the name of the current database until everything 
                // is loaded, because doing so would short-circuit the proper 
                // initialization of the disk file combo box
                this.m_dbName = job.Database;
                this.Unload = false;
            }
            catch (Exception ex)
            {
                this.Unload = true;
                Utility.HandleException("frmShrinkJob", "New", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Command button event handlers
        private void cmdOK_Click(object sender, EventArgs e)
        {
            ShrinkJob job;
            Job.JobTasks task;

            try
            {
                if (ValidInput())
                {
                    task = Job.GetTaskValue(cmbShrinkTask.Text);
                    job = new ShrinkJob();
                    job.Key = this.m_key;
                    job.Task = task;
                    job.RecoveryModel = lblRecoveryModel.Text;
                    job.SetToSimple = chkSetToSimple.Checked;
                    job.UpdateIndexes = chkUpdateIndexes.Checked;
                    job.ShrinkFile = chkShrinkFile.Checked;

                    if (chkShrinkFile.Checked)
                    {
                        job.FileToShrink = cmbDiskFile.Text;
                        job.FileType = ((ItemData) cmbDiskFile.SelectedItem).Tag;
                    }

                    switch (task)
                    {
                        case Job.JobTasks.SingleDatabase:
                            job.Database = cmbDatabase.Text;
                            break;
                        default:
                            job.Database = "N/A";
                            break;
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
                            cmbDatabase.SelectedIndex = -1;
                            chkSetToSimple.Checked = false;
                            chkShrinkFile.Checked = false;
                            cmbDiskFile.Items.Clear();
                            Utility.LockControl(cmbDiskFile);
                            lblRecoveryModel.Text = "";
                            lblFileGroup.Text = "";
                            lblFileType.Text = "";
                            lblSize.Text = "";
                            lblFreeSpace.Text = "";

                            cmbDatabase.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
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
                Utility.HandleException("frmShrinkJob", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc event handlers
        private void cmbShrinkTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            Job.JobTasks task;

            try
            {
                task = Job.GetTaskValue(cmbShrinkTask.Text);

                if (task == Job.JobTasks.SingleDatabase || task == Job.JobTasks.ByWildcard)
                {
                    cmbDatabase.Enabled = true;

                    if (task == Job.JobTasks.SingleDatabase)
                    {
                        lblDatabase.Text = "Database:";
                        lblNote.Visible = false;
                        chkShrinkFile.Enabled = true;

                        if (chkShrinkFile.Checked)
                        {
                            Utility.UnlockControl(cmbDiskFile);
                        }
                    }
                    else
                    {
                        cmbDatabase.Items.Clear();
                        lblDatabase.Text = "Database:";
                        lblNote.Visible = true;
                        chkShrinkFile.Enabled = false;
                        Utility.LockControl(cmbDiskFile);
                    }
                }
                else
                {
                    lblDatabase.Text = "Database:";
                    lblNote.Visible = false;
                    cmbDatabase.Enabled = false;
                    chkShrinkFile.Enabled = false;
                    Utility.LockControl(cmbDiskFile);
                    lblRecoveryModel.Text = "";
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "cmbShrinkTask_SelectedIndexChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (Job.GetTaskValue(cmbShrinkTask.Text) != Job.JobTasks.ByWildcard)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ServerUtility.InitDatabaseList(cmbDatabase);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "cmbDatabase_DropDown", ex.Source, ex.Message, ex.InnerException);
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
                Utility.HandleException("frmShrinkJob", "cmbDatabase_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbDatabase_Leave(object sender, EventArgs e)
        {
            try
            {
                if (Job.GetTaskValue(cmbShrinkTask.Text) != Job.JobTasks.ByWildcard)
                {
                    cmbDatabase_SelectedIndexChanged(null, null);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "cmbDatabase_Leave", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cmbDatabase.Text) && cmbDatabase.Text.ToLower() != this.m_dbName.ToLower())
                {
                    cmbDiskFile.Items.Clear();
                    cmbDiskFile.SelectedIndex = -1;
                    lblFileGroup.Text = "";
                    lblFileType.Text = "";
                    lblSize.Text = "";
                    lblFreeSpace.Text = "";

                    switch (Program.CurrentServer.Databases[cmbDatabase.Text].RecoveryModel)
                    {
                         case Microsoft.SqlServer.Management.Smo.RecoveryModel.Simple:
                            lblRecoveryModel.Text = "Simple";
                            chkSetToSimple.Checked = false;
                            chkSetToSimple.Enabled = false;

                            break;
                         case Microsoft.SqlServer.Management.Smo.RecoveryModel.BulkLogged:
                            lblRecoveryModel.Text = "Bulk Logged";
                            chkSetToSimple.Enabled = true;

                            break;
                         case Microsoft.SqlServer.Management.Smo.RecoveryModel.Full:
                            lblRecoveryModel.Text = "Full";
                            chkSetToSimple.Enabled = true;

                            break;
                    }

                    lblRecoveryModel.Visible = true;

                    foreach (FileGroup fileGrp in Program.CurrentServer.Databases[cmbDatabase.Text].FileGroups)
                    {
                        foreach (DataFile df in fileGrp.Files)
                        {
                            cmbDiskFile.Items.Add(new ItemData(df.Name, fileGrp.ID, "Data"));
                        }
                    }
                    foreach (LogFile log in Program.CurrentServer.Databases[cmbDatabase.Text].LogFiles)
                    {
                        cmbDiskFile.Items.Add(new ItemData(log.Name, "Log"));
                    }
                }

                this.m_dbName = cmbDatabase.Text.Trim();
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "cmbDatabase_SelectedIndexChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbDiskFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemData diskFileItem = (ItemData) cmbDiskFile.SelectedItem;
            string grpName;
            double usedSpace;
            double freeSpace;

            try
            {
                if (diskFileItem.Tag == "Data")
                {
                    grpName = Program.CurrentServer.Databases[cmbDatabase.Text].FileGroups.ItemById(diskFileItem.ID).Name;

                    lblFileGroup.Text = grpName;
                    lblFileType.Text = "Data file";
                    lblSize.Text = Utility.FormatSize((long) Program.CurrentServer.Databases[cmbDatabase.Text].FileGroups[grpName].Files[cmbDiskFile.Text].Size * 1024);
                    lblFreeSpace.Text = Utility.FormatSize((long)Program.CurrentServer.Databases[cmbDatabase.Text].FileGroups[grpName].Files[cmbDiskFile.Text].AvailableSpace * 1024);

                    chkUpdateIndexes.Enabled = true;
                }
                else
                {
                    usedSpace = Program.CurrentServer.Databases[cmbDatabase.Text].LogFiles[cmbDiskFile.Text].UsedSpace * 1024;
                    freeSpace = (Program.CurrentServer.Databases[cmbDatabase.Text].LogFiles[cmbDiskFile.Text].Size * 1024) - usedSpace;

                    lblFileGroup.Text = "";
                    lblFileType.Text = "Log file";
                    lblSize.Text = Utility.FormatSize((long)Program.CurrentServer.Databases[cmbDatabase.Text].LogFiles[cmbDiskFile.Text].Size * 1024);
                    lblFreeSpace.Text = Utility.FormatSize((long)freeSpace);

                    chkUpdateIndexes.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "cmbDiskFile_SelectedIndexChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void chkShrinkFile_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkShrinkFile.Checked)
                {
                    Utility.UnlockControl(cmbDiskFile);
                }
                else
                {
                    Utility.LockControl(cmbDiskFile);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "chkShrinkFile_CheckedChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc functions
        private bool ValidInput()
        {
            Job.JobTasks task;

            try
            {
                task = Job.GetTaskValue(cmbShrinkTask.Text);

                if (task == Job.JobTasks.SingleDatabase)
                {
                    if (string.IsNullOrEmpty(cmbDatabase.Text.Trim()))
                    {
                        Utility.ShowError("You must select a database to shrink.");
                        cmbDatabase.Select();
                        return false;
                    }

                    if (chkShrinkFile.Checked && string.IsNullOrEmpty(cmbDiskFile.Text))
                    {
                        Utility.ShowError("You must specify a disk file to shrink.");
                        cmbDiskFile.Select();
                        return false;
                    }
                }

                if (task == Job.JobTasks.ByWildcard && string.IsNullOrEmpty(cmbDatabase.Text))
                {
                    Utility.ShowError("You must input a search string for the databases to be shrunk.");
                    cmbDatabase.Select();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "ValidInput", ex.Source, ex.Message, ex.InnerException);
                return false;
            }
        }

        private string GetRecoveryModel()
        {
            string retVal = "";

            try
            {
                if (Job.GetTaskValue(cmbShrinkTask.Text) == Job.JobTasks.SingleDatabase && Program.CurrentServer.Databases[cmbDatabase.Text] != null)
                {
                    switch (Program.CurrentServer.Databases[cmbDatabase.Text].RecoveryModel)
                    {
                        case Microsoft.SqlServer.Management.Smo.RecoveryModel.Simple:
                            retVal = "Simple";
                            chkSetToSimple.Checked = false;
                            chkSetToSimple.Enabled = false;
                            break;
                        case Microsoft.SqlServer.Management.Smo.RecoveryModel.BulkLogged:
                            retVal = "Bulk Logged";
                            break;
                        case Microsoft.SqlServer.Management.Smo.RecoveryModel.Full:
                            retVal = "Full";
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmShrinkJob", "GetRecoveryModel", ex.Source, ex.Message, ex.InnerException);
            }

            return retVal;
        }
        #endregion
    }
}
