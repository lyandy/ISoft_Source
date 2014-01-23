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
using System.Drawing.Drawing2D;
using ControlExs;

namespace ISoft
{

    public delegate void ShowTipBallonHandle();
    public partial class SetForm : FormEx
    {
        public ShowTipBallonHandle ShowTipBallon;
        public SetForm():base()
        {
            InitializeComponent();
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
                0.11f,
                0.15f,
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

        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        private void btnSet_Click(object sender, EventArgs e)
        {
            try
            {
                //启动项
                if (this.AutorunCheck.Checked)
                {
                    RegistryManager.CheckAutoRun(true);
                }
                else
                {
                    RegistryManager.DeleteKey();
                }

                if (MemCleanCheck.Checked)
                {
                    MemCleanCheck.Checked = true;
                    Thread newThread = new Thread(new ThreadStart(myTimer));
                    newThread.Start();
                }

                if (AutorunCheck.Checked == true && MemCleanCheck.Checked == true)
                {
                    ShowTipBallon();
                    QQMessageBox.Show(this,"已设置开机启动，已开启内存整理", "提示", QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                }
                else
                    if (AutorunCheck.Checked == false && MemCleanCheck.Checked == true)
                    {
                        ShowTipBallon();
                        QQMessageBox.Show(this, "已取消开机启动，已开启内存整理", "提示", QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                    }
                    else
                        if (AutorunCheck.Checked == true && MemCleanCheck.Checked == false)
                        {
                            QQMessageBox.Show(this, "已设置开机启动，已取消内存整理", "提示", QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                        }
                        else
                        {
                            QQMessageBox.Show(this, "已取消开机启动，已取消内存整理", "提示", QQMessageBoxIcon.Information, QQMessageBoxButtons.OK);
                        }
                ////信息
                //string info = (this.AutorunCheck.Checked ? "添加启动项成功！" : "删除启动项成功！");
                ////提示
                //MessageBox.Show(info, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                QQMessageBox.Show(this, "应用设置时出现错误!\n\n" + ex.Message, "错误", QQMessageBoxIcon.Error, QQMessageBoxButtons.OK);
            }
        }

        public void myTimer()
        {
            System.Threading.Timer newTimer = new System.Threading.Timer(new TimerCallback(myWork));
            newTimer.Change(1000, 300000);
        }

        public void myWork(object obj)
        {
            SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            this.Left = (Screen.PrimaryScreen.WorkingArea.Width - Width) / 2;
            this.Top = (Screen.PrimaryScreen.WorkingArea.Height - Height) / 2;
        }

    }
}
