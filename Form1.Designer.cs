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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			notifyIcon1 = new NotifyIcon(components);
			contextMenuStrip1 = new ContextMenuStrip(components);
			啟用ToolStripMenuItem = new ToolStripMenuItem();
			開機時啟動ToolStripMenuItem = new ToolStripMenuItem();
			離開ToolStripMenuItem = new ToolStripMenuItem();
			label1 = new Label();
			richTextBox1 = new RichTextBox();
			checkedListBox1 = new CheckedListBox();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// notifyIcon1
			// 
			notifyIcon1.ContextMenuStrip = contextMenuStrip1;
			notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
			notifyIcon1.Text = "BGMuter";
			notifyIcon1.Visible = true;
			notifyIcon1.MouseClick += notifyIcon1_MouseClick;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.ImageScalingSize = new Size(20, 20);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 啟用ToolStripMenuItem, 開機時啟動ToolStripMenuItem, 離開ToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(154, 76);
			// 
			// 啟用ToolStripMenuItem
			// 
			啟用ToolStripMenuItem.CheckOnClick = true;
			啟用ToolStripMenuItem.Name = "啟用ToolStripMenuItem";
			啟用ToolStripMenuItem.Size = new Size(153, 24);
			啟用ToolStripMenuItem.Text = "啟用";
			啟用ToolStripMenuItem.CheckedChanged += 啟用ToolStripMenuItem_CheckedChanged;
			// 
			// 開機時啟動ToolStripMenuItem
			// 
			開機時啟動ToolStripMenuItem.CheckOnClick = true;
			開機時啟動ToolStripMenuItem.Name = "開機時啟動ToolStripMenuItem";
			開機時啟動ToolStripMenuItem.Size = new Size(153, 24);
			開機時啟動ToolStripMenuItem.Text = "開機時啟動";
			開機時啟動ToolStripMenuItem.CheckedChanged += 開機時啟動ToolStripMenuItem_CheckedChanged;
			// 
			// 離開ToolStripMenuItem
			// 
			離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
			離開ToolStripMenuItem.Size = new Size(153, 24);
			離開ToolStripMenuItem.Text = "離開";
			離開ToolStripMenuItem.Click += 離開ToolStripMenuItem_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(344, 24);
			label1.Name = "label1";
			label1.Size = new Size(51, 19);
			label1.TabIndex = 0;
			label1.Text = "label1";
			// 
			// richTextBox1
			// 
			richTextBox1.Location = new Point(295, 70);
			richTextBox1.Name = "richTextBox1";
			richTextBox1.Size = new Size(164, 185);
			richTextBox1.TabIndex = 2;
			richTextBox1.Text = "";
			// 
			// checkedListBox1
			// 
			checkedListBox1.FormattingEnabled = true;
			checkedListBox1.Location = new Point(12, 9);
			checkedListBox1.Name = "checkedListBox1";
			checkedListBox1.Size = new Size(254, 246);
			checkedListBox1.TabIndex = 1;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(9F, 19F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(471, 272);
			Controls.Add(richTextBox1);
			Controls.Add(checkedListBox1);
			Controls.Add(label1);
			MaximizeBox = false;
			Name = "Form1";
			ShowInTaskbar = false;
			Text = "Form1";
			WindowState = FormWindowState.Minimized;
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			Shown += Form1_Shown;
			Resize += Form1_Resize;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private NotifyIcon notifyIcon1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem 開機時啟動ToolStripMenuItem;
		private ToolStripMenuItem 離開ToolStripMenuItem;
		private ToolStripMenuItem 啟用ToolStripMenuItem;
		private Label label1;
		private RichTextBox richTextBox1;
		private CheckedListBox checkedListBox1;
	}
}