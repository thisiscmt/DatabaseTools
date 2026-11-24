namespace DBTools
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            cmdOK = new Button();
            pbIcon = new PictureBox();
            lblDesc = new Label();
            Line2 = new Label();
            Line1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbIcon).BeginInit();
            SuspendLayout();
            // 
            // cmdOK
            // 
            cmdOK.DialogResult = DialogResult.Cancel;
            cmdOK.Location = new Point(112, 122);
            cmdOK.Margin = new Padding(4, 4, 4, 4);
            cmdOK.Name = "cmdOK";
            cmdOK.Size = new Size(88, 26);
            cmdOK.TabIndex = 0;
            cmdOK.Text = "OK";
            cmdOK.UseVisualStyleBackColor = true;
            cmdOK.Click += cmdOK_Click;
            // 
            // pbIcon
            // 
            pbIcon.Image = (Image)resources.GetObject("pbIcon.Image");
            pbIcon.Location = new Point(10, 11);
            pbIcon.Margin = new Padding(4, 4, 4, 4);
            pbIcon.Name = "pbIcon";
            pbIcon.Size = new Size(38, 37);
            pbIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            pbIcon.TabIndex = 1;
            pbIcon.TabStop = false;
            // 
            // lblDesc
            // 
            lblDesc.Location = new Point(58, 9);
            lblDesc.Margin = new Padding(4, 0, 4, 0);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(245, 92);
            lblDesc.TabIndex = 2;
            // 
            // Line2
            // 
            Line2.BackColor = Color.FromArgb(128, 128, 128);
            Line2.Location = new Point(3, 110);
            Line2.Margin = new Padding(4, 0, 4, 0);
            Line2.Name = "Line2";
            Line2.Size = new Size(307, 1);
            Line2.TabIndex = 24;
            // 
            // Line1
            // 
            Line1.BackColor = Color.White;
            Line1.Location = new Point(4, 111);
            Line1.Margin = new Padding(4, 0, 4, 0);
            Line1.Name = "Line1";
            Line1.Size = new Size(305, 2);
            Line1.TabIndex = 25;
            // 
            // frmAbout
            // 
            AcceptButton = cmdOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cmdOK;
            ClientSize = new Size(312, 158);
            Controls.Add(Line2);
            Controls.Add(Line1);
            Controls.Add(lblDesc);
            Controls.Add(pbIcon);
            Controls.Add(cmdOK);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAbout";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            ((System.ComponentModel.ISupportInitialize)pbIcon).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.Label lblDesc;
        public System.Windows.Forms.Label Line2;
        public System.Windows.Forms.Label Line1;
    }
}