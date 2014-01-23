using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace ScanLargeFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1.CheckForIllegalCrossThreadCalls = false;
        }
        private string selectDisk;
        private string scanningDisk; 
        Thread search_thread = null;
        private void Form1_Load(object sender, EventArgs e)
        {
            tsLocalVolumes.Renderer = new VistaRenderer.WindowsVistaRenderer();
            tsDriver.Renderer = new VistaRenderer.WindowsVistaRenderer();

            initialDiskRead();

            label5.Text = "为您找出占用 " + tsLocalVolumes.Items[0].Text + " 空间50个大文件，并可按类型对文件进行分类管理";

            label4.Text = "扫描 " + tsLocalVolumes.Items[0].Text + " ?";

            lab_showfile.Text = tsLocalVolumes.Items[0].Text + " 等待扫描...";

            selectDisk = tsLocalVolumes.Items[0].Text.Substring(1, 2) + "\\";

            scanningDisk = tsLocalVolumes.Items[0].Text;
        }

        private void show(object sender, EventArgs e)
        {
            if (search_thread != null)
            {
                if (search_thread.ThreadState == ThreadState.Running||search_thread.ThreadState == ThreadState.Suspended)
                {
                    search_thread.Suspend();

                    for (int i = 0; i < tsLocalVolumes.Items.Count; i++)
                    {
                        if (tsLocalVolumes.Items[i].Selected == true)
                        {

                            if (MessageBox.Show("正在扫描 " + scanningDisk + "\r切换磁盘将停止当前扫描,确定切换到 " + tsLocalVolumes.Items[i].Text + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                search_Thread_stop();

                                search_thread = null;

                                lvScanResult.Items.Clear();
                                lvScanResult.Visible = false;
                                pannerShow.Visible = true;

                                string driverPath = tsLocalVolumes.Items[i].Text.Substring(1, 2) + "\\";
                                label4.Text = "扫描 " + tsLocalVolumes.Items[i].Text + " ?";

                                lab_showfile.Text = tsLocalVolumes.Items[i].Text + " 等待扫描...";

                                string diskFlag = tsLocalVolumes.Items[i].Text.Substring(1, 2) + "\\";
                                diskInfo(diskFlag);

                                selectDisk = diskFlag;
                                scanningDisk = tsLocalVolumes.Items[i].Text;

                                break;

                            }
                            else
                            {
                                search_thread.Resume();
                                break;
                            }                          
                        }
                    }

                    for (int i = 0; i < tsDriver.Items.Count; i++)
                    {
                        if (tsDriver.Items[i].Selected == true)
                        {
                            if (MessageBox.Show("正在扫描 " + scanningDisk + "\r切换磁盘将停止当前扫描,确定切换到 " + tsDriver.Items[i].Text + " 吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                search_Thread_stop();

                                search_thread = null;

                                lvScanResult.Items.Clear();
                                lvScanResult.Visible = false;
                                pannerShow.Visible = true;
                                string driverPath = tsDriver.Items[i].Text.Substring(1, 2) + "\\";
                                label4.Text = "扫描 " + tsDriver.Items[i].Text + " ?";

                                lab_showfile.Text = tsDriver.Items[i].Text + " 等待扫描...";

                                string diskFlag = tsDriver.Items[i].Text.Substring(1, 2) + "\\";
                                diskInfo(diskFlag);

                                selectDisk = diskFlag;

                                scanningDisk = tsDriver.Items[i].Text;

                                break;
                            }
                            else
                            {
                                search_thread.Resume();
                                break;
                            }
                        }
                    }                    
                }
            }
            else
            {
                scanShow();
            }
        }

        private void scanShow()
        {
            for (int i = 0; i < tsLocalVolumes.Items.Count; i++)
            {
                if (tsLocalVolumes.Items[i].Selected == true)
                {
                    lvScanResult.Items.Clear();
                    lvScanResult.Visible = false;
                    pannerShow.Visible = true;

                    string driverPath = tsLocalVolumes.Items[i].Text.Substring(1, 2) + "\\";
                    label4.Text = "扫描 " + tsLocalVolumes.Items[i].Text + " ?";

                    lab_showfile.Text = tsLocalVolumes.Items[i].Text + " 等待扫描...";

                    string diskFlag = tsLocalVolumes.Items[i].Text.Substring(1, 2) + "\\";
                    diskInfo(diskFlag);

                    selectDisk = diskFlag;
                    scanningDisk = tsLocalVolumes.Items[i].Text;

                    break;
                }
            }

            for (int i = 0; i < tsDriver.Items.Count; i++)
            {
                if (tsDriver.Items[i].Selected == true)
                {
                    string driverPath = tsDriver.Items[i].Text.Substring(1, 2) + "\\";
                    label4.Text = "扫描 " + tsDriver.Items[i].Text + " ?";

                    lab_showfile.Text = tsDriver.Items[i].Text + " 等待扫描...";

                    string diskFlag = tsDriver.Items[i].Text.Substring(1, 2) + "\\";
                    diskInfo(diskFlag);

                    selectDisk = diskFlag;

                    scanningDisk = tsDriver.Items[i].Text;

                    break;
                }
            }
        }
        private void diskInfo(string diskFlag)
        {
            label5.Text = "正在统计磁盘信息...";
            try
            {
                WMIDrives wmiDrives = new WMIDrives();
                int num2;
                if (wmiDrives.VolumeLetter != null)
                {
                    int num4 = wmiDrives.VolumeLetter.Count - 1;
                    for (num2 = 0; num2 <= num4; num2++)
                    {
                        if (wmiDrives.VolumeLetter[num2].ToString() == diskFlag)
                            label5.Text = wmiDrives.VolumeLetter[num2].ToString().Substring(0, 1) + "盘空间总计： " + GeneralModule.FormatBytes(double.Parse(wmiDrives.VolumeTotalSize[num2].ToString())) + " （已用 " + GeneralModule.FormatBytes(double.Parse(wmiDrives.VolumeUsedSpace[num2].ToString())) + "，剩余 " + GeneralModule.FormatBytes(double.Parse(wmiDrives.VolumeFreeSpace[num2].ToString())) + " ) 建议马上扫描";
                    }
                }
            }
            catch
            {
                label5.Text = "磁盘信息读取出错！";
                return;
            }
        }

        private void initialDiskRead()
        {

            try
            {
                WMIDrives wmiDrives = new WMIDrives();
                int num2 ;
                this.tsLocalVolumes.Items.Clear();
                if (wmiDrives.VolumeLetter != null)
                {
                    int num4 = wmiDrives.VolumeLetter.Count - 1;
                    for (num2 = 0; num2 <= num4; num2++)
                    {
                        if (wmiDrives.VolumeFileSystem != null)
                        {
                            if (wmiDrives.VolumeFileSystem[num2].ToString() == "NTFS")
                            {
                                if (wmiDrives.VolumeLabel[num2].ToString() == "")
                                {
                                    ToolStripButton item = tsLocalVolumes.Items.Add("button1") as ToolStripButton;

                                    item.AutoSize = false;
                                    item.Size = new Size(190, 35);

                                    item.Image = imageList1.Images[1];
                                    item.ImageAlign = ContentAlignment.MiddleLeft;

                                    item.Text = "(" + wmiDrives.VolumeLetter[num2].ToString().Substring(0, 2) + ")" + "系统盘";
                                    item.TextAlign = ContentAlignment.MiddleLeft;

                                    tsLocalVolumes.Items[tsLocalVolumes.Items.Count - 1].Click += new EventHandler(show);
                                }
                                else
                                {

                                    ToolStripButton item = tsLocalVolumes.Items.Add("button1") as ToolStripButton;

                                    item.AutoSize = false;
                                    item.Size = new Size(190, 35);

                                    item.Image = imageList1.Images[0];
                                    item.ImageAlign = ContentAlignment.MiddleLeft;

                                    item.Text = "(" + wmiDrives.VolumeLetter[num2].ToString().Substring(0, 2) + ")" + wmiDrives.VolumeLabel[num2].ToString();
                                    item.TextAlign = ContentAlignment.MiddleLeft;

                                    tsLocalVolumes.Items[tsLocalVolumes.Items.Count - 1].Click += new EventHandler(show);
                                }
                            }
                            else
                            {
                                if (wmiDrives.VolumeFileSystem[num2].ToString() == "FAT32")
                                {
                                    ToolStripButton item = tsDriver.Items.Add("button1") as ToolStripButton;

                                    item.AutoSize = false;
                                    item.Size = new Size(190, 35);

                                    item.Image = imageList1.Images[0];
                                    item.ImageAlign = ContentAlignment.MiddleLeft;

                                    item.Text = "(" + wmiDrives.VolumeLetter[num2].ToString().Substring(0, 2) + ")" + wmiDrives.VolumeLabel[num2].ToString();
                                    item.TextAlign = ContentAlignment.MiddleLeft;

                                    tsDriver.Items[tsDriver.Items.Count - 1].Click += new EventHandler(show);
                                }
                            }
                        }
                        else
                        {
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }

        

        private void btStartScan_Click(object sender, EventArgs e)
        {
            pannerShow.Visible = false;
            lvScanResult.Visible = true;
            label5.Text = "为您找出占用 " + scanningDisk + " 空间50个大文件，并可按类型对文件进行分类管理";
            lab_showfile.Text = scanningDisk + " 等待扫描...";

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
        private void startsearch()
        {
            lvScanResult.Items.Clear();
            ScanFiles(selectDisk);
        }

        private void ScanFiles(string filepath)
        {         
            if (filepath.Trim().Length > 0)
            {
                try
                {
                    string[] filecollect = Directory.GetFileSystemEntries(filepath);
                    foreach (string file in filecollect)
                    {

                        if (Directory.Exists(file))
                        {
                            if (lvScanResult.Items.Count < 25)
                                ScanFiles(file);
                            else
                            {
                                try
                                {
                                    if (search_thread != null)
                                    {
                                        if (search_thread.ThreadState == ThreadState.Suspended || search_thread.ThreadState == ThreadState.Running)
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
                                }
                                catch
                                {
                                    search_thread = null;
                                    lab_showfile.Text = scanningDisk + " 50个大文件扫描完成，请点击右键定位文件---------------------------------->>>>>>>";
                                }
                            }
                        }
                        else
                        {
                            ListViewItem item;
                            lab_showfile.Text = "正在扫描：" + file;
                            System.IO.FileInfo f = new System.IO.FileInfo(file);
                            if (f.Length >= 20971520)
                            {
                                item = new ListViewItem(f.Name);

                                int j = imageList2.Images.Count;
                                ApiGetICON.GetIcon(file, imageList2);
                                item.ImageIndex = j;

                                item.SubItems.Add(GeneralModule.FormatBytes(double.Parse(f.Length.ToString())));
                                item.SubItems.Add(file);
                                lvScanResult.Items.Add(item);
                            }
                        }
                    }
                }
                catch 
                {
                    //MessageBox.Show("扫描已经完成");

                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            search_Thread_stop();
        }

        private void search_Thread_stop()
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

        private void locationSite_Click(object sender, EventArgs e)
        {
            int selFlag = 0;
            for (int i = 0; i < lvScanResult.Items.Count; i++)
            {
                if (lvScanResult.Items[i].Selected == true)
                {
                    string path = lvScanResult.Items[i].SubItems[2].Text.Substring(0, lvScanResult.Items[i].SubItems[2].Text.LastIndexOf("\\") + 1);
                    System.Diagnostics.Process.Start(path);

                    selFlag = 1;

                    break;
                }
            }

            if (selFlag == 0)
                MessageBox.Show("请先选择一个文件进行定位", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
