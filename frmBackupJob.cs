using System.ComponentModel;

namespace DBTools
{
    public partial class BackupJobForm : Form
    {
        private string m_key;
        private BackupJob m_job = null;

        #region Form event handlers
        public BackupJobForm()
        {
            InitializeComponent();

            try
            {
                this.Action = JobFormActions.Add;
                this.Text = JobFormActions.Add.ToString() + " Backup Job";
                cmbBackupTask.Items.AddRange(Job.GetTaskDescriptions(Job.JobTypes.Backup).ToArray());
                cmbBackupTask.SelectedIndex = 0;
                txtBackupPath.Text = Program.CurrentServer.Settings.BackupDirectory;
                cmbDatabase.Select();

                this.Unload = false;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }

        public BackupJobForm(BackupJob job)
        {
            InitializeComponent();

            try
            {
                this.m_job = job;
                this.Action = JobFormActions.Edit;
                this.Text = JobFormActions.Edit.ToString() + " Backup Job";
                this.m_key = job.Key;
                cmbBackupTask.Items.AddRange(Job.GetTaskDescriptions(Job.JobTypes.Backup).ToArray());
                cmbBackupTask.SelectedItem = job.Task.TaskDescription();
                txtBackupPath.Text = job.Path;
                chkUpdate.Enabled = false;

                if (job.Task == Job.JobTasks.SingleDatabase || job.Task == Job.JobTasks.ByWildcard)
                {
                    cmbDatabase.Text = job.Database;
                }

                if (((BackupJob) job).BackupType == BackupJob.BackupTypes.Complete)
                {
                    optComplete.Checked = true;
                }
                else
                {
                    optTransLog.Checked = true;
                }

                if (((BackupJob)job).BackupOption == BackupJob.BackupOverwriteOptions.Overwrite)
                {
                    optOverwrite.Checked = true;
                }
                else
                {
                    optAppend.Checked = true;
                }

                cmbDatabase.Select();
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }
        #endregion

        #region Command button event handlers
        private void cmdOK_Click(object sender, EventArgs e)
        {
            BackupJob job;

            try
            {
                if (ValidInput())
                {
                    job = new BackupJob
                    {
                        Key = this.m_key,
                        Task = Job.GetTaskValue(cmbBackupTask.Text),
                        Path = txtBackupPath.Text
                    };

                    if (job.Task == Job.JobTasks.SingleDatabase || job.Task == Job.JobTasks.ByWildcard)
                    {
                        job.Database = cmbDatabase.Text;
                    }
                    else
                    {
                        job.Database = "N/A";
                    }

                    if (optComplete.Checked)
                    {
                        job.BackupType = BackupJob.BackupTypes.Complete;
                    }
                    else
                    {
                        job.BackupType = BackupJob.BackupTypes.TransactionLog;
                    }

                    if (optOverwrite.Checked)
                    {
                        job.BackupOption = BackupJob.BackupOverwriteOptions.Overwrite;
                    }
                    else
                    {
                        job.BackupOption = BackupJob.BackupOverwriteOptions.Append;
                    }

                    if (Program.MainForm.SaveJobToList(job, this.Action))
                    {
                        if (chkUpdate.Checked)
                        {
                            this.DialogResult = DialogResult.OK;
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
                Utility.HandleException("frmBackupJob", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            frmBrowse browseForm = null;
            bool includeFiles;

            try
            {
                if (Job.GetTaskValue(cmbBackupTask.Text) == Job.JobTasks.SingleDatabase)
                {
                    includeFiles = true;
                }
                else
                {
                    includeFiles = false;
                }

                browseForm = new frmBrowse(txtBackupPath.Text, includeFiles);

                if (!browseForm.Unload)
                {
                    if (browseForm.ShowDialog() != DialogResult.Cancel)
                    {
                        txtBackupPath.Text = browseForm.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "cmdBrowse_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                if (browseForm != null)
                {
                    browseForm.Dispose();
                }
            }
        }
        #endregion

        #region Misc event handlers
        private void cmbBackupTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            Job.JobTasks task;

            try
            {
                task = Job.GetTaskValue(cmbBackupTask.Text);
                cmbDatabase.Text = "";

                if (task == Job.JobTasks.SingleDatabase || task == Job.JobTasks.ByWildcard)
                {
                    cmbDatabase.Enabled = true;

                    if (task == Job.JobTasks.SingleDatabase)
                    {
                        lblDatabase.Text = "Database:";
                        lblNote.Visible = false;
                    }
                    else
                    {
                        lblDatabase.Text = "Search string:";
                        lblNote.Visible = true;
                    }
                }
                else
                {
                    cmbDatabase.Enabled = false;
                    lblDatabase.Text = "Database:";
                    lblNote.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "cmbBackupTask_SelectedIndexChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (Job.GetTaskValue(cmbBackupTask.Text) != Job.JobTasks.ByWildcard)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ServerUtility.InitDatabaseList(cmbDatabase);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "cmbDatabase_DropDown", ex.Source, ex.Message, ex.InnerException);
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
                Utility.HandleException("frmBackupJob", "cmbDatabase_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.m_job == null)
                {
                    txtBackupPath.Text = Program.CurrentServer.Settings.BackupDirectory + "\\" + cmbDatabase.Text + ".bak";
                }

                if (Program.CurrentServer.Databases[cmbDatabase.Text].RecoveryModel == Microsoft.SqlServer.Management.Smo.RecoveryModel.Simple)
                {
                    optComplete.Checked = true;
                    optTransLog.Checked = false;
                    optTransLog.Enabled = false;
                }
                else
                {
                    optTransLog.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmBackupJob", "cmbDatabase_SelectedIndexChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc functions
            private bool ValidInput()
            {
                Job.JobTasks task;

                try
                {
                    task = Job.GetTaskValue(cmbBackupTask.Text);

                    switch (task)
                    {
                        case Job.JobTasks.SingleDatabase:
                            if (string.IsNullOrEmpty(cmbDatabase.Text.Trim()))
                            {
                                Utility.ShowError("You must select a database to back up.");
                                cmbDatabase.Select();
                                return false;
                            }

                            Program.CurrentServer.Databases.Refresh();

                            if (!Program.CurrentServer.Databases.Contains(cmbDatabase.Text))
                            {
                                Utility.ShowError("Database '" + cmbDatabase.Text + "' not found on the server.");
                                cmbDatabase.Select();
                                return false;
                            }

                            txtBackupPath.Text = txtBackupPath.Text.Trim();
                            if (txtBackupPath.Text == "" || txtBackupPath.Text.EndsWith("\\"))
                            {
                                Utility.ShowError("You must specify a backup file.");
                                txtBackupPath.Select();
                                return false;
                            }

                            if (Directory.Exists(txtBackupPath.Text))
                            {
                                Utility.ShowError("You cannot name the backup file the same as a folder name.");
                                txtBackupPath.Select();
                                return false;
                            }

                            break;
                        case Job.JobTasks.ByWildcard:
                            if (string.IsNullOrEmpty(cmbDatabase.Text.Trim()))
                            {
                                Utility.ShowError("You must input a search string for the databases to be backed up.");
                                cmbDatabase.Select();
                                return false;
                            }

                            if (cmbDatabase.Text.Count(x => x == '*') > 1)
                            {
                                Utility.ShowError("You can only include one wildcard character.");
                                cmbDatabase.Select();
                                return false;
                            }

                            break;
                    }

                    return true;
                }
                catch (Exception ex)
                {
                    Utility.HandleException("frmBackupJob", "ValidInput", ex.Source, ex.Message, ex.InnerException);
                    return false;
                }
            }
        #endregion

        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public JobFormActions Action { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Unload { get; set; }
        #endregion
    }
}
