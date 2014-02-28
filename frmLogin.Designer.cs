namespace DBTools
{
    partial class frmLogin
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOK = new System.Windows.Forms.Button();
            this.fraLogon = new System.Windows.Forms.GroupBox();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkWinAuth = new System.Windows.Forms.CheckBox();
            this.lblPWD = new System.Windows.Forms.Label();
            this.lblUID = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.fraLogon.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(232, 136);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(72, 24);
            this.cmdCancel.TabIndex = 5;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(154, 136);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(72, 24);
            this.cmdOK.TabIndex = 4;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // fraLogon
            // 
            this.fraLogon.BackColor = System.Drawing.SystemColors.Control;
            this.fraLogon.Controls.Add(this.cmbServer);
            this.fraLogon.Controls.Add(this.txtUserID);
            this.fraLogon.Controls.Add(this.txtPassword);
            this.fraLogon.Controls.Add(this.chkWinAuth);
            this.fraLogon.Controls.Add(this.lblPWD);
            this.fraLogon.Controls.Add(this.lblUID);
            this.fraLogon.Controls.Add(this.lblServer);
            this.fraLogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraLogon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraLogon.Location = new System.Drawing.Point(5, 2);
            this.fraLogon.Name = "fraLogon";
            this.fraLogon.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraLogon.Size = new System.Drawing.Size(300, 129);
            this.fraLogon.TabIndex = 3;
            this.fraLogon.TabStop = false;
            this.fraLogon.Text = "Information";
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(72, 77);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(216, 21);
            this.cmbServer.TabIndex = 5;
            this.cmbServer.DropDown += new System.EventHandler(this.cmbServer_DropDown);
            this.cmbServer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbServer_KeyDown);
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(72, 21);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(216, 20);
            this.txtUserID.TabIndex = 1;
            this.txtUserID.Leave += new System.EventHandler(this.txtUserID_Leave);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(72, 49);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(216, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // chkWinAuth
            // 
            this.chkWinAuth.AutoSize = true;
            this.chkWinAuth.Location = new System.Drawing.Point(72, 103);
            this.chkWinAuth.Name = "chkWinAuth";
            this.chkWinAuth.Size = new System.Drawing.Size(162, 17);
            this.chkWinAuth.TabIndex = 6;
            this.chkWinAuth.Text = "Use Windows authentication";
            this.chkWinAuth.UseVisualStyleBackColor = true;
            this.chkWinAuth.CheckedChanged += new System.EventHandler(this.chkWinAuth_CheckedChanged);
            // 
            // lblPWD
            // 
            this.lblPWD.AutoSize = true;
            this.lblPWD.BackColor = System.Drawing.SystemColors.Control;
            this.lblPWD.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblPWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPWD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPWD.Location = new System.Drawing.Point(8, 52);
            this.lblPWD.Name = "lblPWD";
            this.lblPWD.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblPWD.Size = new System.Drawing.Size(56, 13);
            this.lblPWD.TabIndex = 2;
            this.lblPWD.Text = "&Password:";
            // 
            // lblUID
            // 
            this.lblUID.AutoSize = true;
            this.lblUID.BackColor = System.Drawing.SystemColors.Control;
            this.lblUID.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblUID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblUID.Location = new System.Drawing.Point(8, 24);
            this.lblUID.Name = "lblUID";
            this.lblUID.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblUID.Size = new System.Drawing.Size(46, 13);
            this.lblUID.TabIndex = 0;
            this.lblUID.Text = "&User ID:";
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.BackColor = System.Drawing.SystemColors.Control;
            this.lblServer.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblServer.Location = new System.Drawing.Point(8, 80);
            this.lblServer.Name = "lblServer";
            this.lblServer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblServer.Size = new System.Drawing.Size(41, 13);
            this.lblServer.TabIndex = 4;
            this.lblServer.Text = "&Server:";
            // 
            // frmLogin
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(310, 165);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.fraLogon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.fraLogon.ResumeLayout(false);
            this.fraLogon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button cmdCancel;
        internal System.Windows.Forms.Button cmdOK;
        public System.Windows.Forms.GroupBox fraLogon;
        internal System.Windows.Forms.ComboBox cmbServer;
        internal System.Windows.Forms.TextBox txtUserID;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.CheckBox chkWinAuth;
        public System.Windows.Forms.Label lblPWD;
        public System.Windows.Forms.Label lblUID;
        public System.Windows.Forms.Label lblServer;
    }
}