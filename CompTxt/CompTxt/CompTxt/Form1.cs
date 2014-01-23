using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpWin;
using System.IO;

namespace CompTxt
{
    public partial class Form1 : SkinForm
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void cButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "*.txt;*.doc;*.docx|*.txt;*.doc;*.docx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cTextBox1.Text = openFileDialog1.FileName;         //要判断的第一个文件
            }
        }

        private void cButton2_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "*.txt;*.doc;*.docx|*.txt;*.doc;*.docx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                cTextBox2.Text = openFileDialog1.FileName;    //要判断的第二个文件
            }
        }

        private void buttonEx5_Click(object sender, EventArgs e)
        {
            if (cTextBox1.Text == "" || cTextBox2.Text == "")
            {
                CustomMessageBox.CustomMessageBox.Show("源文件或目标文件不存在", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                return;
            }
            else
            {
                StreamReader sr1 = new StreamReader(cTextBox1.Text);
                StreamReader sr2 = new StreamReader(cTextBox2.Text);
                if (object.Equals(sr1.ReadToEnd(), sr2.ReadToEnd()))        //读取文件内容并判断
                {
                    CustomMessageBox.CustomMessageBox.Show("两个文件内容相同！", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
                    return;
                }
                else
                {
                    CustomMessageBox.CustomMessageBox.Show("两个文件内容不相同！", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
                    return;
                }
            }
        }
    }
}


