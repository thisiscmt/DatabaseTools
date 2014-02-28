namespace DBTools
{
    partial class frmBackupJob
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
            this.fraMain = new System.Windows.Forms.GroupBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.cmbBackupTask = new System.Windows.Forms.ComboBox();
            this.lblBackupTask = new System.Windows.Forms.Label();
            this.fraOverwrite = new System.Windows.Forms.GroupBox();
            this.optAppend = new System.Windows.Forms.RadioButton();
            this.optOverwrite = new System.Windows.Forms.RadioButton();
            this.fraBackupType = new System.Windows.Forms.GroupBox();
            this.optComplete = new System.Windows.Forms.RadioButton();
            this.optTransLog = new System.Windows.Forms.RadioButton();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.cmdBrowse = new System.Windows.Forms.Button();
            this.lblDatabase = new System.Windows.Forms.Label();
            this.lblBackupTo = new System.Windows.Forms.Label();
            this.chkUpdate = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.fraMain.SuspendLayout();
            this.fraOverwrite.SuspendLayout();
            this.fraBackupType.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraMain
            // 
            this.fraMain.BackColor = System.Drawing.SystemColors.Control;
            this.fraMain.Controls.Add(this.lblNote);
            this.fraMain.Controls.Add(this.cmbBackupTask);
            this.fraMain.Controls.Add(this.lblBackupTask);
            this.fraMain.Controls.Add(this.fraOverwrite);
            this.fraMain.Controls.Add(this.fraBackupType);
            this.fraMain.Controls.Add(this.cmbDatabase);
            this.fraMain.Controls.Add(this.txtBackupPath);
            this.fraMain.Controls.Add(this.cmdBrowse);
            this.fraMain.Controls.Add(this.lblDatabase);
            this.fraMain.Controls.Add(this.lblBackupTo);
            this.fraMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraMain.Location = new System.Drawing.Point(5, 2);
            this.fraMain.Name = "fraMain";
            this.fraMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraMain.Size = new System.Drawing.Size(465, 193);
            this.fraMain.TabIndex = 1;
            this.fraMain.TabStop = false;
            this.fraMain.Text = "Backup Information";
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(282, 24);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(146, 13);
            this.lblNote.TabIndex = 9;
            this.lblNote.Text = "Use * as a wildcard character";
            // 
            // cmbBackupTask
            // 
            this.cmbBackupTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBackupTask.FormattingEnabled = true;
            this.cmbBackupTask.Location = new System.Drawing.Point(88, 21);
            this.cmbBackupTask.Name = "cmbBackupTask";
            this.cmbBackupTask.Size = new System.Drawing.Size(183, 21);
            this.cmbBackupTask.TabIndex = 1;
            this.cmbBackupTask.SelectedIndexChanged += new System.EventHandler(this.cmbBackupTask_SelectedIndexChanged);
            // 
            // lblBackupTask
            // 
            this.lblBackupTask.AutoSize = true;
            this.lblBackupTask.Location = new System.Drawing.Point(10, 24);
            this.lblBackupTask.Name = "lblBackupTask";
            this.lblBackupTask.Size = new System.Drawing.Size(70, 13);
            this.lblBackupTask.TabIndex = 0;
            this.lblBackupTask.Text = "Backup task:";
            // 
            // fraOverwrite
            // 
            this.fraOverwrite.BackColor = System.Drawing.SystemColors.Control;
            this.fraOverwrite.Controls.Add(this.optAppend);
            this.fraOverwrite.Controls.Add(this.optOverwrite);
            this.fraOverwrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraOverwrite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraOverwrite.Location = new System.Drawing.Point(224, 117);
            this.fraOverwrite.Name = "fraOverwrite";
            this.fraOverwrite.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraOverwrite.Size = new System.Drawing.Size(201, 65);
            this.fraOverwrite.TabIndex = 8;
            this.fraOverwrite.TabStop = false;
            this.fraOverwrite.Text = "Overwrite";
            // 
            // optAppend
            // 
            this.optAppend.BackColor = System.Drawing.SystemColors.Control;
            this.optAppend.Cursor = System.Windows.Forms.Cursors.Default;
            this.optAppend.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optAppend.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optAppend.Location = new System.Drawing.Point(16, 20);
            this.optAppend.Name = "optAppend";
            this.optAppend.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optAppend.Size = new System.Drawing.Size(105, 17);
            this.optAppend.TabIndex = 0;
            this.optAppend.TabStop = true;
            this.optAppend.Text = "Append to file";
            this.optAppend.UseVisualStyleBackColor = false;
            // 
            // optOverwrite
            // 
            this.optOverwrite.BackColor = System.Drawing.SystemColors.Control;
            this.optOverwrite.Checked = true;
            this.optOverwrite.Cursor = System.Windows.Forms.Cursors.Default;
            this.optOverwrite.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOverwrite.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optOverwrite.Location = new System.Drawing.Point(16, 40);
            this.optOverwrite.Name = "optOverwrite";
            this.optOverwrite.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optOverwrite.Size = new System.Drawing.Size(97, 17);
            this.optOverwrite.TabIndex = 1;
            this.optOverwrite.TabStop = true;
            this.optOverwrite.Text = "Overwrite file";
            this.optOverwrite.UseVisualStyleBackColor = false;
            // 
            // fraBackupType
            // 
            this.fraBackupType.BackColor = System.Drawing.SystemColors.Control;
            this.fraBackupType.Controls.Add(this.optComplete);
            this.fraBackupType.Controls.Add(this.optTransLog);
            this.fraBackupType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraBackupType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraBackupType.Location = new System.Drawing.Point(11, 117);
            this.fraBackupType.Name = "fraBackupType";
            this.fraBackupType.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraBackupType.Size = new System.Drawing.Size(201, 65);
            this.fraBackupType.TabIndex = 7;
            this.fraBackupType.TabStop = false;
            this.fraBackupType.Text = "Backup Type";
            // 
            // optComplete
            // 
            this.optComplete.BackColor = System.Drawing.SystemColors.Control;
            this.optComplete.Checked = true;
            this.optComplete.Cursor = System.Windows.Forms.Cursors.Default;
            this.optComplete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optComplete.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optComplete.Location = new System.Drawing.Point(16, 20);
            this.optComplete.Name = "optComplete";
            this.optComplete.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optComplete.Size = new System.Drawing.Size(113, 17);
            this.optComplete.TabIndex = 0;
            this.optComplete.TabStop = true;
            this.optComplete.Text = "Complete backup";
            this.optComplete.UseVisualStyleBackColor = false;
            // 
            // optTransLog
            // 
            this.optTransLog.BackColor = System.Drawing.SystemColors.Control;
            this.optTransLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.optTransLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTransLog.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optTransLog.Location = new System.Drawing.Point(16, 40);
            this.optTransLog.Name = "optTransLog";
            this.optTransLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.optTransLog.Size = new System.Drawing.Size(105, 17);
            this.optTransLog.TabIndex = 1;
            this.optTransLog.TabStop = true;
            this.optTransLog.Text = "Transaction log";
            this.optTransLog.UseVisualStyleBackColor = false;
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDatabase.Location = new System.Drawing.Point(88, 53);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDatabase.Size = new System.Drawing.Size(337, 21);
            this.cmbDatabase.TabIndex = 3;
            this.cmbDatabase.DropDown += new System.EventHandler(this.cmbDatabase_DropDown);
            this.cmbDatabase.SelectedIndexChanged += new System.EventHandler(this.cmbDatabase_SelectedIndexChanged);
            this.cmbDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDatabase_KeyDown);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.AcceptsReturn = true;
            this.txtBackupPath.BackColor = System.Drawing.SystemColors.Window;
            this.txtBackupPath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBackupPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBackupPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtBackupPath.Location = new System.Drawing.Point(88, 85);
            this.txtBackupPath.MaxLength = 0;
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtBackupPath.Size = new System.Drawing.Size(337, 20);
            this.txtBackupPath.TabIndex = 5;
            // 
            // cmdBrowse
            // 
            this.cmdBrowse.BackColor = System.Drawing.SystemColors.Control;
            this.cmdBrowse.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdBrowse.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdBrowse.Location = new System.Drawing.Point(429, 85);
            this.cmdBrowse.Name = "cmdBrowse";
            this.cmdBrowse.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdBrowse.Size = new System.Drawing.Size(24, 20);
            this.cmdBrowse.TabIndex = 6;
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
            this.lblDatabase.Location = new System.Drawing.Point(10, 56);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDatabase.Size = new System.Drawing.Size(74, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            // 
            // lblBackupTo
            // 
            this.lblBackupTo.AutoSize = true;
            this.lblBackupTo.BackColor = System.Drawing.Color.Transparent;
            this.lblBackupTo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBackupTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackupTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBackupTo.Location = new System.Drawing.Point(10, 88);
            this.lblBackupTo.Name = "lblBackupTo";
            this.lblBackupTo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBackupTo.Size = new System.Drawing.Size(59, 13);
            this.lblBackupTo.TabIndex = 4;
            this.lblBackupTo.Text = "Backup to:";
            // 
            // chkUpdate
            // 
            this.chkUpdate.BackColor = System.Drawing.SystemColors.Control;
            this.chkUpdate.Checked = true;
            this.chkUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpdate.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUpdate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkUpdate.Location = new System.Drawing.Point(5, 206);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUpdate.Size = new System.Drawing.Size(145, 17);
            this.chkUpdate.TabIndex = 4;
            this.chkUpdate.Text = "&Close dialog after update";
            this.chkUpdate.UseVisualStyleBackColor = false;
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdCancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Location = new System.Drawing.Point(398, 201);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdCancel.Size = new System.Drawing.Size(72, 24);
            this.cmdCancel.TabIndex = 6;
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
            this.cmdOK.Location = new System.Drawing.Point(320, 201);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdOK.Size = new System.Drawing.Size(72, 24);
            this.cmdOK.TabIndex = 5;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // frmBackupJob
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 230);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.fraMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBackupJob";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.fraMain.ResumeLayout(false);
            this.fraMain.PerformLayout();
            this.fraOverwrite.ResumeLayout(false);
            this.fraBackupType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox fraMain;
        internal System.Windows.Forms.Label lblNote;
        internal System.Windows.Forms.ComboBox cmbBackupTask;
        internal System.Windows.Forms.Label lblBackupTask;
        public System.Windows.Forms.GroupBox fraOverwrite;
        public System.Windows.Forms.RadioButton optAppend;
        public System.Windows.Forms.RadioButton optOverwrite;
        public System.Windows.Forms.GroupBox fraBackupType;
        public System.Windows.Forms.RadioButton optComplete;
        public System.Windows.Forms.RadioButton optTransLog;
        public System.Windows.Forms.ComboBox cmbDatabase;
        public System.Windows.Forms.TextBox txtBackupPath;
        public System.Windows.Forms.Button cmdBrowse;
        public System.Windows.Forms.Label lblDatabase;
        public System.Windows.Forms.Label lblBackupTo;
        public System.Windows.Forms.CheckBox chkUpdate;
        public System.Windows.Forms.Button cmdCancel;
        public System.Windows.Forms.Button cmdOK;
    }
}