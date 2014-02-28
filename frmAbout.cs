using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace DBTools
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            FileVersionInfo fileInfo;
            string desc;
            string ver;

            fileInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            ver = fileInfo.FileMajorPart.ToString() + "." + fileInfo.FileMinorPart.ToString() + "." + fileInfo.FileBuildPart.ToString();
            desc = "Database Tools " + ver + Environment.NewLine + Environment.NewLine;
            desc = desc + ((AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description + Environment.NewLine;

            lblAck.Text = "Silk icon set provided by Mark James.";
            lblLink.Text = "www.famfamfam.com/lab/icons/silk";
            lblDesc.Text = desc;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://" + ((LinkLabel) sender).Text);
        }
    }
}
