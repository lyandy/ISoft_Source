namespace ScanLargeFile
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lab_showfile = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pannerShow = new System.Windows.Forms.Panel();
            this.btStartScan = new CSharpWin.ButtonEx();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lvScanResult = new CSharpWin.ListViewEx();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.locationSite = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pushPanel1 = new CSharpWin.PushPanel();
            this.pushPanelItem1 = new CSharpWin.PushPanelItem();
            this.tsLocalVolumes = new System.Windows.Forms.ToolStrip();
            this.pushPanelItem2 = new CSharpWin.PushPanelItem();
            this.tsDriver = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.pannerShow.SuspendLayout();
            this.panel4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).BeginInit();
            this.pushPanel1.SuspendLayout();
            this.pushPanelItem1.SuspendLayout();
            this.pushPanelItem2.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hdd.ico");
            this.imageList1.Images.SetKeyName(1, "hdd_win.ico");
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.lab_showfile);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 447);
            this.panel1.TabIndex = 0;
            // 
            // lab_showfile
            // 
            this.lab_showfile.AutoSize = true;
            this.lab_showfile.Location = new System.Drawing.Point(7, 426);
            this.lab_showfile.Name = "lab_showfile";
            this.lab_showfile.Size = new System.Drawing.Size(0, 12);
            this.lab_showfile.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(437, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "为您找出占用 (C:)系统盘 空间最大的50个文件，并可按类型对文件进行分类管理";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pannerShow);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.lvScanResult);
            this.panel3.Location = new System.Drawing.Point(198, 31);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(595, 390);
            this.panel3.TabIndex = 0;
            // 
            // pannerShow
            // 
            this.pannerShow.BackColor = System.Drawing.SystemColors.Info;
            this.pannerShow.Controls.Add(this.btStartScan);
            this.pannerShow.Controls.Add(this.label4);
            this.pannerShow.Location = new System.Drawing.Point(175, 135);
            this.pannerShow.Name = "pannerShow";
            this.pannerShow.Size = new System.Drawing.Size(261, 101);
            this.pannerShow.TabIndex = 3;
            // 
            // btStartScan
            // 
            this.btStartScan.Location = new System.Drawing.Point(92, 63);
            this.btStartScan.Name = "btStartScan";
            this.btStartScan.Size = new System.Drawing.Size(75, 23);
            this.btStartScan.TabIndex = 1;
            this.btStartScan.Text = "开始扫描";
            this.btStartScan.UseVisualStyleBackColor = true;
            this.btStartScan.Click += new System.EventHandler(this.btStartScan_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 12);
            this.label4.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(123, 135);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(0, 0);
            this.panel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(49, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            // 
            // lvScanResult
            // 
            this.lvScanResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvScanResult.ContextMenuStrip = this.contextMenuStrip1;
            this.lvScanResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvScanResult.FullRowSelect = true;
            this.lvScanResult.Location = new System.Drawing.Point(0, 0);
            this.lvScanResult.Name = "lvScanResult";
            this.lvScanResult.OwnerDraw = true;
            this.lvScanResult.Size = new System.Drawing.Size(593, 388);
            this.lvScanResult.SmallImageList = this.imageList2;
            this.lvScanResult.TabIndex = 0;
            this.lvScanResult.UseCompatibleStateImageBehavior = false;
            this.lvScanResult.View = System.Windows.Forms.View.Details;
            this.lvScanResult.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 182;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "大小";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 111;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "文件路径";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 287;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.locationSite});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // locationSite
            // 
            this.locationSite.Name = "locationSite";
            this.locationSite.Size = new System.Drawing.Size(124, 22);
            this.locationSite.Text = "定位文件";
            this.locationSite.Click += new System.EventHandler(this.locationSite_Click);
            // 
            // imageList2
            // 
            this.imageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList2.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pushPanel1);
            this.panel2.Location = new System.Drawing.Point(0, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 390);
            this.panel2.TabIndex = 0;
            // 
            // pushPanel1
            // 
            this.pushPanel1.Items.AddRange(new CSharpWin.PushPanelItem[] {
            this.pushPanelItem1,
            this.pushPanelItem2});
            this.pushPanel1.Location = new System.Drawing.Point(-1, -1);
            this.pushPanel1.Name = "pushPanel1";
            this.pushPanel1.Size = new System.Drawing.Size(198, 390);
            this.pushPanel1.TabIndex = 0;
            // 
            // pushPanelItem1
            // 
            this.pushPanelItem1.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.pushPanelItem1.Controls.Add(this.tsLocalVolumes);
            this.pushPanelItem1.Name = "pushPanelItem1";
            this.pushPanelItem1.Text = "本地磁盘";
            // 
            // tsLocalVolumes
            // 
            this.tsLocalVolumes.AutoSize = false;
            this.tsLocalVolumes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsLocalVolumes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsLocalVolumes.Location = new System.Drawing.Point(2, 24);
            this.tsLocalVolumes.Name = "tsLocalVolumes";
            this.tsLocalVolumes.Size = new System.Drawing.Size(190, 25);
            this.tsLocalVolumes.TabIndex = 0;
            this.tsLocalVolumes.Text = "toolStrip1";
            // 
            // pushPanelItem2
            // 
            this.pushPanelItem2.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.pushPanelItem2.Controls.Add(this.tsDriver);
            this.pushPanelItem2.Name = "pushPanelItem2";
            this.pushPanelItem2.Text = "可移动磁盘";
            // 
            // tsDriver
            // 
            this.tsDriver.Location = new System.Drawing.Point(2, 24);
            this.tsDriver.Name = "tsDriver";
            this.tsDriver.Size = new System.Drawing.Size(190, 25);
            this.tsDriver.TabIndex = 0;
            this.tsDriver.Text = "toolStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "请展开显示磁盘列表";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 447);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "大文件扫描 v1.0.4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.pannerShow.ResumeLayout(false);
            this.pannerShow.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pushPanel1)).EndInit();
            this.pushPanel1.ResumeLayout(false);
            this.pushPanelItem1.ResumeLayout(false);
            this.pushPanelItem2.ResumeLayout(false);
            this.pushPanelItem2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private CSharpWin.PushPanel pushPanel1;
        private CSharpWin.PushPanelItem pushPanelItem1;
        private System.Windows.Forms.ToolStrip tsLocalVolumes;
        private CSharpWin.PushPanelItem pushPanelItem2;
        private System.Windows.Forms.ToolStrip tsDriver;
        private CSharpWin.ListViewEx lvScanResult;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pannerShow;
        private CSharpWin.ButtonEx btStartScan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_showfile;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem locationSite;

    }
}

