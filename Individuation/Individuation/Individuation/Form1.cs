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
using Microsoft.Win32;
using IWshRuntimeLibrary;
using System.Collections;
using System.Diagnostics;

namespace Individuation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //调用API实现计算机的锁定功能
        [DllImport("user32.dll")]
        private static extern void LockWorkStation();
        //

        private void Form1_Load(object sender, EventArgs e)
        {
            CompInfo();
            ScreenSizelbl.Text = Screen.PrimaryScreen.Bounds.Width.ToString() + "x" + Screen.PrimaryScreen.Bounds.Height.ToString();

            string b = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            GetListViewItem(b, imageList1, listView5);

            DrviersList();
        }

        #region 发送到菜单模块
        public class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
            public const uint SHGFI_SMALLICON = 0x1; // 'Small icon
            [DllImport("shell32.dll", EntryPoint = "ExtractIcon")]
            public static extern int ExtractIcon(IntPtr hInst, string lpFileName, int nIndex);
            [DllImport("shell32.dll", EntryPoint = "SHGetFileInfo")]
            public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttribute, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint Flags);
            [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
            public static extern int DestroyIcon(IntPtr hIcon);
            [DllImport("shell32.dll")]
            public static extern uint ExtractIconEx(string lpszFile, int nIconIndex, int[] phiconLarge, int[] phiconSmall, uint nIcons);
            [StructLayout(LayoutKind.Sequential)]
            public struct SHFILEINFO
            {
                public IntPtr hIcon;
                public IntPtr iIcon;
                public uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                public string szTypeName;
            }
        }

        

        public void GetListViewItem(string path, ImageList imglist, ListView lv)//获取指定路径下所有文件及其图标
        {
            lv.Items.Clear();
            Win32.SHFILEINFO shfi = new Win32.SHFILEINFO();
            try
            {
                string[] dirs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                for (int i = 0; i < dirs.Length; i++)
                {
                    string[] info = new string[4];
                    DirectoryInfo dir = new DirectoryInfo(dirs[i]);
                    if (dir.Name == "RECYCLER" || dir.Name == "RECYCLED" || dir.Name == "Recycled" || dir.Name == "System Volume Information")
                    { }
                    else
                    {
                        //获得图标
                        Win32.SHGetFileInfo(dirs[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //取得Icon和TypeName
                        //添加图标
                        imglist.Images.Add(dir.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = dir.Name.Remove(dir.Name.LastIndexOf("."));
                        info[1] = "";
                        info[2] = "文件夹";
                        info[3] = dir.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, dir.Name);
                        lv.Items.Add(item);
                        //销毁图标
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
                for (int i = 0; i < files.Length; i++)
                {
                    string[] info = new string[4];
                    FileInfo fi = new FileInfo(files[i]);
                    string Filetype = fi.Name.Substring(fi.Name.LastIndexOf(".") + 1, fi.Name.Length - fi.Name.LastIndexOf(".") - 1);
                    string newtype = Filetype.ToLower();
                    if (newtype == "sys" || newtype == "ini" || newtype == "bin" || newtype == "log" || newtype == "com" || newtype == "bat" || newtype == "db")
                    { }
                    else
                    {


                        //获得图标
                        Win32.SHGetFileInfo(files[i],
                                            (uint)0x80,
                                            ref shfi,
                                            (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                                            (uint)(0x100 | 0x400)); //取得Icon和TypeName
                        //添加图标
                        imglist.Images.Add(fi.Name, (Icon)Icon.FromHandle(shfi.hIcon).Clone());
                        info[0] = fi.Name.Remove(fi.Name.LastIndexOf("."));
                        info[1] = fi.Length.ToString();
                        info[2] = fi.Extension.ToString();
                        info[3] = fi.LastWriteTime.ToString();
                        ListViewItem item = new ListViewItem(info, fi.Name);
                        lv.Items.Add(item);
                        //销毁图标
                        Win32.DestroyIcon(shfi.hIcon);
                    }
                }
            }
            catch
            {
                MessageBox.Show("发生未知错误", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btNew_Click(object sender, EventArgs e)
        {
            string sendtostr = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string px = folderBrowserDialog1.SelectedPath;
                string FolderName = "";
                if (px.Length != 3)
                {
                    int SameCheckFlag = 0;
                    FolderName = px.Substring(px.LastIndexOf("\\") + 1);

                    if (FolderName == "Desktop")
                    {
                        MessageBox.Show("已存在相同的发送到菜单项 Desktop (create shotcut)", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int i = 0; i < listView5.Items.Count; i++)
                    {
                        if (listView5.Items[i].SubItems[0].Text == FolderName)
                        {
                            SameCheckFlag = 1;
                            break;
                        }
                    }

                    if (SameCheckFlag == 1)
                    {
                        MessageBox.Show("已存在相同的发送到菜单项 " + FolderName, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SameCheckFlag = 0;
                        return;
                    }
                    
                }
                else
                {
                    int SameCheckFlag = 0;

                    FolderName = "磁盘" + px.Remove(px.LastIndexOf(":"));

                    for (int i = 0; i < listView5.Items.Count; i++)
                    {
                        if (listView5.Items[i].SubItems[0].Text == FolderName)
                        {
                            SameCheckFlag = 1;
                            break;
                        }
                    }

                    if (SameCheckFlag == 1)
                    {
                        MessageBox.Show("已存在相同的发送到菜单项 " + FolderName, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        SameCheckFlag = 0;
                        return;
                    }
                }
                //创建快捷方式
                //建立对象
                WshShell shell = new WshShell();
                //生成快捷方式文件，指定路径及文件名
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(sendtostr + "\\" + FolderName + ".lnk");
                //快捷方式指向的目标
                shortcut.TargetPath = px;
                //起始目录
                shortcut.WorkingDirectory = System.Environment.CurrentDirectory;
                //窗口类型
                shortcut.WindowStyle = 1;
                //描述
                shortcut.Description = "my Application";
                //图标
                shortcut.IconLocation = System.Environment.SystemDirectory + "\\" + "shell32.dll, 165";
                //保存，注意一定要保存，否则无效
                shortcut.Save();
                string b = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
                GetListViewItem(b, imageList1, listView5);

                MessageBox.Show("新建发送到菜单添加成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择某个选项进行删除", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string sendtostr = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
                string fname = listView5.SelectedItems[0].Text;
                ArrayList al = new ArrayList();
                DirectoryInfo di = new DirectoryInfo(sendtostr);
                FileSystemInfo[] fsi = di.GetFileSystemInfos();
                for (int i = 0; i < fsi.Length; i++)
                {
                    if (fsi[i].ToString().Substring(fsi[i].ToString().LastIndexOf(".") + 1) != "lnk")
                    {
                        al.Add(fsi[i].ToString().Remove(fsi[i].ToString().LastIndexOf(".")));
                    }
                }
                bool check = true;
                for (int j = 0; j < al.Count; j++)
                {
                    if (al[j].ToString() == fname)
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    System.IO.FileInfo fi = new FileInfo(sendtostr + "\\" + fname + ".lnk");
                    fi.Delete();
                }
            }

            string b = Environment.GetFolderPath(Environment.SpecialFolder.SendTo);
            GetListViewItem(b, imageList1, listView5);

            MessageBox.Show("删除陈功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region 修改计算机信息模块

        private void btModify_Click(object sender, EventArgs e)
        {

            if (CurrentCompNameTxt1.Text == ""|| RegName.Text == "")
            {
                MessageBox.Show("名称不能为空！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {

                RegistryKey bot = Registry.LocalMachine;

                RegistryKey jsj = bot.OpenSubKey(@"SYSTEM\ControlSet001\Services\Tcpip\Parameters", true);
                RegistryKey info = bot.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion", true);
                jsj.SetValue("NV Hostname", CurrentCompNameTxt1.Text);
                info.SetValue("RegisteredOrganization", RegCommuNameTxt1.Text);
                info.SetValue("RegisteredOwner", RegName1.Text);
                MessageBox.Show("修改成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
                CompInfo();
            }
        }

        
        private void CompInfo()
        {
            RegistryKey bot = Registry.LocalMachine;

            RegistryKey jsj = bot.OpenSubKey(@"SYSTEM\ControlSet001\Services\Tcpip\Parameters");
            RegistryKey info = bot.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

            foreach (string s in jsj.GetValueNames())
            {

                if (s == "NV Hostname")
                {
                    CurrentCompNameTxt.Text = CurrentCompNameTxt1.Text = jsj.GetValue(s).ToString();
                    bot.Close();
                }

            }
            foreach (string s in info.GetValueNames())
            {
                if (s == "RegisteredOrganization")
                    RegCommuNameTxt.Text = RegCommuNameTxt1.Text = info.GetValue(s).ToString();
                if (s == "RegisteredOwner")
                    RegName.Text = RegName1.Text = info.GetValue(s).ToString();

            }
            info.Close();
        }

        #endregion

        #region 修改开机画面模块

        private void btPicBrower_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "图片文件(*.jpg,*.bmp,*.gif,*.png|*.jpg;*.bmp;*.gif;*.png)";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PicDirectTxt.Text = openFileDialog1.FileName;
                PicShow.Image = Image.FromFile(openFileDialog1.FileName);
                PicShow.Visible = true;
            }
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            if (PicDirectTxt.Text == "")
            {
                MessageBox.Show("请先选择选择图片！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                RegistryKey reg;
                reg = Registry.LocalMachine;
                reg = reg.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI\\Background",true);
                reg.SetValue("OEMBackground", 1, RegistryValueKind.DWord);
                reg.Close();

                Directory.CreateDirectory("C:/Windows/System32/oobe/info/backgrounds");
                System.IO.File.Copy(PicDirectTxt.Text, "C:/Windows/System32/oobe/info/backgrounds/backgroundDefault.jpg", true);

                if (MessageBox.Show("修改成功，您现在就想查看修改后的效果吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    LockWorkStation(); 
                }

            }
        }

        private void btRecover_Click(object sender, EventArgs e)
        {
            RegistryKey reg;
            reg = Registry.LocalMachine;
            reg = reg.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Authentication\\LogonUI\\Background", true);
            reg.SetValue("OEMBackground", 0, RegistryValueKind.DWord);
            reg.Close();

            if (MessageBox.Show("恢复成功，您现在就想查看恢复到系统默认后的效果吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                LockWorkStation();
            }
        }

        private void btOpenSave_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:/Windows/System32/oobe/info/backgrounds");
        }

        #endregion

        private void DrviersList()
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

                                this.lvwVolumes.Items[num2].SubItems.Add("正常");
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

        private void btHide_Click(object sender, EventArgs e)
        {
            int iData = 0, chekFlag = 0;
            for (int i = 0; i < lvwVolumes.Items.Count; i++)
            {
                if (lvwVolumes.Items[i].Checked == true)
                {
                    chekFlag = i;
                    string StrPath = lvwVolumes.Items[i].SubItems[0].Text;
                    string DriverLetter = StrPath.Substring(0, 1);
                    switch (DriverLetter)
                    {
                        case "A":
                            iData += 1;
                            break;
                        case "B":
                            iData += 1 * 2;
                            break;
                        case "C":
                            iData += 1 * 2 * 2;
                            break;
                        case "D":
                            iData += 1 * 2 * 2 * 2;
                            break;
                        case "E":
                            iData += 1 * 2 * 2 * 2 * 2;
                            break;
                        case "F":
                            iData += 1 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "G":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "H":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "I":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "J":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "K":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "L":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "M":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "N":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "O":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "P":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "Q":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "R":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "S":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "T":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "U":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "V":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "W":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "X":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "Y":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        case "Z":
                            iData += 1 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2 * 2;
                            break;
                        default:
                            break;
                    }
                }
            }
			try
			{
				RegistryKey MyReg=Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer");
				MyReg.SetValue("NoDrives",iData);
				MyReg.Close();
                lvwVolumes.Items[chekFlag].SubItems[2].Text = "隐藏";
                if (MessageBox.Show("隐藏驱动器操作成功,现在就要查看效果吗？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process[] explorers = Process.GetProcessesByName("explorer");
                    foreach (Process ex in explorers)
                    {
                        ex.Kill();
                    }
                }					
			}
			catch(Exception Err)
			{
				MessageBox.Show("隐藏驱动器发生错误："+Err.Message,"信息提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}		
		}

        private void btShow_Click(object sender, EventArgs e)
        {
            //取消隐藏驱动器
            try
            {
                RegistryKey MyReg = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true);
                MyReg.DeleteValue("NoDrives");
                MyReg.Close();
                if (MessageBox.Show("显示驱动器操作成功,现在就要查看效果吗？", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Process[] explorers = Process.GetProcessesByName("explorer");
                    foreach (Process ex in explorers)
                    {
                        ex.Kill();
                    }
                }	
            }
            catch (Exception Err)
            {
                MessageBox.Show("显示驱动器发生错误：" + Err.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
