using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Management;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Collections;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Net;
using System.Threading;
using System.Drawing.Drawing2D;
using ControlExs;

namespace ISoft
{
    public partial class MainForm : FormEx
    {
        #region 信息初始化模块
 
        public MainForm():base()
        {
            InitializeComponent();

            ShowLoadInfo frm = new ShowLoadInfo();
            frm.Show();

            Application.DoEvents();

            Delay(1500);

            frm.proBar.Value = 1;

            frm.label2.Text = "正在启动系统线程...";

            Control.CheckForIllegalCrossThreadCalls = false;

            Delay(900);

            frm.proBar.Value = 2;
            frm.label2.Text = "正在检查操作系统...";

            SysCheck();

            Delay(900);

            frm.proBar.Value = 3;
            frm.label2.Text = "正在接管系统桌面...";

            DeskMonitor();

            Delay(900);

            frm.proBar.Value = 4;
            frm.label2.Text = "正在加载皮肤...";

            //try
            //{
            //    SkinLoad();
            //}
            //catch
            //{

            //}

            Delay(900);

            frm.proBar.Value = 5;
            frm.label2.Text = "正在检查U盘防御设置...";

            UdiskCheckLoad();

            Delay(900);

            frm.proBar.Value = 6;

            Delay(50);

            frm.label2.Text = "正在准备界面...";

            panelFirst.Visible = true;
            panelHardwareCheck.Visible = false;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = false;
            ToolPannel.Visible = false;

            Thread VThread = new Thread(new ThreadStart(VersionLoad));
            VThread.Start();

            Delay(400);

            frm.proBar.Value = 7;
            ////frm.label2.Text = "完成";

            ////Delay(500);
            ////以下可加快界面的显示速度
            ////建立画布
            //System.Drawing.Bitmap bitmap = new Bitmap(804, 421);
            ////在画布上创建对象
            //Graphics graphics = Graphics.FromImage(bitmap);
            //////开始画图
            ////graphics.DrawArc(new Pen(new SolidBrush(Color.Red)), 0, 0, 300, 200, 180, 180);
            ////在界面上输出
            //Graphics g = this.CreateGraphics();
            //g.DrawImage(bitmap, 0, 0);
            ////

            frm.Dispose();

            CurrDevices = Environment.GetLogicalDrives();
        }

        #region 延时函数 非Sleep

        [DllImport("kernel32.dll")]

        static extern uint GetTickCount();

        static void Delay(uint ms)
        {
            uint start = GetTickCount();
            while (GetTickCount() - start < ms)
            {
                Application.DoEvents();
            }
        }
        #endregion


        private void Form1_Load(object sender, EventArgs e)
        {
            SkinLoad();

            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
            
            //panelFirst.Visible = true;
            //panelHardwareCheck.Visible = false;
            //ProgressPannel.Visible = false;
            //OptimizationPanel.Visible = false;
            //UdiskPannel.Visible = false;
            //ToolPannel.Visible = false;
          
            //Thread VThread = new Thread(new ThreadStart(VersionLoad));
            //VThread.Start();

            //new Thread((ThreadStart)delegate()
            //    {
            //        Connecttimer_Tick(null, null);
            //    })
            //    .Start();


        }

        private void MainForm_Shown(object sender, EventArgs e)
        {

            Thread newThread = new Thread(new ThreadStart(myTimer));
            newThread.Start();
        }

        #region 接管桌面模块
        private void DeskMonitor()
        {
            fileSystemWatcher2.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            fileSystemWatcher2.EnableRaisingEvents = true;
        }
        #endregion


        private string DeskFilePath = null;

