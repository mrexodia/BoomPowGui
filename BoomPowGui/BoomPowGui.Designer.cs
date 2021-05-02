namespace BoomPowGui
{
    partial class BoomPowGui
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
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tabPagePowService = new System.Windows.Forms.TabPage();
            this.textBoxPowService = new System.Windows.Forms.TextBox();
            this.tabPageBpowClient = new System.Windows.Forms.TabPage();
            this.textBoxBpowClient = new System.Windows.Forms.TextBox();
            this.tabControlProcesses = new System.Windows.Forms.TabControl();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxServiceArguments = new System.Windows.Forms.TextBox();
            this.textBoxBanAddress = new System.Windows.Forms.TextBox();
            this.checkBoxAutostart = new System.Windows.Forms.CheckBox();
            this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
            this.tabPagePowService.SuspendLayout();
            this.tabPageBpowClient.SuspendLayout();
            this.tabControlProcesses.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(12, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "&Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tabPagePowService
            // 
            this.tabPagePowService.Controls.Add(this.textBoxPowService);
            this.tabPagePowService.Location = new System.Drawing.Point(4, 22);
            this.tabPagePowService.Name = "tabPagePowService";
            this.tabPagePowService.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePowService.Size = new System.Drawing.Size(768, 371);
            this.tabPagePowService.TabIndex = 3;
            this.tabPagePowService.Text = "PoW Service";
            this.tabPagePowService.UseVisualStyleBackColor = true;
            // 
            // textBoxPowService
            // 
            this.textBoxPowService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPowService.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPowService.Location = new System.Drawing.Point(0, 0);
            this.textBoxPowService.Multiline = true;
            this.textBoxPowService.Name = "textBoxPowService";
            this.textBoxPowService.ReadOnly = true;
            this.textBoxPowService.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxPowService.Size = new System.Drawing.Size(768, 371);
            this.textBoxPowService.TabIndex = 1;
            this.textBoxPowService.WordWrap = false;
            // 
            // tabPageBpowClient
            // 
            this.tabPageBpowClient.Controls.Add(this.textBoxBpowClient);
            this.tabPageBpowClient.Location = new System.Drawing.Point(4, 22);
            this.tabPageBpowClient.Name = "tabPageBpowClient";
            this.tabPageBpowClient.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageBpowClient.Size = new System.Drawing.Size(768, 371);
            this.tabPageBpowClient.TabIndex = 2;
            this.tabPageBpowClient.Text = "bpow-client";
            this.tabPageBpowClient.UseVisualStyleBackColor = true;
            // 
            // textBoxBpowClient
            // 
            this.textBoxBpowClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBpowClient.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBpowClient.Location = new System.Drawing.Point(0, 0);
            this.textBoxBpowClient.Multiline = true;
            this.textBoxBpowClient.Name = "textBoxBpowClient";
            this.textBoxBpowClient.ReadOnly = true;
            this.textBoxBpowClient.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBpowClient.Size = new System.Drawing.Size(768, 371);
            this.textBoxBpowClient.TabIndex = 1;
            this.textBoxBpowClient.WordWrap = false;
            // 
            // tabControlProcesses
            // 
            this.tabControlProcesses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlProcesses.Controls.Add(this.tabPageBpowClient);
            this.tabControlProcesses.Controls.Add(this.tabPagePowService);
            this.tabControlProcesses.Location = new System.Drawing.Point(12, 41);
            this.tabControlProcesses.Name = "tabControlProcesses";
            this.tabControlProcesses.SelectedIndex = 0;
            this.tabControlProcesses.Size = new System.Drawing.Size(776, 397);
            this.tabControlProcesses.TabIndex = 1;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
            this.notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "&Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // textBoxServiceArguments
            // 
            this.textBoxServiceArguments.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxServiceArguments.Location = new System.Drawing.Point(505, 14);
            this.textBoxServiceArguments.Name = "textBoxServiceArguments";
            this.textBoxServiceArguments.Size = new System.Drawing.Size(100, 20);
            this.textBoxServiceArguments.TabIndex = 3;
            this.textBoxServiceArguments.Text = global::BoomPowGui.Properties.Settings.Default.ServiceArguments;
            // 
            // textBoxBanAddress
            // 
            this.textBoxBanAddress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBanAddress.Location = new System.Drawing.Point(93, 14);
            this.textBoxBanAddress.Name = "textBoxBanAddress";
            this.textBoxBanAddress.Size = new System.Drawing.Size(406, 20);
            this.textBoxBanAddress.TabIndex = 2;
            this.textBoxBanAddress.Text = global::BoomPowGui.Properties.Settings.Default.BananoAddress;
            // 
            // checkBoxAutostart
            // 
            this.checkBoxAutostart.AutoSize = true;
            this.checkBoxAutostart.Location = new System.Drawing.Point(611, 16);
            this.checkBoxAutostart.Name = "checkBoxAutostart";
            this.checkBoxAutostart.Size = new System.Drawing.Size(68, 17);
            this.checkBoxAutostart.TabIndex = 4;
            this.checkBoxAutostart.Text = "&Autostart";
            this.checkBoxAutostart.UseVisualStyleBackColor = true;
            this.checkBoxAutostart.CheckedChanged += new System.EventHandler(this.checkBoxAutostart_CheckedChanged);
            // 
            // linkLabelGitHub
            // 
            this.linkLabelGitHub.AutoSize = true;
            this.linkLabelGitHub.Location = new System.Drawing.Point(748, 17);
            this.linkLabelGitHub.Name = "linkLabelGitHub";
            this.linkLabelGitHub.Size = new System.Drawing.Size(40, 13);
            this.linkLabelGitHub.TabIndex = 5;
            this.linkLabelGitHub.TabStop = true;
            this.linkLabelGitHub.Text = "&GitHub";
            this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
            // 
            // BoomPowGui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLabelGitHub);
            this.Controls.Add(this.checkBoxAutostart);
            this.Controls.Add(this.textBoxServiceArguments);
            this.Controls.Add(this.textBoxBanAddress);
            this.Controls.Add(this.tabControlProcesses);
            this.Controls.Add(this.buttonStart);
            this.Name = "BoomPowGui";
            this.Text = "BoomPow GUI";
            this.tabPagePowService.ResumeLayout(false);
            this.tabPagePowService.PerformLayout();
            this.tabPageBpowClient.ResumeLayout(false);
            this.tabPageBpowClient.PerformLayout();
            this.tabControlProcesses.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TabPage tabPagePowService;
        private System.Windows.Forms.TextBox textBoxPowService;
        private System.Windows.Forms.TabPage tabPageBpowClient;
        private System.Windows.Forms.TextBox textBoxBpowClient;
        private System.Windows.Forms.TabControl tabControlProcesses;
        private System.Windows.Forms.TextBox textBoxBanAddress;
        private System.Windows.Forms.TextBox textBoxServiceArguments;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox checkBoxAutostart;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabelGitHub;
    }
}

