using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Net;
using System.IO;
using System.Threading;
using System.Diagnostics;

//源码下载www.51aspx.com
namespace AutoUpdate
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class FrmUpdate : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ColumnHeader chFileName;
		private System.Windows.Forms.ColumnHeader chVersion;
		private System.Windows.Forms.ColumnHeader chProgress;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView lvUpdateList;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ProgressBar pbDownFile;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private ListView lvUpdateList1;
        private ToolTip tip;
        private Button btnNext;
        private Button btnCancel;
        private Button btnFinish;
        private Button btnClose;
        private Label label6;
        private IContainer components;


		public FrmUpdate()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            AeroForm.AeroEffect(this);
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdate));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvUpdateList1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvUpdateList = new System.Windows.Forms.ListView();
            this.chFileName = new System.Windows.Forms.ColumnHeader();
            this.chVersion = new System.Windows.Forms.ColumnHeader();
            this.chProgress = new System.Windows.Forms.ColumnHeader();
            this.pbDownFile = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tip = new System.Windows.Forms.ToolTip(this.components);
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 240);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvUpdateList1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.lvUpdateList);
            this.panel1.Controls.Add(this.pbDownFile);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(120, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 240);
            this.panel1.TabIndex = 2;
            // 
            // lvUpdateList1
            // 
            this.lvUpdateList1.Location = new System.Drawing.Point(260, 174);
            this.lvUpdateList1.Name = "lvUpdateList1";
            this.lvUpdateList1.Size = new System.Drawing.Size(121, 20);
            this.lvUpdateList1.TabIndex = 10;
            this.lvUpdateList1.UseCompatibleStateImageBehavior = false;
            this.lvUpdateList1.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "正在检查更新，请稍候...";
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 8);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // lvUpdateList
            // 
            this.lvUpdateList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chFileName,
            this.chVersion,
            this.chProgress});
            this.lvUpdateList.FullRowSelect = true;
            this.lvUpdateList.Location = new System.Drawing.Point(3, 48);
            this.lvUpdateList.Name = "lvUpdateList";
            this.lvUpdateList.Size = new System.Drawing.Size(375, 146);
            this.lvUpdateList.TabIndex = 6;
            this.lvUpdateList.UseCompatibleStateImageBehavior = false;
            this.lvUpdateList.View = System.Windows.Forms.View.Details;
            this.lvUpdateList.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lvUpdateList_MouseMove);
            this.lvUpdateList.MouseLeave += new System.EventHandler(this.lvUpdateList_MouseLeave);
            // 
            // chFileName
            // 
            this.chFileName.Text = "组件名";
            this.chFileName.Width = 123;
            // 
            // chVersion
            // 
            this.chVersion.Text = "版本号";
            this.chVersion.Width = 106;
            // 
            // chProgress
            // 
            this.chProgress.Text = "进度";
            this.chProgress.Width = 116;
            // 
            // pbDownFile
            // 
            this.pbDownFile.Location = new System.Drawing.Point(3, 200);
            this.pbDownFile.Name = "pbDownFile";
            this.pbDownFile.Size = new System.Drawing.Size(375, 17);
            this.pbDownFile.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(381, 8);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.linkLabel1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Location = new System.Drawing.Point(8, 264);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(112, 24);
            this.panel2.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 208);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "官方网站：";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(4, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "感谢使用在线升级";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(144, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "夜空团队";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(210, 208);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(250, 16);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.chinetsoft.com";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(184, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "   欢迎继续关注我们的产品。";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(312, 66);
            this.label2.TabIndex = 10;
            this.label2.Text = "   程序更新完成!\r\n\r\n   点击\"完成\"按钮，程序会自动重新启动系统。";
            // 
            // groupBox3
            // 
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(112, 8);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(0, 32);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 8);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // tip
            // 
            this.tip.AutoPopDelay = 5000;
            this.tip.InitialDelay = 500;
            this.tip.OwnerDraw = true;
            this.tip.ReshowDelay = 100;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(269, 264);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "下一步(&N)";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(410, 263);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取 消(&C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(138, 263);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 9;
            this.btnFinish.Text = "完成(&F)";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(220, 262);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmUpdate
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(513, 301);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "自动更新";
            this.Load += new System.EventHandler(this.FrmUpdate_Load);
            this.Shown += new System.EventHandler(this.FrmUpdate_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private string updateUrl = string.Empty;
		private string tempUpdatePath = string.Empty;
        private string tempUpdatePath1 = string.Empty;
		XmlFiles updaterXmlFiles = null;
		private int availableUpdate = 0;
		bool isRun = false;
		string mainAppExe = "";

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FrmUpdate());
        }

        #region Load事件
        private void FrmUpdate_Load(object sender, System.EventArgs e)
		{
			
			panel2.Visible = false;
			btnFinish.Visible = false;
            btnNext.Visible = false;
            btnClose.Visible = false;

			
        }

        #endregion

        private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
			Application.ExitThread();
			Application.Exit();
		}
        
        //点击"下一步"要执行的动作
		private void btnNext_Click(object sender, System.EventArgs e)
		{
            Thread threadDown = new Thread(new ThreadStart(DownUpdateFile));
            threadDown.IsBackground = true;
            threadDown.Start();

            btnNext.Enabled = false;
		}

        //下载可更新的文件
		private void DownUpdateFile()
		{
			mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
			Process [] allProcess = Process.GetProcesses();
			foreach(Process p in allProcess)
			{
				
				if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower() )
				{
					for(int i=0;i<p.Threads.Count;i++)
						p.Threads[i].Dispose();
					p.Kill();
					isRun = true;
					//break;
				}
			}
			WebClient wcClient = new WebClient();
            for (int i = 0; i < this.lvUpdateList1.Items.Count; i++)
            {
                string UpdateFile = lvUpdateList1.Items[i].Text.Trim();
                string updateFileUrl = updateUrl + lvUpdateList1.Items[i].Text.Trim();
                long fileLength = 0;

                WebRequest webReq = WebRequest.Create(updateFileUrl);
                WebResponse webRes = webReq.GetResponse();
                fileLength = webRes.ContentLength;

                label1.Text = "正在下载更新文件,请稍后...";
                pbDownFile.Value = 0;
                pbDownFile.Maximum = (int)fileLength;

                try
                {
                    Stream srm = webRes.GetResponseStream();
                    StreamReader srmReader = new StreamReader(srm);
                    byte[] bufferbyte = new byte[fileLength];
                    int allByte = (int)bufferbyte.Length;
                    int startByte = 0;
                    while (fileLength > 0)
                    {
                        Application.DoEvents();
                        int downByte = srm.Read(bufferbyte, startByte, allByte);
                        if (downByte == 0) { break; };
                        startByte += downByte;
                        allByte -= downByte;
                        pbDownFile.Value += downByte;

                        float part = (float)startByte / 1024;
                        float total = (float)bufferbyte.Length / 1024;
                        int percent = Convert.ToInt32((part / total) * 100);

                        this.lvUpdateList.Items[i].SubItems[2].Text = percent.ToString() + "%";

                    }

                    string tempPath = tempUpdatePath + UpdateFile;
                    CreateDirtory(tempPath);
                    FileStream fs = new FileStream(tempPath, FileMode.OpenOrCreate, FileAccess.Write);
                    fs.Write(bufferbyte, 0, bufferbyte.Length);
                    srm.Close();
                    srmReader.Close();
                    fs.Close();
                }
                catch (WebException ex)
                {
                    MessageBox.Show("更新文件下载失败！" + ex.Message.ToString(), "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
			InvalidateControl();
            //this.Cursor = Cursors.Default;
		}

		//创建目录
		private void CreateDirtory(string path)
		{
			if(!File.Exists(path))
			{
				string [] dirArray = path.Split('\\'); 
				string temp = string.Empty;
				for(int i = 0;i<dirArray.Length - 1;i++)
				{
					temp += dirArray[i].Trim() + "\\";
					if(!Directory.Exists(temp))
						Directory.CreateDirectory(temp);
				}
			}
		}

		//复制文件;
		public void CopyFile(string sourcePath,string objPath)
		{
//			char[] split = @"\".ToCharArray();
			if(!Directory.Exists(objPath))
			{
				Directory.CreateDirectory(objPath);
			}
			string[] files = Directory.GetFiles(sourcePath);
			for(int i=0;i<files.Length;i++)
			{
				string[] childfile = files[i].Split('\\');
				File.Copy(files[i],objPath + @"\" + childfile[childfile.Length-1],true);
			}
			string[] dirs = Directory.GetDirectories(sourcePath);
			for(int i=0;i<dirs.Length;i++)
			{
				string[] childdir = dirs[i].Split('\\');
				CopyFile(dirs[i],objPath + @"\" + childdir[childdir.Length-1]);
			}
		} 

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			//打开艾软国际首页
			System.Diagnostics.Process.Start("http://chinetsoft.d209.cnaaa5.com");
		}

		//点击完成复制更新文件到应用程序目录
		private void btnFinish_Click(object sender, System.EventArgs e)
		{
			
			this.Close();
			this.Dispose();
			try
			{
				CopyFile(tempUpdatePath,Directory.GetCurrentDirectory() + "\\..\\");
				System.IO.Directory.Delete(tempUpdatePath,true);

                CopyFile(tempUpdatePath1, Directory.GetCurrentDirectory() + "\\..\\");
                System.IO.Directory.Delete(tempUpdatePath1, true);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}
			if(true == this.isRun) Process.Start(".\\ISoft.exe");
		}
		
		//更新完毕重新绘制窗体部分控件属性
		private void InvalidateControl()
		{
			panel2.Location = panel1.Location;
			panel2.Size = panel1.Size;
			panel1.Visible = false;
			panel2.Visible = true;

			btnNext.Visible = false;
			btnCancel.Visible = false;
			btnFinish.Location = btnCancel.Location;
			btnFinish.Visible = true;
		}

        //检查无更新重新绘制窗体部分控件属性
        private void InvalidateControl1()
        {
            panel2.Location = panel1.Location;
            panel2.Size = panel1.Size;
            panel1.Visible = false;

            label2.Text = "   恭喜，您的程序已经是最新版！";

            panel2.Visible = true;

            

            btnCancel.Visible = false;
            btnClose.Location = btnCancel.Location;
            btnClose.Visible = true;
        }

		//判断主应用程序是否正在运行
		private bool IsMainAppRun()
		{
			string mainAppExe = updaterXmlFiles.GetNodeValue("//EntryPoint");
			bool isRun = false;
			Process [] allProcess = Process.GetProcesses();
			foreach(Process p in allProcess)
			{
				
				if (p.ProcessName.ToLower() + ".exe" == mainAppExe.ToLower() )
				{
					isRun = true;
					//break;
				}
			}
			return isRun;
		}

        //显示更新详细信息
        private void lvUpdateList_MouseMove(object sender, MouseEventArgs e)
        {

            ListViewItem item = lvUpdateList.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                tip.Show(lvUpdateList.Items[item.Index].SubItems[3].Text, lvUpdateList, new Point(e.X + 20, e.Y + 20), 15000);
                tip.Active = true;
            }
            else
            {
                tip.Active = false;
            }
        }

        //窗体显示之后开始检查是否有更新
        private void FrmUpdate_Shown(object sender, EventArgs e)
        {
            Thread threadCheck = new Thread(new ThreadStart(XMLCheckUpdate));
            threadCheck.IsBackground = true;
            threadCheck.Start();
        }

        //对比XML文件检查是否有升级条目
        private void XMLCheckUpdate()
        {
            label1.Text = "正在检查更新，请稍候...";
            string localXmlFile = Application.StartupPath + "\\Update\\UpdateList.xml";
            string serverXmlFile = string.Empty;


            try
            {
                //从本地读取更新配置文件信息
                updaterXmlFiles = new XmlFiles(localXmlFile);
            }
            catch
            {
                MessageBox.Show("本地配置文件出错!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            //获取服务器地址
            updateUrl = updaterXmlFiles.GetNodeValue("//Url");

            AppUpdater appUpdater = new AppUpdater();
            appUpdater.UpdaterUrl = updateUrl + "/UpdateList.xml";
            appUpdater.UpdaterUrl1 = updateUrl + "/Update.xml";


            //与服务器连接,下载更新配置文件
            try
            {
                tempUpdatePath = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\";//非配置文件临时文件顶级路径
                tempUpdatePath1 = Environment.GetEnvironmentVariable("Temp") + "\\" + "_" + updaterXmlFiles.FindNode("//Application").Attributes["applicationId"].Value + "_" + "y" + "_" + "x" + "_" + "m" + "_" + "\\" + "ISoft\\Update\\";//配置文件临时文件路径
                appUpdater.DownAutoUpdateFile(tempUpdatePath1);
            }
            catch
            {
                MessageBox.Show("与服务器连接失败,操作超时!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;

            }

            //获取更新文件列表
            Hashtable htUpdateFile = new Hashtable();

            serverXmlFile = tempUpdatePath1 + "\\UpdateList.xml";
            if (!File.Exists(serverXmlFile))
            {
                return;
            }

            availableUpdate = appUpdater.CheckForUpdate(serverXmlFile, localXmlFile, out htUpdateFile);
            if (availableUpdate > 0)
            {
                for (int i = 0; i < htUpdateFile.Count; i++)
                {
                    string[] fileArray = (string[])htUpdateFile[i];

                    lvUpdateList1.Items.Add(new ListViewItem(fileArray[0]));

                    if (fileArray[0] == "ISoft\\ISoft.exe")
                    {
                        fileArray[0] = "主程序";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\Update\\AutoUpdate.exe")
                    {
                        fileArray[0] = "自动更新程序";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\HotTools\\FileDestrory\\FileDestory.exe")
                    {
                        fileArray[0] = "文件粉碎机";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\HotTools\\Individuation\\Individuation.exe")
                    {
                        fileArray[0] = "个性化";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\HotTools\\RubbishCleaner\\RubbishCleaner.exe")
                    {
                        fileArray[0] = "垃圾清理";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\SysOptimizedTools\\OSSpeed\\OSSpeed.exe")
                    {
                        fileArray[0] = "系统加速";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\SysOptimizedTools\\ScanLargeFile\\ScanLargeFile.exe")
                    {
                        fileArray[0] = "大文件扫描";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\SysTools\\DefaultSet\\DefaultSet.exe")
                    {
                        fileArray[0] = "默认软件设置";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\SysTools\\ReadText\\ReadText.exe")
                    {
                        fileArray[0] = "语音朗读机";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\SysTools\\FileMonitor\\FileMonitor.exe")
                    {
                        fileArray[0] = "磁盘监视";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\SysTools\\TimeSyn\\TimeSyn.exe")
                    {
                        fileArray[0] = "时间同步助手";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\OtherTools\\VideoRec\\VideoRec.exe")
                    {
                        fileArray[0] = "视频录制器";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\OtherTools\\FileSplitAndJion\\FileSplitAndJion.exe")
                    {
                        fileArray[0] = "文件分割与合并";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\OtherTools\\CompTxt\\CompTxt.exe")
                    {
                        fileArray[0] = "文件内容比较器";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }

                    if (fileArray[0] == "ISoft\\AdvancedFunctions\\OtherTools\\ThunderEncodeDecode\\ThunderEncodeDecode.exe")
                    {
                        fileArray[0] = "迅雷地址解码器";
                        lvUpdateList.Items.Add(new ListViewItem(fileArray));
                        continue;
                    }
                }
            }
            if (availableUpdate == 0)
            {
                InvalidateControl1();
            }
            else
            {
                label1.Text = "以下为更新文件列表，请点击“下一步”开始更新";
                btnNext.Visible = true;
            }
        }

        private void lvUpdateList_MouseLeave(object sender, EventArgs e)
        {
            tip.Active = false;
        }
	}
}
