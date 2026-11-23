using System.ComponentModel;
using System.Text.RegularExpressions;

namespace DBTools
{
    public partial class frmOptions : Form
    {
        #region Form event handlers
        public frmOptions()
        {
            InitializeComponent();

            try
            {
                this.Unload = false;

                txtMRULength.Text = Program.AppConfig.MaxMRULength.ToString();
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmOptions", "New", ex.Source, ex.Message, ex.InnerException);
                this.Unload = true;
            }
        }
        #endregion

        #region Command button event handlers
        private void cmdOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidInput())
                {
                    Program.AppConfig.MaxMRULength = int.Parse(txtMRULength.Text);
                    Utility.SaveAppConfig();

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmOptions", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
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
                Utility.HandleException("frmOptions", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }
        #endregion

        #region Misc functions
        private bool ValidInput()
        {
            int maxMRULength;

            try
            {
                if (string.IsNullOrEmpty(txtMRULength.Text))
                {
                    Utility.ShowError("You must specify a max MRU length.");
                    txtMRULength.Select();
                    return false;
                }

                Regex maxMRUCheck = new(@"^[0-9]+$");
                if (!maxMRUCheck.IsMatch(txtMRULength.Text))
                {
                    Utility.ShowError("You must specify only digits for the max MRU length.");
                    txtMRULength.Select();
                    return false;
                }

                maxMRULength = int.Parse(txtMRULength.Text);

                if (maxMRULength < 1 || maxMRULength > 30)
                {
                    Utility.ShowError("The max MRU length value must be between 1 and 30.");
                    txtMRULength.Select();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmOptions", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
                return false;
            }
        }
        #endregion

        #region Properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool Unload { get; set; }
        #endregion
    }
}
