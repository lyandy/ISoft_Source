using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DefaultSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("Wave.dll")]
        public static extern int E_WaveInit(IntPtr hwnd, string bmpStr);//初始化对象
        [DllImport("Wave.dll")]
        public static extern int E_AutoEffects(int type, int type1, int type2, int type3);//效果类型
        [DllImport("Wave.dll")]
        public static extern int E_WaveDropStone(int x, int y, int dx, int zl);//仍石头
        [DllImport("Wave.dll")]
        public static extern void E_WaveFree();//释放对象

        Random r = new Random();//置随机数种子

        private void Form1_Load(object sender, EventArgs e)
        {
            E_WaveInit(this.Handle, Application.StartupPath + "\\wave.bmp");
            E_AutoEffects(2, 0, 0, 0);

            E_AutoEffects(1, r.Next(3, 25), r.Next(0, 5), r.Next(50, 250));

            foreach (InputLanguage ilanguage in InputLanguage.InstalledInputLanguages)
            {
                cboInpulg.Items.Add(ilanguage.LayoutName);    //动态添加系统输入法
            }
            cboInpulg.SelectedIndex = 0;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            E_WaveDropStone(e.X, e.Y, r.Next(0, 5), r.Next(300, 800));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            E_WaveDropStone(e.X, e.Y, r.Next(0, 5), r.Next(300, 800));
        }

        private void vbtSet_Click(object sender, EventArgs e)
        {
            InputLanguage currentLanguage = InputLanguage.InstalledInputLanguages[cboInpulg.SelectedIndex];
            InputLanguage.CurrentInputLanguage = currentLanguage;
            MessageBox.Show(this, "成功设置系统默认输入法！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void vbtExit_Click(object sender, EventArgs e)
        {
            E_WaveFree();//释放资源
            this.Close();

            Application.Exit();
        }
    }
}
