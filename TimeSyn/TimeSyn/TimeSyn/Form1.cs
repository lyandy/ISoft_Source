using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net;
using System.Net.Sockets;

namespace TimeSyn
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Form1.CheckForIllegalCrossThreadCalls = false;

            AeroForm.AeroEffect(this);
        }

        Thread show_thread = null;

        [DllImport("kernel32.dll")]
        private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

        [DllImport("kernel32.dll")]
        private extern static uint SetSystemTime(ref SYSTEMTIME lpSystemTime);

        //[DllImport("wininet.dll", EntryPoint = "InternetGetConnectedState")]
        //public extern static bool InternetGetConnectedState(out int conState, int reder);
        ////参数说明 constate 连接说明 ，reder保留值
        //public bool IsConnectedToInternet()
        //{
        //    int Desc = 0;
        //    return InternetGetConnectedState(out  Desc, 1);
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Green;
            this.label4.Text = Convert.ToDateTime(this.label4.Text).AddSeconds(1).ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Green;
            this.label5.Text = DateTime.Now.ToString();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (this.label4.Text == "")
            {
                label4.ForeColor = Color.Red;
                this.label4.Text = "正在获取北京标准时间，请稍候...";
                this.vistaButton1.Enabled = false;
                this.vistaButton1.BaseColor = Color.Gray;
            }
            else
            {
                this.vistaButton1.Enabled = true;
                this.vistaButton1.BaseColor = Color.RoyalBlue;
                this.timer3.Stop();
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //if (IsConnectedToInternet())
            //{
                label4.Text = "";
                this.vistaButton1.BaseColor = Color.Gray;
                show_thread = new Thread(new ThreadStart(show));
                show_thread.Start();
            //}
            //else
            //{
            //    this.vistaButton1.BaseColor = Color.Gray;
            //    label4.ForeColor = Color.Red;
            //    label4.Text = "未连接至互联网，无法获取网络时间...";
            //}
                
                       
        }

        private void show()
        {
            this.timer1.Stop();
            this.label4.Text = "";
            this.vistaButton1.Enabled = false;
            this.vistaButton1.BackColor = Color.Gray;
            new Thread(new ThreadStart(this.GetDateTime)).Start();
        }

        private void GetDateTime()
        {
            Thread.Sleep(1000);
            label4.BeginInvoke(new System.EventHandler(UpdateUI), this.label4.Text);
        }

        private void UpdateUI(object o, System.EventArgs e)
        {
            //UI线程设置label1属性
            this.label4.Text = GetServerDateTime().ToString();
            this.timer1.Start();
        }

        int nSize = 0;
        public System.DateTime GetServerDateTime()
        {
            string[,] TimeServer = new string[14, 2];
            int[] SearchOrder = new int[] { 1, 2, 4, 8, 9, 6, 11, 5, 10, 0, 3, 7, 12 };
            TimeServer[0, 0] = "time-a.nist.gov";
            TimeServer[0, 1] = "129.6.15.28";
            TimeServer[1, 0] = "time-b.nist.gov";
            TimeServer[1, 1] = "129.6.15.29";
            TimeServer[2, 0] = "time-a.timefreq.bldrdoc.gov";
            TimeServer[2, 1] = "132.163.4.101";
            TimeServer[3, 0] = "time-b.timefreq.bldrdoc.gov";
            TimeServer[3, 1] = "132.163.4.102";
            TimeServer[4, 0] = "time-c.timefreq.bldrdoc.gov";
            TimeServer[4, 1] = "132.163.4.103";
            TimeServer[5, 0] = "utcnist.colorado.edu";
            TimeServer[5, 1] = "128.138.140.44";
            TimeServer[6, 0] = "time.nist.gov";
            TimeServer[6, 1] = "192.43.244.18";
            TimeServer[7, 0] = "time-nw.nist.gov";
            TimeServer[7, 1] = "131.107.1.10";
            TimeServer[8, 0] = "nist1.symmetricom.com";
            TimeServer[8, 1] = "69.25.96.13";
            TimeServer[9, 0] = "nist1-dc.glassey.com";
            TimeServer[9, 1] = "216.200.93.8";
            TimeServer[10, 0] = "nist1-ny.glassey.com";
            TimeServer[10, 1] = "208.184.49.9";
            TimeServer[11, 0] = "nist1-sj.glassey.com";
            TimeServer[11, 1] = "207.126.98.204";
            TimeServer[12, 0] = "nist1.aol-ca.truetime.com";
            TimeServer[12, 1] = "207.200.81.113";
            TimeServer[13, 0] = "nist1.aol-va.truetime.com";
            TimeServer[13, 1] = "64.236.96.53";

            System.DateTime ret;
            ret = System.DateTime.MinValue;

            byte[] RecvBuf = new byte[1024];

            RecvBuf.Initialize();

            string ServerIP;
            for (int i = 0; i < 13; i++)
            {
                ServerIP = TimeServer[SearchOrder[i], 1];

                //服务器IP 端口129.6.15.28
                IPEndPoint ServerEp = new IPEndPoint(IPAddress.Parse(ServerIP), 37);

                Socket Time_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                {
                    try
                    {
                        Time_Socket.Connect(ServerEp);
                        nSize = Time_Socket.Receive(RecvBuf);
                        Time_Socket.Close();
                        if (nSize == 4 || i == 12)
                        {
                            break;
                        }

                    }
                    catch (System.Exception)
                    {

                    }

                }
            }
            if (nSize == 4)//接收到一个位的整型   
            {
                try
                {
                    int recvInt = BitConverter.ToInt32(RecvBuf, 0);
                    //   这里转换网络字节序为主机字节序   
                    recvInt = System.Net.IPAddress.NetworkToHostOrder(recvInt);

                    //   转换为真正的秒数   

                    uint ServerSecs = (uint)(recvInt);
                    //   The   ServerSecs   is   the   number   of   seconds   since   00:00   (midnight)   1   January   1900   GMT   

                    ret = DateTime.Parse("1900-01-01 00:00:00 ");

                    ret = ret.AddSeconds(ServerSecs - 8);//因为根据网络的快慢 减8 是为了减小秒间的差距 

                    ret = ret.AddHours(8);     //   转换为东区时间   
                }
                catch
                {
                    GetServerDateTime();
                }
            }
            else
            {
            }
            return ret;
        }

        private struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        public bool SetSysTimeByStr(string timestr)
        {
            int temp = 0;
            SYSTEMTIME sysTime = new SYSTEMTIME();
            //给sysTIme初始赋值
            GetSystemTime(ref sysTime);
            string SysTime = timestr;
            sysTime.wYear = Convert.ToUInt16(SysTime.Substring(0, 4));
            sysTime.wMonth = Convert.ToUInt16(SysTime.Substring(4, 2));
            sysTime.wDay = Convert.ToUInt16(SysTime.Substring(6, 2));
            sysTime.wHour = Convert.ToUInt16(SysTime.Substring(8, 2));

            //为抵消北京时间+8而进行的操作
            temp = Convert.ToInt16(SysTime.Substring(8, 2)) - 8;
            if (temp < 0)
            {
                sysTime.wHour = Convert.ToUInt16(temp + 24);//Convert.ToUInt16(SysTime.Substring(8,2))-Convert.ToInt16(8);
                sysTime.wDay = Convert.ToUInt16(sysTime.wDay - 1);
                if (sysTime.wDay == 0)
                {
                    if (sysTime.wMonth == 5 | sysTime.wMonth == 7 | sysTime.wMonth == 8 | sysTime.wMonth == 10 | sysTime.wMonth == 12)
                    {
                        sysTime.wMonth = Convert.ToUInt16(sysTime.wMonth - 1);
                        sysTime.wDay = Convert.ToUInt16(30);
                    }
                    else if (sysTime.wMonth == 1)
                    {
                        sysTime.wMonth = Convert.ToUInt16(12);
                        sysTime.wDay = Convert.ToUInt16(31);
                        sysTime.wYear = Convert.ToUInt16(sysTime.wYear - 1);
                    }
                    else if (sysTime.wMonth == 3)
                    {
                        sysTime.wMonth = Convert.ToUInt16(2);
                        if (sysTime.wYear % 4 == 0 && sysTime.wYear % 100 != 0)
                            sysTime.wDay = Convert.ToUInt16(29);
                        else
                            sysTime.wDay = Convert.ToUInt16(28);
                    }
                    else
                    {
                        sysTime.wMonth = Convert.ToUInt16(sysTime.wMonth - 1);
                        sysTime.wDay = Convert.ToUInt16(31);
                    }

                }
            }
            else
            {
                sysTime.wHour = Convert.ToUInt16(temp);
            }

            sysTime.wMinute = Convert.ToUInt16(SysTime.Substring(10, 2));
            sysTime.wSecond = Convert.ToUInt16(SysTime.Substring(12, 2));
            uint flag = SetSystemTime(ref sysTime);

            return Convert.ToBoolean(flag);
        }

        private void vistaButton1_Click(object sender, EventArgs e)
        {
            //timer1.Enabled = false;
            //timer2.Enabled = false;
            //label4.ForeColor = Color.Blue;
            //label4.Text = "正在发送同步数据，请稍候...";

            //label5.ForeColor = Color.Blue;
            //label5.Text = "正在接收同步数据，请稍候...";


            if (SetSysTimeByStr(GetServerDateTime().ToString("yyyyMMddHHmmss")))
            {
                //timer1.Enabled = true; 
                //timer2.Enabled = true;
                CustomMessageBox.CustomMessageBox.Show("同步完毕，若显示不一致是网络延迟原因，重启工具即可", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
            }
            else
            {
                CustomMessageBox.CustomMessageBox.Show("时间同步发生未知错误，请再次同步", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                return;
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //if (IsConnectedToInternet())
            //{
            //    timer1.Enabled = true;
 
            //    timer3.Enabled = true;
            //}
        }    
    }
}
