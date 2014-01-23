namespace ISoft
{
    partial class ErrorCollection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorCollection));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblErrorView = new System.Windows.Forms.LinkLabel();
            this.plError = new System.Windows.Forms.Panel();
            this.stopDesc = new System.Windows.Forms.TextBox();
            this.stopCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.sendCHK = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblConnecQQ = new System.Windows.Forms.LinkLabel();
            this.btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.plError.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(38, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "很抱歉，ISoft遇到了一个未知错误\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(164, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "我们为此生成了一个错误报告，希望您发送此报告\r\n\r\n以帮助我们改善ISoft的体验";
            // 
            // lblErrorView
            // 
            this.lblErrorView.AutoSize = true;
            this.lblErrorView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblErrorView.Location = new System.Drawing.Point(166, 98);
            this.lblErrorView.Name = "lblErrorView";
            this.lblErrorView.Size = new System.Drawing.Size(89, 12);
            this.lblErrorView.TabIndex = 2;
            this.lblErrorView.TabStop = true;
            this.lblErrorView.Text = "查看错误信息>>";
            this.lblErrorView.Click += new System.EventHandler(this.lblErrorView_Click);
            // 
            // plError
            // 
            this.plError.Controls.Add(this.stopDesc);
            this.plError.Controls.Add(this.stopCode);
            this.plError.Controls.Add(this.label4);
            this.plError.Controls.Add(this.label3);
            this.plError.Location = new System.Drawing.Point(168, 119);
            this.plError.Name = "plError";
            this.plError.Size = new System.Drawing.Size(316, 27);
            this.plError.TabIndex = 3;
            this.plError.Visible = false;
            // 
            // stopDesc
            // 
            this.stopDesc.Location = new System.Drawing.Point(213, 3);
            this.stopDesc.Name = "stopDesc";
            this.stopDesc.ReadOnly = true;
            this.stopDesc.Size = new System.Drawing.Size(100, 21);
            this.stopDesc.TabIndex = 1;
            // 
            // stopCode
            // 
            this.stopCode.Location = new System.Drawing.Point(49, 3);
            this.stopCode.Name = "stopCode";
            this.stopCode.ReadOnly = true;
            this.stopCode.Size = new System.Drawing.Size(100, 21);
            this.stopCode.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "错误描述:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "停止码:";
            // 
            // sendCHK
            // 
            this.sendCHK.AutoSize = true;
            this.sendCHK.Checked = true;
            this.sendCHK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.sendCHK.Location = new System.Drawing.Point(38, 170);
            this.sendCHK.Name = "sendCHK";
            this.sendCHK.Size = new System.Drawing.Size(210, 16);
            this.sendCHK.TabIndex = 4;
            this.sendCHK.Text = "发送错误报告，帮助ISoft做的更好";
            this.sendCHK.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(269, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "我们对给您带来的不便深表歉意，如需任何帮助，";
            // 
            // lblConnecQQ
            // 
            this.lblConnecQQ.AutoSize = true;
            this.lblConnecQQ.Location = new System.Drawing.Point(311, 199);
            this.lblConnecQQ.Name = "lblConnecQQ";
            this.lblConnecQQ.Size = new System.Drawing.Size(65, 12);
            this.lblConnecQQ.TabIndex = 2;
            this.lblConnecQQ.TabStop = true;
            this.lblConnecQQ.Text = "联系作者QQ";
            this.lblConnecQQ.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblConnecQQ_LinkClicked);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(381, 219);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "关 闭";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // ErrorCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 254);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.sendCHK);
            this.Controls.Add(this.plError);
            this.Controls.Add(this.lblConnecQQ);
            this.Controls.Add(this.lblErrorView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ErrorCollection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISoft错误收集程序";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.plError.ResumeLayout(false);
            this.plError.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblErrorView;
        private System.Windows.Forms.Panel plError;
        private System.Windows.Forms.TextBox stopCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox stopDesc;
        private System.Windows.Forms.CheckBox sendCHK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lblConnecQQ;
        private System.Windows.Forms.Button btClose;
    }
}