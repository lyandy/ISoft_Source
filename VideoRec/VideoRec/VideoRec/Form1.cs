using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VideoRec
{
    public partial class Form1 : Form
    {
        VideoWork vw;
        public Form1()
        {
            InitializeComponent();
            this.skinEngine1.SkinFile = "SteelBlack.ssk";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            vw = new VideoWork(panel1.Handle, 0, 0, 400, 300);

            label1.Visible = true;
            panel1.Visible = false;

            btnStop.Enabled = false;
            btnKinescope.Enabled = false;
            btnSaveImage.Enabled = false;
            btnStopKinescope.Enabled = false;

            label2.Text = "状态：等待开始...";

        }

        //开始
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                label1.Visible = false;
                panel1.Visible = true;
                vw.Start();            

                btnStop.Enabled = true;
                btnKinescope.Enabled = true;
                btnSaveImage.Enabled = true;
                btnStopKinescope.Enabled = false;

                label2.Text = "状态：摄像头已成功打开...";
            }
            catch
            {
                MessageBox.Show("未探测到摄像头！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                label1.Visible = true;
                panel1.Visible = false;

                btnStop.Enabled = false;
                btnKinescope.Enabled = false;
                btnSaveImage.Enabled = false;
                btnStopKinescope.Enabled = false;

                label2.Text = "状态：未探测到摄像头...";

                return;
            }
        }

        //停止
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {

                label1.Visible = true;
                panel1.Visible = false;

                vw.Stop();

                label2.Text = "状态：摄像头已经关闭，等待开始...";

                btnStop.Enabled = false;
                btnKinescope.Enabled = false;
                btnSaveImage.Enabled = false;
                btnStopKinescope.Enabled = false;
            }
            catch
            {
                MessageBox.Show("发生未知错误，点击“确定”关闭软件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                Application.Exit();
            }
        }

        //截图
        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            try
            {

                vw.GrabImage("c:\\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg");

                label2.Text = "状态：截图成功保存...";

                if (btnStopKinescope.Enabled == true)
                    label2.Text = "状态：正在录像...";
            }
            catch
            {
                MessageBox.Show("保存错误，点击“确定”关闭软件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();
            }
        }

        //录像
        private void btnKinescope_Click(object sender, EventArgs e)
        {
            try
            {
                vw.Kinescope("c:\\" + System.DateTime.Now.ToString("yyyyMMddHHmmss") + ".avi");

                label2.Text = "状态：正在录像...";

                btnKinescope.Enabled = false;
                btnSaveImage.Enabled = true;
                btnStopKinescope.Enabled = true;
            }
            catch
            {
                MessageBox.Show("发生未知错误，点击“确定”关闭软件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();
            }
        }

        //停止录像
        private void btnStopKinescope_Click(object sender, EventArgs e)
        {
            try
            {
                Application.DoEvents();
                vw.StopKinescope();
                label2.Text = "状态：录像已成功保存...";

                btnStopKinescope.Enabled = false;
                btnKinescope.Enabled = true;

            }
            catch
            {
                MessageBox.Show("发生未知错误，点击“确定”关闭软件", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                Application.Exit();
            }

        }
    }
}
