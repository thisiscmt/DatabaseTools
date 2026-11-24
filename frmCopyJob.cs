using System.ComponentModel;

namespace DBTools
{
    public partial class frmCopyJob : Form
    {
        private string m_key;

        #region Constructors
        public frmCopyJob()
        {
            InitializeComponent();

            try
            {
                this.Action = JobFormActions.Add;
                this.Text = JobFormActions.Add.ToString() + " Copy Job";
                cmbDatabase.Select();

                this.Unload = false;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }

        public frmCopyJob(CopyJob job)
        {
            InitializeComponent();

            try
            {
                this.Action = JobFormActions.Edit;
                this.Text = JobFormActions.Edit.ToString() + " Copy Job";
                this.m_key = job.Key;
                cmbDatabase.Text = job.Database;
                cmbNewDB.Text = job.NewDatabase;
                cmbDatabase.Select();

                this.Unload = false;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }
        #endregion

        #region Command button event handlers
        private void cmdOK_Click(object sender, EventArgs e)
        {
            CopyJob job;

            try
            {
                if (ValidInput())
                {
                    job = new CopyJob
                    {
                        Key = this.m_key,
                        Database = cmbDatabase.Text,
                        NewDatabase = cmbNewDB.Text
                    };

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
                            cmbNewDB.Text = "";
                            cmbNewDB.SelectedIndex = -1;
                            cmbDatabase.Select();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
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
                Utility.HandleException("frmCopyJob", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc event handlers
        private void cmbDatabase_DropDown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ServerUtility.InitDatabaseList(cmbDatabase);
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "cmbDatabase_DropDown", ex.Source, ex.Message, ex.InnerException);
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
                cmbDatabase_DropDown(null, null);
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "cmbDatabase_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbNewDB_DropDown(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ServerUtility.InitDatabaseList(cmbNewDB);
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "cmbNewDB_DropDown", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void cmbNewDB_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                cmbNewDB_DropDown(null, null);
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "cmbNewDB_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc functions
        private bool ValidInput()
        {
            try
            {
                if (string.IsNullOrEmpty(cmbDatabase.Text.Trim()))
                {
                    Utility.ShowError("You must select a database to copy.");
                    cmbDatabase.Select();
                    return false;
                }

                if (Program.CurrentServer.Databases[cmbDatabase.Text] == null)
                {
                    Utility.ShowError("Database '" + cmbDatabase.Text + "' not found on the server.");
                    cmbDatabase.Select();
                    return false;
                }

                if (string.IsNullOrEmpty(cmbNewDB.Text.Trim()))
                {
                    Utility.ShowError("You must input the name of the new database.");
                    cmbNewDB.Select();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmCopyJob", "ValidInput", ex.Source, ex.Message, ex.InnerException);
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
