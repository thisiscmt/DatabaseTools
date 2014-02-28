namespace DBTools
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSaveOnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuJobs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddBackupJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddRestoreJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddShrinkJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAddCopyJob = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditJob = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteJob = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuStartJobs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWizards = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateBackupScript = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSystemLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tbrMain = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddBackupJob = new System.Windows.Forms.ToolStripButton();
            this.tsbAddRestoreJob = new System.Windows.Forms.ToolStripButton();
            this.tsbAddShrinkJob = new System.Windows.Forms.ToolStripButton();
            this.tsbAddCopyJob = new System.Windows.Forms.ToolStripButton();
            this.tsbEditJob = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteJob = new System.Windows.Forms.ToolStripButton();
            this.tsbStartJobs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBackupScript = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSystemLog = new System.Windows.Forms.ToolStripButton();
            this.tsbLogin = new System.Windows.Forms.ToolStripButton();
            this.sbrMain = new System.Windows.Forms.StatusStrip();
            this.lblCancel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbrMain = new System.Windows.Forms.ToolStripProgressBar();
            this.lblServer = new System.Windows.Forms.ToolStripStatusLabel();
            this.lvwMain = new System.Windows.Forms.ListView();
            this.colDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJobType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTask = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDetails = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.mnuMain.SuspendLayout();
            this.tbrMain.SuspendLayout();
            this.sbrMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuJobs,
            this.mnuWizards,
            this.mnuTools,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(0, 2, 2, 2);
            this.mnuMain.Size = new System.Drawing.Size(792, 24);
            this.mnuMain.TabIndex = 0;
            this.mnuMain.Text = "Main Menu";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuSave,
            this.toolStripSeparator3,
            this.mnuSaveOnExit,
            this.ExitSeparator,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(35, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(159, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuSave.Image")));
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuSave.Size = new System.Drawing.Size(159, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuSaveOnExit
            // 
            this.mnuSaveOnExit.CheckOnClick = true;
            this.mnuSaveOnExit.Name = "mnuSaveOnExit";
            this.mnuSaveOnExit.Size = new System.Drawing.Size(159, 22);
            this.mnuSaveOnExit.Text = "Save Jobs on Exit";
            // 
            // ExitSeparator
            // 
            this.ExitSeparator.Name = "ExitSeparator";
            this.ExitSeparator.Size = new System.Drawing.Size(156, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(159, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // mnuJobs
            // 
            this.mnuJobs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddBackupJob,
            this.mnuAddRestoreJob,
            this.mnuAddShrinkJob,
            this.mnuAddCopyJob,
            this.toolStripSeparator2,
            this.mnuSelectAll,
            this.mnuClearAll,
            this.toolStripSeparator5,
            this.mnuEditJob,
            this.mnuDeleteJob,
            this.toolStripSeparator6,
            this.mnuStartJobs});
            this.mnuJobs.Name = "mnuJobs";
            this.mnuJobs.Size = new System.Drawing.Size(41, 20);
            this.mnuJobs.Text = "Jobs";
            // 
            // mnuAddBackupJob
            // 
            this.mnuAddBackupJob.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddBackupJob.Image")));
            this.mnuAddBackupJob.Name = "mnuAddBackupJob";
            this.mnuAddBackupJob.Size = new System.Drawing.Size(160, 22);
            this.mnuAddBackupJob.Text = "Add Backup Job";
            this.mnuAddBackupJob.Click += new System.EventHandler(this.mnuAddBackupJob_Click);
            // 
            // mnuAddRestoreJob
            // 
            this.mnuAddRestoreJob.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddRestoreJob.Image")));
            this.mnuAddRestoreJob.Name = "mnuAddRestoreJob";
            this.mnuAddRestoreJob.Size = new System.Drawing.Size(160, 22);
            this.mnuAddRestoreJob.Text = "Add Restore Job";
            this.mnuAddRestoreJob.Click += new System.EventHandler(this.mnuAddRestoreJob_Click);
            // 
            // mnuAddShrinkJob
            // 
            this.mnuAddShrinkJob.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddShrinkJob.Image")));
            this.mnuAddShrinkJob.Name = "mnuAddShrinkJob";
            this.mnuAddShrinkJob.Size = new System.Drawing.Size(160, 22);
            this.mnuAddShrinkJob.Text = "Add Shrink Job";
            this.mnuAddShrinkJob.Click += new System.EventHandler(this.mnuAddShrinkJob_Click);
            // 
            // mnuAddCopyJob
            // 
            this.mnuAddCopyJob.Image = ((System.Drawing.Image)(resources.GetObject("mnuAddCopyJob.Image")));
            this.mnuAddCopyJob.Name = "mnuAddCopyJob";
            this.mnuAddCopyJob.Size = new System.Drawing.Size(160, 22);
            this.mnuAddCopyJob.Text = "Add Copy Job";
            this.mnuAddCopyJob.Click += new System.EventHandler(this.mnuAddCopyJob_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
            // 
            // mnuSelectAll
            // 
            this.mnuSelectAll.Name = "mnuSelectAll";
            this.mnuSelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuSelectAll.Size = new System.Drawing.Size(160, 22);
            this.mnuSelectAll.Text = "Select All";
            this.mnuSelectAll.Click += new System.EventHandler(this.mnuSelectAll_Click);
            // 
            // mnuClearAll
            // 
            this.mnuClearAll.Name = "mnuClearAll";
            this.mnuClearAll.Size = new System.Drawing.Size(160, 22);
            this.mnuClearAll.Text = "Clear All";
            this.mnuClearAll.Click += new System.EventHandler(this.mnuClearAll_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(157, 6);
            // 
            // mnuEditJob
            // 
            this.mnuEditJob.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditJob.Image")));
            this.mnuEditJob.Name = "mnuEditJob";
            this.mnuEditJob.Size = new System.Drawing.Size(160, 22);
            this.mnuEditJob.Text = "Edit Job";
            this.mnuEditJob.Click += new System.EventHandler(this.mnuEditJob_Click);
            // 
            // mnuDeleteJob
            // 
            this.mnuDeleteJob.Image = ((System.Drawing.Image)(resources.GetObject("mnuDeleteJob.Image")));
            this.mnuDeleteJob.Name = "mnuDeleteJob";
            this.mnuDeleteJob.Size = new System.Drawing.Size(160, 22);
            this.mnuDeleteJob.Text = "Delete Job";
            this.mnuDeleteJob.Click += new System.EventHandler(this.mnuDeleteJob_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(157, 6);
            // 
            // mnuStartJobs
            // 
            this.mnuStartJobs.Image = ((System.Drawing.Image)(resources.GetObject("mnuStartJobs.Image")));
            this.mnuStartJobs.Name = "mnuStartJobs";
            this.mnuStartJobs.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.mnuStartJobs.Size = new System.Drawing.Size(160, 22);
            this.mnuStartJobs.Text = "Start Jobs";
            this.mnuStartJobs.Click += new System.EventHandler(this.mnuStartJobs_Click);
            // 
            // mnuWizards
            // 
            this.mnuWizards.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCreateBackupScript});
            this.mnuWizards.Name = "mnuWizards";
            this.mnuWizards.Size = new System.Drawing.Size(57, 20);
            this.mnuWizards.Text = "Wizards";
            // 
            // mnuCreateBackupScript
            // 
            this.mnuCreateBackupScript.Image = ((System.Drawing.Image)(resources.GetObject("mnuCreateBackupScript.Image")));
            this.mnuCreateBackupScript.Name = "mnuCreateBackupScript";
            this.mnuCreateBackupScript.Size = new System.Drawing.Size(174, 22);
            this.mnuCreateBackupScript.Text = "Create Backup Script";
            this.mnuCreateBackupScript.Click += new System.EventHandler(this.mnuCreateBackupScript_Click);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSystemLog,
            this.mnuLogin,
            this.toolStripSeparator8,
            this.mnuOptions});
            this.mnuTools.Name = "mnuTools";
            this.mnuTools.Size = new System.Drawing.Size(44, 20);
            this.mnuTools.Text = "Tools";
            // 
            // mnuSystemLog
            // 
            this.mnuSystemLog.Image = ((System.Drawing.Image)(resources.GetObject("mnuSystemLog.Image")));
            this.mnuSystemLog.Name = "mnuSystemLog";
            this.mnuSystemLog.Size = new System.Drawing.Size(129, 22);
            this.mnuSystemLog.Text = "System Log";
            this.mnuSystemLog.Click += new System.EventHandler(this.mnuSystemLog_Click);
            // 
            // mnuLogin
            // 
            this.mnuLogin.Image = ((System.Drawing.Image)(resources.GetObject("mnuLogin.Image")));
            this.mnuLogin.Name = "mnuLogin";
            this.mnuLogin.Size = new System.Drawing.Size(129, 22);
            this.mnuLogin.Text = "Login";
            this.mnuLogin.Click += new System.EventHandler(this.mnuLogin_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(126, 6);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Name = "mnuOptions";
            this.mnuOptions.Size = new System.Drawing.Size(129, 22);
            this.mnuOptions.Text = "Options";
            this.mnuOptions.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(40, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(103, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // tbrMain
            // 
            this.tbrMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbAddBackupJob,
            this.tsbAddRestoreJob,
            this.tsbAddShrinkJob,
            this.tsbAddCopyJob,
            this.tsbEditJob,
            this.tsbDeleteJob,
            this.tsbStartJobs,
            this.toolStripSeparator4,
            this.tsbBackupScript,
            this.toolStripSeparator7,
            this.tsbSystemLog,
            this.tsbLogin});
            this.tbrMain.Location = new System.Drawing.Point(0, 24);
            this.tbrMain.Name = "tbrMain";
            this.tbrMain.Size = new System.Drawing.Size(792, 25);
            this.tbrMain.TabIndex = 1;
            this.tbrMain.Text = "Main Toolbar";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "Open";
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAddBackupJob
            // 
            this.tsbAddBackupJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddBackupJob.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddBackupJob.Image")));
            this.tsbAddBackupJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddBackupJob.Name = "tsbAddBackupJob";
            this.tsbAddBackupJob.Size = new System.Drawing.Size(23, 22);
            this.tsbAddBackupJob.Text = "Add Backup Job";
            this.tsbAddBackupJob.Click += new System.EventHandler(this.tsbAddBackupJob_Click);
            // 
            // tsbAddRestoreJob
            // 
            this.tsbAddRestoreJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddRestoreJob.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddRestoreJob.Image")));
            this.tsbAddRestoreJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddRestoreJob.Name = "tsbAddRestoreJob";
            this.tsbAddRestoreJob.Size = new System.Drawing.Size(23, 22);
            this.tsbAddRestoreJob.Text = "Add Restore Job";
            this.tsbAddRestoreJob.Click += new System.EventHandler(this.tsbAddRestoreJob_Click);
            // 
            // tsbAddShrinkJob
            // 
            this.tsbAddShrinkJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddShrinkJob.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddShrinkJob.Image")));
            this.tsbAddShrinkJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddShrinkJob.Name = "tsbAddShrinkJob";
            this.tsbAddShrinkJob.Size = new System.Drawing.Size(23, 22);
            this.tsbAddShrinkJob.Text = "Add Shrink Job";
            this.tsbAddShrinkJob.Click += new System.EventHandler(this.tsbAddShrinkJob_Click);
            // 
            // tsbAddCopyJob
            // 
            this.tsbAddCopyJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddCopyJob.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddCopyJob.Image")));
            this.tsbAddCopyJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddCopyJob.Name = "tsbAddCopyJob";
            this.tsbAddCopyJob.Size = new System.Drawing.Size(23, 22);
            this.tsbAddCopyJob.Text = "Add Copy Job";
            this.tsbAddCopyJob.Click += new System.EventHandler(this.tsbAddCopyJob_Click);
            // 
            // tsbEditJob
            // 
            this.tsbEditJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEditJob.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditJob.Image")));
            this.tsbEditJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditJob.Name = "tsbEditJob";
            this.tsbEditJob.Size = new System.Drawing.Size(23, 22);
            this.tsbEditJob.Text = "Edit Job";
            this.tsbEditJob.Click += new System.EventHandler(this.tsbEditJob_Click);
            // 
            // tsbDeleteJob
            // 
            this.tsbDeleteJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDeleteJob.Image = ((System.Drawing.Image)(resources.GetObject("tsbDeleteJob.Image")));
            this.tsbDeleteJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteJob.Name = "tsbDeleteJob";
            this.tsbDeleteJob.Size = new System.Drawing.Size(23, 22);
            this.tsbDeleteJob.Text = "Delete Job";
            this.tsbDeleteJob.Click += new System.EventHandler(this.tsbDeleteJob_Click);
            // 
            // tsbStartJobs
            // 
            this.tsbStartJobs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStartJobs.Image = ((System.Drawing.Image)(resources.GetObject("tsbStartJobs.Image")));
            this.tsbStartJobs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStartJobs.Name = "tsbStartJobs";
            this.tsbStartJobs.Size = new System.Drawing.Size(23, 22);
            this.tsbStartJobs.Text = "Start Jobs";
            this.tsbStartJobs.Click += new System.EventHandler(this.tsbStartJobs_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBackupScript
            // 
            this.tsbBackupScript.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBackupScript.Image = ((System.Drawing.Image)(resources.GetObject("tsbBackupScript.Image")));
            this.tsbBackupScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBackupScript.Name = "tsbBackupScript";
            this.tsbBackupScript.Size = new System.Drawing.Size(23, 22);
            this.tsbBackupScript.Text = "Create Backup Script";
            this.tsbBackupScript.Click += new System.EventHandler(this.tsbBackupScript_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbSystemLog
            // 
            this.tsbSystemLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSystemLog.Image = ((System.Drawing.Image)(resources.GetObject("tsbSystemLog.Image")));
            this.tsbSystemLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSystemLog.Name = "tsbSystemLog";
            this.tsbSystemLog.Size = new System.Drawing.Size(23, 22);
            this.tsbSystemLog.Text = "System Log";
            this.tsbSystemLog.Click += new System.EventHandler(this.tsbSystemLog_Click);
            // 
            // tsbLogin
            // 
            this.tsbLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLogin.Image = ((System.Drawing.Image)(resources.GetObject("tsbLogin.Image")));
            this.tsbLogin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLogin.Name = "tsbLogin";
            this.tsbLogin.Size = new System.Drawing.Size(23, 22);
            this.tsbLogin.Text = "Login";
            this.tsbLogin.Click += new System.EventHandler(this.tsbLogin_Click);
            // 
            // sbrMain
            // 
            this.sbrMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCancel,
            this.lblStatus,
            this.pbrMain,
            this.lblServer});
            this.sbrMain.Location = new System.Drawing.Point(0, 551);
            this.sbrMain.Name = "sbrMain";
            this.sbrMain.Size = new System.Drawing.Size(792, 22);
            this.sbrMain.TabIndex = 2;
            // 
            // lblCancel
            // 
            this.lblCancel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblCancel.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.lblCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblCancel.IsLink = true;
            this.lblCancel.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lblCancel.LinkColor = System.Drawing.Color.Black;
            this.lblCancel.Name = "lblCancel";
            this.lblCancel.Size = new System.Drawing.Size(43, 17);
            this.lblCancel.Text = "Cancel";
            this.lblCancel.Click += new System.EventHandler(this.lblCancel_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblStatus.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(628, 17);
            this.lblStatus.Spring = true;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbrMain
            // 
            this.pbrMain.Name = "pbrMain";
            this.pbrMain.Size = new System.Drawing.Size(100, 16);
            // 
            // lblServer
            // 
            this.lblServer.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblServer.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.lblServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(4, 17);
            // 
            // lvwMain
            // 
            this.lvwMain.AllowDrop = true;
            this.lvwMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDatabase,
            this.colJobType,
            this.colTask,
            this.colPath,
            this.colDetails});
            this.lvwMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMain.Location = new System.Drawing.Point(0, 49);
            this.lvwMain.Name = "lvwMain";
            this.lvwMain.Size = new System.Drawing.Size(792, 502);
            this.lvwMain.SmallImageList = this.imlSmall;
            this.lvwMain.TabIndex = 3;
            this.lvwMain.UseCompatibleStateImageBehavior = false;
            this.lvwMain.View = System.Windows.Forms.View.Details;
            this.lvwMain.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvwMain_ItemDrag);
            this.lvwMain.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwMain_DragDrop);
            this.lvwMain.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwMain_DragEnter);
            this.lvwMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwMain_KeyDown);
            this.lvwMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwMain_MouseDoubleClick);
            // 
            // colDatabase
            // 
            this.colDatabase.Text = "Database";
            this.colDatabase.Width = 175;
            // 
            // colJobType
            // 
            this.colJobType.Text = "Job Type";
            this.colJobType.Width = 100;
            // 
            // colTask
            // 
            this.colTask.Text = "Task";
            this.colTask.Width = 125;
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 450;
            // 
            // colDetails
            // 
            this.colDetails.Text = "Details";
            this.colDetails.Width = 400;
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "Job");
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.lvwMain);
            this.Controls.Add(this.sbrMain);
            this.Controls.Add(this.tbrMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "Database Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.tbrMain.ResumeLayout(false);
            this.tbrMain.PerformLayout();
            this.sbrMain.ResumeLayout(false);
            this.sbrMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStrip tbrMain;
        private System.Windows.Forms.StatusStrip sbrMain;
        private System.Windows.Forms.ListView lvwMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuJobs;
        private System.Windows.Forms.ToolStripMenuItem mnuWizards;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveOnExit;
        private System.Windows.Forms.ToolStripSeparator ExitSeparator;
        private System.Windows.Forms.ToolStripMenuItem mnuAddBackupJob;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRestoreJob;
        private System.Windows.Forms.ToolStripMenuItem mnuAddShrinkJob;
        private System.Windows.Forms.ToolStripMenuItem mnuAddCopyJob;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuStartJobs;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripMenuItem mnuSystemLog;
        private System.Windows.Forms.ToolStripMenuItem mnuLogin;
        private System.Windows.Forms.ColumnHeader colDatabase;
        private System.Windows.Forms.ColumnHeader colJobType;
        private System.Windows.Forms.ColumnHeader colTask;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ColumnHeader colDetails;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbAddBackupJob;
        private System.Windows.Forms.ToolStripButton tsbAddRestoreJob;
        private System.Windows.Forms.ToolStripButton tsbAddShrinkJob;
        private System.Windows.Forms.ToolStripButton tsbAddCopyJob;
        private System.Windows.Forms.ToolStripButton tsbEditJob;
        private System.Windows.Forms.ToolStripButton tsbDeleteJob;
        private System.Windows.Forms.ToolStripButton tsbStartJobs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbSystemLog;
        private System.Windows.Forms.ToolStripButton tsbLogin;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem mnuClearAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuEditJob;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteJob;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateBackupScript;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripProgressBar pbrMain;
        private System.Windows.Forms.ToolStripStatusLabel lblServer;
        private System.Windows.Forms.ToolStripStatusLabel lblCancel;
        private System.Windows.Forms.ToolStripButton tsbBackupScript;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem mnuOptions;
    }
}

