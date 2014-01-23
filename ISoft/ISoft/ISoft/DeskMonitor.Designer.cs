namespace ISoft
{
    partial class DeskMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeskMonitor));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.fileCHK = new System.Windows.Forms.CheckBox();
            this.vBdelete = new 试验TimeLabel.VistaButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(12, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(110, 110);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(148, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 95);
            this.label3.TabIndex = 5;
            this.label3.Text = "检测到桌面恶意图标  \r\n\r\nMS-DOS快捷方式 \r\n\r\n建议立即删除";
            // 
            // fileCHK
            // 
            this.fileCHK.AutoSize = true;
            this.fileCHK.BackColor = System.Drawing.Color.Transparent;
            this.fileCHK.Checked = true;
            this.fileCHK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fileCHK.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.fileCHK.Location = new System.Drawing.Point(25, 177);
            this.fileCHK.Name = "fileCHK";
            this.fileCHK.Size = new System.Drawing.Size(89, 21);
            this.fileCHK.TabIndex = 6;
            this.fileCHK.Text = "checkBox1";
            this.fileCHK.UseVisualStyleBackColor = false;
            this.fileCHK.CheckedChanged += new System.EventHandler(this.fileCHK_CheckedChanged);
            // 
            // vBdelete
            // 
            this.vBdelete.BackColor = System.Drawing.Color.Transparent;
            this.vBdelete.BaseColor = System.Drawing.Color.Transparent;
            this.vBdelete.ButtonText = "删 除";
            this.vBdelete.CornerRadius = 0;
            this.vBdelete.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.vBdelete.Location = new System.Drawing.Point(248, 163);
            this.vBdelete.Name = "vBdelete";
            this.vBdelete.Size = new System.Drawing.Size(60, 30);
            this.vBdelete.TabIndex = 7;
            this.vBdelete.Click += new System.EventHandler(this.vBdelete_Click);
            // 
            // DeskMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(320, 210);
            this.Controls.Add(this.vBdelete);
            this.Controls.Add(this.fileCHK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeskMonitor";
            this.ShowInTaskbar = false;
            this.Text = "警告";
            this.Load += new System.EventHandler(this.DeskMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox fileCHK;
        private 试验TimeLabel.VistaButton vBdelete;
    }
}