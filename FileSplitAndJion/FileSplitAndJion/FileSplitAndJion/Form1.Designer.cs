namespace FileSplitAndJion
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
            CSharpWin.ProgressBarColorTable progressBarColorTable1 = new CSharpWin.ProgressBarColorTable();
            CSharpWin.ProgressBarColorTable progressBarColorTable2 = new CSharpWin.ProgressBarColorTable();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControlEx1 = new CSharpWin.TabControlEx();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new CSharpWin.ComboBoxEx();
            this.progressBar1 = new CSharpWin.ProgressBarEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_len = new CSharpWin.RadioButtonEx();
            this.rb_num = new CSharpWin.RadioButtonEx();
            this.cLabel3 = new bxyztSkin.CControls.CLabel();
            this.tb_num = new bxyztSkin.CControls.CTextBox();
            this.tb_show_filelen = new bxyztSkin.CControls.CTextBox();
            this.cLabel2 = new bxyztSkin.CControls.CLabel();
            this.btn_cancle = new CSharpWin.ButtonEx();
            this.btn_start_split = new CSharpWin.ButtonEx();
            this.btn_show = new CSharpWin.ButtonEx();
            this.tb_show_filename = new bxyztSkin.CControls.CTextBox();
            this.cLabel1 = new bxyztSkin.CControls.CLabel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBar2 = new CSharpWin.ProgressBarEx();
            this.btnCancleCom = new CSharpWin.ButtonEx();
            this.btnCombine = new CSharpWin.ButtonEx();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbSaveFileName = new bxyztSkin.CControls.CTextBox();
            this.btnBrowse = new CSharpWin.ButtonEx();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.checkbox = new CSharpWin.CheckBoxEx();
            this.btnClear = new CSharpWin.ButtonEx();
            this.btnDelete = new CSharpWin.ButtonEx();
            this.btnAdd = new CSharpWin.ButtonEx();
            this.btnSetBottom = new CSharpWin.ButtonEx();
            this.btnMoveBottom = new CSharpWin.ButtonEx();
            this.btnMoveTop = new CSharpWin.ButtonEx();
            this.btnSetTop = new CSharpWin.ButtonEx();
            this.tabControlEx1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlEx1
            // 
            this.tabControlEx1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlEx1.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(79)))), ((int)(((byte)(125)))));
            this.tabControlEx1.Controls.Add(this.tabPage1);
            this.tabControlEx1.Controls.Add(this.tabPage2);
            this.tabControlEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEx1.Location = new System.Drawing.Point(3, 24);
            this.tabControlEx1.Name = "tabControlEx1";
            this.tabControlEx1.SelectedIndex = 0;
            this.tabControlEx1.Size = new System.Drawing.Size(500, 315);
            this.tabControlEx1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.tb_show_filelen);
            this.tabPage1.Controls.Add(this.cLabel2);
            this.tabPage1.Controls.Add(this.btn_cancle);
            this.tabPage1.Controls.Add(this.btn_start_split);
            this.tabPage1.Controls.Add(this.btn_show);
            this.tabPage1.Controls.Add(this.tb_show_filename);
            this.tabPage1.Controls.Add(this.cLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(492, 282);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = " 切 分 ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "B",
            "KB",
            "MB"});
            this.comboBox1.Location = new System.Drawing.Point(280, 60);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.selectChange);
            // 
            // progressBar1
            // 
            this.progressBar1.ColorTable = progressBarColorTable1;
            this.progressBar1.Location = new System.Drawing.Point(9, 250);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(476, 23);
            this.progressBar1.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rb_len);
            this.groupBox1.Controls.Add(this.rb_num);
            this.groupBox1.Controls.Add(this.cLabel3);
            this.groupBox1.Controls.Add(this.tb_num);
            this.groupBox1.Location = new System.Drawing.Point(8, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 82);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "切分方式";
            // 
            // rb_len
            // 
            this.rb_len.AutoSize = true;
            this.rb_len.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.rb_len.Location = new System.Drawing.Point(351, 37);
            this.rb_len.Name = "rb_len";
            this.rb_len.Size = new System.Drawing.Size(71, 16);
            this.rb_len.TabIndex = 5;
            this.rb_len.Text = "大小等分";
            this.rb_len.UseVisualStyleBackColor = true;
            // 
            // rb_num
            // 
            this.rb_num.AutoSize = true;
            this.rb_num.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.rb_num.Location = new System.Drawing.Point(256, 36);
            this.rb_num.Name = "rb_num";
            this.rb_num.Size = new System.Drawing.Size(71, 16);
            this.rb_num.TabIndex = 5;
            this.rb_num.Text = "份数等分";
            this.rb_num.UseVisualStyleBackColor = true;
            // 
            // cLabel3
            // 
            this.cLabel3.AutoSize = true;
            this.cLabel3.BackColor = System.Drawing.Color.Transparent;
            this.cLabel3.Location = new System.Drawing.Point(6, 41);
            this.cLabel3.Name = "cLabel3";
            this.cLabel3.Size = new System.Drawing.Size(71, 12);
            this.cLabel3.TabIndex = 3;
            this.cLabel3.Text = "份数/大小：";
            // 
            // tb_num
            // 
            this.tb_num.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_num.Location = new System.Drawing.Point(83, 32);
            this.tb_num.Name = "tb_num";
            this.tb_num.Size = new System.Drawing.Size(149, 21);
            this.tb_num.TabIndex = 4;
            // 
            // tb_show_filelen
            // 
            this.tb_show_filelen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_show_filelen.Location = new System.Drawing.Point(79, 60);
            this.tb_show_filelen.Name = "tb_show_filelen";
            this.tb_show_filelen.ReadOnly = true;
            this.tb_show_filelen.Size = new System.Drawing.Size(149, 21);
            this.tb_show_filelen.TabIndex = 4;
            // 
            // cLabel2
            // 
            this.cLabel2.AutoSize = true;
            this.cLabel2.BackColor = System.Drawing.Color.Transparent;
            this.cLabel2.Location = new System.Drawing.Point(6, 69);
            this.cLabel2.Name = "cLabel2";
            this.cLabel2.Size = new System.Drawing.Size(65, 12);
            this.cLabel2.TabIndex = 3;
            this.cLabel2.Text = "文件长度：";
            // 
            // btn_cancle
            // 
            this.btn_cancle.Location = new System.Drawing.Point(409, 209);
            this.btn_cancle.Name = "btn_cancle";
            this.btn_cancle.Size = new System.Drawing.Size(77, 23);
            this.btn_cancle.TabIndex = 2;
            this.btn_cancle.Tag = " ";
            this.btn_cancle.Text = "取 消";
            this.btn_cancle.UseVisualStyleBackColor = true;
            this.btn_cancle.Click += new System.EventHandler(this.btn_cancle_Click);
            // 
            // btn_start_split
            // 
            this.btn_start_split.Location = new System.Drawing.Point(8, 209);
            this.btn_start_split.Name = "btn_start_split";
            this.btn_start_split.Size = new System.Drawing.Size(77, 23);
            this.btn_start_split.TabIndex = 2;
            this.btn_start_split.Text = "切 分";
            this.btn_start_split.UseVisualStyleBackColor = true;
            this.btn_start_split.Click += new System.EventHandler(this.btn_start_split_Click);
            // 
            // btn_show
            // 
            this.btn_show.Location = new System.Drawing.Point(449, 12);
            this.btn_show.Name = "btn_show";
            this.btn_show.Size = new System.Drawing.Size(35, 23);
            this.btn_show.TabIndex = 2;
            this.btn_show.Text = "...";
            this.btn_show.UseVisualStyleBackColor = true;
            this.btn_show.Click += new System.EventHandler(this.btn_show_Click);
            // 
            // tb_show_filename
            // 
            this.tb_show_filename.BackColor = System.Drawing.SystemColors.Window;
            this.tb_show_filename.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_show_filename.Location = new System.Drawing.Point(79, 15);
            this.tb_show_filename.Name = "tb_show_filename";
            this.tb_show_filename.ReadOnly = true;
            this.tb_show_filename.Size = new System.Drawing.Size(364, 21);
            this.tb_show_filename.TabIndex = 1;
            // 
            // cLabel1
            // 
            this.cLabel1.AutoSize = true;
            this.cLabel1.BackColor = System.Drawing.Color.Transparent;
            this.cLabel1.Location = new System.Drawing.Point(6, 24);
            this.cLabel1.Name = "cLabel1";
            this.cLabel1.Size = new System.Drawing.Size(53, 12);
            this.cLabel1.TabIndex = 0;
            this.cLabel1.Text = "文件名：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.progressBar2);
            this.tabPage2.Controls.Add(this.btnCancleCom);
            this.tabPage2.Controls.Add(this.btnCombine);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(492, 282);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "合 并";
            this.tabPage2.ToolTipText = " ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.ColorTable = progressBarColorTable2;
            this.progressBar2.Location = new System.Drawing.Point(7, 254);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(333, 23);
            this.progressBar2.TabIndex = 2;
            // 
            // btnCancleCom
            // 
            this.btnCancleCom.Location = new System.Drawing.Point(416, 254);
            this.btnCancleCom.Name = "btnCancleCom";
            this.btnCancleCom.Size = new System.Drawing.Size(59, 23);
            this.btnCancleCom.TabIndex = 1;
            this.btnCancleCom.Text = "取 消";
            this.btnCancleCom.UseVisualStyleBackColor = true;
            this.btnCancleCom.Click += new System.EventHandler(this.btnCancleCom_Click);
            // 
            // btnCombine
            // 
            this.btnCombine.Location = new System.Drawing.Point(346, 253);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(59, 23);
            this.btnCombine.TabIndex = 1;
            this.btnCombine.Text = "合 并";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbSaveFileName);
            this.groupBox3.Controls.Add(this.btnBrowse);
            this.groupBox3.Location = new System.Drawing.Point(7, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(479, 48);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "合并后文件保存路径和名称";
            // 
            // tbSaveFileName
            // 
            this.tbSaveFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSaveFileName.Location = new System.Drawing.Point(7, 21);
            this.tbSaveFileName.Name = "tbSaveFileName";
            this.tbSaveFileName.ReadOnly = true;
            this.tbSaveFileName.Size = new System.Drawing.Size(391, 21);
            this.tbSaveFileName.TabIndex = 0;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(409, 19);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(59, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.checkbox);
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.btnSetBottom);
            this.groupBox2.Controls.Add(this.btnMoveBottom);
            this.groupBox2.Controls.Add(this.btnMoveTop);
            this.groupBox2.Controls.Add(this.btnSetTop);
            this.groupBox2.Location = new System.Drawing.Point(7, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 185);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "要合并的文件";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(6, 20);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(396, 124);
            this.listBox1.TabIndex = 3;
            // 
            // checkbox
            // 
            this.checkbox.AutoSize = true;
            this.checkbox.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.checkbox.Location = new System.Drawing.Point(256, 156);
            this.checkbox.Name = "checkbox";
            this.checkbox.Size = new System.Drawing.Size(96, 16);
            this.checkbox.TabIndex = 2;
            this.checkbox.Text = "按文件名排序";
            this.checkbox.UseVisualStyleBackColor = true;
            this.checkbox.CheckedChanged += new System.EventHandler(this.check_Changed);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(170, 152);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(59, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "清 空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(74, 152);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(59, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "移 除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(6, 152);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(59, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添 加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnSetBottom
            // 
            this.btnSetBottom.Location = new System.Drawing.Point(409, 152);
            this.btnSetBottom.Name = "btnSetBottom";
            this.btnSetBottom.Size = new System.Drawing.Size(59, 23);
            this.btnSetBottom.TabIndex = 1;
            this.btnSetBottom.Text = "置 底";
            this.btnSetBottom.UseVisualStyleBackColor = true;
            this.btnSetBottom.Click += new System.EventHandler(this.btnSetBottom_Click);
            // 
            // btnMoveBottom
            // 
            this.btnMoveBottom.Location = new System.Drawing.Point(409, 112);
            this.btnMoveBottom.Name = "btnMoveBottom";
            this.btnMoveBottom.Size = new System.Drawing.Size(59, 23);
            this.btnMoveBottom.TabIndex = 1;
            this.btnMoveBottom.Text = "下 移";
            this.btnMoveBottom.UseVisualStyleBackColor = true;
            this.btnMoveBottom.Click += new System.EventHandler(this.btnMoveBottom_Click);
            // 
            // btnMoveTop
            // 
            this.btnMoveTop.Location = new System.Drawing.Point(409, 63);
            this.btnMoveTop.Name = "btnMoveTop";
            this.btnMoveTop.Size = new System.Drawing.Size(59, 23);
            this.btnMoveTop.TabIndex = 1;
            this.btnMoveTop.Text = "上 移";
            this.btnMoveTop.UseVisualStyleBackColor = true;
            this.btnMoveTop.Click += new System.EventHandler(this.btnMoveTop_Click);
            // 
            // btnSetTop
            // 
            this.btnSetTop.Location = new System.Drawing.Point(409, 20);
            this.btnSetTop.Name = "btnSetTop";
            this.btnSetTop.Size = new System.Drawing.Size(59, 23);
            this.btnSetTop.TabIndex = 1;
            this.btnSetTop.Text = "置 顶";
            this.btnSetTop.UseVisualStyleBackColor = true;
            this.btnSetTop.Click += new System.EventHandler(this.btnSetTop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(506, 342);
            this.Controls.Add(this.tabControlEx1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件的切分与合并 v1.0.5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControlEx1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CSharpWin.TabControlEx tabControlEx1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private CSharpWin.ButtonEx btn_show;
        private bxyztSkin.CControls.CTextBox tb_show_filename;
        private bxyztSkin.CControls.CLabel cLabel1;
        private bxyztSkin.CControls.CTextBox tb_show_filelen;
        private bxyztSkin.CControls.CLabel cLabel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private CSharpWin.RadioButtonEx rb_num;
        private bxyztSkin.CControls.CLabel cLabel3;
        private bxyztSkin.CControls.CTextBox tb_num;
        private CSharpWin.RadioButtonEx rb_len;
        private CSharpWin.ProgressBarEx progressBar1;
        private CSharpWin.ButtonEx btn_cancle;
        private CSharpWin.ButtonEx btn_start_split;
        private System.Windows.Forms.GroupBox groupBox2;
        private CSharpWin.CheckBoxEx checkbox;
        private CSharpWin.ButtonEx btnClear;
        private CSharpWin.ButtonEx btnDelete;
        private CSharpWin.ButtonEx btnAdd;
        private CSharpWin.ButtonEx btnSetBottom;
        private CSharpWin.ButtonEx btnMoveBottom;
        private CSharpWin.ButtonEx btnMoveTop;
        private CSharpWin.ButtonEx btnSetTop;
        private CSharpWin.ProgressBarEx progressBar2;
        private CSharpWin.ButtonEx btnCancleCom;
        private CSharpWin.ButtonEx btnCombine;
        private System.Windows.Forms.GroupBox groupBox3;
        private bxyztSkin.CControls.CTextBox tbSaveFileName;
        private CSharpWin.ButtonEx btnBrowse;
        private System.Windows.Forms.ListBox listBox1;
        private CSharpWin.ComboBoxEx comboBox1;

    }
}

