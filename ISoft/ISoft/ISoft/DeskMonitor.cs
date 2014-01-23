using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;
using ControlExs;

namespace ISoft
{
    public delegate void StartDeleteFileHandle();
    public partial class DeskMonitor : FormEx
    {
        public StartDeleteFileHandle DeleteFile;
        System.Threading.Thread show;

        public DeskMonitor(string info):base()
        {
            InitializeComponent();

            fileCHK.Text = info;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fileCHK_CheckedChanged(object sender, EventArgs e)
        {
            if (fileCHK.Checked == true)
                vBdelete.Enabled = true;
            else
                vBdelete.Enabled = false;
        }

        private void DeskMonitor_Load(object sender, EventArgs e)
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
        }

        delegate void SetForm(double value);

        private void vBdelete_Click(object sender, EventArgs e)
        {
            DeleteFile();
        }

    }
}
