namespace OSSpeed
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
            this.tabControlEx1 = new CSharpWin.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btDelete = new CSharpWin.ButtonEx();
            this.btRefresh = new CSharpWin.ButtonEx();
            this.lvStart = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btSearch = new CSharpWin.ButtonEx();
            this.btOpenPath = new CSharpWin.ButtonEx();
            this.btUpdateService = new CSharpWin.ButtonEx();
            this.panel1 = new System.Windows.Forms.Panel();
            this.servicePathtxt = new System.Windows.Forms.Label();
            this.btServiceStop = new CSharpWin.ButtonEx();
            this.btServiceStart = new CSharpWin.ButtonEx();
            this.btRefreshService = new CSharpWin.ButtonEx();
            this.lvService = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ServiceTT = new System.Windows.Forms.ToolTip(this.components);
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlEx1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlEx1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(125)))));
            this.tabControlEx1.Controls.Add(this.tabPage1);
            this.tabControlEx1.Controls.Add(this.tabPage2);
            this.tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEx1.Location = new System.Drawing.Point(0, 0);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(794, 471);
            this.tabControlEx1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btDelete);
            this.tabPage1.Controls.Add(this.btRefresh);
            this.tabPage1.Controls.Add(this.lvStart);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(786, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "开机启动项优化";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(705, 407);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 1;
            this.btDelete.Text = "删 除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(592, 407);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 1;
            this.btRefresh.Tag = " ";
            this.btRefresh.Text = "刷 新";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // lvStart
            // 
            this.lvStart.CheckBoxes = true;
            this.lvStart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvStart.FullRowSelect = true;
            this.lvStart.Location = new System.Drawing.Point(0, 0);
            this.lvStart.Name = "lvStart";
            this.lvStart.Size = new System.Drawing.Size(786, 380);
            this.lvStart.SmallImageList = this.imageList1;
            this.lvStart.TabIndex = 0;
            this.lvStart.UseCompatibleStateImageBehavior = false;
            this.lvStart.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "启动项";
            this.columnHeader1.Width = 111;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.Width = 267;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "注册表键位置";
            this.columnHeader3.Width = 232;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btSearch);
            this.tabPage2.Controls.Add(this.btOpenPath);
            this.tabPage2.Controls.Add(this.btUpdateService);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Controls.Add(this.btServiceStop);
            this.tabPage2.Controls.Add(this.btServiceStart);
            this.tabPage2.Controls.Add(this.btRefreshService);
            this.tabPage2.Controls.Add(this.lvService);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(786, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "系统服务优化";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 421);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "提示：双击某个服务可查看详细信息";
            // 
            // btSearch
            // 
            this.btSearch.Enabled = false;
            this.btSearch.Location = new System.Drawing.Point(141, 389);
            this.btSearch.Name = "btSearch";
            this.btSearch.Size = new System.Drawing.Size(75, 23);
            this.btSearch.TabIndex = 6;
            this.btSearch.Text = "查 询";
            this.btSearch.UseVisualStyleBackColor = true;
            this.btSearch.Click += new System.EventHandler(this.btSearch_Click);
            // 
            // btOpenPath
            // 
            this.btOpenPath.Enabled = false;
            this.btOpenPath.Location = new System.Drawing.Point(9, 389);
            this.btOpenPath.Name = "btOpenPath";
            this.btOpenPath.Size = new System.Drawing.Size(75, 23);
            this.btOpenPath.TabIndex = 5;
            this.btOpenPath.Text = "打开位置";
            this.btOpenPath.UseVisualStyleBackColor = true;
            this.btOpenPath.Click += new System.EventHandler(this.btOpenPath_Click);
            // 
            // btUpdateService
            // 
            this.btUpdateService.Location = new System.Drawing.Point(285, 389);
            this.btUpdateService.Name = "btUpdateService";
            this.btUpdateService.Size = new System.Drawing.Size(75, 23);
            this.btUpdateService.TabIndex = 4;
            this.btUpdateService.Text = "更新服务";
            this.btUpdateService.UseVisualStyleBackColor = true;
            this.btUpdateService.Click += new System.EventHandler(this.btUpdateService_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.servicePathtxt);
            this.panel1.Location = new System.Drawing.Point(0, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 21);
            this.panel1.TabIndex = 3;
            // 
            // servicePathtxt
            // 
            this.servicePathtxt.AutoSize = true;
            this.servicePathtxt.Location = new System.Drawing.Point(5, 4);
            this.servicePathtxt.Name = "servicePathtxt";
            this.servicePathtxt.Size = new System.Drawing.Size(0, 12);
            this.servicePathtxt.TabIndex = 2;
            // 
            // btServiceStop
            // 
            this.btServiceStop.Location = new System.Drawing.Point(705, 389);
            this.btServiceStop.Name = "btServiceStop";
            this.btServiceStop.Size = new System.Drawing.Size(75, 23);
            this.btServiceStop.TabIndex = 1;
            this.btServiceStop.Text = "停 止";
            this.btServiceStop.UseVisualStyleBackColor = true;
            this.btServiceStop.Click += new System.EventHandler(this.btServiceStop_Click);
            // 
            // btServiceStart
            // 
            this.btServiceStart.Location = new System.Drawing.Point(562, 389);
            this.btServiceStart.Name = "btServiceStart";
            this.btServiceStart.Size = new System.Drawing.Size(75, 23);
            this.btServiceStart.TabIndex = 1;
            this.btServiceStart.Text = "启 动";
            this.btServiceStart.UseVisualStyleBackColor = true;
            this.btServiceStart.Click += new System.EventHandler(this.btServiceStart_Click);
            // 
            // btRefreshService
            // 
            this.btRefreshService.Location = new System.Drawing.Point(422, 389);
            this.btRefreshService.Name = "btRefreshService";
            this.btRefreshService.Size = new System.Drawing.Size(75, 23);
            this.btRefreshService.TabIndex = 1;
            this.btRefreshService.Text = "刷 新";
            this.btRefreshService.UseVisualStyleBackColor = true;
            this.btRefreshService.Click += new System.EventHandler(this.btRefreshService_Click);
            // 
            // lvService
            // 
            this.lvService.CheckBoxes = true;
            this.lvService.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvService.FullRowSelect = true;
            this.lvService.Location = new System.Drawing.Point(0, 0);
            this.lvService.Name = "lvService";
            this.lvService.Size = new System.Drawing.Size(786, 357);
            this.lvService.SmallImageList = this.imageList2;
            this.lvService.TabIndex = 0;
            this.lvService.UseCompatibleStateImageBehavior = false;
            this.lvService.View = System.Windows.Forms.View.Details;
            this.lvService.DoubleClick += new System.EventHandler(this.lvService_DoubleClick);
            this.lvService.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvService_MouseMove);
            this.lvService.Click += new System.EventHandler(this.lvService_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "名称";
            this.columnHeader4.Width = 128;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "状态";
            this.columnHeader5.Width = 76;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "可执行文件路径";
            this.columnHeader6.Width = 234;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "服务详细描述";
            this.columnHeader7.Width = 300;
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 471);
            this.Controls.Add(this.tabControlEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统加速 v1.0.4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlEx1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpWin.TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CSharpWin.ButtonEx btDelete;
        private CSharpWin.ButtonEx btRefresh;
        private System.Windows.Forms.ListView lvStart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lvService;
        private CSharpWin.ButtonEx btServiceStop;
        private CSharpWin.ButtonEx btServiceStart;
        private CSharpWin.ButtonEx btRefreshService;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label servicePathtxt;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private CSharpWin.ButtonEx btUpdateService;
        private CSharpWin.ButtonEx btSearch;
        private CSharpWin.ButtonEx btOpenPath;
        private System.Windows.Forms.ToolTip ServiceTT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolTip tip;
    }
}

