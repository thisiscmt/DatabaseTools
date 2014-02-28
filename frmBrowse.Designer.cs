namespace DBTools
{
    partial class frmBrowse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrowse));
            this.lblFileName = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.tvwMain = new System.Windows.Forms.TreeView();
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(6, 330);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(58, 16);
            this.lblFileName.TabIndex = 7;
            this.lblFileName.Text = "File name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(69, 327);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(339, 20);
            this.txtFileName.TabIndex = 8;
            // 
            // tvwMain
            // 
            this.tvwMain.ImageIndex = 0;
            this.tvwMain.ImageList = this.imlSmall;
            this.tvwMain.Location = new System.Drawing.Point(4, 5);
            this.tvwMain.Name = "tvwMain";
            this.tvwMain.SelectedImageIndex = 0;
            this.tvwMain.Size = new System.Drawing.Size(404, 288);
            this.tvwMain.TabIndex = 11;
            this.tvwMain.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwMain_AfterSelect);
            this.tvwMain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tvwMain_KeyDown);
            this.tvwMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tvwMain_MouseDoubleClick);
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "FolderClosed");
            this.imlSmall.Images.SetKeyName(1, "FolderOpen");
            this.imlSmall.Images.SetKeyName(2, "File");
            this.imlSmall.Images.SetKeyName(3, "FolderOpenOld");
            this.imlSmall.Images.SetKeyName(4, "FileOld");
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(336, 353);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(72, 24);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(258, 353);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(72, 24);
            this.cmdOK.TabIndex = 9;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.Location = new System.Drawing.Point(6, 304);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(32, 16);
            this.lblFolder.TabIndex = 12;
            this.lblFolder.Text = "Path:";
            // 
            // txtFolder
            // 
            this.txtFolder.Location = new System.Drawing.Point(69, 301);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(339, 20);
            this.txtFolder.TabIndex = 14;
            // 
            // frmBrowse
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(413, 382);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.tvwMain);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lblFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBrowse";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Browse";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBrowse_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label lblFileName;
        internal System.Windows.Forms.TextBox txtFileName;
        internal System.Windows.Forms.TreeView tvwMain;
        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;
        internal System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.TextBox txtFolder;
    }
}