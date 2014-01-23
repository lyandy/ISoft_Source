namespace FileDestory
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
            this.SelectAllCheck = new CSharpWin.CheckBoxEx();
            this.AddFile = new CSharpWin.ButtonEx();
            this.StartDestory = new CSharpWin.ButtonEx();
            this.FileListview = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SelectAllCheck
            // 
            this.SelectAllCheck.AutoSize = true;
            this.SelectAllCheck.BackColor = System.Drawing.Color.Transparent;
            this.SelectAllCheck.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(224)))));
            this.SelectAllCheck.Checked = true;
            this.SelectAllCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SelectAllCheck.Location = new System.Drawing.Point(3, 386);
            this.SelectAllCheck.Name = "SelectAllCheck";
            this.SelectAllCheck.Size = new System.Drawing.Size(48, 16);
            this.SelectAllCheck.TabIndex = 1;
            this.SelectAllCheck.Text = "全选";
            this.SelectAllCheck.UseVisualStyleBackColor = false;
            this.SelectAllCheck.CheckedChanged += new System.EventHandler(this.SelectAllCheck_CheckedChanged);
            // 
            // AddFile
            // 
            this.AddFile.Location = new System.Drawing.Point(400, 408);
            this.AddFile.Name = "AddFile";
            this.AddFile.Size = new System.Drawing.Size(102, 34);
            this.AddFile.TabIndex = 2;
            this.AddFile.Text = "添加文件";
            this.AddFile.UseVisualStyleBackColor = true;
            this.AddFile.Click += new System.EventHandler(this.AddFile_Click);
            // 
            // StartDestory
            // 
            this.StartDestory.Enabled = false;
            this.StartDestory.Location = new System.Drawing.Point(537, 408);
            this.StartDestory.Name = "StartDestory";
            this.StartDestory.Size = new System.Drawing.Size(102, 34);
            this.StartDestory.TabIndex = 2;
            this.StartDestory.Text = "开始粉碎";
            this.StartDestory.UseVisualStyleBackColor = true;
            this.StartDestory.Click += new System.EventHandler(this.StartDestory_Click);
            // 
            // FileListview
            // 
            this.FileListview.AllowDrop = true;
            this.FileListview.CheckBoxes = true;
            this.FileListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.FileListview.FullRowSelect = true;
            this.FileListview.GridLines = true;
            this.FileListview.Location = new System.Drawing.Point(0, 56);
            this.FileListview.Name = "FileListview";
            this.FileListview.Size = new System.Drawing.Size(676, 321);
            this.FileListview.TabIndex = 3;
            this.FileListview.UseCompatibleStateImageBehavior = false;
            this.FileListview.View = System.Windows.Forms.View.Details;
            this.FileListview.DragDrop += new System.Windows.Forms.DragEventHandler(this.FileListview_DragDrop);
            this.FileListview.DragEnter += new System.Windows.Forms.DragEventHandler(this.FileListview_DragEnter);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 196;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "路径";
            this.columnHeader2.Width = 353;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "大小";
            this.columnHeader3.Width = 121;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(79, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "提示：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(115, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "强制删除、彻底粉碎文件,被粉碎的文件将无法恢复";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(674, 454);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FileListview);
            this.Controls.Add(this.StartDestory);
            this.Controls.Add(this.AddFile);
            this.Controls.Add(this.SelectAllCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "文件粉碎机 v1.0.3";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CSharpWin.CheckBoxEx SelectAllCheck;
        private CSharpWin.ButtonEx AddFile;
        private CSharpWin.ButtonEx StartDestory;
        private System.Windows.Forms.ListView FileListview;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;



    }
}

