using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;


namespace RubbishCleaner
{
    public partial class Form1 : Form
    {
        System.Threading.Thread OneKeyClean;
        System.Threading.Thread search_thread = null;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        [DllImport("shell32.dll")]
        public static extern int SHEmptyRecycleBin(IntPtr hwnd, int pszRootPath, int dwFlags);

        private void splitContainer1_Panel1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void splitContainer1_Panel2_MouseEnter(object sender, EventArgs e)
        {
            timer2.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 697;
            VolumeRead();
        }

        private void VolumeRead()
        {

            try
            {
                WMIDrives wmiDrives = new WMIDrives();
                int num2 = 0;
                this.lvwVolumes.Items.Clear();
                if (wmiDrives.VolumeLetter != null)
                {
                    int num4 = wmiDrives.VolumeLetter.Count - 1;
                    for (num2 = 0; num2 <= num4; num2++)
                    {
                        if (wmiDrives.VolumeFileSystem != null)
                        {
                            if (wmiDrives.VolumeFileSystem[num2].ToString() == "NTFS")
                            {
                                int imageIndex = ReturnImageIndex(wmiDrives.VolumeType[num2].ToString());
                                this.lvwVolumes.Items.Add(wmiDrives.VolumeLetter[num2].ToString(), imageIndex);
                                if (wmiDrives.VolumeLabel != null)
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add(wmiDrives.VolumeLabel[num2].ToString());
                                }
                                else
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add("N/A");
                                }

                                this.lvwVolumes.Items[num2].SubItems.Add(wmiDrives.VolumeFileSystem[num2].ToString());

                                if (wmiDrives.VolumeTotalSize != null && wmiDrives.VolumeTotalSize[num2].ToString() != "")
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add(GeneralModule.FormatBytes(double.Parse(wmiDrives.VolumeTotalSize[num2].ToString())));
                                }
                                else
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add("N/A");
                                }
                                if (wmiDrives.VolumeUsedSpace != null && wmiDrives.VolumeUsedSpace[num2].ToString() != "")
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add(GeneralModule.FormatBytes(double.Parse(wmiDrives.VolumeUsedSpace[num2].ToString())));
                                }
                                else
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add("N/A");
                                }
                                if (wmiDrives.VolumeFreeSpace != null && wmiDrives.VolumeFreeSpace[num2].ToString() != "")
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add(GeneralModule.FormatBytes(double.Parse(wmiDrives.VolumeFreeSpace[num2].ToString())));
                                }
                                else
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add("N/A");
                                }
                                if (wmiDrives.VolumePercentFreeSpace != null && wmiDrives.VolumePercentFreeSpace[num2].ToString() != "")
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add(wmiDrives.VolumePercentFreeSpace[num2].ToString());
                                }
                                else
                                {
                                    this.lvwVolumes.Items[num2].SubItems.Add("N/A");
                                }
                                //if (wmiDrives.VolumeReady != null)
                                //{
                                //    if (bool.Parse(wmiDrives.VolumeReady[num2].ToString()))
                                //    {
                                //        this.lvwVolumes.Items[num2].SubItems.Add("是");
                                //    }
                                //    else
                                //    {
                                //        this.lvwVolumes.Items[num2].SubItems.Add("否");
                                //    }
                                //}
                                //else
                                //{
                                //    this.lvwVolumes.Items[num2].SubItems.Add("未知");
                                //}
                            }
                        }
                        else
                        {
                            this.lvwVolumes.Items.Add("");
                            this.lvwVolumes.Items[0].SubItems.Add("None");
                        }
                    }
                }
            }
            catch
            {
            }

        }

        private static int ReturnImageIndex(string strDriveType)
        {
            string text = strDriveType.ToLower();
            if (text.Equals("removable"))
            {
                return 0;
            }
            if (text.Equals("fixed"))
            {
                return 1;
            }
            if (text.Equals("network"))
            {
                return 2;
            }
            if (text.Equals("cdrom"))
            {
                return 3;
            }
            return 4;
        }

        private void SelAllCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SelAllCheck.Checked == true)
            {
                for (int i = 0; i < OneKeyCleanListview.Items.Count; i++)
                    OneKeyCleanListview.Items[i].Checked = true;
            }
            else
            {
                for (int i = 0; i < OneKeyCleanListview.Items.Count; i++)
                    OneKeyCleanListview.Items[i].Checked = false;
            }
        }

        private void btClean_Click(object sender, EventArgs e)
        {
            OneKeyClean = new System.Threading.Thread(OKClean);
            OneKeyClean.IsBackground = true;
            OneKeyClean.Start();
            
        }

        private void OKClean()
        {
            try
            {
                for (int i = 0; i < OneKeyCleanListview.Items.Count; i++)
                {
                    if (OneKeyCleanListview.Items[i].Checked == false)
                    { }
                    else
                    {
                        str = OneKeyCleanListview.Items[i].Text;
                        label9.Text = "状态：正在执行 " + str;
                        OneKClean();
                    }
                }
                MessageBox.Show("一键清理完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label9.Text = "操作系统使用的时间越长，所积累的垃圾文件也越多，特别是临时文件，还会影响硬盘的速度，如果有效的清除这些临时文" + "\r" + "件可以获得更多的空间，请在下面选择要清除的项目！";
            }
            catch
            {
                MessageBox.Show("发生未知错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        string str = "";
        private void OneKClean()
        {
            try
            {
                switch (str)
                {
                    case "清空回收站":
                        SHEmptyRecycleBin(this.Handle, 0, 7);
                        break;
                    case "清空IE缓存区":
                        string dir = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
                        DirectoryInfo mDi = new DirectoryInfo(dir);
                        mDi.Delete(true);
                        mDi.Create();
                        break;
                    case "清空IE　Cookies":
                        string strx = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);
                        DirectoryInfo dix = new DirectoryInfo(strx);
                        if (dix.Exists)
                        {
                            dix.Delete(true);
                            dix.Create();
                        }
                        break;
                    case "清空Windows临时文件":
                        string BufferStr = Environment.GetEnvironmentVariable("WinDir") + "\\Temp";
                        string BufferStr1 = Environment.GetEnvironmentVariable("TEMP");
                        DirectoryInfo di = new DirectoryInfo(BufferStr);
                        DirectoryInfo di2 = new DirectoryInfo(BufferStr1);
                        if (di.Exists)
                        {
                            di.Delete(true);
                            di.Create();

                        }
                        if (di2.Exists)
                        {
                            di2.Delete(true);
                            di2.Create();
                        }
                        break;
                    case "清空打开的文件记录":
                        string str1 = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
                        DirectoryInfo dii = new DirectoryInfo(str1);
                        if (dii.Exists)
                        {
                            dii.Delete(true);
                            dii.Create();
                        }
                        break;
                    case "清除IE地址栏中的历史网址":
                        RegistryKey hklm = Registry.CurrentUser;
                        RegistryKey software = hklm.OpenSubKey(@"Software\Microsoft\Internet Explorer", true);
                        software.DeleteSubKeyTree("TypedURLs");
                        break;
                    case "清除运行对话框":
                        RegistryKey MyReg;
                        MyReg = Registry.CurrentUser;
                        MyReg = MyReg.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\RunMRU");
                        string MyMRU = (String)MyReg.GetValue("MRULIST");
                        for (int i = 0; i < MyMRU.Length; i++)
                        {
                            MyReg.DeleteValue(MyMRU[i].ToString());
                        }
                        MyReg.SetValue("MRUList", "");
                        MyReg.Close();
                        break;
                }
            }
            catch
            {
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 697;
            timer1.Enabled = false;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 40;
            timer2.Enabled = false;
        }

        private void splitContainer1_Panel1_MouseLeave(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void splitContainer1_Panel2_MouseLeave(object sender, EventArgs e)
        {
            timer2.Enabled = false;
        }


        int wasteTime = 0;

        int selDriverFlag = 0;

        private void btStartScan_Click(object sender, EventArgs e)
        {          
            if (btStartScan.Text == "开始扫描")
            {
                for (int i = 0; i < lvwVolumes.Items.Count; i++)
                {
                    if (lvwVolumes.Items[i].Checked == true)
                    {
                        selDriverFlag = 1;
                        break;
                    }
                }
                wasteTimer.Enabled = true;
                btStartScan.Text = "暂 停";
                btCleaner.Enabled = true;
                btCleaner.Text = "取消扫描";
                if (search_thread == null)
                    search_thread = new Thread(new ThreadStart(startsearch));

                if (search_thread.ThreadState == ThreadState.Stopped)
                {
                    search_thread = null;
                    search_thread = new Thread(new ThreadStart(startsearch));
                }

                if (!search_thread.IsAlive)
                    search_thread.Start();
            }
            else
            {
                if (btStartScan.Text == "暂 停")
                {
                    search_thread.Suspend();

                    wasteTimer.Enabled = false;

                    btStartScan.Text = "继续扫描";
                }
                else
                {
                    if (btStartScan.Text == "继续扫描")
                    {
                        search_thread.Resume();

                        wasteTimer.Enabled = true;

                        btStartScan.Text = "暂 停";
                    }
                    else
                    {
                        if (btStartScan.Text == "重新扫描")
                        {
                            ScanResLisv.Items.Clear();

                            ScanFileCount = 0;

                            for (int i = 0; i < lvwVolumes.Items.Count; i++)
                            {
                                if (lvwVolumes.Items[i].Checked == true)
                                {
                                    selDriverFlag = 1;
                                    break;
                                }
                            }
                            wasteTime = 0;
                            wasteTimer.Enabled = true;
                            btStartScan.Text = "暂 停";
                            btCleaner.Enabled = true;
                            btCleaner.Text = "取消扫描";
                            if (search_thread == null)
                                search_thread = new Thread(new ThreadStart(startsearch));

                            if (search_thread.ThreadState == ThreadState.Stopped)
                            {
                                search_thread = null;
                                search_thread = new Thread(new ThreadStart(startsearch));
                            }

                            if (!search_thread.IsAlive)
                                search_thread.Start();
                        }
                    }

                }
            }
        }

        private void startsearch()
        {
            if (selDriverFlag == 1)
            {
                for (int i = 0; i < lvwVolumes.Items.Count; i++)
                {
                    if (lvwVolumes.Items[i].Checked == true)
                        ScanFiles(lvwVolumes.Items[i].SubItems[0].Text);
                }
            }
            else
            {
                MessageBox.Show("你未选中磁盘驱动器，扫描程序将会选择扫描系统临时文件等信息","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                selDriverFlag = 0;
                ScanFiles("C:\\Users\\Andy\\AppData\\Local\\Temp");

            }
        }

        int ScanFileCount = 0;
        private void ScanFiles(string filepath)
        {
            if (filepath.Trim().Length > 0)
            {
                try
                {                    
                    string[] filecollect = Directory.GetFileSystemEntries(filepath);

                    ++ScanFileCount;
                    foreach (string file in filecollect)
                    {
                        if (Directory.Exists(file))
                            ScanFiles(file);                           
                        else
                        {

                            lab_showfile.Text = "正在扫描：" + file;
                            if (file.EndsWith(".tmp") || file.EndsWith(".temp") || file.EndsWith("._mp") || file.EndsWith(".~mp") || file.EndsWith(".syd") || file.EndsWith(".$db") || file.EndsWith(".db$"))
                            {
                                System.IO.FileInfo f = new System.IO.FileInfo(file);

                                int j = 0;

                                j = f.Name.IndexOf(".");

                                string fileSuffix = f.Name.Substring(j, 4);

                                string[] str =
                                 {
                                     file,
                                     Convert.ToString(f.Length / 1024) + "K",
                                     fileSuffix+ "文件",
                                     f.LastWriteTime.ToString()
                                 };
                                ListViewItem item = new ListViewItem(str);
                                ScanResLisv.Items.Add(item);

                                selAllRubblishCheck_CheckedChanged(null, null);
                            }
                            if (ScanResLisv.Items.Count == 0)
                                ScanRestxt.Text = "正在扫描磁盘文件...";
                            else
                                ScanRestxt.Text = "扫描了 " + ScanFileCount + " 个文件，" + "已发现垃圾文件 " + ScanResLisv.Items.Count + " 个！";
                        }
                    }
                }
                catch
                {
                    //MessageBox.Show("扫描意外终止", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btCleaner_Click(object sender, EventArgs e)
        {
            if (btCleaner.Text == "取消扫描")
            {
                if (search_thread != null)
                {
                    try
                    {
                        if (search_thread.ThreadState == ThreadState.Suspended)
                        {
                            search_thread.Resume();
                            while (search_thread.ThreadState != ThreadState.Running)
                            {
                            }

                        }
                        search_thread.Abort();
                        search_thread.Join();
                        search_thread = null;
                    }
                    catch (Exception ex)
                    {
                        ex.ToString();
                    }
                }

                wasteTimer.Enabled = false;

                int rubblishSize = 0;

                for (int i = 0; i < ScanResLisv.Items.Count; i++)
                {
                    int length = ScanResLisv.Items[i].SubItems[1].Text.Length - 1;
                    rubblishSize += Convert.ToInt32(ScanResLisv.Items[i].SubItems[1].Text.Substring(0,length));
                }

                lab_showfile.Text = "扫描结束，" + "有效扫描耗时 " + wasteTime + " 秒，" + "扫描了 " + ScanFileCount + " 个文件" + "，找到 " + ScanResLisv.Items.Count + " 个垃圾文件" + "，共计 " + rubblishSize + "K ！";

                if (ScanResLisv.Items.Count == 0)
                {
                    ScanRestxt.Text = "扫描完成，恭喜您，未发现垃圾文件！";
                }

                btStartScan.Text = "重新扫描";
                btCleaner.Text = "立即清理";
            }
            else
                if (btCleaner.Text == "立即清理")
                {
                    wasteTimer.Enabled = false;
                    int seFlag = 0;
                    for(int i = 0;i < ScanResLisv.Items.Count;i++)
                    {
                        if(ScanResLisv.Items[i].Checked == true)
                        {
                            seFlag = 1;
                            break;
                        }
                    }

                    if (seFlag == 0)
                    {
                        MessageBox.Show("清理前，您至少选择一个需要清理的垃圾文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (rbDelete.Checked == true)
                        {
                            if (MessageBox.Show("您选择了直接删除，垃圾文件将不再进入回收站，确定直接删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                int FailCount = 0, SucessCount = 0;
                                for (int i = 0; i < ScanResLisv.Items.Count; i++)
                                {
                                    if (ScanResLisv.Items[i].Checked == true)
                                    {
                                        File.Delete(ScanResLisv.Items[i].SubItems[0].Text);
                                        if (File.Exists(ScanResLisv.Items[i].SubItems[0].Text))
                                            FailCount++;
                                        else
                                        {
                                            ScanResLisv.Items[i].Remove();
                                            i--;
                                            SucessCount++;
                                        }
                                    }
                                }

                                if (FailCount != 0)
                                    MessageBox.Show("成功删除 " + SucessCount + " 个垃圾文件\r" + "还有 " + FailCount + " 个垃圾文件未清除成功，这些文件可能在使用中\r" + "建议使用文件粉碎机将其粉碎", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("所选垃圾文件已成功直接删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        if (rbRecycle.Checked == true)
                        {
                            if (MessageBox.Show("您选择了将垃圾文件移入回收站，确定不直接删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                int FailCount = 0, SucessCount = 0;
                                for (int i = 0; i < ScanResLisv.Items.Count; i++)
                                {
                                    if (ScanResLisv.Items[i].Checked == true)
                                    {
                                        recycleDelFile(ScanResLisv.Items[i].SubItems[0].Text);
                                        if (File.Exists(ScanResLisv.Items[i].SubItems[0].Text))
                                            FailCount++;
                                        else
                                        {
                                            ScanResLisv.Items[i].Remove();
                                            i--;
                                            SucessCount++;
                                        }
                                    }
                                }

                                if (FailCount != 0)
                                    MessageBox.Show("成功将 " + SucessCount + " 个垃圾文件移至回收站\r" + "还有 " + FailCount + " 个垃圾文件未移动成功，这些文件可能在使用中\r" + "建议“打开文件位置”手动将其移除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else
                                    MessageBox.Show("所选垃圾文件已成功移至回收站", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }
        }


        //将文件移至回收站
        private void recycleDelFile(string fullName)
        {
            try
            {
                //为何不始用File.Delete()，是因为该方法不经过回收站，直接删除文件
                //要删除至回收站，可使用VisualBasic删除文件，需引用Microsoft.VisualBasic
                Microsoft.VisualBasic.FileIO.FileSystem.DeleteFile(fullName,
                    Microsoft.VisualBasic.FileIO.UIOption.OnlyErrorDialogs,
                    Microsoft.VisualBasic.FileIO.RecycleOption.SendToRecycleBin,
                    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出错了" + System.Environment.NewLine + ex.Message);
                return;
            }
        }
        //


        private void wasteTimer_Tick(object sender, EventArgs e)
        {
            wasteTime++;
        }

        private void selAllVolumeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (selAllVolumeCheck.Checked == true)
            {
                for (int i = 0; i < lvwVolumes.Items.Count; i++)
                    lvwVolumes.Items[i].Checked = true;
            }
            else
            {
                for (int i = 0; i < lvwVolumes.Items.Count; i++)
                    lvwVolumes.Items[i].Checked = false;
            }
        }

        private void selAllRubblishCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (selAllRubblishCheck.Checked == true)
            {
                for (int i = 0; i < ScanResLisv.Items.Count; i++)
                    ScanResLisv.Items[i].Checked = true;
            }
            else
            {
                for (int i = 0; i < ScanResLisv.Items.Count; i++)
                    ScanResLisv.Items[i].Checked = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (search_thread != null)
            {
                try
                {
                    if (search_thread.ThreadState == ThreadState.Suspended)
                    {
                        search_thread.Resume();
                        while (search_thread.ThreadState != ThreadState.Running)
                        {

                        }
                    }
                    search_thread.Abort();
                    search_thread.Join();
                    search_thread = null;
                }
                catch (Exception ex)
                {
                    ex.ToString();
                }
            }
        }

        private void ScanResLisv_Click(object sender, EventArgs e)
        {
            if (ScanResLisv.SelectedItems.Count != 0)
                btOpenPath.Enabled = true;
        }

        private void btOpenPath_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ScanResLisv.Items.Count; i++)
            {
                if (ScanResLisv.Items[i].Selected == true)
                {
                    string filePath = ScanResLisv.Items[i].SubItems[0].Text.Substring(0, (ScanResLisv.Items[i].SubItems[0].Text.LastIndexOf("\\")));
                    System.Diagnostics.Process.Start(filePath);
                }
            }
        }
    }
}
