namespace CompTxt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cTextBox1 = new bxyztSkin.CControls.CTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cTextBox2 = new bxyztSkin.CControls.CTextBox();
            this.buttonEx4 = new CSharpWin.ButtonEx();
            this.buttonEx3 = new CSharpWin.ButtonEx();
            this.buttonEx5 = new CSharpWin.ButtonEx();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(7, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "源文件位置及名称";
            // 
            // cTextBox1
            // 
            this.cTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cTextBox1.Location = new System.Drawing.Point(6, 30);
            this.cTextBox1.Name = "cTextBox1";
            this.cTextBox1.ReadOnly = true;
            this.cTextBox1.Size = new System.Drawing.Size(334, 21);
            this.cTextBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cTextBox2);
            this.groupBox2.Location = new System.Drawing.Point(6, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 70);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "目标文件位置及名称";
            // 
            // cTextBox2
            // 
            this.cTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cTextBox2.Location = new System.Drawing.Point(7, 31);
            this.cTextBox2.Name = "cTextBox2";
            this.cTextBox2.ReadOnly = true;
            this.cTextBox2.Size = new System.Drawing.Size(334, 21);
            this.cTextBox2.TabIndex = 0;
            // 
            // buttonEx4
            // 
            this.buttonEx4.Location = new System.Drawing.Point(13, 186);
            this.buttonEx4.Name = "buttonEx4";
            this.buttonEx4.Size = new System.Drawing.Size(79, 26);
            this.buttonEx4.TabIndex = 1;
            this.buttonEx4.Text = "打开源文件";
            this.buttonEx4.UseVisualStyleBackColor = true;
            this.buttonEx4.Click += new System.EventHandler(this.cButton1_Click);
            // 
            // buttonEx3
            // 
            this.buttonEx3.Location = new System.Drawing.Point(135, 186);
            this.buttonEx3.Name = "buttonEx3";
            this.buttonEx3.Size = new System.Drawing.Size(79, 26);
            this.buttonEx3.TabIndex = 1;
            this.buttonEx3.Text = "打开目标文件";
            this.buttonEx3.UseVisualStyleBackColor = true;
            this.buttonEx3.Click += new System.EventHandler(this.cButton2_Click);
            // 
            // buttonEx5
            // 
            this.buttonEx5.Location = new System.Drawing.Point(257, 186);
            this.buttonEx5.Name = "buttonEx5";
            this.buttonEx5.Size = new System.Drawing.Size(79, 26);
            this.buttonEx5.TabIndex = 1;
            this.buttonEx5.Text = "开始比较";
            this.buttonEx5.UseVisualStyleBackColor = true;
            this.buttonEx5.Click += new System.EventHandler(this.buttonEx5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CanResize = false;
            this.ClientSize = new System.Drawing.Size(360, 221);
            this.Controls.Add(this.buttonEx5);
            this.Controls.Add(this.buttonEx3);
            this.Controls.Add(this.buttonEx4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件内容比较器 v1.0.4";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private bxyztSkin.CControls.CTextBox cTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private bxyztSkin.CControls.CTextBox cTextBox2;
        private CSharpWin.ButtonEx buttonEx4;
        private CSharpWin.ButtonEx buttonEx3;
        private CSharpWin.ButtonEx buttonEx5;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

