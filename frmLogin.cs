using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nini.Config;

namespace DBTools
{
    public partial class frmLogin : JobForm
    {
        public frmLogin(bool firstLogin)
        {
            InitializeComponent();

            User user;
            bool userIDSet = false;

            try
            {
                this.FirstLogin = firstLogin;
                this.LastUserID = Environment.UserName;
                user = Program.LoadLoginInfo();
                txtUserID.Text = user.UserID;
                cmbServer.Text = user.Server;

                if (!string.IsNullOrEmpty(txtUserID.Text))
                {
                    userIDSet = true;
                }

                if (user.Authentication == User.AuthenticationType.Windows)
                {
                    chkWinAuth.Checked = true;

                    if (!userIDSet)
                    {
                        txtUserID.Text = Environment.UserDomainName + "\\" + Environment.UserName;
                    }
                }
                else
                {
                    if (!userIDSet)
                    {
                        txtUserID.Text = Environment.UserName;
                    }
                }

                txtPassword.Select();
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmLogin", "New", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            User user = new User();

            try
            {
                Cursor.Current  = Cursors.WaitCursor;
                cmbServer.Text = cmbServer.Text.Trim();

                if (txtUserID.Text == "")
                {
                    MessageBox.Show("User ID cannot be blank.", Program.ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtUserID.Select();
                    return;
                }
                if (cmbServer.Text == "")
                {
                    MessageBox.Show("Enter the name of a server or select one from the drop-down list.", Program.ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbServer.Select();
                    return;
                }

                user.UserID = txtUserID.Text;
                user.Password = txtPassword.Text;
                user.Server = cmbServer.Text;

                if (chkWinAuth.Checked)
                {
                    user.Authentication = User.AuthenticationType.Windows;
                }
                else
                {
                    user.Authentication = User.AuthenticationType.SQL;
                }

                if (ServerUtility.ConnectToServer(user))
                {
                    Program.SaveLoginInfo(user);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmLogin", "cmdOK_Click", ex.Source, ex.Message, ex.InnerException);
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
                if (!this.FirstLogin)
                {
                    // We need to try to re-establish the previous connection in 
                    // case there was a failed connection attempt (e.g. wrong 
                    // password), which would have caused it to be severed
                    ServerUtility.ConnectToServer(Program.CurrentUser);
                }

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmLogin", "cmdCancel_Click", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void txtUserID_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtUserID.Text != this.LastUserID)
                {
                    this.LastUserID = txtUserID.Text;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmLogin", "txtUserID_Leave", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void cmbServer_DropDown(object sender, EventArgs e)
        {
            List<string> servers;
            List<string> aliases;
            DataTable dt = null;

            try
            {
                if (cmbServer.Items.Count == 0)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    servers = new List<string>();
                    dt = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();

                    foreach (DataRow dr in dt.Rows)
                    {
                        if (string.IsNullOrEmpty(dr["InstanceName"].ToString()))
                        {
                            servers.Add(dr["ServerName"].ToString());
                        }
                        else
                        {
                            servers.Add(dr["ServerName"].ToString() + "\\" + dr["InstanceName"].ToString());
                        }
                    }

                    aliases = ServerUtility.GetServerAliases();
                    servers.AddRange(aliases);
                    servers.Sort();
                    cmbServer.Items.AddRange(servers.ToArray());
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmLogin", "cmbServer_DropDown", ex.Source, ex.Message, ex.InnerException);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

                if (dt != null)
                {
                    dt.Dispose();
                }
            }
        }

        private void cmbServer_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    cmbServer_DropDown(sender, e);
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmLogin", "cmbServer_KeyDown", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private void chkWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (((CheckBox)sender).Checked)
                {
                    txtUserID.Enabled = false;
                    txtPassword.Enabled = false;
                    txtUserID.Text = Environment.UserDomainName + "\\" + Environment.UserName;
                }
                else
                {
                    txtUserID.Enabled = true;
                    txtPassword.Enabled = true;
                    txtUserID.Text = this.LastUserID;
                }
            }
            catch (Exception ex)
            {
                Utility.HandleException("frmLogin", "chkWinAuth_CheckedChanged", ex.Source, ex.Message, ex.InnerException);
            }
        }

        private string LastUserID { get; set; }
        private bool FirstLogin { get; set; }
    }
}