        private void fileSystemWatcher2_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (e.Name.Substring(e.Name.LastIndexOf("."), 4).Trim().ToLower() == ".pif")
                {
                    string info = (e.Name);

                    DeskFilePath = e.FullPath;

                    DeskMonitor frm = new DeskMonitor(info);

                    ChangeSkin(frm);

                    frm.DeleteFile += new StartDeleteFileHandle(DFDDel);

                    frm.Show();
                }
            }
            catch
            {
            }
        }

        private void fileSystemWatcher2_Renamed(object sender, RenamedEventArgs e)
        {
            if (e.Name.Substring(e.Name.LastIndexOf("."), 4).Trim().ToLower() == ".pif")
            {
                string info = (e.Name);

                DeskFilePath = e.FullPath;

                DeskMonitor frm = new DeskMonitor(info);

                ChangeSkin(frm);

                frm.DeleteFile += new StartDeleteFileHandle(DFDDel);

                frm.Show();
            }

        }

        private void DFDDel()
        {
            DFD();
        }

        private void DFD()
        {
            FileDestory file = new FileDestory( DeskFilePath);
        }

        #region U盘防御信息初始化模块
        private void UdiskCheckLoad()
        {
            XElement xe = XElement.Load("Config\\Config.xml");
            IEnumerable<XElement> elements = from PInfo in xe.Elements("Udisk")
                                             where PInfo.Attribute("ID").Value == "MonitorUdiskCheck"
                                             select PInfo;
            foreach (XElement element in elements)
            {
                UdiskMonitorFlag = Convert.ToInt32(element.Element("Mark").Value);
            }

            if (UdiskMonitorFlag == 1)
            {
                MarkPicBox.BackgroundImage = imageList1.Images[0];

                Marklkl.LinkColor = Color.LawnGreen;
                Marklkl.Text = "U盘防护已经开启";

                MonitorUdiskCheck.Checked = true;

                //if (ConnectFlag == 1)
                //{
                //    this.notifyIcon1.Text = "ISoft：U盘防护已经开启 成功连接至云服务器";
                //}
                //else
                //{
                //    this.notifyIcon1.Text = "ISoft：U盘防护已经开启 云服务器连接失败";
                //}
            }
            else
            {
                MarkPicBox.BackgroundImage = imageList1.Images[1];

                Marklkl.LinkColor = Color.Firebrick;
                Marklkl.Text = "U盘防护已经关闭";

                MonitorUdiskCheck.Checked = false;

                //if (ConnectFlag == 1)
                //{
                //    this.notifyIcon1.Text = "ISoft：U盘防护已经关闭 成功连接至云服务器";
                //}
                //else
                //{
                //    this.notifyIcon1.Text = "ISoft：U盘防护已经关闭 云服务器连接失败";
                //}

            }
        }
        #endregion

        #region 程序版本模块
        private void VersionLoad()
        {
            XElement xe = XElement.Load("Update\\Update.xml");
            IEnumerable<XElement> elements = from PInfo in xe.Elements("LocalInfo")
                                             where PInfo.Attribute("ID").Value == "W7"
                                             select PInfo;
            foreach (XElement element in elements)
            {
                CurrentVersion.Text = "当前软件版本：" + element.Element("LastVersion").Value + "  ";
                LatestUpdate.Text = "最后升级时间：" + element.Element("LastUpdateTime").Value + "      ";
            }

        }
        #endregion

        #region 对notifyIcon1的描述
        private void ShowNotiText()
        {
            if (UdiskMonitorFlag == 1)
            {
                if (ConnectFlag == 1)
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经开启 成功连接至云服务器";
                }
                else
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经开启 云服务器连接失败";
                }
            }
            else
            {
                if (ConnectFlag == 1)
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经关闭 成功连接至云服务器";
                }
                else
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经关闭 云服务器连接失败";
                }

            }
        }
        #endregion

        #region 判断Vista系统
        private void SysCheck()
        {
            if (System.Environment.OSVersion.Version.Major < 6)
            {
                QQMessageBox.Show(this, "请在vista及以上操作系统版本上运行", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                this.notifyIcon1.Visible = true;
            }
        }
        #endregion

        #region 云服务初始化模块

        int ConnectFlag = 0;

        public void myTimer()
        {
            System.Threading.Timer newTimer = new System.Threading.Timer(new TimerCallback(ConnectLoad));
            newTimer.Change(1000, 7000);
        }

        private void ConnectLoad(object obj)
        {
            if (IsWebResourceAvailable("http://chinetsoft.d209.cnaaa5.com"))
            {
                ConnPicBox.BackgroundImage = imageList2.Images[1];
                Connectlbl.Text = "已连接至ISoft云安全中心";

                ConnectFlag = 1;
            }
            else
            {
                ConnPicBox.BackgroundImage = imageList2.Images[0];
                Connectlbl.Text = "ISoft云安全中心连接失败";

                ConnectFlag = 0;
            }

            ShowNotiText();
        }
            

        private static bool IsWebResourceAvailable(string webResourceAddress)
        {
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(webResourceAddress));
                req.Method = "HEAD";
                req.Timeout = 5000;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                return (res.StatusCode == HttpStatusCode.OK);
            }
            catch (WebException wex)
            {
                System.Diagnostics.Trace.Write(wex.Message);
                return false;
            }
        }

        #endregion

        #endregion

        #region 绘制白色遮罩层模块

        #region Override

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!DesignMode)
                {
                    cp.ExStyle |= (int)WindowStyle.WS_CLIPCHILDREN;
                }
                return cp;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawFromAlphaMainPart(this, e.Graphics);
        }

        #endregion

        #region Private

        /// <summary>
        /// 绘制窗体主体部分白色透明层
        /// </summary>
        /// <param name="form"></param>
        /// <param name="g"></param>
        public static void DrawFromAlphaMainPart(Form form, Graphics g)
        {
            Color[] colors = 
            {
                Color.FromArgb(5, Color.White),
                Color.FromArgb(30, Color.White),
                Color.FromArgb(140, Color.White),
                Color.FromArgb(200, Color.White),
                Color.FromArgb(240, Color.White),
                Color.FromArgb(240, Color.White)
            };

            float[] pos = 
            {
                0.0f,
                0.19f,
                0.10f,
                0.95f,
                0.999f,
                1.0f       
            };

            ColorBlend colorBlend = new ColorBlend(6);
            colorBlend.Colors = colors;
            colorBlend.Positions = pos;

            RectangleF destRect = new RectangleF(0, 0, form.Width, form.Height);
            using (LinearGradientBrush lBrush = new LinearGradientBrush(destRect, colors[0], colors[5], LinearGradientMode.Vertical))
            {
                lBrush.InterpolationColors = colorBlend;
                g.FillRectangle(lBrush, destRect);
            }
        }


        private void SetStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        #endregion

        #endregion 

        #region  换肤模块
        private void btChangeShow_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "图片文件(*.jpg,*.bmp,*.png|*.jpg;*.bmp;*.png)";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.BackgroundImage = Image.FromFile(openFileDialog1.FileName);

                XElement xe = XElement.Load("Skin\\SkinConfig.xml");
                IEnumerable<XElement> elements = from element in xe.Elements("SC")
                                                 where element.Attribute("ID").Value == "Skin"
                                                 select element;
                if (elements.Count() > 0)
                {
                    XElement newXE = elements.First();
                    newXE.SetAttributeValue("ID", "Skin");
                    newXE.ReplaceNodes(
                        new XElement("Path", openFileDialog1.FileName)
                        );
                }
                xe.Save("Skin\\SkinConfig.xml");
            }
        }           

        private void SkinLoad()
        {
            try
            {
                this.BackgroundImage = Image.FromFile(Skin());

                //Thread oThread = new Thread(new ThreadStart(ConnectLoad));
                //oThread.Start();
            }
            catch
            {
                this.BackgroundImage = Image.FromFile(".\\Skin\\DefaultSkin.jpg");

                QQMessageBox.Show(this, "检测到皮肤配置错误，系统还原为默认皮肤", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);

                XElement xe = XElement.Load("Skin\\SkinConfig.xml");
                IEnumerable<XElement> elements = from element in xe.Elements("SC")
                                                 where element.Attribute("ID").Value == "Skin"
                                                 select element;
                if (elements.Count() > 0)
                {
                    XElement newXE = elements.First();
                    newXE.SetAttributeValue("ID", "Skin");
                    newXE.ReplaceNodes(
                        new XElement("Path", ".\\Skin\\DefaultSkin.jpg")
                        );
                }
                xe.Save("Skin\\SkinConfig.xml");

                //Thread oThread = new Thread(new ThreadStart(ConnectLoad));
                //oThread.Start();
            }
        }

        private string Skin()
        {
            string s = null;

            XElement xe = XElement.Load("Skin\\SkinConfig.xml");
            IEnumerable<XElement> elements = from PInfo in xe.Elements("SC")
                                             where PInfo.Attribute("ID").Value == "Skin"
                                             select PInfo;
            foreach (XElement element in elements)
            {
                s = element.Element("Path").Value;
            }
            return s;
        }

        #region 右下角窗体换肤模块

        private void ChangeSkin(Form fm)
        {
            try
            {
                fm.BackgroundImage = Image.FromFile(Skin());

            }
            catch
            {
                fm.BackgroundImage = Image.FromFile(".\\Skin\\DefaultSkin.bmp");
            }
        }
        #endregion



        #endregion

        #region 硬件检测模块
        private void btHardwareCheck_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
                this.WindowState = FormWindowState.Normal;

            if (this.Visible == false)
                this.Visible = true;

            btHardwareCheck.Select();

            //SetFirstPanel();
            panelFirst.Visible = false;
            panelHardwareCheck.Visible = true;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = false;
            ToolPannel.Visible = false;

            if (treeView1.Nodes.Count == 0)
            {
                SpecificCheck();
            }
        }

        #region 详细的硬件检测

        private void SpecificCheck()
        {
            CheckForIllegalCrossThreadCalls = false;
            TreeNode tn1 = new TreeNode("Windows");
            TreeNode tn2 = new TreeNode("CPU与主板");
            TreeNode tn3 = new TreeNode("视频设备");
            TreeNode tn4 = new TreeNode("音频设备");
            TreeNode tn5 = new TreeNode("存储设备");
            TreeNode tn6 = new TreeNode("网络设备");
            TreeNode tn8 = new TreeNode("总线与接口");
            TreeNode tn9 = new TreeNode("输入设备");
            TreeNode tn10 = new TreeNode("打印与传真");


            #region Windows父节点的子节点
            tn1.Nodes.Add("Windows信息");
            tn1.Nodes.Add("Windows用户");
            tn1.Nodes.Add("用户组别");
            tn1.Nodes.Add("当前进程");
            tn1.Nodes.Add("系统服务");
            tn1.Nodes.Add("系统驱动");
            #endregion

            #region CPU与主板父节点的子节点
            tn2.Nodes.Add("中央处理器");
            tn2.Nodes.Add("主板");
            tn2.Nodes.Add("BIOS信息");
            #endregion

            #region 视频设备父节点的子节点
            tn3.Nodes.Add("显卡");
            #endregion

            #region 存储设备父节点的子节点
            tn5.Nodes.Add("物理内存");
            tn5.Nodes.Add("磁盘");
            #endregion


            tn6.Nodes.Add("网络适配器");
            tn6.Nodes.Add("网络协议");

            tn8.Nodes.Add("串口");
            tn8.Nodes.Add("IDE控制器");
            tn8.Nodes.Add("软驱控制器");
            tn8.Nodes.Add("USB控制器");
            tn8.Nodes.Add("SCSI控制器");
            tn8.Nodes.Add("PCMCIA卡控制器");
            tn8.Nodes.Add("1394控制器");
            tn8.Nodes.Add("即插即用设备");

            tn9.Nodes.Add("鼠标");
            tn9.Nodes.Add("键盘");


            treeView1.Nodes.Add(tn1);
            treeView1.Nodes.Add(tn10);
            treeView1.Nodes.Add(tn2);
            treeView1.Nodes.Add(tn3);
            treeView1.Nodes.Add(tn4);
            treeView1.Nodes.Add(tn5);
            treeView1.Nodes.Add(tn6);
            treeView1.Nodes.Add(tn8);
            treeView1.Nodes.Add(tn9);
        }

        public string selectTxt;
        private void GetInfo()
        {
            PublicClass pc = new PublicClass();
            switch (selectTxt)
            {
                case "Windows信息":
                    pc.getInfo1(listView1);
                    break;
                case "Windows用户":
                    pc.InsertInfo("Win32_UserAccount", ref listView1, true);
                    break;
                case "用户组别":
                    pc.InsertInfo("Win32_Group", ref listView1, true);
                    break;
                case "当前进程":
                    pc.InsertInfo("Win32_Process", ref listView1, true);
                    break;
                case "系统服务":
                    pc.InsertInfo("Win32_Service", ref listView1, true);
                    break;
                case "系统驱动":
                    pc.InsertInfo("Win32_SystemDriver", ref listView1, true);
                    break;
                case "中央处理器":
                    pc.InsertInfo("Win32_Processor", ref listView1, true);
                    break;
                case "主板":
                    pc.InsertInfo("Win32_BaseBoard", ref listView1, true);
                    break;
                case "BIOS信息":
                    pc.InsertInfo("Win32_BIOS", ref listView1, true);
                    break;
                case "显卡":
                    pc.InsertInfo("Win32_VideoController", ref listView1, true);
                    break;
                case "音频设备":
                    pc.InsertInfo("Win32_SoundDevice", ref listView1, true);
                    break;
                case "物理内存":
                    pc.InsertInfo("Win32_PhysicalMemory", ref listView1, true);
                    break;
                case "磁盘":
                    pc.InsertInfo("Win32_LogicalDisk", ref listView1, true);
                    break;
                case "网络适配器":
                    pc.InsertInfo("Win32_NetworkAdapter", ref listView1, true);
                    break;
                case "网络协议":
                    pc.InsertInfo("Win32_NetworkProtocol", ref listView1, true);
                    break;
                case "打印与传真":
                    pc.InsertInfo("Win32_Printer", ref listView1, true);
                    break;
                case "键盘":
                    pc.InsertInfo("Win32_Keyboard", ref listView1, true);
                    break;
                case "鼠标":
                    pc.InsertInfo("Win32_PointingDevice", ref listView1, true);
                    break;
                case "串口":
                    pc.InsertInfo("Win32_SerialPort", ref listView1, true);
                    break;
                case "IDE控制器":
                    pc.InsertInfo("Win32_IDEController", ref listView1, true);
                    break;
                case "软驱控制器":
                    pc.InsertInfo("Win32_FloppyController", ref listView1, true);
                    break;
                case "USB控制器":
                    pc.InsertInfo("Win32_USBController", ref listView1, true);
                    break;
                case "SCSI控制器":
                    pc.InsertInfo("Win32_SCSIController", ref listView1, true);
                    break;
                case "PCMCIA卡控制器":
                    pc.InsertInfo("Win32_PCMCIAController", ref listView1, true);
                    break;
                case "1394控制器":
                    pc.InsertInfo("Win32_1394Controller", ref listView1, true);
                    break;
                case "即插即用设备":
                    pc.InsertInfo("Win32_PnPEntity", ref listView1, true);
                    break;


            }

        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            listView1.Items.Clear();
            selectTxt = treeView1.SelectedNode.Text;
            GetInfo();
        }
        #endregion

        #endregion
        
        #region 首页硬件检测

        private void btFirst_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
                this.WindowState = FormWindowState.Normal;

            if (this.Visible == false)
                this.Visible = true;

            btFirst.Select();

            //SetFirstPanel();
            panelFirst.Visible = true;
            panelHardwareCheck.Visible = false;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = false;
            ToolPannel.Visible = false;

            //以下可加快界面的显示速度
            //建立画布
            System.Drawing.Bitmap bitmap = new Bitmap(840, 600);
            //在画布上创建对象
            Graphics graphics = Graphics.FromImage(bitmap);
            ////开始画图
            //graphics.DrawArc(new Pen(new SolidBrush(Color.Red)), 0, 0, 300, 200, 180, 180);
            //在界面上输出
            Graphics g = this.CreateGraphics();
            g.DrawImage(bitmap, 0, 0);
            //
            
        }

        private void btViewSpecificInfo_Click(object sender, EventArgs e)
        {
            btHardwareCheck.Select();

            panelFirst.Visible = false;
            panelHardwareCheck.Visible = true;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = false;
            ToolPannel.Visible = false;

            if (treeView1.Nodes.Count == 0)
            {
                SpecificCheck();
            }
        }
      
        //首页的硬件检测
        private void InitWindows()
        {
            //OSCheck.ForeColor = Color.White;
            proOSCheck.Value = 1;
            OSCheck.Text = "操作系统：正在检测...";
            OSCheck.Visible = true;
            //Delay(1);
            OSCheck.Text = "操作系统：" + Environment.OSVersion.VersionString;

            proOSCheck.Value = 2;
            CPUCheck.Text = "处理器：正在检测...";
            CPUCheck.Visible = true;
            Delay(1);
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from  Win32_Processor");
            string sharename = "";
            foreach (ManagementObject share in searcher.Get())
            {
                sharename = share["Name"].ToString();
            }

            //CPUCheck.ForeColor = Color.White;
            CPUCheck.Text = "处理器：" + sharename;

            proOSCheck.Value = 3;
            MemCheck.Text = "内存：正在检测...";
            MemCheck.Visible = true;
            Delay(3);
            Microsoft.VisualBasic.Devices.Computer My = new Microsoft.VisualBasic.Devices.Computer();

            //MemCheck.ForeColor = Color.White;
            MemCheck.Text = "内存：" + (My.Info.TotalPhysicalMemory / 1024 / 1024).ToString() + "M";

            proOSCheck.Value = 4;
            GPUCheck.Text = "显卡：正在检测...";
            GPUCheck.Visible = true;
            ManagementObjectSearcher searcher1 = new ManagementObjectSearcher("select * from  Win32_VideoController");
            string sharename1 = "";
            foreach (ManagementObject share in searcher1.Get())
            {
                sharename1 = share["Name"].ToString();
            }

            //GPUCheck.ForeColor = Color.White;
            GPUCheck.Text = "显卡：" + sharename1;

            proOSCheck.Value = 5;
            SoundCheck.Text = "音频设备：正在检测...";
            SoundCheck.Visible = true;
            Delay(3);
            ManagementObjectSearcher searcher2 = new ManagementObjectSearcher("select * from  Win32_SoundDevice");
            string sharename2 = "";
            foreach (ManagementObject share in searcher2.Get())
            {
                sharename2 = share["Name"].ToString();
            }

            //SoundCheck.ForeColor = Color.White;
            SoundCheck.Text = "音频设备：" + sharename2;

            proOSCheck.Value = 6;
            StartTime.Text = "开机时间：正在检测...";
            StartTime.Visible = true;
            Delay(3);
            String MyInfo1 = "";
            ManagementObjectSearcher MySearcher1 = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject MyObject in MySearcher1.Get())
            {
                MyInfo1 += MyObject["LastBootUpTime"].ToString().Substring(0, 8);
            }
            MyInfo1 = MyInfo1.Insert(4, "-");
            MyInfo1 = MyInfo1.Insert(7, "-");

            //StartTime.ForeColor = Color.White;
            StartTime.Text = "开机时间：" + MyInfo1;

            proOSCheck.Value = 7;
            OSSetup.Text = "系统安装日期：正在检测...";
            OSSetup.Visible = true;
            Delay(3);
            string MyInfo = "";
            ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject MyObject in MySearcher.Get())
            {
                MyInfo += MyObject["InstallDate"].ToString().Substring(0, 8);
            }
            MyInfo = MyInfo.Insert(4, "-");
            MyInfo = MyInfo.Insert(7, "-");

            //OSSetup.ForeColor = Color.White;
            OSSetup.Text = "系统安装日期：" + MyInfo;

            btViewSpecificInfo.Visible = true;

            clockLoadingProgress1.Stop();
            proOSCheck.Visible = false;
            OSChecklb.Text = "电脑系统检测完毕,请" + "\"" + "查看详细" + "\"";
            goBacklbl.Visible = true;
        }
        #endregion

        #region 进程模块
        private void btProgress_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
                this.WindowState = FormWindowState.Normal;

            if (this.Visible == false)
                this.Visible = true;

            btProgress.Select();

            //SetFirstPanel();
            panelFirst.Visible = false;
            panelHardwareCheck.Visible = false;
            ProgressPannel.Visible = true;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = false;
            ToolPannel.Visible = false;


            Thread ProcessInfo = new Thread(new ThreadStart(ProcessInfoTime));
            ProcessInfo.Start();

            Thread WindowsInfo = new Thread(new ThreadStart(WindowsInfoTime));
            WindowsInfo.Start();

        }

        private void ProcessInfoTime()
        {
            System.Threading.Timer newProcessInfoTimer = new System.Threading.Timer(new TimerCallback(getProcessInfo));
            newProcessInfoTimer.Change(0, 8000);
        }

        private void WindowsInfoTime()
        {
            System.Threading.Timer newWindowsInfoTimer = new System.Threading.Timer(new TimerCallback(getWindowsInfo));
            newWindowsInfoTimer.Change(0, 2000);
        }



        #region 进程管理

        private void getProcessInfo(object obj)
        {
            try
            {
                listView2.Items.Clear();
                Process[] MyProcesses = Process.GetProcesses();
                string[] Minfo = new string[6];
                foreach (Process MyProcess in MyProcesses)
                {
                    Minfo[0] = MyProcess.ProcessName;
                    Minfo[1] = MyProcess.Id.ToString();
                    Minfo[2] = MyProcess.Threads.Count.ToString();
                    Minfo[3] = MyProcess.BasePriority.ToString();
                    Minfo[4] = Convert.ToString(MyProcess.WorkingSet / 1024) + "K";
                    Minfo[5] = Convert.ToString(MyProcess.VirtualMemorySize / 1024) + "K";
                    ListViewItem lvi = new ListViewItem(Minfo, "process");
                    listView2.Items.Add(lvi);
                }
            }
            catch { }
        }
        private void getWindowsInfo(object obj)
        {
            try
            {
                listView3.Items.Clear();
                Process[] MyProcesses = Process.GetProcesses();
                string[] Minfo = new string[6];
                foreach (Process MyProcess in MyProcesses)
                {
                    if (MyProcess.MainWindowTitle.Length > 0)
                    {
                        Minfo[0] = MyProcess.MainWindowTitle;
                        Minfo[1] = MyProcess.Id.ToString();
                        Minfo[2] = MyProcess.ProcessName;
                        Minfo[3] = MyProcess.StartTime.ToString();
                        ListViewItem lvi = new ListViewItem(Minfo, "process");
                        listView3.Items.Add(lvi);
                    }
                }
            }
            catch { }
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            getProcessInfo(null);
        }

        private void 结束进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (QQMessageBox.Show(this,"警告:终止进程会导致不希望发生的结果，\r包括数据丢失和系统不稳定。在被终止前，\r进程将没有机会保存其状态和数据。确实\r想终止该进程吗?", "任务管理器警告", QQMessageBoxIcon.Warning,QQMessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    string ProcessName = listView2.SelectedItems[0].Text;
                    Process[] MyProcess = Process.GetProcessesByName(ProcessName);
                    MyProcess[0].Kill();
                    getProcessInfo(null);
                }
                else
                { }
            }
            catch
            {
                string ProcessName = listView2.SelectedItems[0].Text;
                Process[] MyProcess1 = Process.GetProcessesByName(ProcessName);
                Process MyProcess = new Process();
                //设定程序名
                MyProcess.StartInfo.FileName = "cmd.exe";
                //关闭Shell的使用
                MyProcess.StartInfo.UseShellExecute = false;
                //重定向标准输入
                MyProcess.StartInfo.RedirectStandardInput = true;
                //重定向标准输出
                MyProcess.StartInfo.RedirectStandardOutput = true;
                //重定向错误输出
                MyProcess.StartInfo.RedirectStandardError = true;
                //设置不显示窗口
                MyProcess.StartInfo.CreateNoWindow = true;
                //执行强制结束命令
                MyProcess.Start();
                MyProcess.StandardInput.WriteLine("ntsd -c q -p " + (MyProcess1[0].Id).ToString());
                MyProcess.StandardInput.WriteLine("Exit");
                getProcessInfo(null);
            }
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getWindowsInfo(null);
        }

        private void 终止进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (QQMessageBox.Show(this,"警告:终止进程会导致不希望发生的结果，\r包括数据丢失和系统不稳定。在被终止前，\r进程将没有机会保存其状态和数据。确实\r想终止该进程吗?", "任务管理器警告", QQMessageBoxIcon.Warning,QQMessageBoxButtons.OKCancel) == DialogResult.Yes)
                {
                    string ProcessName = listView3.SelectedItems[0].SubItems[2].Text.Trim();
                    Process[] MyProcess = Process.GetProcessesByName(ProcessName);
                    MyProcess[0].Kill();
                    listView2.Items.Clear();
                    getWindowsInfo(null);
                }
                else
                { }
            }
            catch
            {
                QQMessageBox.Show(this, "请选择要终止的进程", "提示", QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
            }
        }

        private void 转到进程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listView2.Items.Count; i++)
                    listView2.Items[i].Selected = false;

                string ProcessName = listView3.SelectedItems[0].SubItems[2].Text.Trim();
                for (int i = 0; i < listView2.Items.Count; i++)
                {
                    if (listView2.Items[i].SubItems[0].Text == ProcessName)
                    {
                        tabPage2.Parent = null;
                        tabPage1.Parent = this.ProgressTab;
                        listView2.Items[i].Selected = true;
                        break;
                    }
                }
                tabPage2.Parent = this.ProgressTab;
            }
            catch
            {
                QQMessageBox.Show(this, "请选择要跳转的进程", "提示", QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
            }

        }

        #endregion

        #endregion

        #region 系统优化模块
        private void btOSgo_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
                this.WindowState = FormWindowState.Normal;

            if (this.Visible == false)
                this.Visible = true;

            btOSgo.Select();

            //SetFirstPanel();
            panelFirst.Visible = false;
            panelHardwareCheck.Visible = false;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = true;
            UdiskPannel.Visible = false;
            ToolPannel.Visible = false;
        }

        #region 系统优化

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                string pp = "regedit /e " + Environment.SystemDirectory.ToString() + "\\backup.reg";
                myProcess.StandardInput.WriteLine(pp);
                QQMessageBox.Show(this, "注册表备份成功", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
            }
            catch
            {
                System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                string pp = "regedit /e " + Environment.SystemDirectory.ToString() + "\\backup.reg";
                myProcess.StandardInput.WriteLine(pp);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                string pp = "regedit /s " + Environment.SystemDirectory.ToString() + "\\backup.reg";
                myProcess.StandardInput.WriteLine(pp);
                QQMessageBox.Show(this, "注册表还原成功", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
            }
            catch
            {
                System.Diagnostics.Process myProcess = new System.Diagnostics.Process();
                myProcess.StartInfo.FileName = "cmd.exe";
                myProcess.StartInfo.UseShellExecute = false;
                myProcess.StartInfo.RedirectStandardInput = true;
                myProcess.StartInfo.RedirectStandardOutput = true;
                myProcess.StartInfo.RedirectStandardError = true;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.Start();
                string pp = "regedit /s " + Environment.SystemDirectory.ToString() + "\\backup.reg";
                myProcess.StandardInput.WriteLine(pp);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Checked == true)
                {
                    SetRegValue(listView1.Items[i].Text);
                }
            }

            QQMessageBox.Show(this, "优化系统成功", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);

        }

        private void SetRegValue(string str)
        {
            RegistryKey reg;
            switch (str)
            {
                case "开机和关机":
                    reg = Registry.CurrentUser;
                    reg = reg.CreateSubKey("SYSTEM\\CurrentControlSet\\Control");
                    reg.SetValue("WaitToKillServiceTimeout", 1000);
                    reg.Close();
                    break;
                case "菜单":
                    reg = Registry.CurrentUser;
                    reg = reg.CreateSubKey("Control Panel\\Desktop");
                    reg.SetValue("MenuShowDelay", 40);
                    reg.Close();
                    break;
                case "程序":
                    reg = Registry.LocalMachine;
                    reg = reg.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\FileSystem");
                    reg.SetValue("ConfigFileAllocSize", "dword:000001f4");
                    reg.Close();
                    break;
                case "加快预读能力":
                    reg = Registry.LocalMachine;
                    reg = reg.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters");
                    reg.SetValue("EnablePrefetcher", 4, RegistryValueKind.DWord);
                    reg.Close();
                    break;
                case "自动清除内存中多余的DLL资料":
                    reg = Registry.LocalMachine;
                    reg = reg.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer");
                    reg.SetValue("AlwaysUnloadDLL", 1, RegistryValueKind.DWord);
                    reg.Close();
                    break;
                case "禁止远程修改注册表":
                    reg = Registry.LocalMachine;
                    reg = reg.CreateSubKey("SYSTEM\\CurrentControlSet\\Control\\SecurePipeServers\\winreg");
                    reg.SetValue("RemoteRegAccess", 1, RegistryValueKind.DWord);
                    reg.Close();
                    break;
                case "禁用系统还原":
                    reg = Registry.LocalMachine;
                    reg = reg.CreateSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\SystemRestore");
                    reg.SetValue("DisableSR", 1, RegistryValueKind.DWord);
                    reg.Close();
                    break;
                case "在桌面上显示系统版本":
                    reg = Registry.CurrentUser;
                    reg = reg.CreateSubKey("Control Panel\\Desktop");
                    reg.SetValue("PaintDesktopVersion", 1, RegistryValueKind.DWord);
                    reg.Close();
                    break;
                case "关机时自动关闭停止响应的程序":
                    reg = Registry.CurrentUser;
                    reg = reg.CreateSubKey("Control Panel\\Desktop");
                    reg.SetValue("AutoEndTasks", 1, RegistryValueKind.DWord);
                    reg.Close();
                    break;
            }
        }

        #endregion

        #endregion
        
        #region U盘防护模块

        private void btUcheck_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Normal)
                this.WindowState = FormWindowState.Normal;

            if (this.Visible == false)
                this.Visible = true;

            btUcheck.Select();

            //SetFirstPanel();
            panelFirst.Visible = false;
            panelHardwareCheck.Visible = false;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = true;
            ToolPannel.Visible = false;

        }

        private void ScanUdisk_Click(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            try
            {

                int i = 0;
                foreach (DriveInfo d in allDrives)
                {
                    if (d.DriveType == DriveType.Removable)
                    {
                        i = 1;
                        ScanU(d);
                        if (listView5.Items.Count == 0)
                        {
                            QQMessageBox.Show(this, "扫描完毕，未发现病毒", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
                            return;
                        }
                        else
                        {
                            QQMessageBox.Show(this, "扫描完毕，发现病毒！请及时清理", "警告", QQMessageBoxIcon.Warning, QQMessageBoxButtons.OK);
                            return;
                        }
                    }
                }
                if (i == 0)
                {
                    QQMessageBox.Show(this, "未检测到U盘", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                    return;
                }
            }
            catch
            {
                QQMessageBox.Show(this, "发生未知异常", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                return;
            }
            
        }

        public void ScanU(DriveInfo d)//查毒代码
        {
            listView5.Items.Clear();
            foreach (FileInfo f in d.RootDirectory.GetFiles())
            {
                f.Attributes = FileAttributes.Normal;
            }
            foreach (DirectoryInfo a in d.RootDirectory.GetDirectories())
            {
                a.Attributes = FileAttributes.Normal;
            }
            foreach (FileInfo f in d.RootDirectory.GetFiles())
            {
                if(f.Extension.ToLower() == ".lnk")
                {
                    string[] str =
					{
						f.Name,
                        "普通程序快捷方式",
						Convert.ToString(f.Length / 1024) + "K",
						f.LastWriteTime.ToString()
					};

                    ListViewItem item = new ListViewItem(str);
                    listView5.Items.Add(item);
                    item.Checked = true;
                }

                if(f.Extension.ToLower() == ".inf")
                {
                    string[] str = 
                    {
                        f.Name,
                        "初始化信息文件",
                        Convert.ToString(f.Length/1024) + "K",
                        f.LastWriteTime.ToString()
                    };
                     ListViewItem item = new ListViewItem(str);
                    listView5.Items.Add(item);
                    item.Checked = true;
                }

                if(f.Extension.ToLower() == ".vbs")
                {
                    string[] str = 
                    {
                        f.Name,
                        "脚本文件",
                        Convert.ToString(f.Length/1024) + "K",
                        f.LastWriteTime.ToString()
                    };
                     ListViewItem item = new ListViewItem(str);
                    listView5.Items.Add(item);
                    item.Checked = true;
                }

                if(f.Extension.ToLower() == ".exe")
                {
                    string[] str = 
                    {
                        f.Name,
                        "可执行文件",
                        Convert.ToString(f.Length/1024) + "K",
                        f.LastWriteTime.ToString()
                    };
                     ListViewItem item = new ListViewItem(str);
                    listView5.Items.Add(item);
                    item.Checked = true;
                }

                if(f.Extension.ToLower() == ".pif")
                {
                    string[] str = 
                    {
                        f.Name,
                        "MS-DOS程序快捷方式",
                        Convert.ToString(f.Length/1024) + "K",
                        f.LastWriteTime.ToString()
                    };
                     ListViewItem item = new ListViewItem(str);
                    listView5.Items.Add(item);
                    item.Checked = true;
                    
                }
            }
            if (listView5.Items.Count == 0)
                KillVirus.Enabled = false;
            else
                KillVirus.Enabled = true;
        }

        private void KillVirus_Click(object sender, EventArgs e)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {
                if (d.DriveType == DriveType.Removable)
                {
                    ClearnU(d);

                }
            }
        }


        #region U盘监视病毒扫描辅助模块
        private void SVS()
        {
            ShowUPannel(true);
            ScanUdisk_Click(null, null);
        }
        #endregion

        #region U盘文件监视模块

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {

            if (UdiskMonitorFlag == 1)
            {
                if (e.Name.Substring(e.Name.LastIndexOf("."), 4).Trim().ToLower() == ".lnk")
                {
                    string info = ("盘符： " + fileSystemWatcher1.Path + "\r\r文件： " + e.Name +
                        "\r\r病毒类型： 程序快捷方式" + "\r\r建议： 马上删除");
                    UdiskMonitor frm = new UdiskMonitor(info);

                    ChangeSkin(frm);

                    frm.StartVirusScan += new StartVirusScanHandle(SVS);

                    frm.Show();
                }

                if (e.Name.Substring(e.Name.LastIndexOf("."), 4).Trim().ToLower() == ".inf")
                {
                    string info = ("盘符： " + fileSystemWatcher1.Path + "\r\r文件： " + e.Name +
                        "\r\r病毒类型： 初始化信息文件" + "\r\r建议： 马上删除");

                    UdiskMonitor frm = new UdiskMonitor(info);

                    ChangeSkin(frm);

                    frm.StartVirusScan += new StartVirusScanHandle(SVS);

                    frm.Show();
                }

                if (e.Name.Substring(e.Name.LastIndexOf("."), 4).Trim().ToLower() == ".vbs")
                {
                    string info = ("盘符： " + fileSystemWatcher1.Path + "\r\r文件： " + e.Name +
                         "\r\r病毒类型： 脚本文件" + "\r\r建议： 马上删除");

                    UdiskMonitor frm = new UdiskMonitor(info);

                    ChangeSkin(frm);

                    frm.StartVirusScan += new StartVirusScanHandle(SVS);

                    frm.Show();
                }

                if (e.Name.Substring(e.Name.LastIndexOf("."), 4).Trim().ToLower() == ".exe")
                {
                    string info = ("盘符： " + fileSystemWatcher1.Path + "\r\r文件： " + e.Name +
                        "\r\r病毒类型： 可执行文件" + "\r\r建议： 马上删除");

                    UdiskMonitor frm = new UdiskMonitor(info);

                    ChangeSkin(frm);

                    frm.StartVirusScan += new StartVirusScanHandle(SVS);

                    frm.Show();
                }

                if (e.Name.Substring(e.Name.LastIndexOf("."), 4).Trim().ToLower() == ".pif")
                {
                    string info = ("盘符： " + fileSystemWatcher1.Path + "\r\r文件： " + e.Name +
                        "\r\r病毒类型： MS-DOS程序快捷方式" + "\r\r建议： 马上删除");

                    UdiskMonitor frm = new UdiskMonitor(info);

                    ChangeSkin(frm);

                    frm.StartVirusScan += new StartVirusScanHandle(SVS);

                    frm.Show();
                }
            }
        }
        #endregion
 
        public void ClearnU(DriveInfo d) //杀毒代码
        {

            for (int i = 0; i < listView5.Items.Count; i++)
            {
                if (listView5.Items[i].Checked == true)
                {
                    FileInfo delfile = new FileInfo(d.RootDirectory + listView5.Items[i].Text);
                    try
                    {
                        delfile.Delete();
                    }
                    catch
                    {
                        QQMessageBox.Show(this, "病毒清理失败，消息为：", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
                    }
                }
            }
            listView5.Items.Clear();
            ScanU(d);
            if (listView5.Items.Count == 0)
            {
                QQMessageBox.Show(this, "病毒已经全部清除", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
                return;
            }
            else
            {
                QQMessageBox.Show(this, "部分病毒清理失败，已提交至云服务器，请等待云服务处理", "提示", QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                return;
            }
        }

        int UdiskMonitorFlag = 0;

        private void UdiskCheckChange()
        {
            XElement xe = XElement.Load("Config\\Config.xml");
                IEnumerable<XElement> elements = from element in xe.Elements("Udisk")
                                                 where element.Attribute("ID").Value == "MonitorUdiskCheck"
                                                 select element;
                if (elements.Count() > 0)
                {
                    XElement newXE = elements.First();
                    newXE.SetAttributeValue("ID", "MonitorUdiskCheck");
                    newXE.ReplaceNodes(
                        new XElement("Mark", UdiskMonitorFlag.ToString())
                        );
                }
                xe.Save("Config\\Config.xml");
        }

        private void USetSave_Click(object sender, EventArgs e)
        {
            if (MonitorUdiskCheck.Checked == true)
            {
                UdiskMonitorFlag = 1;

                MarkPicBox.BackgroundImage = imageList1.Images[0];

                Marklkl.LinkColor = Color.LawnGreen;
                Marklkl.Text = "U盘防护已经开启";

                if (ConnectFlag == 1)
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经开启 成功连接至云服务器";
                }
                else
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经开启 云服务器连接失败";
                }

                UdiskCheckChange();
            }
            else
            {
                UdiskMonitorFlag = 0;

                MarkPicBox.BackgroundImage = imageList1.Images[1];

                Marklkl.LinkColor = Color.Firebrick;
                Marklkl.Text = "U盘防护已经关闭";

                if (ConnectFlag == 1)
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经关闭 成功连接至云服务器";
                }
                else
                {
                    this.notifyIcon1.Text = "ISoft：U盘防护已经关闭 云服务器连接失败";
                }

                UdiskCheckChange();
            }

            try
            {
                if (StopAutorunUdisk.Checked == true)
                {
                    RegistryKey reg;
                    reg = Registry.CurrentUser;
                    reg = reg.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
                    reg.SetValue("NoDriveTypeAutoRun", "dword:0000005b");
                    reg.Close();

                    Process[] explorers = Process.GetProcessesByName("explorer");
                    foreach (Process ex in explorers)
                    {
                        ex.Kill();
                    }

                }
            }
            catch
            {
                QQMessageBox.Show(this, "注册表读写错误", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                return;
            }

            try
            {
                if (RecoverShowCheck.Checked == true)
                {
                    string DiskFlag = null;
                    DriveInfo[] Drives = DriveInfo.GetDrives();
                    foreach (DriveInfo d in Drives)
                    {
                        if (d.DriveType == DriveType.Removable)
                        {
                            DiskFlag = d.ToString();
                        }
                    }
                    Process MyProcess = new Process();
                    //设定程序名
                    MyProcess.StartInfo.FileName = "cmd.exe";
                    //关闭Shell的使用
                    MyProcess.StartInfo.UseShellExecute = false;
                    //重定向标准输入
                    MyProcess.StartInfo.RedirectStandardInput = true;
                    //重定向标准输出
                    MyProcess.StartInfo.RedirectStandardOutput = true;
                    //重定向错误输出
                    MyProcess.StartInfo.RedirectStandardError = true;
                    //设置不显示窗口
                    MyProcess.StartInfo.CreateNoWindow = true;
                    //执行强制结束命令
                    MyProcess.Start();
                    MyProcess.StandardInput.WriteLine(DiskFlag.Substring(0, 2));
                    MyProcess.StandardInput.WriteLine("attrib -s -h *.* /s /d");
                    MyProcess.StandardInput.WriteLine("Exit");
                }
            }
            catch
            {
                QQMessageBox.Show(this, "发生未知错误，请确保U盘设备已经插入", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                return;
            }
            if (MonitorUdiskCheck.Checked == true || RecoverShowCheck.Checked == true)
                QQMessageBox.Show(this, "操作成功", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
            else
            {
                QQMessageBox.Show(this, "操作成功", "提示", QQMessageBoxIcon.OK, QQMessageBoxButtons.OK);
            }
        }

        string[] CurrDevices; //发生插入/拔出前有的设备
        string[] CurrDevices_; //发生插入/拔出后有的设备
        int CheckAutorunFlag = 0;//检测U盘里是否有autorun.inf可自执行文件，0表示无，1表示有

        //检测到U盘插入时窗体黄色闪烁提示
        #region 窗体黄色闪烁提示

        [DllImport("user32.dll")]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr handle, bool invert);

        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        } 

        public const UInt32 FLASHW_STOP = 0;
        public const UInt32 FLASHW_CAPTION = 1;
        public const UInt32 FLASHW_TRAY = 2;
        public const UInt32 FLASHW_ALL = 3;
        public const UInt32 FLASHW_TIMER = 4;
        public const UInt32 FLASHW_TIMERNOFG = 12; 

        private void FormTwinkle()
        {
            FLASHWINFO fInfo = new FLASHWINFO();

            fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
            fInfo.hwnd = this.Handle;
            fInfo.dwFlags = FLASHW_TRAY | FLASHW_TIMERNOFG;
            fInfo.uCount = UInt32.MaxValue;
            fInfo.dwTimeout = 0;
            FlashWindowEx(ref fInfo);
        }
        #endregion

        //U盘插入提示模块
        protected override void WndProc(ref  Message m)
        {
            const int WM_DEVICECHANGE = 0x219; //设备有变动（插入或拔出）
            const int WM_DEVICEARRVIAL = 0x8000; //设备有变动（插入）
            const int WM_DEVICEMOVECOMPLETE = 0x8004; //设备有变动 （拔出）
            switch (m.Msg)
            {
                case WM_DEVICECHANGE:
                    {
                        if (m.WParam.ToInt32() == WM_DEVICEARRVIAL)
                        {

                            if (UdiskMonitorFlag == 1)
                            {
                                listView5.Items.Clear();

                                FormTwinkle();//窗体黄色闪烁提示

                                string UMark = null;

                                UMark = this.doCheck(true);

                                try
                                {
                                    fileSystemWatcher1.Path = UMark;

                                    fileSystemWatcher1.EnableRaisingEvents = true;

                                    
                                }
                                catch
                                {
                                    QQMessageBox.Show(this, "发生未知错误", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                                }

                                string info = ("动作：有移动设备插入\r\r时间： "
                                    + DateTime.Now.ToString() + "\r\r盘符：" + UMark);                               
                                this.CurrDevices = Environment.GetLogicalDrives();//储存现有盘符
                                this.CurrDevices_ = null;                            

                                ShowUdisk formU = new ShowUdisk(info,CheckAutorunFlag);

                                ChangeSkin(formU);

                                formU.ShowUdiskPannel += new ShowUdiskPannelHandle(ShowUPannel);

                                formU.Show();

                                

                            }
                        }
                        if (m.WParam.ToInt32() == WM_DEVICEMOVECOMPLETE)
                        {
                            if (UdiskMonitorFlag == 1)
                            {
                                listView5.Items.Clear();

                                FormTwinkle();//窗体黄色闪烁提示
                                try
                                {
                                    fileSystemWatcher1.EnableRaisingEvents = false;
                                }
                                catch
                                {
                                    QQMessageBox.Show(this, "发生未知错误", "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
                                }


                                string info = ("动作：有移动设备拔出\r\r时间："
                                      + DateTime.Now.ToString() + "\r\r盘符：" + this.doCheck(false));
                                this.CurrDevices = Environment.GetLogicalDrives();//储存现有盘符
                                this.CurrDevices_ = null;
                                ShowUdisk formU = new ShowUdisk(info,0);

                                ChangeSkin(formU);

                                formU.Show();
                            }
                            CheckAutorunFlag = 0;//U盘拔出去了就重置U盘autorun.inf检测标记
                        }
                        break;
                    }

            }
            base.WndProc(ref m);
        }

        //右下角窗体委托父窗体进行控件的操作
        private void ShowUPannel(bool topmost)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            panelFirst.Visible = false;
            panelHardwareCheck.Visible = false;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = true;
            ToolPannel.Visible = false;
        }

        /// <summary>
        /// 检查插入/拔出设备的盘符
        /// true为插入、false为拔出，没有default情况滴~
        /// </summary>
        /// <param name="isArrival"></param>
        /// <returns>string 插入\拔出设备名</returns>
        protected string doCheck(bool isArrival)
        {
            switch (isArrival)
            {
                case true: //插入段
                    {
                        CurrDevices_ = Environment.GetLogicalDrives(); //获取插入/拔出后的驱动器列表
                        var al = new ArrayList();
                        /*
                         * 这里要注意，插入时驱动器多一个，所以
                         * 我通过遍历现有驱动器列表检查原有驱动器列表
                         * 中是否含有某个驱动器，如果不存在则这就是
                         * 被插入的驱动器。但是下面拔出段的情况是相反的。
                        */

                        //将原有的驱动器列表缓存到ArrayList
                        foreach (string DeviceName in CurrDevices)
                        {
                            al.Add(DeviceName);
                        }
                        //遍历现有驱动器列表与原有驱动器列表对比
                        foreach (string DeviceName_ in CurrDevices_)
                        {
                            if (!al.Contains(DeviceName_))
                            {
                                chkAutorun(DeviceName_);
                                return DeviceName_;
                                //检测到则return，因为只有插入了才有消息，所以基本是100%会return。

                            }
                        }
                        break;
                    }
                case false: //拔出段，思路同插入段。
                    {
                        CurrDevices_ = Environment.GetLogicalDrives();
                        var al_ = new ArrayList();
                        foreach (string DeviceName_ in CurrDevices_)
                        {
                            al_.Add(DeviceName_);
                        }
                        foreach (string DeviceName in CurrDevices)
                        {
                            if (!al_.Contains(DeviceName))
                            {
                                return DeviceName;
                            }
                        }
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return "无法检测";
        }

        protected void chkAutorun(string DeviceName_)
        {
            string path = DeviceName_ + "autorun.inf";
            if (File.Exists(path))
            {
                CheckAutorunFlag = 1;
            }
        }
        #endregion

        #region 高级功能模块

        private void btDevelop_Click(object sender, EventArgs e)
        {
            btDevelop.Select();

            //SetFirstPanel();
            panelFirst.Visible = false;
            panelHardwareCheck.Visible = false;
            ProgressPannel.Visible = false;
            OptimizationPanel.Visible = false;
            UdiskPannel.Visible = false;
            ToolPannel.Visible = true;

            if (SelectCBox.Items.Count != 0)
                SelectCBox.SelectedItem = SelectCBox.Items[0];
        }

        //搜索执行代码
        private void btSearch_Click(object sender, EventArgs e)
        {
            string result = System.Web.HttpUtility.UrlEncode(SearchText.Text, System.Text.Encoding.GetEncoding("utf-8"));
            switch (SelectCBox.Text)
            {
                case "百度一下":
                    System.Diagnostics.Process.Start(@"http://www.baidu.com/s?wd=" + result);
                    this.TopMost = false;
                    break;
                case "Google":
                    System.Diagnostics.Process.Start(@"http://www.google.com.hk/search?q=" + result);
                    this.TopMost = false;
                    break;
                case "有道搜索":
                    System.Diagnostics.Process.Start(@"http://www.youdao.com/search?q=" + result);
                    this.TopMost = false;
                    break;
                case "搜搜":
                    System.Diagnostics.Process.Start(@"http://www.soso.com/q?pid=s.idx&w=" + SearchText.Text);
                    this.TopMost = false;
                    break;
                case "MSDN":
                    this.TopMost = false;
                    System.Diagnostics.Process.Start(@"http://social.msdn.microsoft.com/Search/zh-cn?query=" + result);
                    this.TopMost = false;
                    break;
                case "必应Bing":
                    this.TopMost = false;
                    System.Diagnostics.Process.Start(@"http://cn.bing.com/search?q=" + result);
                    this.TopMost = false;
                    break;
            }
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\HotTools\FileDestrory\FileDestory.exe");
        }

        private void vistaButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\HotTools\Individuation\Individuation.exe");
        }

        private void vistaButton3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\HotTools\RubbishCleaner\RubbishCleaner.exe");
        }

        private void vistaButton4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("appwiz.cpl");
        }

        private void vistaButton5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\SysOptimizedTools\OSSpeed\OSSpeed.exe");
        }

        private void vistaButton6_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\SysOptimizedTools\ScanLargeFile\ScanLargeFile.exe");
        }

        private void vistaButton8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\SysTools\DefaultSet\DefaultSet.exe");
        }

        private void vistaButton13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\SysTools\ReadText\ReadText.exe");
        }

        private void vistaButton20_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\SysTools\FileMonitor\FileMonitor.exe");
        }

        private void vistaButton11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\SysTools\TimeSyn\TimeSyn.exe");
        }

        private void vistaButton15_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\OtherTools\VideoRec\VideoRec.exe");
        }

        private void vistaButton17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\OtherTools\FileSplitAndJion\FileSplitAndJion.exe");
        }

        private void vistaButton18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\OtherTools\CompTxt\CompTxt.exe");
        }

        private void vistaButton19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AdvancedFunctions\OtherTools\ThunderEncodeDecode\ThunderEncodeDecode.exe");
        }
        #endregion

        #region 程序退出模块
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowExit)
            {
                e.Cancel = true;

                this.Visible = false;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private bool allowExit = false;

        private void contextMenuStrip3_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "cntExit")
            {
                contextMenuStrip3.Visible = false;
                DialogResult dr = QQMessageBox.Show(this,"确认要退出吗？", "提示", QQMessageBoxIcon.Question,QQMessageBoxButtons.OKCancel);
                //DialogResult dr = MessageBox.Show("确认要退出吗？", "提示", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    allowExit = true;

                    this.notifyIcon1.Visible = false;

                    Application.Exit();
                }
            }
        }

        #endregion

        #region ISoft设置模块
        private void iSoft设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetForm autorunForm = new SetForm();

            autorunForm.ShowTipBallon += new ShowTipBallonHandle(STB);

            ChangeSkin(autorunForm);

            autorunForm.Show();
        }

        private void STB()
        {
            this.notifyIcon1.ShowBalloonTip(3000, "提示", "每隔5分钟将进行一次内存整理", ToolTipIcon.Info);
        }

        #endregion

        #region 程序更新模块
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@".\AutoUpdate.exe");
        }
        #endregion

        #region 联系作者模块
        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://403760530.qzone.qq.com/");
        }
        #endregion

        #region
        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ChangeSkin(ab);
            ab.ShowDialog();
        }
        #endregion

        #region 右上角图标点击连接
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://403760530.qzone.qq.com/");
        }
        #endregion

        private void btnSafeCheck_Click(object sender, EventArgs e)
        {
            clockLoadingProgress1.Start();
            OSCheckDetaillb.Visible = false;
            btnSafeCheck.Visible = false;
            OSChecklb.Text = "正在检测电脑...";
            proOSCheck.Minimum = 0;
            proOSCheck.Maximum = 7;
            proOSCheck.Step = 1;
            proOSCheck.Visible = true;
            goBacklbl.Visible = false;
            proOSCheck.Value = 0;

            InitWindows();

        }

        private void SetFirstPanel()
        {
            proOSCheck.Visible = false;
            goBacklbl.Visible = false;
            btViewSpecificInfo.Visible = false;

            clockLoadingProgress1.Stop();
            OSChecklb.Text = "立即体检，检测电脑系统";
            OSCheckDetaillb.Visible = true;
            btnSafeCheck.Visible = true;
            OSCheck.Visible = false;
            CPUCheck.Visible = false;
            GPUCheck.Visible = false;
            SoundCheck.Visible = false;
            MemCheck.Visible = false;
            StartTime.Visible = false;
            OSSetup.Visible = false;
        }

        private void goBacklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SetFirstPanel();
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Minimized)
            //{
            //    this.Visible = false;
            //    this.ShowInTaskbar = false;
            //    this.WindowState = FormWindowState.Minimized;
            //}
            //else
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.Visible = true;
            //    this.ShowInTaskbar = true;
            //}
        }        
    }
}
