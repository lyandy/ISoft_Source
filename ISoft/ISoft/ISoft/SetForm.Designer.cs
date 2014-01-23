namespace ISoft
{
    partial class SetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetForm));
            this.AutorunCheck = new System.Windows.Forms.CheckBox();
            this.btnSet = new System.Windows.Forms.Button();
            this.MemCleanCheck = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AutorunCheck
            // 
            this.AutorunCheck.AutoSize = true;
            this.AutorunCheck.BackColor = System.Drawing.Color.Transparent;
            this.AutorunCheck.Location = new System.Drawing.Point(34, 72);
            this.AutorunCheck.Name = "AutorunCheck";
            this.AutorunCheck.Size = new System.Drawing.Size(72, 16);
            this.AutorunCheck.TabIndex = 0;
            this.AutorunCheck.Text = "开机启动";
            this.AutorunCheck.UseVisualStyleBackColor = false;
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(123, 125);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "保 存";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // MemCleanCheck
            // 
            this.MemCleanCheck.AutoSize = true;
            this.MemCleanCheck.BackColor = System.Drawing.Color.Transparent;
            this.MemCleanCheck.Location = new System.Drawing.Point(193, 72);
            this.MemCleanCheck.Name = "MemCleanCheck";
            this.MemCleanCheck.Size = new System.Drawing.Size(96, 16);
            this.MemCleanCheck.TabIndex = 2;
            this.MemCleanCheck.Text = "定时内存整理";
            this.MemCleanCheck.UseVisualStyleBackColor = false;
            // 
            // SetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 179);
            this.Controls.Add(this.MemCleanCheck);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.AutorunCheck);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ISoft设置";
            this.Load += new System.EventHandler(this.SetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AutorunCheck;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.CheckBox MemCleanCheck;
    }
}