using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBTools
{
    public abstract class WizardForm : System.Windows.Forms.Form
    {
        protected System.Windows.Forms.Button cmdBack;
        protected System.Windows.Forms.Button cmdNext;
        protected System.Windows.Forms.Button cmdCancel;
        protected System.Windows.Forms.Panel panHeader;
        protected System.Windows.Forms.Label Line2;
        protected System.Windows.Forms.Label Line1;
        protected System.Windows.Forms.Label Line3;
        protected System.Windows.Forms.Label Line4;
        protected System.Windows.Forms.Label lblHeader2;
        protected System.Windows.Forms.Label lblHeader1;
        protected System.Windows.Forms.Panel panMsg;
        protected System.Windows.Forms.Label lblMsg;
        protected System.Windows.Forms.ProgressBar pbrMain;
        protected System.Windows.Forms.Panel panMain;

        public WizardForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.cmdBack = new System.Windows.Forms.Button();
            this.cmdNext = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.panHeader = new System.Windows.Forms.Panel();
            this.lblHeader2 = new System.Windows.Forms.Label();
            this.lblHeader1 = new System.Windows.Forms.Label();
            this.panMain = new System.Windows.Forms.Panel();
            this.panMsg = new System.Windows.Forms.Panel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pbrMain = new System.Windows.Forms.ProgressBar();
            this.Line2 = new System.Windows.Forms.Label();
            this.Line1 = new System.Windows.Forms.Label();
            this.Line3 = new System.Windows.Forms.Label();
            this.Line4 = new System.Windows.Forms.Label();
            this.panHeader.SuspendLayout();
            this.panMain.SuspendLayout();
            this.panMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdBack
            // 
            this.cmdBack.Location = new System.Drawing.Point(299, 306);
            this.cmdBack.Name = "cmdBack";
            this.cmdBack.Size = new System.Drawing.Size(75, 23);
            this.cmdBack.TabIndex = 2;
            this.cmdBack.Text = "< &Back";
            this.cmdBack.UseVisualStyleBackColor = true;
            // 
            // cmdNext
            // 
            this.cmdNext.Location = new System.Drawing.Point(380, 306);
            this.cmdNext.Name = "cmdNext";
            this.cmdNext.Size = new System.Drawing.Size(75, 23);
            this.cmdNext.TabIndex = 3;
            this.cmdNext.Text = "&Next >";
            this.cmdNext.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(461, 306);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(75, 23);
            this.cmdCancel.TabIndex = 4;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // panHeader
            // 
            this.panHeader.BackColor = System.Drawing.SystemColors.Window;
            this.panHeader.Controls.Add(this.lblHeader2);
            this.panHeader.Controls.Add(this.lblHeader1);
            this.panHeader.Location = new System.Drawing.Point(0, 0);
            this.panHeader.Name = "panHeader";
            this.panHeader.Size = new System.Drawing.Size(544, 72);
            this.panHeader.TabIndex = 0;
            // 
            // lblHeader2
            // 
            this.lblHeader2.Location = new System.Drawing.Point(38, 27);
            this.lblHeader2.Name = "lblHeader2";
            this.lblHeader2.Size = new System.Drawing.Size(488, 38);
            this.lblHeader2.TabIndex = 1;
            this.lblHeader2.Text = "Header2";
            // 
            // lblHeader1
            // 
            this.lblHeader1.Location = new System.Drawing.Point(18, 9);
            this.lblHeader1.Name = "lblHeader1";
            this.lblHeader1.Size = new System.Drawing.Size(508, 13);
            this.lblHeader1.TabIndex = 0;
            this.lblHeader1.Text = "Header1";
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panMsg);
            this.panMain.Location = new System.Drawing.Point(0, 76);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(544, 218);
            this.panMain.TabIndex = 4;
            // 
            // panMsg
            // 
            this.panMsg.Controls.Add(this.lblMsg);
            this.panMsg.Controls.Add(this.pbrMain);
            this.panMsg.Location = new System.Drawing.Point(8, 3);
            this.panMsg.Name = "panMsg";
            this.panMsg.Size = new System.Drawing.Size(528, 212);
            this.panMsg.TabIndex = 3;
            // 
            // lblMsg
            // 
            this.lblMsg.Location = new System.Drawing.Point(16, 47);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(496, 65);
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "Add message here";
            // 
            // pbrMain
            // 
            this.pbrMain.Location = new System.Drawing.Point(24, 135);
            this.pbrMain.Name = "pbrMain";
            this.pbrMain.Size = new System.Drawing.Size(480, 16);
            this.pbrMain.TabIndex = 0;
            this.pbrMain.Visible = false;
            // 
            // Line2
            // 
            this.Line2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Line2.Location = new System.Drawing.Point(0, 72);
            this.Line2.Name = "Line2";
            this.Line2.Size = new System.Drawing.Size(544, 1);
            this.Line2.TabIndex = 1;
            // 
            // Line1
            // 
            this.Line1.BackColor = System.Drawing.Color.White;
            this.Line1.Location = new System.Drawing.Point(0, 73);
            this.Line1.Name = "Line1";
            this.Line1.Size = new System.Drawing.Size(544, 1);
            this.Line1.TabIndex = 27;
            // 
            // Line3
            // 
            this.Line3.BackColor = System.Drawing.Color.White;
            this.Line3.Location = new System.Drawing.Point(0, 297);
            this.Line3.Name = "Line3";
            this.Line3.Size = new System.Drawing.Size(544, 1);
            this.Line3.TabIndex = 28;
            // 
            // Line4
            // 
            this.Line4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Line4.Location = new System.Drawing.Point(0, 296);
            this.Line4.Name = "Line4";
            this.Line4.Size = new System.Drawing.Size(544, 1);
            this.Line4.TabIndex = 29;
            // 
            // WizardForm
            // 
            this.AcceptButton = this.cmdNext;
            this.ClientSize = new System.Drawing.Size(544, 336);
            this.Controls.Add(this.Line4);
            this.Controls.Add(this.Line3);
            this.Controls.Add(this.Line2);
            this.Controls.Add(this.Line1);
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panHeader);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdNext);
            this.Controls.Add(this.cmdBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panHeader.ResumeLayout(false);
            this.panMain.ResumeLayout(false);
            this.panMsg.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        public bool Unload { get; set; }
    }
}
