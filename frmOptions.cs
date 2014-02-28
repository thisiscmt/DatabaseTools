using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Nini.Config;

namespace DBTools
{
    public partial class frmOptions : Form
    {
        #region Form event handlers
        public frmOptions()
        {
            InitializeComponent();

            IConfig optionsSection;

            try
            {
                this.Unload = false;

                if (Program.ConfigFile.Configs["Options"] == null)
                {
                    optionsSection = Program.ConfigFile.Configs.Add("Options");
                }
                else
                {
                    optionsSection = Program.ConfigFile.Configs["Options"];
                    txtMRULength.Text = optionsSection.GetString("MaxMRULength");
                }
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
            IConfig optionsSection;

            try
            {
                if (ValidInput())
                {
                    optionsSection = Program.ConfigFile.Configs["Options"];
                    optionsSection.Set("MaxMRULength", int.Parse(txtMRULength.Text));
                    Program.ConfigFile.Save();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
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

                Regex maxMRUCheck = new Regex(@"^[0-9]+$");
                if (!maxMRUCheck.IsMatch(txtMRULength.Text))
                {
                    Utility.ShowError("You must specify only digits for the max MRU length.");
                    txtMRULength.Select();
                    return false;
                }

                maxMRULength = int.Parse(txtMRULength.Text);

                if (maxMRULength < 1 || maxMRULength > 12)
                {
                    Utility.ShowError("The max MRU length value must be between 1 and 16.");
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
        public bool Unload { get; set; }
        #endregion
    }
}
