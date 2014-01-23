using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Drawing2D;
using ControlExs;

namespace ISoft
{

    public delegate void ShowUdiskPannelHandle(bool topmost);
    public partial class ShowUdisk : FormEx
    {
        public ShowUdiskPannelHandle ShowUdiskPannel;
        byte[] t;
        System.Threading.Thread show;
        Thread speak_Thread = null;

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
                Color.FromArgb(20, Color.White),
                Color.FromArgb(60, Color.White),
                Color.FromArgb(140, Color.White),
                Color.FromArgb(200, Color.White),
                Color.FromArgb(240, Color.White),
                Color.FromArgb(240, Color.White)
            };

            float[] pos = 
            {
                0.0f,
                0.04f,
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

        public ShowUdisk(string info,int ReciveCheckFlag):base()
        {
            
            InitializeComponent();

            SpVoice spv = new SpVoice();
            if (spv == null) return;
            ISpeechObjectTokens arrVoices = spv.GetVoices(string.Empty, string.Empty);
            List<string> arrlist = new List<string>();

            for (int i = 0; i < arrVoices.Count; i++)
            {
                arrlist.Add(arrVoices.Item(i).GetDescription(0));
            }
            cmbVoices.DataSource = arrlist;

            Point p = new Point(500, 1024);
            this.Location = p;
            t = new byte[4];
            t[0] = 5;
            label1.Text = info;
            if (ReciveCheckFlag == 1)
            {
                speak_Thread = new Thread(new ThreadStart(start_Speak));
                speak_Thread.Start();

                linkLabel1.Visible = true;
                linkLabel1.Text = "检测到可自执行文件，建议使用U盘防护扫描";
                linkLabel1.LinkColor = Color.Red;
            }
            else
            {
                linkLabel1.Visible = false;
            }
                //linkLabel1.Text = "未检测到可自执行文件，\r建议使用U盘防护扫描";
        }

        private void start_Speak()
        {
            SpVoice spv = new SpVoice();
            if (spv == null) return;

            spv.Voice = spv.GetVoices(string.Empty, string.Empty).Item(cmbVoices.SelectedIndex);
            spv.Volume = 100;

            spv.Speak("警告！！检测到可自执行文件，建议使用U盘防护扫描", SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);
        }


        //#region 实现窗体可以移动
        //[DllImport("user32.dll")]
        //public static extern bool ReleaseCapture();
        //[DllImport("user32.dll")]
        //public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int IParam);
        //public const int WM_SYSCOMMAND = 0x0112;
        //public const int SC_MOVE = 0xF010;
        //public const int HTCAPTION = 0x0002;


        //private void ShowUdisk_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        //}

        //#endregion

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

        private void ShowUdisk_Load(object sender, EventArgs e)
        {

            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;

            show = new System.Threading.Thread(ShowForm);
            show.IsBackground = true;
            show.Start();
            Rectangle E = Screen.PrimaryScreen.Bounds;
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - 322, Screen.PrimaryScreen.WorkingArea.Height - 210);
            this.Location = p;
        }

        private void ShowForm()
        {

            double t = 0.1;
            while (true)
            {

                if (this.InvokeRequired)
                {
                    SetForm d = delegate(double value)
                    {

                        this.Opacity = value;
                    };
                    this.Invoke(d, new object[1] { t });
                }
                else
                {
                    this.Opacity = t;
                }
                t += 0.1;
                Delay(150);
                if (this.Opacity == 1.0)
                {
                    break;
                }
            }

            Delay(8000);

            while (true)
            {

                if (this.InvokeRequired)
                {
                    SetForm d = delegate(double value)
                    {

                        this.Opacity = value;
                    };
                    this.Invoke(d, new object[1] { t });
                }
                else
                {
                    this.Opacity = t;
                }
                t -= 0.1;
                System.Threading.Thread.Sleep(150);
                if (this.Opacity == 0)
                {
                    break;
                }
            }
            this.Dispose();
        }

        delegate void SetForm(double value);

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowUdiskPannel(true);
        }

        private void ShowUdisk_MouseEnter(object sender, EventArgs e)
        {
        //    show.Abort();

        //    this.Opacity = 1;
        //    double t = 1;
        //    Delay(3000);

        //    while (true)
        //    {

        //        if (this.InvokeRequired)
        //        {
        //            SetForm d = delegate(double value)
        //            {

        //                this.Opacity = value;
        //            };
        //            this.Invoke(d, new object[1] { t });
        //        }
        //        else
        //        {
        //            this.Opacity = t;
        //        }
        //        t -= 0.1;
        //        System.Threading.Thread.Sleep(150);
        //        if (this.Opacity == 0)
        //        {
        //            break;
        //        }
        //    }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
