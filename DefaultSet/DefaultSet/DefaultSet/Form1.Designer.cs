namespace DefaultSet
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
            this.label1 = new System.Windows.Forms.Label();
            this.cboInpulg = new CSharpWin.ComboBoxEx();
            this.vbtSet = new 试验TimeLabel.VistaButton();
            this.vbtExit = new 试验TimeLabel.VistaButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(47, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择系统输入法：";
            // 
            // cboInpulg
            // 
            this.cboInpulg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInpulg.FormattingEnabled = true;
            this.cboInpulg.Location = new System.Drawing.Point(49, 45);
            this.cboInpulg.Name = "cboInpulg";
            this.cboInpulg.Size = new System.Drawing.Size(233, 20);
            this.cboInpulg.TabIndex = 1;
            // 
            // vbtSet
            // 
            this.vbtSet.BackColor = System.Drawing.Color.Transparent;
            this.vbtSet.BaseColor = System.Drawing.Color.Transparent;
            this.vbtSet.ButtonText = "设为默认";
            this.vbtSet.Location = new System.Drawing.Point(49, 143);
            this.vbtSet.Name = "vbtSet";
            this.vbtSet.Size = new System.Drawing.Size(100, 32);
            this.vbtSet.TabIndex = 2;
            this.vbtSet.Click += new System.EventHandler(this.vbtSet_Click);
            // 
            // vbtExit
            // 
            this.vbtExit.BackColor = System.Drawing.Color.Transparent;
            this.vbtExit.BaseColor = System.Drawing.Color.Transparent;
            this.vbtExit.ButtonText = "退出程序";
            this.vbtExit.Location = new System.Drawing.Point(194, 143);
            this.vbtExit.Name = "vbtExit";
            this.vbtExit.Size = new System.Drawing.Size(100, 32);
            this.vbtExit.TabIndex = 2;
            this.vbtExit.Click += new System.EventHandler(this.vbtExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(331, 214);
            this.Controls.Add(this.vbtExit);
            this.Controls.Add(this.vbtSet);
            this.Controls.Add(this.cboInpulg);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "默认软件设置 v1.0.5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CSharpWin.ComboBoxEx cboInpulg;
        private 试验TimeLabel.VistaButton vbtSet;
        private 试验TimeLabel.VistaButton vbtExit;
    }
}

