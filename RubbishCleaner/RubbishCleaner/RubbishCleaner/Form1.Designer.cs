namespace RubbishCleaner
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "清空回收站",
            "将系统回收站中的内容彻底删除"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "清空IE缓存区",
            "彻底删除在系统中保留的IE缓存文件"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "清空IE　Cookies",
            "清除在系统中保留的IE Cookies文件"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "清空Windows临时文件",
            "删除在Windows中保留的临时文件"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "清空打开的文件记录",
            "删除【开始】→【文档】中打开记录"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "清除IE地址栏中的历史网址",
            "删除IE地址栏中访问过的网页地址"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "清除运行对话框",
            "清除【开始】→【运行】对话框中的历史记录"}, -1);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SelAllCheck = new CSharpWin.CheckBoxEx();
            this.btClean = new CSharpWin.ButtonEx();
            this.OneKeyCleanListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btOpenPath = new CSharpWin.ButtonEx();
            this.btStartScan = new CSharpWin.ButtonEx();
            this.btCleaner = new CSharpWin.ButtonEx();
            this.rbRecycle = new CSharpWin.RadioButtonEx();
            this.rbDelete = new CSharpWin.RadioButtonEx();
            this.label13 = new System.Windows.Forms.Label();
            this.selAllVolumeCheck = new CSharpWin.CheckBoxEx();
            this.selAllRubblishCheck = new CSharpWin.CheckBoxEx();
            this.ScanResLisv = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.lvwVolumes = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.ScanRestxt = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lab_showfile = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.wasteTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.LavenderBlush;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.Khaki;
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.MouseLeave += new System.EventHandler(this.splitContainer1_Panel1_MouseLeave);
            this.splitContainer1.Panel1.MouseEnter += new System.EventHandler(this.splitContainer1_Panel1_MouseEnter);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.MouseLeave += new System.EventHandler(this.splitContainer1_Panel2_MouseLeave);
            this.splitContainer1.Panel2.MouseEnter += new System.EventHandler(this.splitContainer1_Panel2_MouseEnter);
            this.splitContainer1.Size = new System.Drawing.Size(744, 454);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Khaki;
            this.panel1.Controls.Add(this.SelAllCheck);
            this.panel1.Controls.Add(this.btClean);
            this.panel1.Controls.Add(this.OneKeyCleanListview);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(42, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(656, 454);
            this.panel1.TabIndex = 2;
            // 
            // SelAllCheck
            // 
            this.SelAllCheck.AutoSize = true;
            this.SelAllCheck.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.SelAllCheck.Checked = true;
            this.SelAllCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelAllCheck.Location = new System.Drawing.Point(22, 417);
            this.SelAllCheck.Name = "SelAllCheck";
            this.SelAllCheck.Size = new System.Drawing.Size(48, 16);
            this.SelAllCheck.TabIndex = 3;
            this.SelAllCheck.Text = "全选";
            this.SelAllCheck.UseVisualStyleBackColor = true;
            this.SelAllCheck.CheckedChanged += new System.EventHandler(this.SelAllCheck_CheckedChanged);
            // 
            // btClean
            // 
            this.btClean.Location = new System.Drawing.Point(524, 411);
            this.btClean.Name = "btClean";
            this.btClean.Size = new System.Drawing.Size(105, 32);
            this.btClean.TabIndex = 2;
            this.btClean.Text = "确 定 清 理";
            this.btClean.UseVisualStyleBackColor = true;
            this.btClean.Click += new System.EventHandler(this.btClean_Click);
            // 
            // OneKeyCleanListview
            // 
            this.OneKeyCleanListview.CheckBoxes = true;
            this.OneKeyCleanListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.OneKeyCleanListview.FullRowSelect = true;
            this.OneKeyCleanListview.GridLines = true;
            listViewItem1.Checked = true;
            listViewItem1.StateImageIndex = 1;
            listViewItem2.Checked = true;
            listViewItem2.StateImageIndex = 1;
            listViewItem3.Checked = true;
            listViewItem3.StateImageIndex = 1;
            listViewItem4.Checked = true;
            listViewItem4.StateImageIndex = 1;
            listViewItem5.Checked = true;
            listViewItem5.StateImageIndex = 1;
            listViewItem6.Checked = true;
            listViewItem6.StateImageIndex = 1;
            listViewItem7.Checked = true;
            listViewItem7.StateImageIndex = 1;
            this.OneKeyCleanListview.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7});
            this.OneKeyCleanListview.Location = new System.Drawing.Point(0, 49);
            this.OneKeyCleanListview.Name = "OneKeyCleanListview";
            this.OneKeyCleanListview.Size = new System.Drawing.Size(649, 356);
            this.OneKeyCleanListview.TabIndex = 1;
            this.OneKeyCleanListview.UseCompatibleStateImageBehavior = false;
            this.OneKeyCleanListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "清理项目";
            this.columnHeader1.Width = 283;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目说明";
            this.columnHeader2.Width = 360;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(653, 24);
            this.label9.TabIndex = 0;
            this.label9.Text = "操作系统使用的时间越长，所积累的垃圾文件也越多，特别是临时文件，还会影响硬盘的速度，如果有效的清除这些临时文\r\n件可以获得更多的空间，请在下面选择要清除的项目！";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(7, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "理";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(7, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "清";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(7, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "键";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(7, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "一";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel2.Controls.Add(this.btOpenPath);
            this.panel2.Controls.Add(this.btStartScan);
            this.panel2.Controls.Add(this.btCleaner);
            this.panel2.Controls.Add(this.rbRecycle);
            this.panel2.Controls.Add(this.rbDelete);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.selAllVolumeCheck);
            this.panel2.Controls.Add(this.selAllRubblishCheck);
            this.panel2.Controls.Add(this.ScanResLisv);
            this.panel2.Controls.Add(this.lvwVolumes);
            this.panel2.Controls.Add(this.ScanRestxt);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lab_showfile);
            this.panel2.Location = new System.Drawing.Point(41, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 454);
            this.panel2.TabIndex = 2;
            // 
            // btOpenPath
            // 
            this.btOpenPath.Enabled = false;
            this.btOpenPath.Location = new System.Drawing.Point(5, 421);
            this.btOpenPath.Name = "btOpenPath";
            this.btOpenPath.Size = new System.Drawing.Size(75, 23);
            this.btOpenPath.TabIndex = 8;
            this.btOpenPath.Text = "打开位置";
            this.btOpenPath.UseVisualStyleBackColor = true;
            this.btOpenPath.Click += new System.EventHandler(this.btOpenPath_Click);
            // 
            // btStartScan
            // 
            this.btStartScan.Location = new System.Drawing.Point(455, 420);
            this.btStartScan.Name = "btStartScan";
            this.btStartScan.Size = new System.Drawing.Size(75, 23);
            this.btStartScan.TabIndex = 8;
            this.btStartScan.Text = "开始扫描";
            this.btStartScan.UseVisualStyleBackColor = true;
            this.btStartScan.Click += new System.EventHandler(this.btStartScan_Click);
            // 
            // btCleaner
            // 
            this.btCleaner.Enabled = false;
            this.btCleaner.Location = new System.Drawing.Point(563, 420);
            this.btCleaner.Name = "btCleaner";
            this.btCleaner.Size = new System.Drawing.Size(75, 23);
            this.btCleaner.TabIndex = 8;
            this.btCleaner.Text = "立即清理";
            this.btCleaner.UseVisualStyleBackColor = true;
            this.btCleaner.Click += new System.EventHandler(this.btCleaner_Click);
            // 
            // rbRecycle
            // 
            this.rbRecycle.AutoSize = true;
            this.rbRecycle.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.rbRecycle.Checked = true;
            this.rbRecycle.Location = new System.Drawing.Point(331, 424);
            this.rbRecycle.Name = "rbRecycle";
            this.rbRecycle.Size = new System.Drawing.Size(95, 16);
            this.rbRecycle.TabIndex = 6;
            this.rbRecycle.TabStop = true;
            this.rbRecycle.Text = "删除到回收站";
            this.rbRecycle.UseVisualStyleBackColor = true;
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.rbDelete.Location = new System.Drawing.Point(254, 424);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(71, 16);
            this.rbDelete.TabIndex = 6;
            this.rbDelete.Text = "直接删除";
            this.rbDelete.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(170, 426);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 5;
            this.label13.Text = "文件删除方式：";
            // 
            // selAllVolumeCheck
            // 
            this.selAllVolumeCheck.AutoSize = true;
            this.selAllVolumeCheck.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.selAllVolumeCheck.Location = new System.Drawing.Point(608, 33);
            this.selAllVolumeCheck.Name = "selAllVolumeCheck";
            this.selAllVolumeCheck.Size = new System.Drawing.Size(48, 16);
            this.selAllVolumeCheck.TabIndex = 4;
            this.selAllVolumeCheck.Text = "全选";
            this.selAllVolumeCheck.UseVisualStyleBackColor = true;
            this.selAllVolumeCheck.CheckedChanged += new System.EventHandler(this.selAllVolumeCheck_CheckedChanged);
            // 
            // selAllRubblishCheck
            // 
            this.selAllRubblishCheck.AutoSize = true;
            this.selAllRubblishCheck.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.selAllRubblishCheck.Checked = true;
            this.selAllRubblishCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.selAllRubblishCheck.Location = new System.Drawing.Point(102, 425);
            this.selAllRubblishCheck.Name = "selAllRubblishCheck";
            this.selAllRubblishCheck.Size = new System.Drawing.Size(48, 16);
            this.selAllRubblishCheck.TabIndex = 4;
            this.selAllRubblishCheck.Text = "全选";
            this.selAllRubblishCheck.UseVisualStyleBackColor = true;
            this.selAllRubblishCheck.CheckedChanged += new System.EventHandler(this.selAllRubblishCheck_CheckedChanged);
            // 
            // ScanResLisv
            // 
            this.ScanResLisv.CheckBoxes = true;
            this.ScanResLisv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.ScanResLisv.FullRowSelect = true;
            this.ScanResLisv.GridLines = true;
            this.ScanResLisv.Location = new System.Drawing.Point(3, 243);
            this.ScanResLisv.Name = "ScanResLisv";
            this.ScanResLisv.Size = new System.Drawing.Size(653, 168);
            this.ScanResLisv.TabIndex = 3;
            this.ScanResLisv.UseCompatibleStateImageBehavior = false;
            this.ScanResLisv.View = System.Windows.Forms.View.Details;
            this.ScanResLisv.Click += new System.EventHandler(this.ScanResLisv_Click);
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "位置";
            this.columnHeader10.Width = 313;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "大小";
            this.columnHeader11.Width = 92;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "文件类型";
            this.columnHeader12.Width = 92;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "修改日期";
            this.columnHeader13.Width = 149;
            // 
            // lvwVolumes
            // 
            this.lvwVolumes.CheckBoxes = true;
            this.lvwVolumes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvwVolumes.FullRowSelect = true;
            this.lvwVolumes.GridLines = true;
            this.lvwVolumes.Location = new System.Drawing.Point(3, 51);
            this.lvwVolumes.Name = "lvwVolumes";
            this.lvwVolumes.Size = new System.Drawing.Size(653, 164);
            this.lvwVolumes.SmallImageList = this.imageList1;
            this.lvwVolumes.TabIndex = 2;
            this.lvwVolumes.UseCompatibleStateImageBehavior = false;
            this.lvwVolumes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "驱动器";
            this.columnHeader3.Width = 113;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "卷标";
            this.columnHeader4.Width = 115;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "文件系统";
            this.columnHeader5.Width = 75;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "容量";
            this.columnHeader6.Width = 82;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "已用空间";
            this.columnHeader7.Width = 83;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "剩余空间";
            this.columnHeader8.Width = 82;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "剩余空间百分比";
            this.columnHeader9.Width = 97;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hdd.ico");
            this.imageList1.Images.SetKeyName(1, "hdd.ico");
            this.imageList1.Images.SetKeyName(2, "hdd.ico");
            this.imageList1.Images.SetKeyName(3, "hdd.ico");
            // 
            // ScanRestxt
            // 
            this.ScanRestxt.AutoSize = true;
            this.ScanRestxt.Location = new System.Drawing.Point(3, 228);
            this.ScanRestxt.Name = "ScanRestxt";
            this.ScanRestxt.Size = new System.Drawing.Size(65, 12);
            this.ScanRestxt.TabIndex = 1;
            this.ScanRestxt.Text = "扫描结果：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 12);
            this.label11.TabIndex = 1;
            this.label11.Text = "请选择要扫描的磁盘：";
            // 
            // lab_showfile
            // 
            this.lab_showfile.AutoSize = true;
            this.lab_showfile.Location = new System.Drawing.Point(3, 9);
            this.lab_showfile.Name = "lab_showfile";
            this.lab_showfile.Size = new System.Drawing.Size(281, 12);
            this.lab_showfile.TabIndex = 0;
            this.lab_showfile.Text = "定时清理垃圾可以节省磁盘空间，提高系统运行速度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(5, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "描";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(5, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 19);
            this.label7.TabIndex = 1;
            this.label7.Text = "扫";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(5, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(5, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "深";
            // 
            // timer1
            // 
            this.timer1.Interval = 400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 400;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // wasteTimer
            // 
            this.wasteTimer.Interval = 1000;
            this.wasteTimer.Tick += new System.EventHandler(this.wasteTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 454);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "垃圾清理 v1.0.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView OneKeyCleanListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private CSharpWin.ButtonEx btClean;
        private CSharpWin.CheckBoxEx SelAllCheck;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lab_showfile;
        private System.Windows.Forms.ListView lvwVolumes;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ListView ScanResLisv;
        private System.Windows.Forms.Label ScanRestxt;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.Label label13;
        private CSharpWin.CheckBoxEx selAllRubblishCheck;
        private CSharpWin.RadioButtonEx rbDelete;
        private CSharpWin.ButtonEx btStartScan;
        private CSharpWin.ButtonEx btCleaner;
        private CSharpWin.RadioButtonEx rbRecycle;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer wasteTimer;
        private CSharpWin.CheckBoxEx selAllVolumeCheck;
        private CSharpWin.ButtonEx btOpenPath;
    }
}

