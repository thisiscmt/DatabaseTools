namespace DBTools
{
    partial class frmRestoreJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRestoreJob));
            this.fraMain = new System.Windows.Forms.GroupBox();
            this.lblExt = new System.Windows.Forms.Label();
            this.txtExt = new System.Windows.Forms.TextBox();
            this.chkClearUsers = new System.Windows.Forms.CheckBox();
            this.cmbRestoreTask = new System.Windows.Forms.ComboBox();
            this.lblRestoreTask = new System.Windows.Forms.Label();
            this.lvwContents = new System.Windows.Forms.ListView();
            this.Database = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DBSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateOfBackup = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Server = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imlSmall = new System.Windows.Forms.ImageList(this.components);
            this.txtRestoreFrom = new System.Windows.Forms.TextBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblRestoreFrom = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.fraMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraMain
            // 
            this.fraMain.BackColor = System.Drawing.SystemColors.Control;
            this.fraMain.Controls.Add(this.lblExt);
            this.fraMain.Controls.Add(this.txtExt);
            this.fraMain.Controls.Add(this.chkClearUsers);
            this.fraMain.Controls.Add(this.cmbRestoreTask);
            this.fraMain.Controls.Add(this.lblRestoreTask);
            this.fraMain.Controls.Add(this.lvwContents);
            this.fraMain.Controls.Add(this.txtRestoreFrom);
            this.fraMain.Controls.Add(this.cmbDatabase);
            this.fraMain.Controls.Add(this.cmdBrowse);
            this.fraMain.Controls.Add(this.lblDatabase);
            this.fraMain.Controls.Add(this.lblRestoreFrom);
            this.fraMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraMain.Location = new System.Drawing.Point(5, 2);
            this.fraMain.Name = "fraMain";
            this.fraMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraMain.Size = new System.Drawing.Size(485, 214);
            this.fraMain.TabIndex = 4;
            this.fraMain.TabStop = false;
            this.fraMain.Text = "Restore Information";
            // 
            // lblExt
            // 
            this.lblExt.Location = new System.Drawing.Point(356, 55);
            this.lblExt.Name = "lblExt";
            this.lblExt.Size = new System.Drawing.Size(57, 13);
            this.lblExt.TabIndex = 6;
            this.lblExt.Text = "Extension:";
            // 
            // txtExt
            // 
            this.txtExt.Location = new System.Drawing.Point(415, 52);
            this.txtExt.Name = "txtExt";
            this.txtExt.Size = new System.Drawing.Size(44, 20);
            this.txtExt.TabIndex = 7;
            // 
            // chkClearUsers
            // 
            this.chkClearUsers.AutoSize = true;
            this.chkClearUsers.Location = new System.Drawing.Point(287, 22);
            this.chkClearUsers.Name = "chkClearUsers";
            this.chkClearUsers.Size = new System.Drawing.Size(137, 17);
            this.chkClearUsers.TabIndex = 2;
            this.chkClearUsers.Text = "Clear users after restore";
            this.chkClearUsers.UseVisualStyleBackColor = true;
            // 
            // cmbRestoreTask
            // 
            this.cmbRestoreTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRestoreTask.FormattingEnabled = true;
            this.cmbRestoreTask.Location = new System.Drawing.Point(86, 19);
            this.cmbRestoreTask.Name = "cmbRestoreTask";
            this.cmbRestoreTask.Size = new System.Drawing.Size(184, 21);
            this.cmbRestoreTask.TabIndex = 1;
            this.cmbRestoreTask.SelectedIndexChanged += new System.EventHandler(this.cmbRestoreTask_SelectedIndexChanged);
            // 
            // lblRestoreTask
            // 
            this.lblRestoreTask.AutoSize = true;
            this.lblRestoreTask.Location = new System.Drawing.Point(10, 22);
            this.lblRestoreTask.Name = "lblRestoreTask";
            this.lblRestoreTask.Size = new System.Drawing.Size(70, 13);
            this.lblRestoreTask.TabIndex = 0;
            this.lblRestoreTask.Text = "Restore task:";
            // 
            // lvwContents
            // 
            this.lvwContents.CheckBoxes = true;
            this.lvwContents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Database,
            this.DBSize,
            this.DateOfBackup,
            this.Server});
            this.lvwContents.Location = new System.Drawing.Point(8, 115);
            this.lvwContents.Name = "lvwContents";
            this.lvwContents.Size = new System.Drawing.Size(469, 89);
            this.lvwContents.SmallImageList = this.imlSmall;
            this.lvwContents.TabIndex = 11;
            this.lvwContents.UseCompatibleStateImageBehavior = false;
            this.lvwContents.View = System.Windows.Forms.View.Details;
            this.lvwContents.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvwContents_ItemCheck);
            // 
            // Database
            // 
            this.Database.Text = "Database";
            this.Database.Width = 155;
            // 
            // DBSize
            // 
            this.DBSize.Text = "Size";
            this.DBSize.Width = 65;
            // 
            // DateOfBackup
            // 
            this.DateOfBackup.Text = "Date of Backup";
            this.DateOfBackup.Width = 135;
            // 
            // Server
            // 
            this.Server.Text = "Server";
            this.Server.Width = 105;
            // 
            // imlSmall
            // 
            this.imlSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlSmall.ImageStream")));
            this.imlSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imlSmall.Images.SetKeyName(0, "Database");
            // 
            // txtRestoreFrom
            // 
            this.txtRestoreFrom.AcceptsReturn = true;
            this.txtRestoreFrom.BackColor = System.Drawing.SystemColors.Window;
            this.txtRestoreFrom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRestoreFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestoreFrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRestoreFrom.Location = new System.Drawing.Point(86, 83);
            this.txtRestoreFrom.MaxLength = 0;
            this.txtRestoreFrom.Name = "txtRestoreFrom";
            this.txtRestoreFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtRestoreFrom.Size = new System.Drawing.Size(361, 20);
            this.txtRestoreFrom.TabIndex = 9;
            this.txtRestoreFrom.Leave += new System.EventHandler(this.txtRestoreFrom_Leave);
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDatabase.Location = new System.Drawing.Point(86, 51);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDatabase.Size = new System.Drawing.Size(263, 21);
            this.cmbDatabase.TabIndex = 5;
            this.cmbDatabase.DropDown += new System.EventHandler(this.cmbDatabase_DropDown);
            this.cmbDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDatabase_KeyDown);
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdBrowse.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdBrowse.Location = new System.Drawing.Point(453, 83);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdBrowse.Size = new System.Drawing.Size(24, 20);
            this.cmdBrowse.TabIndex = 10;
            this.cmdBrowse.Text = "...";
            this.cmdBrowse.UseVisualStyleBackColor = false;
            this.cmdBrowse.Click += new System.EventHandler(this.cmdBrowse_Click);
            // 
            // lblDatabase
            // 
            this.lblDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.lblDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDatabase.Location = new System.Drawing.Point(10, 54);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDatabase.Size = new System.Drawing.Size(65, 13);
            this.lblDatabase.TabIndex = 4;
            this.lblDatabase.Text = "Database:";
            // 
            // lblRestoreFrom
            // 
            this.lblRestoreFrom.AutoSize = true;
            this.lblRestoreFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblRestoreFrom.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRestoreFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRestoreFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRestoreFrom.Location = new System.Drawing.Point(10, 86);
            this.lblRestoreFrom.Name = "lblRestoreFrom";
            this.lblRestoreFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRestoreFrom.Size = new System.Drawing.Size(73, 13);
            this.lblRestoreFrom.TabIndex = 8;
            this.lblRestoreFrom.Text = "Restore From:";
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOK.Location = new System.Drawing.Point(340, 222);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOK.Size = new System.Drawing.Size(72, 24);
            this.cmdOK.TabIndex = 6;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Location = new System.Drawing.Point(418, 222);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdCancel.Size = new System.Drawing.Size(72, 24);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkUpdate
            // 
            this.chkUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUpdate.Location = new System.Drawing.Point(5, 227);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUpdate.Size = new System.Drawing.Size(160, 17);
            this.chkUpdate.TabIndex = 5;
            this.chkUpdate.Text = "&Close dialog after update";
            this.chkUpdate.UseVisualStyleBackColor = false;
            // 
            // frmRestoreJob
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 251);
            this.Controls.Add(this.fraMain);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.chkUpdate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRestoreJob";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.fraMain.ResumeLayout(false);
            this.fraMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox fraMain;
        internal System.Windows.Forms.Label lblExt;
        internal System.Windows.Forms.TextBox txtExt;
        internal System.Windows.Forms.CheckBox chkClearUsers;
        internal System.Windows.Forms.ComboBox cmbRestoreTask;
        internal System.Windows.Forms.Label lblRestoreTask;
        internal System.Windows.Forms.ListView lvwContents;
        internal System.Windows.Forms.ColumnHeader Database;
        internal System.Windows.Forms.ColumnHeader DBSize;
        internal System.Windows.Forms.ColumnHeader DateOfBackup;
        internal System.Windows.Forms.ColumnHeader Server;
        public System.Windows.Forms.TextBox txtRestoreFrom;
        public System.Windows.Forms.ComboBox cmbDatabase;
        public System.Windows.Forms.Button cmdBrowse;
        public System.Windows.Forms.Label lblDatabase;
        public System.Windows.Forms.Label lblRestoreFrom;
        public System.Windows.Forms.Button cmdOK;
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.CheckBox chkUpdate;
        private System.Windows.Forms.ImageList imlSmall;
    }
}