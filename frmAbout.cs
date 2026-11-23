using System.Diagnostics;
using System.Reflection;

namespace DBTools
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();

            FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string ver = fileInfo.FileMajorPart.ToString() + "." + fileInfo.FileMinorPart.ToString() + "." + fileInfo.FileBuildPart.ToString();
            string desc = "Database Tools " + ver + Environment.NewLine + Environment.NewLine;
            desc = desc + ((AssemblyDescriptionAttribute)Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)[0]).Description + Environment.NewLine;

            lblDesc.Text = desc;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
