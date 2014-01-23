namespace ReadText
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
            CSharpWin.TrackBarColorTable trackBarColorTable1 = new CSharpWin.TrackBarColorTable();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVoices = new CSharpWin.ComboBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.trVolume = new CSharpWin.TrackBarEx();
            this.txtSpeach = new bxyztSkin.CControls.CTextBox();
            this.start_Read = new CSharpWin.ButtonEx();
            this.btSave = new CSharpWin.ButtonEx();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.trVolume)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择声音引擎：";
            // 
            // cmbVoices
            // 
            this.cmbVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoices.FormattingEnabled = true;
            this.cmbVoices.Location = new System.Drawing.Point(111, 17);
            this.cmbVoices.Name = "cmbVoices";
            this.cmbVoices.Size = new System.Drawing.Size(353, 20);
            this.cmbVoices.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "音量大小：";
            // 
            // trVolume
            // 
            this.trVolume.ColorTable = trackBarColorTable1;
            this.trVolume.Location = new System.Drawing.Point(101, 58);
            this.trVolume.Maximum = 100;
            this.trVolume.Minimum = 10;
            this.trVolume.Name = "trVolume";
            this.trVolume.Size = new System.Drawing.Size(371, 45);
            this.trVolume.TabIndex = 2;
            this.trVolume.TickFrequency = 10;
            this.trVolume.Value = 100;
            this.trVolume.Scroll += new System.EventHandler(this.trVolume_Scroll);
            // 
            // txtSpeach
            // 
            this.txtSpeach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSpeach.Location = new System.Drawing.Point(18, 99);
            this.txtSpeach.Multiline = true;
            this.txtSpeach.Name = "txtSpeach";
            this.txtSpeach.Size = new System.Drawing.Size(446, 152);
            this.txtSpeach.TabIndex = 3;
            // 
            // start_Read
            // 
            this.start_Read.Location = new System.Drawing.Point(44, 257);
            this.start_Read.Name = "start_Read";
            this.start_Read.Size = new System.Drawing.Size(75, 23);
            this.start_Read.TabIndex = 4;
            this.start_Read.Text = "阅 读";
            this.start_Read.UseVisualStyleBackColor = true;
            this.start_Read.Click += new System.EventHandler(this.start_Read_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(350, 257);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 4;
            this.btSave.Text = "保存wav";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(484, 289);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.start_Read);
            this.Controls.Add(this.txtSpeach);
            this.Controls.Add(this.trVolume);
            this.Controls.Add(this.cmbVoices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "语音朗读机 v1.0.5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trVolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CSharpWin.ComboBoxEx cmbVoices;
        private System.Windows.Forms.Label label2;
        private CSharpWin.TrackBarEx trVolume;
        private bxyztSkin.CControls.CTextBox txtSpeach;
        private CSharpWin.ButtonEx start_Read;
        private CSharpWin.ButtonEx btSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

