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
            chkUpdate = new CheckBox();
            cmdOK = new Button();
            cmdCancel = new Button();
            gbxMain = new GroupBox();
            cmbNewDB = new ComboBox();
            lblNewDB = new Label();
            cmbDatabase = new ComboBox();
            lblSourceDB = new Label();
            gbxMain.SuspendLayout();
            SuspendLayout();
            // 
            // chkUpdate
            // 
            chkUpdate.BackColor = SystemColors.Control;
            chkUpdate.Checked = true;
            chkUpdate.CheckState = CheckState.Checked;
            chkUpdate.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkUpdate.ForeColor = SystemColors.ControlText;
            chkUpdate.Location = new Point(6, 128);
            chkUpdate.Margin = new Padding(4, 3, 4, 3);
            chkUpdate.Name = "chkUpdate";
            chkUpdate.RightToLeft = RightToLeft.No;
            chkUpdate.Size = new Size(187, 20);
            chkUpdate.TabIndex = 5;
            chkUpdate.Text = "Close dialog after update";
            chkUpdate.UseVisualStyleBackColor = false;
            // 
            // cmdOK
            // 
            cmdOK.BackColor = SystemColors.Control;
            cmdOK.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdOK.ForeColor = SystemColors.ControlText;
            cmdOK.Location = new Point(266, 122);
            cmdOK.Margin = new Padding(4, 3, 4, 3);
            cmdOK.Name = "cmdOK";
            cmdOK.RightToLeft = RightToLeft.No;
            cmdOK.Size = new Size(84, 28);
            cmdOK.TabIndex = 6;
            cmdOK.Text = "OK";
            cmdOK.UseVisualStyleBackColor = false;
            cmdOK.Click += cmdOK_Click;
            // 
            // cmdCancel
            // 
            cmdCancel.BackColor = SystemColors.Control;
            cmdCancel.DialogResult = DialogResult.Cancel;
            cmdCancel.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCancel.ForeColor = SystemColors.ControlText;
            cmdCancel.Location = new Point(357, 122);
            cmdCancel.Margin = new Padding(4, 3, 4, 3);
            cmdCancel.Name = "cmdCancel";
            cmdCancel.RightToLeft = RightToLeft.No;
            cmdCancel.Size = new Size(84, 28);
            cmdCancel.TabIndex = 7;
            cmdCancel.Text = "Cancel";
            cmdCancel.UseVisualStyleBackColor = false;
            cmdCancel.Click += cmdCancel_Click;
            // 
            // gbxMain
            // 
            gbxMain.Controls.Add(cmbNewDB);
            gbxMain.Controls.Add(lblNewDB);
            gbxMain.Controls.Add(cmbDatabase);
            gbxMain.Controls.Add(lblSourceDB);
            gbxMain.Location = new Point(6, 2);
            gbxMain.Margin = new Padding(4, 3, 4, 3);
            gbxMain.Name = "gbxMain";
            gbxMain.Padding = new Padding(4, 3, 4, 3);
            gbxMain.Size = new Size(435, 113);
            gbxMain.TabIndex = 4;
            gbxMain.TabStop = false;
            gbxMain.Text = "Copy Information";
            // 
            // cmbNewDB
            // 
            cmbNewDB.FormattingEnabled = true;
            cmbNewDB.Location = new Point(128, 66);
            cmbNewDB.Margin = new Padding(4, 3, 4, 3);
            cmbNewDB.Name = "cmbNewDB";
            cmbNewDB.Size = new Size(283, 23);
            cmbNewDB.TabIndex = 3;
            cmbNewDB.DropDown += cmbNewDB_DropDown;
            cmbNewDB.KeyDown += cmbNewDB_KeyDown;
            // 
            // lblNewDB
            // 
            lblNewDB.BackColor = SystemColors.Control;
            lblNewDB.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewDB.ForeColor = SystemColors.ControlText;
            lblNewDB.Location = new Point(9, 69);
            lblNewDB.Margin = new Padding(4, 0, 4, 0);
            lblNewDB.Name = "lblNewDB";
            lblNewDB.RightToLeft = RightToLeft.No;
            lblNewDB.Size = new Size(112, 15);
            lblNewDB.TabIndex = 2;
            lblNewDB.Text = "New database:";
            // 
            // cmbDatabase
            // 
            cmbDatabase.BackColor = SystemColors.Window;
            cmbDatabase.ForeColor = SystemColors.WindowText;
            cmbDatabase.ItemHeight = 15;
            cmbDatabase.Location = new Point(128, 25);
            cmbDatabase.Margin = new Padding(4, 3, 4, 3);
            cmbDatabase.Name = "cmbDatabase";
            cmbDatabase.RightToLeft = RightToLeft.No;
            cmbDatabase.Size = new Size(283, 23);
            cmbDatabase.TabIndex = 1;
            cmbDatabase.DropDown += cmbDatabase_DropDown;
            cmbDatabase.KeyDown += cmbDatabase_KeyDown;
            // 
            // lblSourceDB
            // 
            lblSourceDB.BackColor = SystemColors.Control;
            lblSourceDB.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSourceDB.ForeColor = SystemColors.ControlText;
            lblSourceDB.Location = new Point(9, 29);
            lblSourceDB.Margin = new Padding(4, 0, 4, 0);
            lblSourceDB.Name = "lblSourceDB";
            lblSourceDB.RightToLeft = RightToLeft.No;
            lblSourceDB.Size = new Size(112, 15);
            lblSourceDB.TabIndex = 0;
            lblSourceDB.Text = "Original database:";
            // 
            // frmCopyJob
            // 
            AcceptButton = cmdOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 156);
            Controls.Add(chkUpdate);
            Controls.Add(cmdOK);
            Controls.Add(cmdCancel);
            Controls.Add(gbxMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmCopyJob";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            gbxMain.ResumeLayout(false);
            ResumeLayout(false);

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