namespace Individuation
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
            this.tabControlEx1 = new CSharpWin.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btModify = new CSharpWin.ButtonEx();
            this.RegName1 = new bxyztSkin.CControls.CTextBox();
            this.RegName = new bxyztSkin.CControls.CTextBox();
            this.RegCommuNameTxt1 = new bxyztSkin.CControls.CTextBox();
            this.RegCommuNameTxt = new bxyztSkin.CControls.CTextBox();
            this.CurrentCompNameTxt1 = new bxyztSkin.CControls.CTextBox();
            this.CurrentCompNameTxt = new bxyztSkin.CControls.CTextBox();
            this.cLabel6 = new bxyztSkin.CControls.CLabel();
            this.cLabel3 = new bxyztSkin.CControls.CLabel();
            this.cLabel5 = new bxyztSkin.CControls.CLabel();
            this.cLabel2 = new bxyztSkin.CControls.CLabel();
            this.cLabel4 = new bxyztSkin.CControls.CLabel();
            this.cLabel1 = new bxyztSkin.CControls.CLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btOpenSave = new CSharpWin.ButtonEx();
            this.btRecover = new CSharpWin.ButtonEx();
            this.btSubmit = new CSharpWin.ButtonEx();
            this.PicShow = new bxyztSkin.CControls.CPictureBox(this.components);
            this.cLabel11 = new bxyztSkin.CControls.CLabel();
            this.btPicBrower = new CSharpWin.ButtonEx();
            this.PicDirectTxt = new bxyztSkin.CControls.CTextBox();
            this.cLabel10 = new bxyztSkin.CControls.CLabel();
            this.cLabel9 = new bxyztSkin.CControls.CLabel();
            this.cLabel8 = new bxyztSkin.CControls.CLabel();
            this.ScreenSizelbl = new bxyztSkin.CControls.CLabel();
            this.cLabel7 = new bxyztSkin.CControls.CLabel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btDelete = new CSharpWin.ButtonEx();
            this.btNew = new CSharpWin.ButtonEx();
            this.listView5 = new CSharpWin.ListViewEx();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cLabel13 = new bxyztSkin.CControls.CLabel();
            this.cLabel12 = new bxyztSkin.CControls.CLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btShow = new CSharpWin.ButtonEx();
            this.btHide = new CSharpWin.ButtonEx();
            this.cLabel14 = new bxyztSkin.CControls.CLabel();
            this.lvwVolumes = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControlEx1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicShow)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlEx1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(125)))));
            this.tabControlEx1.Controls.Add(this.tabPage1);
            this.tabControlEx1.Controls.Add(this.tabPage3);
            this.tabControlEx1.Controls.Add(this.tabPage4);
            this.tabControlEx1.Controls.Add(this.tabPage2);
            this.tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEx1.Location = new System.Drawing.Point(0, 0);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(544, 374);
            this.tabControlEx1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btModify);
            this.tabPage1.Controls.Add(this.RegName1);
            this.tabPage1.Controls.Add(this.RegName);
            this.tabPage1.Controls.Add(this.RegCommuNameTxt1);
            this.tabPage1.Controls.Add(this.RegCommuNameTxt);
            this.tabPage1.Controls.Add(this.CurrentCompNameTxt1);
            this.tabPage1.Controls.Add(this.CurrentCompNameTxt);
            this.tabPage1.Controls.Add(this.cLabel6);
            this.tabPage1.Controls.Add(this.cLabel3);
            this.tabPage1.Controls.Add(this.cLabel5);
            this.tabPage1.Controls.Add(this.cLabel2);
            this.tabPage1.Controls.Add(this.cLabel4);
            this.tabPage1.Controls.Add(this.cLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(536, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "计算机信息设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btModify
            // 
            this.btModify.Location = new System.Drawing.Point(227, 298);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(84, 29);
            this.btModify.TabIndex = 2;
            this.btModify.Text = "更 改";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // RegName1
            // 
            this.RegName1.BackColor = System.Drawing.SystemColors.Window;
            this.RegName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegName1.Location = new System.Drawing.Point(358, 216);
            this.RegName1.Name = "RegName1";
            this.RegName1.Size = new System.Drawing.Size(100, 21);
            this.RegName1.TabIndex = 1;
            // 
            // RegName
            // 
            this.RegName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegName.Location = new System.Drawing.Point(137, 216);
            this.RegName.Name = "RegName";
            this.RegName.ReadOnly = true;
            this.RegName.Size = new System.Drawing.Size(100, 21);
            this.RegName.TabIndex = 1;
            // 
            // RegCommuNameTxt1
            // 
            this.RegCommuNameTxt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegCommuNameTxt1.Location = new System.Drawing.Point(358, 132);
            this.RegCommuNameTxt1.Name = "RegCommuNameTxt1";
            this.RegCommuNameTxt1.Size = new System.Drawing.Size(100, 21);
            this.RegCommuNameTxt1.TabIndex = 1;
            // 
            // RegCommuNameTxt
            // 
            this.RegCommuNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RegCommuNameTxt.Location = new System.Drawing.Point(137, 132);
            this.RegCommuNameTxt.Name = "RegCommuNameTxt";
            this.RegCommuNameTxt.ReadOnly = true;
            this.RegCommuNameTxt.Size = new System.Drawing.Size(100, 21);
            this.RegCommuNameTxt.TabIndex = 1;
            // 
            // CurrentCompNameTxt1
            // 
            this.CurrentCompNameTxt1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentCompNameTxt1.Location = new System.Drawing.Point(358, 57);
            this.CurrentCompNameTxt1.Name = "CurrentCompNameTxt1";
            this.CurrentCompNameTxt1.Size = new System.Drawing.Size(100, 21);
            this.CurrentCompNameTxt1.TabIndex = 1;
            // 
            // CurrentCompNameTxt
            // 
            this.CurrentCompNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentCompNameTxt.Location = new System.Drawing.Point(137, 57);
            this.CurrentCompNameTxt.Name = "CurrentCompNameTxt";
            this.CurrentCompNameTxt.ReadOnly = true;
            this.CurrentCompNameTxt.Size = new System.Drawing.Size(100, 21);
            this.CurrentCompNameTxt.TabIndex = 1;
            // 
            // cLabel6
            // 
            this.cLabel6.AutoSize = true;
            this.cLabel6.BackColor = System.Drawing.Color.Transparent;
            this.cLabel6.Location = new System.Drawing.Point(292, 225);
            this.cLabel6.Name = "cLabel6";
            this.cLabel6.Size = new System.Drawing.Size(47, 12);
            this.cLabel6.TabIndex = 0;
            this.cLabel6.Text = "更改为:";
            // 
            // cLabel3
            // 
            this.cLabel3.AutoSize = true;
            this.cLabel3.BackColor = System.Drawing.Color.Transparent;
            this.cLabel3.Location = new System.Drawing.Point(43, 225);
            this.cLabel3.Name = "cLabel3";
            this.cLabel3.Size = new System.Drawing.Size(83, 12);
            this.cLabel3.TabIndex = 0;
            this.cLabel3.Text = "注册用户名称:";
            // 
            // cLabel5
            // 
            this.cLabel5.AutoSize = true;
            this.cLabel5.BackColor = System.Drawing.Color.Transparent;
            this.cLabel5.Location = new System.Drawing.Point(292, 141);
            this.cLabel5.Name = "cLabel5";
            this.cLabel5.Size = new System.Drawing.Size(47, 12);
            this.cLabel5.TabIndex = 0;
            this.cLabel5.Text = "更改为:";
            // 
            // cLabel2
            // 
            this.cLabel2.AutoSize = true;
            this.cLabel2.BackColor = System.Drawing.Color.Transparent;
            this.cLabel2.Location = new System.Drawing.Point(43, 141);
            this.cLabel2.Name = "cLabel2";
            this.cLabel2.Size = new System.Drawing.Size(83, 12);
            this.cLabel2.TabIndex = 0;
            this.cLabel2.Text = "注册组织名称:";
            // 
            // cLabel4
            // 
            this.cLabel4.AutoSize = true;
            this.cLabel4.BackColor = System.Drawing.Color.Transparent;
            this.cLabel4.Location = new System.Drawing.Point(292, 66);
            this.cLabel4.Name = "cLabel4";
            this.cLabel4.Size = new System.Drawing.Size(47, 12);
            this.cLabel4.TabIndex = 0;
            this.cLabel4.Text = "更改为:";
            // 
            // cLabel1
            // 
            this.cLabel1.AutoSize = true;
            this.cLabel1.BackColor = System.Drawing.Color.Transparent;
            this.cLabel1.Location = new System.Drawing.Point(36, 66);
            this.cLabel1.Name = "cLabel1";
            this.cLabel1.Size = new System.Drawing.Size(95, 12);
            this.cLabel1.TabIndex = 0;
            this.cLabel1.Text = "当前计算机名称:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btOpenSave);
            this.tabPage3.Controls.Add(this.btRecover);
            this.tabPage3.Controls.Add(this.btSubmit);
            this.tabPage3.Controls.Add(this.PicShow);
            this.tabPage3.Controls.Add(this.cLabel11);
            this.tabPage3.Controls.Add(this.btPicBrower);
            this.tabPage3.Controls.Add(this.PicDirectTxt);
            this.tabPage3.Controls.Add(this.cLabel10);
            this.tabPage3.Controls.Add(this.cLabel9);
            this.tabPage3.Controls.Add(this.cLabel8);
            this.tabPage3.Controls.Add(this.ScreenSizelbl);
            this.tabPage3.Controls.Add(this.cLabel7);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(536, 341);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "修改开机画面";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btOpenSave
            // 
            this.btOpenSave.Location = new System.Drawing.Point(151, 301);
            this.btOpenSave.Name = "btOpenSave";
            this.btOpenSave.Size = new System.Drawing.Size(96, 29);
            this.btOpenSave.TabIndex = 9;
            this.btOpenSave.Text = "打开保存文件夹";
            this.btOpenSave.UseVisualStyleBackColor = true;
            this.btOpenSave.Click += new System.EventHandler(this.btOpenSave_Click);
            // 
            // btRecover
            // 
            this.btRecover.Location = new System.Drawing.Point(270, 301);
            this.btRecover.Name = "btRecover";
            this.btRecover.Size = new System.Drawing.Size(96, 29);
            this.btRecover.TabIndex = 9;
            this.btRecover.Text = "恢复系统默认";
            this.btRecover.UseVisualStyleBackColor = true;
            this.btRecover.Click += new System.EventHandler(this.btRecover_Click);
            // 
            // btSubmit
            // 
            this.btSubmit.Location = new System.Drawing.Point(390, 301);
            this.btSubmit.Name = "btSubmit";
            this.btSubmit.Size = new System.Drawing.Size(96, 29);
            this.btSubmit.TabIndex = 9;
            this.btSubmit.Text = "应 用";
            this.btSubmit.UseVisualStyleBackColor = true;
            this.btSubmit.Click += new System.EventHandler(this.btSubmit_Click);
            // 
            // PicShow
            // 
            this.PicShow.BackColor = System.Drawing.Color.Transparent;
            this.PicShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PicShow.Location = new System.Drawing.Point(89, 104);
            this.PicShow.Name = "PicShow";
            this.PicShow.Size = new System.Drawing.Size(379, 180);
            this.PicShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicShow.TabIndex = 8;
            this.PicShow.TabStop = false;
            this.PicShow.Visible = false;
            // 
            // cLabel11
            // 
            this.cLabel11.AutoSize = true;
            this.cLabel11.BackColor = System.Drawing.Color.Transparent;
            this.cLabel11.Location = new System.Drawing.Point(9, 104);
            this.cLabel11.Name = "cLabel11";
            this.cLabel11.Size = new System.Drawing.Size(65, 12);
            this.cLabel11.TabIndex = 7;
            this.cLabel11.Text = "图片浏览：";
            // 
            // btPicBrower
            // 
            this.btPicBrower.Location = new System.Drawing.Point(408, 59);
            this.btPicBrower.Name = "btPicBrower";
            this.btPicBrower.Size = new System.Drawing.Size(75, 23);
            this.btPicBrower.TabIndex = 6;
            this.btPicBrower.Text = "浏 览";
            this.btPicBrower.UseVisualStyleBackColor = true;
            this.btPicBrower.Click += new System.EventHandler(this.btPicBrower_Click);
            // 
            // PicDirectTxt
            // 
            this.PicDirectTxt.BackColor = System.Drawing.SystemColors.Window;
            this.PicDirectTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicDirectTxt.Location = new System.Drawing.Point(89, 61);
            this.PicDirectTxt.Name = "PicDirectTxt";
            this.PicDirectTxt.Size = new System.Drawing.Size(304, 21);
            this.PicDirectTxt.TabIndex = 5;
            // 
            // cLabel10
            // 
            this.cLabel10.AutoSize = true;
            this.cLabel10.BackColor = System.Drawing.Color.Transparent;
            this.cLabel10.Location = new System.Drawing.Point(9, 70);
            this.cLabel10.Name = "cLabel10";
            this.cLabel10.Size = new System.Drawing.Size(65, 12);
            this.cLabel10.TabIndex = 4;
            this.cLabel10.Text = "图片位置：";
            // 
            // cLabel9
            // 
            this.cLabel9.AutoSize = true;
            this.cLabel9.BackColor = System.Drawing.Color.Transparent;
            this.cLabel9.Location = new System.Drawing.Point(9, 34);
            this.cLabel9.Name = "cLabel9";
            this.cLabel9.Size = new System.Drawing.Size(401, 12);
            this.cLabel9.TabIndex = 3;
            this.cLabel9.Text = "注意：在个性化里更改系统主题之后，登录画面会失效，需要重新设置一次";
            // 
            // cLabel8
            // 
            this.cLabel8.AutoSize = true;
            this.cLabel8.BackColor = System.Drawing.Color.Transparent;
            this.cLabel8.Location = new System.Drawing.Point(63, 20);
            this.cLabel8.Name = "cLabel8";
            this.cLabel8.Size = new System.Drawing.Size(77, 12);
            this.cLabel8.TabIndex = 2;
            this.cLabel8.Text = "一致的图片）";
            // 
            // ScreenSizelbl
            // 
            this.ScreenSizelbl.AutoSize = true;
            this.ScreenSizelbl.BackColor = System.Drawing.Color.Transparent;
            this.ScreenSizelbl.Location = new System.Drawing.Point(9, 20);
            this.ScreenSizelbl.Name = "ScreenSizelbl";
            this.ScreenSizelbl.Size = new System.Drawing.Size(0, 12);
            this.ScreenSizelbl.TabIndex = 1;
            // 
            // cLabel7
            // 
            this.cLabel7.AutoSize = true;
            this.cLabel7.BackColor = System.Drawing.Color.Transparent;
            this.cLabel7.Location = new System.Drawing.Point(9, 3);
            this.cLabel7.Name = "cLabel7";
            this.cLabel7.Size = new System.Drawing.Size(515, 12);
            this.cLabel7.TabIndex = 0;
            this.cLabel7.Text = "请选择一张图片，点击“应用”按钮，即可更改您的登录画面（建议使用尺寸与系统显示分辨率 ";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btDelete);
            this.tabPage4.Controls.Add(this.btNew);
            this.tabPage4.Controls.Add(this.listView5);
            this.tabPage4.Controls.Add(this.cLabel13);
            this.tabPage4.Controls.Add(this.cLabel12);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(536, 341);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "发送到菜单";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(438, 120);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(75, 23);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "删 除";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(438, 59);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(75, 23);
            this.btNew.TabIndex = 3;
            this.btNew.Text = "新 建";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.btNew_Click);
            // 
            // listView5
            // 
            this.listView5.Location = new System.Drawing.Point(9, 59);
            this.listView5.Name = "listView5";
            this.listView5.OwnerDraw = true;
            this.listView5.Size = new System.Drawing.Size(406, 277);
            this.listView5.SmallImageList = this.imageList1;
            this.listView5.TabIndex = 2;
            this.listView5.UseCompatibleStateImageBehavior = false;
            this.listView5.View = System.Windows.Forms.View.List;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(18, 18);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // cLabel13
            // 
            this.cLabel13.AutoSize = true;
            this.cLabel13.BackColor = System.Drawing.Color.Transparent;
            this.cLabel13.ForeColor = System.Drawing.Color.Red;
            this.cLabel13.Location = new System.Drawing.Point(9, 34);
            this.cLabel13.Name = "cLabel13";
            this.cLabel13.Size = new System.Drawing.Size(197, 12);
            this.cLabel13.TabIndex = 1;
            this.cLabel13.Text = "注意：删除发送到项目后将无法恢复";
            // 
            // cLabel12
            // 
            this.cLabel12.AutoSize = true;
            this.cLabel12.BackColor = System.Drawing.Color.Transparent;
            this.cLabel12.Location = new System.Drawing.Point(7, 7);
            this.cLabel12.Name = "cLabel12";
            this.cLabel12.Size = new System.Drawing.Size(353, 12);
            this.cLabel12.TabIndex = 0;
            this.cLabel12.Text = "管理发送到菜单，可以添加或删除鼠标右键菜单中的发送到项目！";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btShow);
            this.tabPage2.Controls.Add(this.btHide);
            this.tabPage2.Controls.Add(this.cLabel14);
            this.tabPage2.Controls.Add(this.lvwVolumes);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(536, 341);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "隐藏/显示驱动器";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btShow
            // 
            this.btShow.Location = new System.Drawing.Point(439, 315);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(75, 23);
            this.btShow.TabIndex = 4;
            this.btShow.Text = "显 示";
            this.btShow.UseVisualStyleBackColor = true;
            this.btShow.Click += new System.EventHandler(this.btShow_Click);
            // 
            // btHide
            // 
            this.btHide.Location = new System.Drawing.Point(330, 315);
            this.btHide.Name = "btHide";
            this.btHide.Size = new System.Drawing.Size(75, 23);
            this.btHide.TabIndex = 3;
            this.btHide.Text = "隐 藏";
            this.btHide.UseVisualStyleBackColor = true;
            this.btHide.Click += new System.EventHandler(this.btHide_Click);
            // 
            // cLabel14
            // 
            this.cLabel14.AutoSize = true;
            this.cLabel14.BackColor = System.Drawing.Color.Transparent;
            this.cLabel14.Location = new System.Drawing.Point(3, 12);
            this.cLabel14.Name = "cLabel14";
            this.cLabel14.Size = new System.Drawing.Size(137, 12);
            this.cLabel14.TabIndex = 2;
            this.cLabel14.Text = "请选择要隐藏的驱动器：";
            // 
            // lvwVolumes
            // 
            this.lvwVolumes.CheckBoxes = true;
            this.lvwVolumes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwVolumes.Location = new System.Drawing.Point(1, 28);
            this.lvwVolumes.Name = "lvwVolumes";
            this.lvwVolumes.Size = new System.Drawing.Size(533, 281);
            this.lvwVolumes.SmallImageList = this.imageList2;
            this.lvwVolumes.TabIndex = 0;
            this.lvwVolumes.UseCompatibleStateImageBehavior = false;
            this.lvwVolumes.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "驱动器";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "卷标";
            this.columnHeader2.Width = 152;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "状态";
            this.columnHeader3.Width = 88;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "hdd.ico");
            this.imageList2.Images.SetKeyName(1, "hdd.ico");
            this.imageList2.Images.SetKeyName(2, "hdd.ico");
            this.imageList2.Images.SetKeyName(3, "hdd.ico");
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 374);
            this.Controls.Add(this.tabControlEx1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "个性化设置 v1.0.2";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlEx1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicShow)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpWin.TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private bxyztSkin.CControls.CTextBox RegName1;
        private bxyztSkin.CControls.CTextBox RegName;
        private bxyztSkin.CControls.CTextBox RegCommuNameTxt1;
        private bxyztSkin.CControls.CTextBox RegCommuNameTxt;
        private bxyztSkin.CControls.CTextBox CurrentCompNameTxt1;
        private bxyztSkin.CControls.CTextBox CurrentCompNameTxt;
        private bxyztSkin.CControls.CLabel cLabel6;
        private bxyztSkin.CControls.CLabel cLabel3;
        private bxyztSkin.CControls.CLabel cLabel5;
        private bxyztSkin.CControls.CLabel cLabel2;
        private bxyztSkin.CControls.CLabel cLabel4;
        private bxyztSkin.CControls.CLabel cLabel1;
        private CSharpWin.ButtonEx btModify;
        private bxyztSkin.CControls.CLabel cLabel7;
        private bxyztSkin.CControls.CLabel cLabel9;
        private bxyztSkin.CControls.CLabel cLabel8;
        private bxyztSkin.CControls.CLabel ScreenSizelbl;
        private CSharpWin.ButtonEx btPicBrower;
        private bxyztSkin.CControls.CTextBox PicDirectTxt;
        private bxyztSkin.CControls.CLabel cLabel10;
        private CSharpWin.ButtonEx btSubmit;
        private bxyztSkin.CControls.CPictureBox PicShow;
        private bxyztSkin.CControls.CLabel cLabel11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CSharpWin.ButtonEx btRecover;
        private CSharpWin.ButtonEx btOpenSave;
        private bxyztSkin.CControls.CLabel cLabel13;
        private bxyztSkin.CControls.CLabel cLabel12;
        private CSharpWin.ListViewEx listView5;
        private CSharpWin.ButtonEx btDelete;
        private CSharpWin.ButtonEx btNew;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView lvwVolumes;
        private bxyztSkin.CControls.CLabel cLabel14;
        private CSharpWin.ButtonEx btShow;
        private CSharpWin.ButtonEx btHide;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList2;

    }
}

