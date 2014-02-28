using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.SqlServer.Management.Smo;

namespace DBTools
{
    public partial class frmCreateBackupScript : WizardForm
    {
        enum Stages
        {
            SelectDatabases,
            SelectPaths,
            Confirmation,
            Processing,
            Completed
        }

        private Stages m_stage;

        #region Constructor
        public frmCreateBackupScript()
        {
            InitializeComponent();

            ListViewItem li;

            try
            {
                this.Unload = false;
                this.m_stage = Stages.SelectDatabases;
                txtBackupDir.Text = Program.CurrentServer.Settings.BackupDirectory;
                txtScriptFilePath.Text = Path.Combine(Program.UserDataPath, "Back up databases.sql");
                panPaths.Visible = false;
                panMsg.Visible = false;
                cmdBack.Enabled = false;

                Program.CurrentServer.Databases.Refresh();
                foreach (Database db in Program.CurrentServer.Databases)
                {
                    li = lvwDatabases.Items.Add(db.Name, "Database");
                    li.SubItems.Add(db.Owner);
                }

                lblHeader1.Text = "Select Databases";
                lblHeader2.Text = "Select the databases that should be backed up by the script.";
            }
            catch (Exception ex)
            {
                this.Unload = true;
                Utility.HandleException("frmCreateBackupScript", "New", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Command button event handlers
        private void cmdBack_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.m_stage)
                {
                    case Stages.SelectPaths:
                        panSelectDB.Visible = true;
                        panPaths.Visible = false;
                        panMsg.Visible = false;
                        cmdBack.Enabled = false;
                        lblHeader1.Text = "Select Databases";
                        lblHeader2.Text = "Select the databases that should be backed up by the script.";
                        this.m_stage = Stages.SelectDatabases;

                        break;
                    case Stages.Confirmation:
                        panSelectDB.Visible = false;
                        panPaths.Visible = true;
                        panMsg.Visible = false;
                        lblHeader1.Text = "Specify Backup and Script File Locations";
                        lblHeader2.Text = "Input the folder where the backup should reside and the folder where the script file should be created.";
                        this.m_stage = Stages.SelectPaths;

                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCreateBackupScript", "cmdBack_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdNext_Click(object sender, EventArgs e)
        {
            string scriptText;

            try
            {
                switch (this.m_stage)
                {
                    case Stages.SelectDatabases:
                        if (lvwDatabases.CheckedItems.Count == 0)
                        {
                            Utility.ShowError("You must select at least one database.");
                            lvwDatabases.Select();
                            return;
                        }

                        panSelectDB.Visible = false;
                        panPaths.Visible = true;
                        panMsg.Visible = false;
                        lblHeader1.Text = "Specify Backup and Script File Locations";
                        lblHeader2.Text = "Input the folder where the backup should reside and the folder where the script file should be created.";
                        txtBackupDir.Select();
                        cmdBack.Enabled = true;
                        this.m_stage = Stages.SelectPaths;

                        break;
                    case Stages.SelectPaths:
                        if (txtBackupDir.Text.Trim() == "")
                        {
                            Utility.ShowError("You must input the path where the backups will be created.");
                            lvwDatabases.Select();
                            return;
                        }
                        if (txtScriptFilePath.Text.Trim() == "")
                        {
                            Utility.ShowError("You must input the path for the script file.");
                            lvwDatabases.Select();
                            return;
                        }

                        panSelectDB.Visible = false;
                        panPaths.Visible = false;
                        panMsg.Visible = true;
                        lblHeader1.Text = "Final Confirmation";
                        lblHeader2.Text = "The wizard has all the information it needs to start the process.";
                        lblMsg.Text = "Click Next to initiate the script creation, or click Back to change any of your options.";
                        this.m_stage = Stages.Confirmation;

                        break;
                    case Stages.Confirmation:
                        this.m_stage = Stages.Processing;
                        Cursor.Current = Cursors.WaitCursor;
                        pbrMain.Visible = true;
                        cmdBack.Enabled = false;
                        cmdCancel.Enabled = false;

                        scriptText = "Set NOCOUNT On" + Environment.NewLine;
                        scriptText += "Declare @DB nvarchar(128)" + Environment.NewLine;
                        scriptText += "Declare @Path nvarchar(256)" + Environment.NewLine;
                        scriptText += "Declare @BackupPath nvarchar(256)" + Environment.NewLine;
                        scriptText += "Declare @Name nvarchar(256)" + Environment.NewLine;
                        scriptText += "Declare @SQL nvarchar(2000)" + Environment.NewLine;
                        scriptText += "Set @Path = '" + Utility.AppendSeparator(txtBackupDir.Text) + "'" + Environment.NewLine + Environment.NewLine;

                        foreach (ListViewItem li in lvwDatabases.CheckedItems)
                        {
                            scriptText += "Set @DB = '" + li.Text + "'" + Environment.NewLine;
                            scriptText += "Set @BackupPath = @Path + @DB + '.bak'" + Environment.NewLine;
                            scriptText += "Set @Name = @DB + 'Full Database Backup'" + Environment.NewLine;
                            scriptText += "Set @SQL = 'BACKUP DATABASE [' + @DB + '] TO DISK = N''' + @BackupPath + ''' WITH NOFORMAT, INIT, NAME = N''' + @Name + ''', SKIP, NOREWIND, NOUNLOAD, STATS = 10'" + Environment.NewLine;
                            scriptText += "exec sp_executesql @SQL " + Environment.NewLine + Environment.NewLine;
                        }

                        File.Delete(txtScriptFilePath.Text);
                        File.WriteAllText(txtScriptFilePath.Text, scriptText);
                        pbrMain.Visible = false;
                        cmdNext.Text = "&Finish";
                        lblMsg.Text = "The wizard has completed successfully. Click Finish to continue.";
                        this.m_stage = Stages.Completed;

                        break;
                    case Stages.Completed:
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;

                        break;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCreateBackupScript", "cmdNext_Click", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_stage != Stages.Processing)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCreateBackupScript", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdSelectAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem li in lvwDatabases.Items)
                {
                    li.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCreateBackupScript", "cmdSelectAll_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdClearAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem li in lvwDatabases.Items)
                {
                    li.Checked = false;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCreateBackupScript", "cmdClearAll_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdBrowseBackupPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fb;

            try
            {
                fb = new FolderBrowserDialog();
                fb.ShowNewFolderButton = true;
                fb.RootFolder = Environment.SpecialFolder.MyComputer;
                fb.Description = "Select Folder";

                if (fb.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                {
                    txtBackupDir.Text = fb.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCreateBackupScript", "cmdBrowseBackupPath_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdBrowseScriptPath_Click(object sender, EventArgs e)
        {
            string filePath;
            string filter;

            try
            {
                filter = "SQL Script Files (*.sql)|*.sql|All Files (*.*)|*.*";
                filePath = Utility.BrowseForFileOpen(extension: "sql", filter: filter, fileExists: false);

                if (filePath != "")
                {
                    txtScriptFilePath.Text = filePath;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCreateBackupScript", "cmdBrowseScriptPath_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion
    }
}
