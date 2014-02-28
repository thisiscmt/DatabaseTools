using System;
using System.Windows.Forms;
using System.IO;

namespace DBTools
{
    public partial class frmSystemLog : Form
    {
        #region Form event handlers
        public frmSystemLog(string logFilePath)
        {
            InitializeComponent();

            try
            {
                this.Unload = false;
                this.LogFilePath = logFilePath;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmSystemLog", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }

        private void frmSystemLog_Shown(object sender, EventArgs e)
        {
            // The log file is loaded here to prevent all the text in the text box 
            // from being selected automatically
            string msg;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                try
                {
                    if (File.Exists(this.LogFilePath))
                    {
                        txtLog.Text = File.ReadAllText(this.LogFilePath);
                    }
                }
                catch (Exception ex)
                {
                    msg = "Unable to read the system log due the following error:" + Environment.NewLine + Environment.NewLine;
                    msg = msg + ex.Message;
                    Utility.ShowError(msg);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmSystemLog", "New", ex.Source, ex.Message, ex.InnerException);
                this.Close();
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region Misc event handlers
        private void mnuClearLog_Click(object sender, EventArgs e)
        {
            try
            {
                txtLog.Text = "";
                File.Delete(this.LogFilePath);
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmSystemLog", "mnuClearLog_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuPrintLog_Click(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement system log printing
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmSystemLog", "mnuPrintLog_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmSystemLog", "mnuClose_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void txtLog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                mnuClose_Click(sender, e);
            }
        }
        #endregion

        #region Properties
        public string LogFilePath { get; set; }
        public bool Unload { get; set; }
        #endregion
    }
}
