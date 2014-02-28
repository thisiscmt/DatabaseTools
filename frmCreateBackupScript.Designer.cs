namespace DBTools
{
    partial class frmCreateBackupScript
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateBackupScript));
            this.panSelectDB = new System.Windows.Forms.Panel();
            this.lblDatabases = new System.Windows.Forms.Label();
            this.cmdClearAll = new System.Windows.Forms.Button();
            this.cmdSelectAll = new System.Windows.Forms.Button();
            this.lvwDatabases = new System.Windows.Forms.ListView();
            this.colDatabase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDBOwner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.panPaths = new System.Windows.Forms.Panel();
            this.cmdBrowseScriptPath = new System.Windows.Forms.Button();
            this.txtScriptFilePath = new System.Windows.Forms.TextBox();
            this.lblScriptFilePath = new System.Windows.Forms.Label();
            this.cmdBrowseBackupPath = new System.Windows.Forms.Button();
            this.txtBackupDir = new System.Windows.Forms.TextBox();
            this.lblBackupDir = new System.Windows.Forms.Label();
            this.panHeader.SuspendLayout();
            this.panMsg.SuspendLayout();
            this.panMain.SuspendLayout();
            this.panSelectDB.SuspendLayout();
            this.panPaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdBack
            // 
            this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
            // 
            // cmdNext
            // 
            this.cmdNext.Click += new System.EventHandler(this.cmdNext_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panPaths);
            this.panMain.Controls.Add(this.panSelectDB);
            this.panMain.TabIndex = 1;
            this.panMain.Controls.SetChildIndex(this.panSelectDB, 0);
            this.panMain.Controls.SetChildIndex(this.panPaths, 0);
            this.panMain.Controls.SetChildIndex(this.panMsg, 0);
            // 
            // panSelectDB
            // 
            this.panSelectDB.Controls.Add(this.lblDatabases);
            this.panSelectDB.Controls.Add(this.cmdClearAll);
            this.panSelectDB.Controls.Add(this.cmdSelectAll);
            this.panSelectDB.Controls.Add(this.lvwDatabases);
            this.panSelectDB.Location = new System.Drawing.Point(8, 3);
            this.panSelectDB.Name = "panSelectDB";
            this.panSelectDB.Size = new System.Drawing.Size(528, 212);
            this.panSelectDB.TabIndex = 0;
            // 
            // lblDatabases
            // 
            this.lblDatabases.AutoSize = true;
            this.lblDatabases.Location = new System.Drawing.Point(16, 15);
            this.lblDatabases.Name = "lblDatabases";
            this.lblDatabases.Size = new System.Drawing.Size(58, 13);
            this.lblDatabases.TabIndex = 0;
            this.lblDatabases.Text = "Databases";
            // 
            // cmdClearAll
            // 
            this.cmdClearAll.Location = new System.Drawing.Point(431, 60);
            this.cmdClearAll.Name = "cmdClearAll";
            this.cmdClearAll.Size = new System.Drawing.Size(75, 23);
            this.cmdClearAll.TabIndex = 3;
            this.cmdClearAll.Text = "Clear All";
            this.cmdClearAll.UseVisualStyleBackColor = true;
            this.cmdClearAll.Click += new System.EventHandler(this.cmdClearAll_Click);
            // 
            // cmdSelectAll
            // 
            this.cmdSelectAll.Location = new System.Drawing.Point(431, 31);
            this.cmdSelectAll.Name = "cmdSelectAll";
            this.cmdSelectAll.Size = new System.Drawing.Size(75, 23);
            this.cmdSelectAll.TabIndex = 2;
            this.cmdSelectAll.Text = "Select All";
            this.cmdSelectAll.UseVisualStyleBackColor = true;
            this.cmdSelectAll.Click += new System.EventHandler(this.cmdSelectAll_Click);
            // 
            // lvwDatabases
            // 
            this.lvwDatabases.CheckBoxes = true;
            this.lvwDatabases.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDatabase,
            this.colDBOwner});
            this.lvwDatabases.Location = new System.Drawing.Point(19, 31);
            this.lvwDatabases.Name = "lvwDatabases";
            this.lvwDatabases.Size = new System.Drawing.Size(397, 157);
            this.lvwDatabases.SmallImageList = this.imlSmall;
            this.lvwDatabases.TabIndex = 1;
            this.lvwDatabases.UseCompatibleStateImageBehavior = false;
            this.lvwDatabases.View = System.Windows.Forms.View.Details;
            // 
            // colDatabase
            // 
            this.colDatabase.Text = "Database";
            this.colDatabase.Width = 225;
            // 
            // colDBOwner
            // 
            this.colDBOwner.Text = "Owner";
            this.colDBOwner.Width = 150;
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "Database");
            // 
            // panPaths
            // 
            this.panPaths.Controls.Add(this.cmdBrowseScriptPath);
            this.panPaths.Controls.Add(this.txtScriptFilePath);
            this.panPaths.Controls.Add(this.lblScriptFilePath);
            this.panPaths.Controls.Add(this.cmdBrowseBackupPath);
            this.panPaths.Controls.Add(this.txtBackupDir);
            this.panPaths.Controls.Add(this.lblBackupDir);
            this.panPaths.Location = new System.Drawing.Point(8, 3);
            this.panPaths.Name = "panPaths";
            this.panPaths.Size = new System.Drawing.Size(528, 212);
            this.panPaths.TabIndex = 1;
            // 
            // cmdBrowseScriptPath
            // 
            this.cmdBrowseScriptPath.Location = new System.Drawing.Point(466, 96);
            this.cmdBrowseScriptPath.Name = "cmdBrowseScriptPath";
            this.cmdBrowseScriptPath.Size = new System.Drawing.Size(24, 20);
            this.cmdBrowseScriptPath.TabIndex = 5;
            this.cmdBrowseScriptPath.Text = "...";
            this.cmdBrowseScriptPath.UseVisualStyleBackColor = true;
            this.cmdBrowseScriptPath.Click += new System.EventHandler(this.cmdBrowseScriptPath_Click);
            // 
            // txtScriptFilePath
            // 
            this.txtScriptFilePath.Location = new System.Drawing.Point(128, 96);
            this.txtScriptFilePath.Name = "txtScriptFilePath";
            this.txtScriptFilePath.Size = new System.Drawing.Size(335, 20);
            this.txtScriptFilePath.TabIndex = 4;
            // 
            // lblScriptFilePath
            // 
            this.lblScriptFilePath.AutoSize = true;
            this.lblScriptFilePath.Location = new System.Drawing.Point(32, 99);
            this.lblScriptFilePath.Name = "lblScriptFilePath";
            this.lblScriptFilePath.Size = new System.Drawing.Size(77, 13);
            this.lblScriptFilePath.TabIndex = 3;
            this.lblScriptFilePath.Text = "Script file path:";
            // 
            // cmdBrowseBackupPath
            // 
            this.cmdBrowseBackupPath.Location = new System.Drawing.Point(466, 55);
            this.cmdBrowseBackupPath.Name = "cmdBrowseBackupPath";
            this.cmdBrowseBackupPath.Size = new System.Drawing.Size(24, 20);
            this.cmdBrowseBackupPath.TabIndex = 2;
            this.cmdBrowseBackupPath.Text = "...";
            this.cmdBrowseBackupPath.UseVisualStyleBackColor = true;
            this.cmdBrowseBackupPath.Click += new System.EventHandler(this.cmdBrowseBackupPath_Click);
            // 
            // txtBackupDir
            // 
            this.txtBackupDir.Location = new System.Drawing.Point(128, 55);
            this.txtBackupDir.Name = "txtBackupDir";
            this.txtBackupDir.Size = new System.Drawing.Size(335, 20);
            this.txtBackupDir.TabIndex = 1;
            // 
            // lblBackupDir
            // 
            this.lblBackupDir.AutoSize = true;
            this.lblBackupDir.Location = new System.Drawing.Point(32, 58);
            this.lblBackupDir.Name = "lblBackupDir";
            this.lblBackupDir.Size = new System.Drawing.Size(90, 13);
            this.lblBackupDir.TabIndex = 0;
            this.lblBackupDir.Text = "Backup directory:";
            // 
            // frmCreateBackupScript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 336);
            this.Name = "frmCreateBackupScript";
            this.Text = "Create Backup Script Wizard";
            this.panHeader.ResumeLayout(false);
            this.panMsg.ResumeLayout(false);
            this.panMain.ResumeLayout(false);
            this.panSelectDB.ResumeLayout(false);
            this.panSelectDB.PerformLayout();
            this.panPaths.ResumeLayout(false);
            this.panPaths.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panSelectDB;
        private System.Windows.Forms.Label lblDatabases;
        private System.Windows.Forms.Button cmdClearAll;
        private System.Windows.Forms.Button cmdSelectAll;
        private System.Windows.Forms.ListView lvwDatabases;
        private System.Windows.Forms.ImageList imlSmall;
        private System.Windows.Forms.ColumnHeader colDatabase;
        private System.Windows.Forms.ColumnHeader colDBOwner;
        private System.Windows.Forms.Panel panPaths;
        private System.Windows.Forms.Button cmdBrowseScriptPath;
        private System.Windows.Forms.TextBox txtScriptFilePath;
        private System.Windows.Forms.Label lblScriptFilePath;
        private System.Windows.Forms.Button cmdBrowseBackupPath;
        private System.Windows.Forms.TextBox txtBackupDir;
        private System.Windows.Forms.Label lblBackupDir;

    }
}