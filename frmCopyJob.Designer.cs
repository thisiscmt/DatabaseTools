namespace DBTools
{
    partial class frmCopyJob
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.gbxMain = new System.Windows.Forms.GroupBox();
            this.cmbNewDB = new System.Windows.Forms.ComboBox();
            this.lblNewDB = new System.Windows.Forms.Label();
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.lblSourceDB = new System.Windows.Forms.Label();
            this.gbxMain.SuspendLayout();
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
            this.chkUpdate.Location = new System.Drawing.Point(5, 111);
            this.chkUpdate.Name = "chkUpdate";
            this.chkUpdate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkUpdate.Size = new System.Drawing.Size(160, 17);
            this.chkUpdate.TabIndex = 5;
            this.chkUpdate.Text = "Close dialog after update";
            this.chkUpdate.UseVisualStyleBackColor = false;
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.SystemColors.Control;
            this.cmdOK.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOK.Location = new System.Drawing.Point(228, 106);
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
            this.cmdCancel.Location = new System.Drawing.Point(306, 106);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdCancel.Size = new System.Drawing.Size(72, 24);
            this.cmdCancel.TabIndex = 7;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // gbxMain
            // 
            this.gbxMain.Controls.Add(this.cmbNewDB);
            this.gbxMain.Controls.Add(this.lblNewDB);
            this.gbxMain.Controls.Add(this.cmbDatabase);
            this.gbxMain.Controls.Add(this.lblSourceDB);
            this.gbxMain.Location = new System.Drawing.Point(5, 2);
            this.gbxMain.Name = "gbxMain";
            this.gbxMain.Size = new System.Drawing.Size(373, 98);
            this.gbxMain.TabIndex = 4;
            this.gbxMain.TabStop = false;
            this.gbxMain.Text = "Copy Information";
            // 
            // cmbNewDB
            // 
            this.cmbNewDB.FormattingEnabled = true;
            this.cmbNewDB.Location = new System.Drawing.Point(110, 57);
            this.cmbNewDB.Name = "cmbNewDB";
            this.cmbNewDB.Size = new System.Drawing.Size(243, 21);
            this.cmbNewDB.TabIndex = 3;
            this.cmbNewDB.DropDown += new System.EventHandler(this.cmbNewDB_DropDown);
            this.cmbNewDB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbNewDB_KeyDown);
            // 
            // lblNewDB
            // 
            this.lblNewDB.BackColor = System.Drawing.SystemColors.Control;
            this.lblNewDB.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNewDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNewDB.Location = new System.Drawing.Point(8, 60);
            this.lblNewDB.Name = "lblNewDB";
            this.lblNewDB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNewDB.Size = new System.Drawing.Size(96, 13);
            this.lblNewDB.TabIndex = 2;
            this.lblNewDB.Text = "New database:";
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.BackColor = System.Drawing.SystemColors.Window;
            this.cmbDatabase.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDatabase.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cmbDatabase.Location = new System.Drawing.Point(110, 22);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmbDatabase.Size = new System.Drawing.Size(243, 21);
            this.cmbDatabase.TabIndex = 1;
            this.cmbDatabase.DropDown += new System.EventHandler(this.cmbDatabase_DropDown);
            this.cmbDatabase.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDatabase_KeyDown);
            // 
            // lblSourceDB
            // 
            this.lblSourceDB.BackColor = System.Drawing.SystemColors.Control;
            this.lblSourceDB.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSourceDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourceDB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSourceDB.Location = new System.Drawing.Point(8, 25);
            this.lblSourceDB.Name = "lblSourceDB";
            this.lblSourceDB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSourceDB.Size = new System.Drawing.Size(96, 13);
            this.lblSourceDB.TabIndex = 0;
            this.lblSourceDB.Text = "Original database:";
            // 
            // frmCopyJob
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 135);
            this.Controls.Add(this.chkUpdate);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.gbxMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCopyJob";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox chkUpdate;
        public System.Windows.Forms.Button cmdOK;
        public System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.GroupBox gbxMain;
        internal System.Windows.Forms.ComboBox cmbNewDB;
        public System.Windows.Forms.Label lblNewDB;
        public System.Windows.Forms.ComboBox cmbDatabase;
        public System.Windows.Forms.Label lblSourceDB;
    }
}