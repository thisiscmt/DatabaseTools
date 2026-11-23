namespace DBTools
{
    partial class frmSystemLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystemLog));
            mnuMain = new MenuStrip();
            mnuActions = new ToolStripMenuItem();
            mnuClearLog = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            mnuClose = new ToolStripMenuItem();
            txtLog = new TextBox();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.Items.AddRange(new ToolStripItem[] { mnuActions });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Padding = new Padding(7, 2, 0, 2);
            mnuMain.Size = new Size(807, 24);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "menuStrip1";
            // 
            // mnuActions
            // 
            mnuActions.DropDownItems.AddRange(new ToolStripItem[] { mnuClearLog, toolStripSeparator1, mnuClose });
            mnuActions.Name = "mnuActions";
            mnuActions.Size = new Size(59, 20);
            mnuActions.Text = "Actions";
            // 
            // mnuClearLog
            // 
            mnuClearLog.Name = "mnuClearLog";
            mnuClearLog.Size = new Size(180, 22);
            mnuClearLog.Text = "Clear Log";
            mnuClearLog.Click += mnuClearLog_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(177, 6);
            // 
            // mnuClose
            // 
            mnuClose.Name = "mnuClose";
            mnuClose.Size = new Size(180, 22);
            mnuClose.Text = "Close";
            mnuClose.Click += mnuClose_Click;
            // 
            // txtLog
            // 
            txtLog.Dock = DockStyle.Fill;
            txtLog.Location = new Point(0, 24);
            txtLog.Margin = new Padding(4, 3, 4, 3);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Both;
            txtLog.Size = new Size(807, 522);
            txtLog.TabIndex = 1;
            txtLog.KeyDown += txtLog_KeyDown;
            // 
            // frmSystemLog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(807, 546);
            Controls.Add(txtLog);
            Controls.Add(mnuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mnuMain;
            Margin = new Padding(4, 3, 4, 3);
            MinimizeBox = false;
            Name = "frmSystemLog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Log";
            Shown += frmSystemLog_Shown;
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.ToolStripMenuItem mnuActions;
        private System.Windows.Forms.ToolStripMenuItem mnuClearLog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuClose;
    }
}