using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace FileDestory
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
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            E_WaveDropStone(e.X, e.Y, r.Next(0, 5), r.Next(300, 800));
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            E_WaveDropStone(e.X, e.Y, r.Next(0, 5), r.Next(300, 800));
        }

        private void FileListview_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))    // 判断拖放的是否为文件
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
                MessageBox.Show("您拖入的是非文件类型，请拖入文件进行粉碎", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FileListview_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                int FileSameFlag = 0;

                if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                {
                    String[] files = (String[])e.Data.GetData(DataFormats.FileDrop);
                    System.IO.FileInfo file = new System.IO.FileInfo(files[0]);

                    string[] str =
					{
						file.Name,
                        files[0],
						Convert.ToString(file.Length / 1024) + "K",
					};



                    for (int i = FileListview.Items.Count; i >= 1; i--)
                    {
                        if (files[0] == FileListview.Items[i - 1].SubItems[1].Text)
                        {
                            MessageBox.Show("粉碎列  " + i + "  已有该文件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            FileSameFlag = 1;
                            break;
                        }
                    }

                    if (FileSameFlag == 0)
                    {
                        ListViewItem item = new ListViewItem(str);
                        FileListview.Items.Add(item);

                        SelectAllCheck_CheckedChanged(null, null);

                        StartDestory.Enabled = true;
                    }

                    else
                    {
                        FileSameFlag = 0;
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("暂不支持文件夹粉碎","警告",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        

        private void SelectAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SelectAllCheck.Checked == true)
            {
                for (int i = 0; i < FileListview.Items.Count; i++)
                {
                    FileListview.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < FileListview.Items.Count; i++)
                {
                    FileListview.Items[i].Checked = false;
                }
            }
        }

        private void AddFile_Click(object sender, EventArgs e)
        {

            int FileSameFlag = 0;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.FileInfo file = new System.IO.FileInfo(openFileDialog1.FileName);

                string[] str =
					{
						file.Name,
                        openFileDialog1.FileName,
						Convert.ToString(file.Length / 1024) + "K",
					};

                for (int i = FileListview.Items.Count; i >= 1; i--)
                {
                    if (openFileDialog1.FileName == FileListview.Items[i - 1].SubItems[1].Text)
                    {
                        MessageBox.Show("粉碎列  " + i + "  已有该文件", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        FileSameFlag = 1;
                        break;
                    }
                }

                if (FileSameFlag == 0)
                {
                    ListViewItem item = new ListViewItem(str);
                    FileListview.Items.Add(item);

                    SelectAllCheck_CheckedChanged(null, null);
                }

                else
                {
                    FileSameFlag = 0;
                    return;
                }
            }
        }

        private void StartDestory_Click(object sender, EventArgs e)
        {
            //int initialFileLsvItemConut = FileListview.Items.Count;
            int CheckCount = 0, NotCheckCount = 0, SucessCount = 0, FailCount = 0;
            for (int i = 0; i < FileListview.Items.Count; i++)
            {
                if (FileListview.Items[i].Checked == true)
                {
                    CheckCount++;
                    try
                    {

                        FileDestory file = new FileDestory(FileListview.Items[i].SubItems[1].Text);
                        if (File.Exists(FileListview.Items[i].SubItems[1].Text))
                            FailCount++;
                        else
                        {
                            FileListview.Items[i].Remove();
                            i--;
                            SucessCount++;
                        }
                    }
                    catch
                    {
                        FailCount++;
                    }
                    
                }
                else
                    NotCheckCount++;
            }
            MessageBox.Show("粉碎完毕！\r文件入列数目 " + (CheckCount + NotCheckCount) + "\r文件确认粉碎数目 " + CheckCount + "\r文件未确认粉碎数目 " + NotCheckCount + "\r文件粉碎成功数目 " + SucessCount + "\r文件粉碎失败数目 " + FailCount,"提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            E_WaveFree();//释放资源
            Application.Exit();
        }
    }
}
