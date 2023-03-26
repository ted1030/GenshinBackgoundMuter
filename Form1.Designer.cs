namespace BGMuter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.label1 = new System.Windows.Forms.Label();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.啟用ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.開機時啟動ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(344, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "BGMuter";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.啟用ToolStripMenuItem,
            this.開機時啟動ToolStripMenuItem,
            this.離開ToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(154, 76);
			// 
			// 啟用ToolStripMenuItem
			// 
			this.啟用ToolStripMenuItem.CheckOnClick = true;
			this.啟用ToolStripMenuItem.Name = "啟用ToolStripMenuItem";
			this.啟用ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
			this.啟用ToolStripMenuItem.Text = "啟用";
			this.啟用ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.啟用ToolStripMenuItem_CheckedChanged);
			// 
			// 開機時啟動ToolStripMenuItem
			// 
			this.開機時啟動ToolStripMenuItem.CheckOnClick = true;
			this.開機時啟動ToolStripMenuItem.Name = "開機時啟動ToolStripMenuItem";
			this.開機時啟動ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
			this.開機時啟動ToolStripMenuItem.Text = "開機時啟動";
			this.開機時啟動ToolStripMenuItem.CheckedChanged += new System.EventHandler(this.開機時啟動ToolStripMenuItem_CheckedChanged);
			// 
			// 離開ToolStripMenuItem
			// 
			this.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
			this.離開ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
			this.離開ToolStripMenuItem.Text = "離開";
			this.離開ToolStripMenuItem.Click += new System.EventHandler(this.離開ToolStripMenuItem_Click);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(12, 9);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(254, 246);
			this.checkedListBox1.TabIndex = 1;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(295, 70);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.Size = new System.Drawing.Size(164, 185);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(471, 272);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Shown += new System.EventHandler(this.Form1_Shown);
			this.Resize += new System.EventHandler(this.Form1_Resize);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

		#endregion

		private Label label1;
		private NotifyIcon notifyIcon1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem 開機時啟動ToolStripMenuItem;
		private ToolStripMenuItem 離開ToolStripMenuItem;
		private ToolStripMenuItem 啟用ToolStripMenuItem;
		private CheckedListBox checkedListBox1;
        private RichTextBox richTextBox1;
    }
}