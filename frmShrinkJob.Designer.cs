namespace DBTools
{
    partial class frmShrinkJob
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
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.fraMain = new System.Windows.Forms.GroupBox();
            this.chkUpdateIndexes = new System.Windows.Forms.CheckBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.cmbShrinkTask = new System.Windows.Forms.ComboBox();
            this.lblShrinkTask = new System.Windows.Forms.Label();
            this.chkShrinkFile = new System.Windows.Forms.CheckBox();
            this.chkSetToSimple = new System.Windows.Forms.CheckBox();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.fraFileDetails = new System.Windows.Forms.GroupBox();
            this.cmbDiskFile = new System.Windows.Forms.ComboBox();
            this.lblFreeSpace = new System.Windows.Forms.Label();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblFileType = new System.Windows.Forms.Label();
            this.lblFileGroup = new System.Windows.Forms.Label();
            this.lblFreeSpaceL = new System.Windows.Forms.Label();
            this.lblSizeL = new System.Windows.Forms.Label();
            this.lblFileTypeL = new System.Windows.Forms.Label();
            this.lblFilegroupL = new System.Windows.Forms.Label();
            this.lblDiskFile = new System.Windows.Forms.Label();
            this.lblRecoveryModel = new System.Windows.Forms.Label();
            this.lblRecoveryModelL = new System.Windows.Forms.Label();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.fraMain.SuspendLayout();
            this.fraFileDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkUpdate
            // 
            this.chkUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUpdate.Location = new System.Drawing.Point(5, 312);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUpdate.Size = new System.Drawing.Size(169, 17);
            this.chkUpdate.TabIndex = 1;
            this.chkUpdate.Text = "&Close dialog after update?";
            this.chkUpdate.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Location = new System.Drawing.Point(334, 307);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdCancel.Size = new System.Drawing.Size(74, 24);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOK.Location = new System.Drawing.Point(256, 307);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOK.Size = new System.Drawing.Size(72, 24);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // fraMain
            // 
            this.fraMain.BackColor = System.Drawing.SystemColors.Control;
            this.fraMain.Controls.Add(this.chkUpdateIndexes);
            this.fraMain.Controls.Add(this.lblNote);
            this.fraMain.Controls.Add(this.cmbShrinkTask);
            this.fraMain.Controls.Add(this.lblShrinkTask);
            this.fraMain.Controls.Add(this.chkShrinkFile);
            this.fraMain.Controls.Add(this.chkSetToSimple);
            this.fraMain.Controls.Add(this.cmbDatabase);
            this.fraMain.Controls.Add(this.fraFileDetails);
            this.fraMain.Controls.Add(this.lblRecoveryModel);
            this.fraMain.Controls.Add(this.lblRecoveryModelL);
            this.fraMain.Controls.Add(this.lblDatabase);
            this.fraMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraMain.Location = new System.Drawing.Point(5, 2);
            this.fraMain.Name = "fraMain";
            this.fraMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraMain.Size = new System.Drawing.Size(403, 299);
            this.fraMain.TabIndex = 0;
            this.fraMain.TabStop = false;
            this.fraMain.Text = "Shrink Information";
            // 
            // chkUpdateIndexes
            // 
            this.chkUpdateIndexes.AutoSize = true;
            this.chkUpdateIndexes.BackColor = System.Drawing.SystemColors.Control;
            this.chkUpdateIndexes.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkUpdateIndexes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdateIndexes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUpdateIndexes.Location = new System.Drawing.Point(223, 102);
            this.chkUpdateIndexes.Name = "chkUpdateIndexes";
            this.chkUpdateIndexes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUpdateIndexes.Size = new System.Drawing.Size(100, 17);
            this.chkUpdateIndexes.TabIndex = 7;
            this.chkUpdateIndexes.Text = "Update indexes";
            this.chkUpdateIndexes.UseVisualStyleBackColor = false;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(248, 24);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(146, 13);
            this.lblNote.TabIndex = 10;
            this.lblNote.Text = "Use * as a wildcard character";
            // 
            // cmbShrinkTask
            // 
            this.cmbShrinkTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShrinkTask.FormattingEnabled = true;
            this.cmbShrinkTask.Location = new System.Drawing.Point(102, 21);
            this.cmbShrinkTask.Name = "cmbShrinkTask";
            this.cmbShrinkTask.Size = new System.Drawing.Size(138, 21);
            this.cmbShrinkTask.TabIndex = 1;
            this.cmbShrinkTask.SelectedIndexChanged += new System.EventHandler(this.cmbShrinkTask_SelectedIndexChanged);
            // 
            // lblShrinkTask
            // 
            this.lblShrinkTask.AutoSize = true;
            this.lblShrinkTask.Location = new System.Drawing.Point(12, 24);
            this.lblShrinkTask.Name = "lblShrinkTask";
            this.lblShrinkTask.Size = new System.Drawing.Size(63, 13);
            this.lblShrinkTask.TabIndex = 0;
            this.lblShrinkTask.Text = "Shrink task:";
            // 
            // chkShrinkFile
            // 
            this.chkShrinkFile.AutoSize = true;
            this.chkShrinkFile.BackColor = System.Drawing.SystemColors.Control;
            this.chkShrinkFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkShrinkFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShrinkFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkShrinkFile.Location = new System.Drawing.Point(223, 122);
            this.chkShrinkFile.Name = "chkShrinkFile";
            this.chkShrinkFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkShrinkFile.Size = new System.Drawing.Size(119, 17);
            this.chkShrinkFile.TabIndex = 8;
            this.chkShrinkFile.Text = "Shrink individual file";
            this.chkShrinkFile.UseVisualStyleBackColor = false;
            this.chkShrinkFile.CheckedChanged += new System.EventHandler(this.chkShrinkFile_CheckedChanged);
            // 
            // chkSetToSimple
            // 
            this.chkSetToSimple.AutoSize = true;
            this.chkSetToSimple.BackColor = System.Drawing.SystemColors.Control;
            this.chkSetToSimple.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSetToSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSetToSimple.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSetToSimple.Location = new System.Drawing.Point(223, 82);
            this.chkSetToSimple.Name = "chkSetToSimple";
            this.chkSetToSimple.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSetToSimple.Size = new System.Drawing.Size(163, 17);
            this.chkSetToSimple.TabIndex = 6;
            this.chkSetToSimple.Text = "Set recovery model to Simple";
            this.chkSetToSimple.UseVisualStyleBackColor = false;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDatabase.Location = new System.Drawing.Point(102, 50);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDatabase.Size = new System.Drawing.Size(268, 21);
            this.cmbDatabase.TabIndex = 3;
            this.cmbDatabase.DropDown += new System.EventHandler(this.cmbDatabase_DropDown);
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            this.cmbDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDatabase_KeyDown);
            this.cmbDatabase.Leave += new System.EventHandler(this.cmbDatabase_Leave);
            // 
            // fraFileDetails
            // 
            this.fraFileDetails.BackColor = System.Drawing.SystemColors.Control;
            this.fraFileDetails.Controls.Add(this.cmbDiskFile);
            this.fraFileDetails.Controls.Add(this.lblFreeSpace);
            this.fraFileDetails.Controls.Add(this.lblSize);
            this.fraFileDetails.Controls.Add(this.lblFileType);
            this.fraFileDetails.Controls.Add(this.lblFileGroup);
            this.fraFileDetails.Controls.Add(this.lblFreeSpaceL);
            this.fraFileDetails.Controls.Add(this.lblSizeL);
            this.fraFileDetails.Controls.Add(this.lblFileTypeL);
            this.fraFileDetails.Controls.Add(this.lblFilegroupL);
            this.fraFileDetails.Controls.Add(this.lblDiskFile);
            this.fraFileDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraFileDetails.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraFileDetails.Location = new System.Drawing.Point(13, 140);
            this.fraFileDetails.Name = "fraFileDetails";
            this.fraFileDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraFileDetails.Size = new System.Drawing.Size(377, 145);
            this.fraFileDetails.TabIndex = 8;
            this.fraFileDetails.TabStop = false;
            this.fraFileDetails.Text = "File Details";
            // 
            // cmbDiskFile
            // 
            this.cmbDiskFile.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDiskFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbDiskFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDiskFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDiskFile.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDiskFile.Location = new System.Drawing.Point(119, 25);
            this.cmbDiskFile.Name = "cmbDiskFile";
            this.cmbDiskFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDiskFile.Size = new System.Drawing.Size(240, 21);
            this.cmbDiskFile.TabIndex = 1;
            this.cmbDiskFile.SelectedIndexChanged += new System.EventHandler(this.cmbDiskFile_SelectedIndexChanged);
            // 
            // lblFreeSpace
            // 
            this.lblFreeSpace.BackColor = System.Drawing.SystemColors.Control;
            this.lblFreeSpace.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFreeSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreeSpace.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFreeSpace.Location = new System.Drawing.Point(116, 116);
            this.lblFreeSpace.Name = "lblFreeSpace";
            this.lblFreeSpace.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFreeSpace.Size = new System.Drawing.Size(240, 13);
            this.lblFreeSpace.TabIndex = 9;
            // 
            // lblSize
            // 
            this.lblSize.BackColor = System.Drawing.SystemColors.Control;
            this.lblSize.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSize.Location = new System.Drawing.Point(116, 96);
            this.lblSize.Name = "lblSize";
            this.lblSize.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSize.Size = new System.Drawing.Size(240, 13);
            this.lblSize.TabIndex = 7;
            // 
            // lblFileType
            // 
            this.lblFileType.BackColor = System.Drawing.SystemColors.Control;
            this.lblFileType.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFileType.Location = new System.Drawing.Point(116, 76);
            this.lblFileType.Name = "lblFileType";
            this.lblFileType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFileType.Size = new System.Drawing.Size(240, 13);
            this.lblFileType.TabIndex = 5;
            // 
            // lblFileGroup
            // 
            this.lblFileGroup.BackColor = System.Drawing.SystemColors.Control;
            this.lblFileGroup.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileGroup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFileGroup.Location = new System.Drawing.Point(116, 56);
            this.lblFileGroup.Name = "lblFileGroup";
            this.lblFileGroup.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFileGroup.Size = new System.Drawing.Size(240, 13);
            this.lblFileGroup.TabIndex = 3;
            // 
            // lblFreeSpaceL
            // 
            this.lblFreeSpaceL.BackColor = System.Drawing.SystemColors.Control;
            this.lblFreeSpaceL.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFreeSpaceL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFreeSpaceL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFreeSpaceL.Location = new System.Drawing.Point(16, 116);
            this.lblFreeSpaceL.Name = "lblFreeSpaceL";
            this.lblFreeSpaceL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFreeSpaceL.Size = new System.Drawing.Size(96, 13);
            this.lblFreeSpaceL.TabIndex = 8;
            this.lblFreeSpaceL.Text = "Free space:";
            // 
            // lblSizeL
            // 
            this.lblSizeL.BackColor = System.Drawing.SystemColors.Control;
            this.lblSizeL.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSizeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSizeL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSizeL.Location = new System.Drawing.Point(16, 96);
            this.lblSizeL.Name = "lblSizeL";
            this.lblSizeL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSizeL.Size = new System.Drawing.Size(105, 13);
            this.lblSizeL.TabIndex = 6;
            this.lblSizeL.Text = "Current size:";
            // 
            // lblFileTypeL
            // 
            this.lblFileTypeL.BackColor = System.Drawing.SystemColors.Control;
            this.lblFileTypeL.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFileTypeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileTypeL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFileTypeL.Location = new System.Drawing.Point(16, 76);
            this.lblFileTypeL.Name = "lblFileTypeL";
            this.lblFileTypeL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFileTypeL.Size = new System.Drawing.Size(56, 13);
            this.lblFileTypeL.TabIndex = 4;
            this.lblFileTypeL.Text = "File type:";
            // 
            // lblFilegroupL
            // 
            this.lblFilegroupL.BackColor = System.Drawing.SystemColors.Control;
            this.lblFilegroupL.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFilegroupL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilegroupL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFilegroupL.Location = new System.Drawing.Point(16, 56);
            this.lblFilegroupL.Name = "lblFilegroupL";
            this.lblFilegroupL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFilegroupL.Size = new System.Drawing.Size(56, 13);
            this.lblFilegroupL.TabIndex = 2;
            this.lblFilegroupL.Text = "Filegroup:";
            // 
            // lblDiskFile
            // 
            this.lblDiskFile.BackColor = System.Drawing.SystemColors.Control;
            this.lblDiskFile.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDiskFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiskFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDiskFile.Location = new System.Drawing.Point(16, 28);
            this.lblDiskFile.Name = "lblDiskFile";
            this.lblDiskFile.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDiskFile.Size = new System.Drawing.Size(49, 13);
            this.lblDiskFile.TabIndex = 0;
            this.lblDiskFile.Text = "Disk &File:";
            // 
            // lblRecoveryModel
            // 
            this.lblRecoveryModel.BackColor = System.Drawing.SystemColors.Control;
            this.lblRecoveryModel.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRecoveryModel.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecoveryModel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRecoveryModel.Location = new System.Drawing.Point(100, 82);
            this.lblRecoveryModel.Name = "lblRecoveryModel";
            this.lblRecoveryModel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecoveryModel.Size = new System.Drawing.Size(108, 13);
            this.lblRecoveryModel.TabIndex = 5;
            this.lblRecoveryModel.Visible = false;
            // 
            // lblRecoveryModelL
            // 
            this.lblRecoveryModelL.BackColor = System.Drawing.SystemColors.Control;
            this.lblRecoveryModelL.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRecoveryModelL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecoveryModelL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRecoveryModelL.Location = new System.Drawing.Point(12, 82);
            this.lblRecoveryModelL.Name = "lblRecoveryModelL";
            this.lblRecoveryModelL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRecoveryModelL.Size = new System.Drawing.Size(89, 13);
            this.lblRecoveryModelL.TabIndex = 4;
            this.lblRecoveryModelL.Text = "Recovery model:";
            // 
            // lblDatabase
            // 
            this.lblDatabase.BackColor = System.Drawing.SystemColors.Control;
            this.lblDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatabase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDatabase.Location = new System.Drawing.Point(12, 53);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDatabase.Size = new System.Drawing.Size(84, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            // 
            // frmShrinkJob
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 337);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.fraMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShrinkJob";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.fraMain.ResumeLayout(false);
            this.fraMain.PerformLayout();
            this.fraFileDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox chkUpdate;
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOK;
        public System.Windows.Forms.GroupBox fraMain;
        internal System.Windows.Forms.Label lblNote;
        internal System.Windows.Forms.ComboBox cmbShrinkTask;
        internal System.Windows.Forms.Label lblShrinkTask;
        public System.Windows.Forms.CheckBox chkShrinkFile;
        public System.Windows.Forms.CheckBox chkSetToSimple;
        public System.Windows.Forms.ComboBox cmbDatabase;
        public System.Windows.Forms.GroupBox fraFileDetails;
        public System.Windows.Forms.ComboBox cmbDiskFile;
        public System.Windows.Forms.Label lblFreeSpace;
        public System.Windows.Forms.Label lblSize;
        public System.Windows.Forms.Label lblFileType;
        public System.Windows.Forms.Label lblFileGroup;
        public System.Windows.Forms.Label lblFreeSpaceL;
        public System.Windows.Forms.Label lblSizeL;
        public System.Windows.Forms.Label lblFileTypeL;
        public System.Windows.Forms.Label lblFilegroupL;
        public System.Windows.Forms.Label lblDiskFile;
        public System.Windows.Forms.Label lblRecoveryModel;
        public System.Windows.Forms.Label lblRecoveryModelL;
        public System.Windows.Forms.Label lblDatabase;
        public System.Windows.Forms.CheckBox chkUpdateIndexes;
    }
}