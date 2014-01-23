namespace FileMonitor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lvMonitor = new CSharpWin.ListViewEx();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btSelPath = new CSharpWin.ButtonEx();
            this.btStartService = new CSharpWin.ButtonEx();
            this.btStopService = new CSharpWin.ButtonEx();
            this.btExportLog = new CSharpWin.ButtonEx();
            this.lbState = new System.Windows.Forms.Label();
            this.startSpeakCheck = new CSharpWin.CheckBoxEx();
            this.cmbVoices = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cntshowMainform = new System.Windows.Forms.ToolStripMenuItem();
            this.cntselPath = new System.Windows.Forms.ToolStripMenuItem();
            this.cntstartService = new System.Windows.Forms.ToolStripMenuItem();
            this.cntstopService = new System.Windows.Forms.ToolStripMenuItem();
            this.cntserviceLog = new System.Windows.Forms.ToolStripMenuItem();
            this.cntExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvMonitor
            // 
            this.lvMonitor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvMonitor.Location = new System.Drawing.Point(0, 1);
            this.lvMonitor.Name = "lvMonitor";
            this.lvMonitor.OwnerDraw = true;
            this.lvMonitor.Size = new System.Drawing.Size(674, 355);
            this.lvMonitor.TabIndex = 0;
            this.lvMonitor.UseCompatibleStateImageBehavior = false;
            this.lvMonitor.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "时间";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "名称";
            this.columnHeader2.Width = 134;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "动作";
            this.columnHeader3.Width = 94;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "路径";
            this.columnHeader4.Width = 272;
            // 
            // btSelPath
            // 
            this.btSelPath.Location = new System.Drawing.Point(680, 12);
            this.btSelPath.Name = "btSelPath";
            this.btSelPath.Size = new System.Drawing.Size(105, 23);
            this.btSelPath.TabIndex = 1;
            this.btSelPath.Text = "选择磁盘或文件夹";
            this.btSelPath.UseVisualStyleBackColor = true;
            this.btSelPath.Click += new System.EventHandler(this.btSelPath_Click);
            // 
            // btStartService
            // 
            this.btStartService.Enabled = false;
            this.btStartService.Location = new System.Drawing.Point(680, 78);
            this.btStartService.Name = "btStartService";
            this.btStartService.Size = new System.Drawing.Size(105, 23);
            this.btStartService.TabIndex = 1;
            this.btStartService.Text = "开启监视服务";
            this.btStartService.UseVisualStyleBackColor = true;
            this.btStartService.Click += new System.EventHandler(this.btStartService_Click);
            // 
            // btStopService
            // 
            this.btStopService.Enabled = false;
            this.btStopService.Location = new System.Drawing.Point(680, 144);
            this.btStopService.Name = "btStopService";
            this.btStopService.Size = new System.Drawing.Size(105, 23);
            this.btStopService.TabIndex = 1;
            this.btStopService.Text = "关闭监视服务";
            this.btStopService.UseVisualStyleBackColor = true;
            this.btStopService.Click += new System.EventHandler(this.btStopService_Click);
            // 
            // btExportLog
            // 
            this.btExportLog.Enabled = false;
            this.btExportLog.Location = new System.Drawing.Point(680, 298);
            this.btExportLog.Name = "btExportLog";
            this.btExportLog.Size = new System.Drawing.Size(105, 23);
            this.btExportLog.TabIndex = 1;
            this.btExportLog.Text = "导出监视日志";
            this.btExportLog.UseVisualStyleBackColor = true;
            this.btExportLog.Click += new System.EventHandler(this.btExportLog_Click);
            // 
            // lbState
            // 
            this.lbState.AutoSize = true;
            this.lbState.ForeColor = System.Drawing.Color.Red;
            this.lbState.Location = new System.Drawing.Point(-2, 359);
            this.lbState.Name = "lbState";
            this.lbState.Size = new System.Drawing.Size(161, 12);
            this.lbState.TabIndex = 2;
            this.lbState.Text = "状态：等待选择磁盘或文件夹";
            // 
            // startSpeakCheck
            // 
            this.startSpeakCheck.AutoSize = true;
            this.startSpeakCheck.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.startSpeakCheck.Checked = true;
            this.startSpeakCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.startSpeakCheck.Location = new System.Drawing.Point(680, 340);
            this.startSpeakCheck.Name = "startSpeakCheck";
            this.startSpeakCheck.Size = new System.Drawing.Size(96, 16);
            this.startSpeakCheck.TabIndex = 3;
            this.startSpeakCheck.Text = "开启语音提示";
            this.startSpeakCheck.UseVisualStyleBackColor = true;
            // 
            // cmbVoices
            // 
            this.cmbVoices.FormattingEnabled = true;
            this.cmbVoices.Location = new System.Drawing.Point(418, 356);
            this.cmbVoices.Name = "cmbVoices";
            this.cmbVoices.Size = new System.Drawing.Size(121, 20);
            this.cmbVoices.TabIndex = 4;
            this.cmbVoices.Visible = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Renamed += new System.IO.RenamedEventHandler(this.fileSystemWatcher1_Renamed);
            this.fileSystemWatcher1.Deleted += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Deleted);
            this.fileSystemWatcher1.Created += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Created);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cntshowMainform,
            this.cntselPath,
            this.cntstartService,
            this.cntstopService,
            this.cntserviceLog,
            this.cntExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 136);
            // 
            // cntshowMainform
            // 
            this.cntshowMainform.Enabled = false;
            this.cntshowMainform.Name = "cntshowMainform";
            this.cntshowMainform.Size = new System.Drawing.Size(172, 22);
            this.cntshowMainform.Text = "显示主界面";
            this.cntshowMainform.Click += new System.EventHandler(this.cntshowMainform_Click);
            // 
            // cntselPath
            // 
            this.cntselPath.Name = "cntselPath";
            this.cntselPath.Size = new System.Drawing.Size(172, 22);
            this.cntselPath.Text = "选择磁盘或文件夹";
            this.cntselPath.Click += new System.EventHandler(this.btSelPath_Click);
            // 
            // cntstartService
            // 
            this.cntstartService.Enabled = false;
            this.cntstartService.Name = "cntstartService";
            this.cntstartService.Size = new System.Drawing.Size(172, 22);
            this.cntstartService.Text = "开启监视服务";
            this.cntstartService.Click += new System.EventHandler(this.btStartService_Click);
            // 
            // cntstopService
            // 
            this.cntstopService.Enabled = false;
            this.cntstopService.Name = "cntstopService";
            this.cntstopService.Size = new System.Drawing.Size(172, 22);
            this.cntstopService.Text = "关闭监视服务";
            this.cntstopService.Click += new System.EventHandler(this.btStopService_Click);
            // 
            // cntserviceLog
            // 
            this.cntserviceLog.Enabled = false;
            this.cntserviceLog.Name = "cntserviceLog";
            this.cntserviceLog.Size = new System.Drawing.Size(172, 22);
            this.cntserviceLog.Text = "导出监视日志";
            this.cntserviceLog.Click += new System.EventHandler(this.btExportLog_Click);
            // 
            // cntExit
            // 
            this.cntExit.Name = "cntExit";
            this.cntExit.Size = new System.Drawing.Size(172, 22);
            this.cntExit.Text = "退出";
            this.cntExit.Click += new System.EventHandler(this.cntExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 380);
            this.Controls.Add(this.cmbVoices);
            this.Controls.Add(this.startSpeakCheck);
            this.Controls.Add(this.lbState);
            this.Controls.Add(this.btExportLog);
            this.Controls.Add(this.btStopService);
            this.Controls.Add(this.btStartService);
            this.Controls.Add(this.btSelPath);
            this.Controls.Add(this.lvMonitor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "磁盘/文件夹监视器 v1.0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpWin.ListViewEx lvMonitor;
        private CSharpWin.ButtonEx btSelPath;
        private CSharpWin.ButtonEx btStartService;
        private CSharpWin.ButtonEx btStopService;
        private CSharpWin.ButtonEx btExportLog;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lbState;
        private CSharpWin.CheckBoxEx startSpeakCheck;
        private System.Windows.Forms.ComboBox cmbVoices;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cntselPath;
        private System.Windows.Forms.ToolStripMenuItem cntstartService;
        private System.Windows.Forms.ToolStripMenuItem cntstopService;
        private System.Windows.Forms.ToolStripMenuItem cntserviceLog;
        private System.Windows.Forms.ToolStripMenuItem cntExit;
        private System.Windows.Forms.ToolStripMenuItem cntshowMainform;
    }
}

