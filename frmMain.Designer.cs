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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            mnuMain = new MenuStrip();
            mnuFile = new ToolStripMenuItem();
            mnuOpen = new ToolStripMenuItem();
            mnuSave = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            mnuSaveOnExit = new ToolStripMenuItem();
            ExitSeparator = new ToolStripSeparator();
            mnuExit = new ToolStripMenuItem();
            mnuJobs = new ToolStripMenuItem();
            mnuAddBackupJob = new ToolStripMenuItem();
            mnuAddRestoreJob = new ToolStripMenuItem();
            mnuAddShrinkJob = new ToolStripMenuItem();
            mnuAddCopyJob = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            mnuSelectAll = new ToolStripMenuItem();
            mnuClearAll = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            mnuEditJob = new ToolStripMenuItem();
            mnuDeleteJob = new ToolStripMenuItem();
            toolStripSeparator6 = new ToolStripSeparator();
            mnuStartJobs = new ToolStripMenuItem();
            mnuWizards = new ToolStripMenuItem();
            mnuCreateBackupScript = new ToolStripMenuItem();
            mnuTools = new ToolStripMenuItem();
            mnuSystemLog = new ToolStripMenuItem();
            mnuLogin = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            mnuOptions = new ToolStripMenuItem();
            mnuHelp = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            tbrMain = new ToolStrip();
            tsbOpen = new ToolStripButton();
            tsbSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            tsbAddBackupJob = new ToolStripButton();
            tsbAddRestoreJob = new ToolStripButton();
            tsbAddShrinkJob = new ToolStripButton();
            tsbAddCopyJob = new ToolStripButton();
            tsbEditJob = new ToolStripButton();
            tsbDeleteJob = new ToolStripButton();
            tsbStartJobs = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            tsbBackupScript = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            tsbSystemLog = new ToolStripButton();
            tsbLogin = new ToolStripButton();
            sbrMain = new StatusStrip();
            lblCancel = new ToolStripStatusLabel();
            lblStatus = new ToolStripStatusLabel();
            pbrMain = new ToolStripProgressBar();
            lblServer = new ToolStripStatusLabel();
            lvwMain = new ListView();
            colDatabase = new ColumnHeader();
            colJobType = new ColumnHeader();
            colTask = new ColumnHeader();
            colPath = new ColumnHeader();
            colDetails = new ColumnHeader();
            imlSmall = new ImageList(components);
            mnuMain.SuspendLayout();
            tbrMain.SuspendLayout();
            sbrMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.ImageScalingSize = new Size(20, 20);
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuFile, mnuJobs, mnuWizards, mnuTools, mnuHelp });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Padding = new Padding(0, 2, 3, 2);
            mnuMain.Size = new Size(924, 24);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "Main Menu";
            // 
            // mnuFile
            // 
            mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuOpen, mnuSave, toolStripSeparator3, mnuSaveOnExit, ExitSeparator, mnuExit });
            mnuFile.Name = "mnuFile";
            mnuFile.Size = new Size(37, 20);
            mnuFile.Text = "File";
            // 
            // mnuOpen
            // 
            mnuOpen.Image = (Image)resources.GetObject("mnuOpen.Image");
            mnuOpen.Name = "mnuOpen";
            mnuOpen.Size = new Size(163, 22);
            mnuOpen.Text = "Open";
            mnuOpen.Click += mnuOpen_Click;
            // 
            // mnuSave
            // 
            mnuSave.Image = (Image)resources.GetObject("mnuSave.Image");
            mnuSave.Name = "mnuSave";
            mnuSave.ShortcutKeys = Keys.Control | Keys.S;
            mnuSave.Size = new Size(163, 22);
            mnuSave.Text = "Save";
            mnuSave.Click += mnuSave_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(160, 6);
            // 
            // mnuSaveOnExit
            // 
            mnuSaveOnExit.CheckOnClick = true;
            mnuSaveOnExit.Name = "mnuSaveOnExit";
            mnuSaveOnExit.Size = new Size(163, 22);
            mnuSaveOnExit.Text = "Save Jobs on Exit";
            // 
            // ExitSeparator
            // 
            ExitSeparator.Name = "ExitSeparator";
            ExitSeparator.Size = new Size(160, 6);
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(163, 22);
            mnuExit.Text = "Exit";
            mnuExit.Click += mnuExit_Click;
            // 
            // mnuJobs
            // 
            mnuJobs.DropDownItems.AddRange(new ToolStripItem[] { mnuAddBackupJob, mnuAddRestoreJob, mnuAddShrinkJob, mnuAddCopyJob, toolStripSeparator2, mnuSelectAll, mnuClearAll, toolStripSeparator5, mnuEditJob, mnuDeleteJob, toolStripSeparator6, mnuStartJobs });
            mnuJobs.Name = "mnuJobs";
            mnuJobs.Size = new Size(42, 20);
            mnuJobs.Text = "Jobs";
            // 
            // mnuAddBackupJob
            // 
            mnuAddBackupJob.Image = (Image)resources.GetObject("mnuAddBackupJob.Image");
            mnuAddBackupJob.Name = "mnuAddBackupJob";
            mnuAddBackupJob.Size = new Size(164, 22);
            mnuAddBackupJob.Text = "Add Backup Job";
            mnuAddBackupJob.Click += mnuAddBackupJob_Click;
            // 
            // mnuAddRestoreJob
            // 
            mnuAddRestoreJob.Image = (Image)resources.GetObject("mnuAddRestoreJob.Image");
            mnuAddRestoreJob.Name = "mnuAddRestoreJob";
            mnuAddRestoreJob.Size = new Size(164, 22);
            mnuAddRestoreJob.Text = "Add Restore Job";
            mnuAddRestoreJob.Click += mnuAddRestoreJob_Click;
            // 
            // mnuAddShrinkJob
            // 
            mnuAddShrinkJob.Image = (Image)resources.GetObject("mnuAddShrinkJob.Image");
            mnuAddShrinkJob.Name = "mnuAddShrinkJob";
            mnuAddShrinkJob.Size = new Size(164, 22);
            mnuAddShrinkJob.Text = "Add Shrink Job";
            mnuAddShrinkJob.Click += mnuAddShrinkJob_Click;
            // 
            // mnuAddCopyJob
            // 
            mnuAddCopyJob.Image = (Image)resources.GetObject("mnuAddCopyJob.Image");
            mnuAddCopyJob.Name = "mnuAddCopyJob";
            mnuAddCopyJob.Size = new Size(164, 22);
            mnuAddCopyJob.Text = "Add Copy Job";
            mnuAddCopyJob.Click += mnuAddCopyJob_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(161, 6);
            // 
            // mnuSelectAll
            // 
            mnuSelectAll.Name = "mnuSelectAll";
            mnuSelectAll.ShortcutKeys = Keys.Control | Keys.A;
            mnuSelectAll.Size = new Size(164, 22);
            mnuSelectAll.Text = "Select All";
            mnuSelectAll.Click += mnuSelectAll_Click;
            // 
            // mnuClearAll
            // 
            mnuClearAll.Name = "mnuClearAll";
            mnuClearAll.Size = new Size(164, 22);
            mnuClearAll.Text = "Clear All";
            mnuClearAll.Click += mnuClearAll_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(161, 6);
            // 
            // mnuEditJob
            // 
            mnuEditJob.Image = (Image)resources.GetObject("mnuEditJob.Image");
            mnuEditJob.Name = "mnuEditJob";
            mnuEditJob.Size = new Size(164, 22);
            mnuEditJob.Text = "Edit Job";
            mnuEditJob.Click += mnuEditJob_Click;
            // 
            // mnuDeleteJob
            // 
            mnuDeleteJob.Image = (Image)resources.GetObject("mnuDeleteJob.Image");
            mnuDeleteJob.Name = "mnuDeleteJob";
            mnuDeleteJob.Size = new Size(164, 22);
            mnuDeleteJob.Text = "Delete Job";
            mnuDeleteJob.Click += mnuDeleteJob_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(161, 6);
            // 
            // mnuStartJobs
            // 
            mnuStartJobs.Image = (Image)resources.GetObject("mnuStartJobs.Image");
            mnuStartJobs.Name = "mnuStartJobs";
            mnuStartJobs.ShortcutKeys = Keys.Control | Keys.J;
            mnuStartJobs.Size = new Size(164, 22);
            mnuStartJobs.Text = "Start Jobs";
            mnuStartJobs.Click += mnuStartJobs_Click;
            // 
            // mnuWizards
            // 
            mnuWizards.DropDownItems.AddRange(new ToolStripItem[] { mnuCreateBackupScript });
            mnuWizards.Name = "mnuWizards";
            mnuWizards.Size = new Size(60, 20);
            mnuWizards.Text = "Wizards";
            // 
            // mnuCreateBackupScript
            // 
            mnuCreateBackupScript.Image = (Image)resources.GetObject("mnuCreateBackupScript.Image");
            mnuCreateBackupScript.Name = "mnuCreateBackupScript";
            mnuCreateBackupScript.Size = new Size(183, 22);
            mnuCreateBackupScript.Text = "Create Backup Script";
            mnuCreateBackupScript.Click += mnuCreateBackupScript_Click;
            // 
            // mnuTools
            // 
            mnuTools.DropDownItems.AddRange(new ToolStripItem[] { mnuSystemLog, mnuLogin, toolStripSeparator8, mnuOptions });
            mnuTools.Name = "mnuTools";
            mnuTools.Size = new Size(46, 20);
            mnuTools.Text = "Tools";
            // 
            // mnuSystemLog
            // 
            mnuSystemLog.Image = (Image)resources.GetObject("mnuSystemLog.Image");
            mnuSystemLog.Name = "mnuSystemLog";
            mnuSystemLog.Size = new Size(135, 22);
            mnuSystemLog.Text = "System Log";
            mnuSystemLog.Click += mnuSystemLog_Click;
            // 
            // mnuLogin
            // 
            mnuLogin.Image = (Image)resources.GetObject("mnuLogin.Image");
            mnuLogin.Name = "mnuLogin";
            mnuLogin.Size = new Size(135, 22);
            mnuLogin.Text = "Login";
            mnuLogin.Click += mnuLogin_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(132, 6);
            // 
            // mnuOptions
            // 
            mnuOptions.Name = "mnuOptions";
            mnuOptions.Size = new Size(135, 22);
            mnuOptions.Text = "Options";
            mnuOptions.Click += mnuOptions_Click;
            // 
            // mnuHelp
            // 
            mnuHelp.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            mnuHelp.Name = "mnuHelp";
            mnuHelp.Size = new Size(44, 20);
            mnuHelp.Text = "Help";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(107, 22);
            mnuAbout.Text = "About";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // tbrMain
            // 
            tbrMain.GripStyle = ToolStripGripStyle.Hidden;
            tbrMain.ImageScalingSize = new Size(20, 20);
            tbrMain.Items.AddRange(new ToolStripItem[] { tsbOpen, tsbSave, toolStripSeparator1, tsbAddBackupJob, tsbAddRestoreJob, tsbAddShrinkJob, tsbAddCopyJob, tsbEditJob, tsbDeleteJob, tsbStartJobs, toolStripSeparator4, tsbBackupScript, toolStripSeparator7, tsbSystemLog, tsbLogin });
            tbrMain.Location = new Point(0, 24);
            tbrMain.Name = "tbrMain";
            tbrMain.Size = new Size(924, 27);
            tbrMain.TabIndex = 1;
            tbrMain.Text = "Main Toolbar";
            // 
            // tsbOpen
            // 
            tsbOpen.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbOpen.Image = (Image)resources.GetObject("tsbOpen.Image");
            tsbOpen.ImageTransparentColor = Color.Magenta;
            tsbOpen.Name = "tsbOpen";
            tsbOpen.Size = new Size(24, 24);
            tsbOpen.Text = "Open";
            tsbOpen.Click += tsbOpen_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(24, 24);
            tsbSave.Text = "Save";
            tsbSave.Click += tsbSave_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 27);
            // 
            // tsbAddBackupJob
            // 
            tsbAddBackupJob.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddBackupJob.Image = (Image)resources.GetObject("tsbAddBackupJob.Image");
            tsbAddBackupJob.ImageTransparentColor = Color.Magenta;
            tsbAddBackupJob.Name = "tsbAddBackupJob";
            tsbAddBackupJob.Size = new Size(24, 24);
            tsbAddBackupJob.Text = "Add Backup Job";
            tsbAddBackupJob.Click += tsbAddBackupJob_Click;
            // 
            // tsbAddRestoreJob
            // 
            tsbAddRestoreJob.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddRestoreJob.Image = (Image)resources.GetObject("tsbAddRestoreJob.Image");
            tsbAddRestoreJob.ImageTransparentColor = Color.Magenta;
            tsbAddRestoreJob.Name = "tsbAddRestoreJob";
            tsbAddRestoreJob.Size = new Size(24, 24);
            tsbAddRestoreJob.Text = "Add Restore Job";
            tsbAddRestoreJob.Click += tsbAddRestoreJob_Click;
            // 
            // tsbAddShrinkJob
            // 
            tsbAddShrinkJob.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddShrinkJob.Image = (Image)resources.GetObject("tsbAddShrinkJob.Image");
            tsbAddShrinkJob.ImageTransparentColor = Color.Magenta;
            tsbAddShrinkJob.Name = "tsbAddShrinkJob";
            tsbAddShrinkJob.Size = new Size(24, 24);
            tsbAddShrinkJob.Text = "Add Shrink Job";
            tsbAddShrinkJob.Click += tsbAddShrinkJob_Click;
            // 
            // tsbAddCopyJob
            // 
            tsbAddCopyJob.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbAddCopyJob.Image = (Image)resources.GetObject("tsbAddCopyJob.Image");
            tsbAddCopyJob.ImageTransparentColor = Color.Magenta;
            tsbAddCopyJob.Name = "tsbAddCopyJob";
            tsbAddCopyJob.Size = new Size(24, 24);
            tsbAddCopyJob.Text = "Add Copy Job";
            tsbAddCopyJob.Click += tsbAddCopyJob_Click;
            // 
            // tsbEditJob
            // 
            tsbEditJob.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbEditJob.Image = (Image)resources.GetObject("tsbEditJob.Image");
            tsbEditJob.ImageTransparentColor = Color.Magenta;
            tsbEditJob.Name = "tsbEditJob";
            tsbEditJob.Size = new Size(24, 24);
            tsbEditJob.Text = "Edit Job";
            tsbEditJob.Click += tsbEditJob_Click;
            // 
            // tsbDeleteJob
            // 
            tsbDeleteJob.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbDeleteJob.Image = (Image)resources.GetObject("tsbDeleteJob.Image");
            tsbDeleteJob.ImageTransparentColor = Color.Magenta;
            tsbDeleteJob.Name = "tsbDeleteJob";
            tsbDeleteJob.Size = new Size(24, 24);
            tsbDeleteJob.Text = "Delete Job";
            tsbDeleteJob.Click += tsbDeleteJob_Click;
            // 
            // tsbStartJobs
            // 
            tsbStartJobs.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbStartJobs.Image = (Image)resources.GetObject("tsbStartJobs.Image");
            tsbStartJobs.ImageTransparentColor = Color.Magenta;
            tsbStartJobs.Name = "tsbStartJobs";
            tsbStartJobs.Size = new Size(24, 24);
            tsbStartJobs.Text = "Start Jobs";
            tsbStartJobs.Click += tsbStartJobs_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 27);
            // 
            // tsbBackupScript
            // 
            tsbBackupScript.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbBackupScript.Image = (Image)resources.GetObject("tsbBackupScript.Image");
            tsbBackupScript.ImageTransparentColor = Color.Magenta;
            tsbBackupScript.Name = "tsbBackupScript";
            tsbBackupScript.Size = new Size(24, 24);
            tsbBackupScript.Text = "Create Backup Script";
            tsbBackupScript.Click += tsbBackupScript_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 27);
            // 
            // tsbSystemLog
            // 
            tsbSystemLog.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbSystemLog.Image = (Image)resources.GetObject("tsbSystemLog.Image");
            tsbSystemLog.ImageTransparentColor = Color.Magenta;
            tsbSystemLog.Name = "tsbSystemLog";
            tsbSystemLog.Size = new Size(24, 24);
            tsbSystemLog.Text = "System Log";
            tsbSystemLog.Click += tsbSystemLog_Click;
            // 
            // tsbLogin
            // 
            tsbLogin.DisplayStyle = ToolStripItemDisplayStyle.Image;
            tsbLogin.Image = (Image)resources.GetObject("tsbLogin.Image");
            tsbLogin.ImageTransparentColor = Color.Magenta;
            tsbLogin.Name = "tsbLogin";
            tsbLogin.Size = new Size(24, 24);
            tsbLogin.Text = "Login";
            tsbLogin.Click += tsbLogin_Click;
            // 
            // sbrMain
            // 
            sbrMain.ImageScalingSize = new Size(20, 20);
            sbrMain.Items.AddRange(new ToolStripItem[] { lblCancel, lblStatus, pbrMain, lblServer });
            sbrMain.Location = new Point(0, 633);
            sbrMain.Name = "sbrMain";
            sbrMain.Padding = new Padding(1, 0, 17, 0);
            sbrMain.Size = new Size(924, 28);
            sbrMain.TabIndex = 2;
            // 
            // lblCancel
            // 
            lblCancel.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblCancel.BorderStyle = Border3DStyle.Raised;
            lblCancel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblCancel.IsLink = true;
            lblCancel.LinkBehavior = LinkBehavior.NeverUnderline;
            lblCancel.LinkColor = Color.Black;
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size(47, 23);
            lblCancel.Text = "Cancel";
            lblCancel.Click += lblCancel_Click;
            // 
            // lblStatus
            // 
            lblStatus.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblStatus.BorderStyle = Border3DStyle.SunkenOuter;
            lblStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(737, 23);
            lblStatus.Spring = true;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pbrMain
            // 
            pbrMain.Name = "pbrMain";
            pbrMain.Size = new Size(116, 22);
            // 
            // lblServer
            // 
            lblServer.BorderSides = ToolStripStatusLabelBorderSides.Left | ToolStripStatusLabelBorderSides.Top | ToolStripStatusLabelBorderSides.Right | ToolStripStatusLabelBorderSides.Bottom;
            lblServer.BorderStyle = Border3DStyle.SunkenOuter;
            lblServer.DisplayStyle = ToolStripItemDisplayStyle.Text;
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(4, 23);
            // 
            // lvwMain
            // 
            lvwMain.AllowDrop = true;
            lvwMain.Columns.AddRange(new ColumnHeader[] { colDatabase, colJobType, colTask, colPath, colDetails });
            lvwMain.Dock = DockStyle.Fill;
            lvwMain.Location = new Point(0, 51);
            lvwMain.Margin = new Padding(4);
            lvwMain.Name = "lvwMain";
            lvwMain.Size = new Size(924, 582);
            lvwMain.SmallImageList = imlSmall;
            lvwMain.TabIndex = 3;
            lvwMain.UseCompatibleStateImageBehavior = false;
            lvwMain.View = View.Details;
            lvwMain.ItemDrag += lvwMain_ItemDrag;
            lvwMain.DragDrop += lvwMain_DragDrop;
            lvwMain.DragEnter += lvwMain_DragEnter;
            lvwMain.KeyDown += lvwMain_KeyDown;
            lvwMain.MouseDoubleClick += lvwMain_MouseDoubleClick;
            // 
            // colDatabase
            // 
            colDatabase.Text = "Database";
            colDatabase.Width = 200;
            // 
            // colJobType
            // 
            colJobType.Text = "Job Type";
            colJobType.Width = 100;
            // 
            // colTask
            // 
            colTask.Text = "Task";
            colTask.Width = 125;
            // 
            // colPath
            // 
            colPath.Text = "Path";
            colPath.Width = 600;
            // 
            // colDetails
            // 
            colDetails.Text = "Details";
            colDetails.Width = 400;
            // 
            // imlSmall
            // 
            imlSmall.ColorDepth = ColorDepth.Depth16Bit;
            imlSmall.ImageStream = (ImageListStreamer)resources.GetObject("imlSmall.ImageStream");
            imlSmall.TransparentColor = Color.Transparent;
            imlSmall.Images.SetKeyName(0, "Job");
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(924, 661);
            Controls.Add(lvwMain);
            Controls.Add(sbrMain);
            Controls.Add(tbrMain);
            Controls.Add(mnuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuMain;
            Margin = new Padding(4);
            Name = "frmMain";
            Text = "Database Tools";
            WindowState = FormWindowState.Maximized;
            FormClosing += frmMain_FormClosing;
            FormClosed += frmMain_FormClosed;
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            tbrMain.ResumeLayout(false);
            tbrMain.PerformLayout();
            sbrMain.ResumeLayout(false);
            sbrMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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

