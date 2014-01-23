using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Management;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Drawing;
namespace ISoft
{
    class PublicClass
    {
        private string ConvertStr(string str)
        {
            string pp = "";
            switch (str)
            {
                case "AddressWidth":
                    pp = "地址宽度";
                    break;
                case "Architecture":
                    pp = "结构";
                    break;
                case "Availability":
                    pp = "可用";
                    break;
                case "Caption":
                    pp = "内部标记";
                    break;
                case "CpuStatus":
                    pp = "处理器情况";
                    break;
                case "CreationClassName":
                    pp = "创造类名称";
                    break;
                case "CurrentClockSpeed":
                    pp = "当前时钟速度";
                    break;
                case "CurrentVoltage":
                    pp = "当前电压";
                    break;
                case "DataWidth":
                    pp = "数据宽度";
                    break;
                case "Description":
                    pp = "描述";
                    break;
                case "DeviceID":
                    pp = "版本";
                    break;
                case "ExtClock":
                    pp = "外部时钟";
                    break;
                case "L2CacheSize":
                    pp = "二级缓存";
                    break;
                case "L2CacheSpeed":
                    pp = "二级缓存速度";
                    break;
                case "Level":
                    pp = "级别";
                    break;
                case "LoadPercentage":
                    pp = "符合百分比";
                    break;
                case "Manufacturer":
                    pp = "制造商";
                    break;
                case "MaxClockSpeed":
                    pp = "最大时钟速度";
                    break;
                case "Name":
                    pp = "名称";
                    break;
                case "PowerManagementSupported":
                    pp = "电源管理支持";
                    break;
                case "ProcessorId":
                    pp = "处理器号码";
                    break;
                case "ProcessorType":
                    pp = "处理器类型";
                    break;
                case "Role":
                    pp = "类型";
                    break;
                case "SocketDesignation":
                    pp = "插槽名称";
                    break;
                case "Status":
                    pp = "状态";
                    break;
                case "StatusInfo":
                    pp = "状态信息";
                    break;
                case "Stepping":
                    pp = "分级";
                    break;
                case "SystemCreationClassName":
                    pp = "系统创造类名称";
                    break;
                case "SystemName":
                    pp = "系统名称";
                    break;
                case "UpgradeMethod":
                    pp = "升级方法";
                    break;
                case "Version":
                    pp = "型号";
                    break;
                case "Family":
                    pp = "家族";
                    break;
                case "Revision":
                    pp = "修订版本号";
                    break;
                case "PoweredOn":
                    pp = "电源开关";
                    break; 
                case "Product":
                    pp = "产品";
                    break; 
                    
            }
            if (pp == "")
                pp = str;
            return pp;
        }
        public void InsertInfo(string Key, ref ListView lst, bool DontInsertNull)
        {
            lst.Items.Clear();
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from " + Key);
            try
            {
                foreach (ManagementObject share in searcher.Get())
                {
                    ListViewGroup grp;
                    try
                    {
                        grp = lst.Groups.Add(share["Name"].ToString(), share["Name"].ToString());
                    }
                    catch
                    {
                        grp = lst.Groups.Add(share.ToString(), share.ToString());
                    }

                    if (share.Properties.Count <= 0)
                    {
                        MessageBox.Show("No Information Available", "No Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    foreach (PropertyData PC in share.Properties)
                    {
                        ListViewItem item = new ListViewItem(grp);
                        if (lst.Items.Count % 2 != 0)
                            item.BackColor = Color.White;
                        else
                            item.BackColor = Color.WhiteSmoke;
                        item.Text =ConvertStr(PC.Name);
                        if (PC.Value != null && PC.Value.ToString() != "")
                        {
                            switch (PC.Value.GetType().ToString())
                            {
                                case "System.String[]":
                                    string[] str = (string[])PC.Value;
                                    string str2 = "";
                                    foreach (string st in str)
                                        str2 += st + " ";
                                    item.SubItems.Add(str2);
                                    break;
                                case "System.UInt16[]":
                                    ushort[] shortData = (ushort[])PC.Value;
                                    string tstr2 = "";
                                    foreach (ushort st in shortData)
                                        tstr2 += st.ToString() + " ";
                                    item.SubItems.Add(tstr2);
                                    break;
                                default:
                                    item.SubItems.Add(PC.Value.ToString());
                                    break;
                            }
                        }
                        else
                        {
                            if (!DontInsertNull)
                                item.SubItems.Add("没有信息");
                            else
                                continue;
                        }

                        lst.Items.Add(item);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        string[] info = new string[2];
        public void getInfo1(ListView lv)
        {
            info[0] = "操作系统";
            info[1]=Environment.OSVersion.VersionString;
            ListViewItem item = new ListViewItem(info, "操作系统");
            lv.Items.Add(item);

            RegistryKey mykey = Registry.LocalMachine;
            mykey = mykey.CreateSubKey("Software\\Microsoft\\Windows NT\\CurrentVersion");
            string a = (string)mykey.GetValue("RegisteredOrganization");
            mykey.Close();
            info[0] = "注册用户";
            info[1] = a;
            ListViewItem item1 = new ListViewItem(info, "注册用户");
            lv.Items.Add(item1);

            info[0] = "Windows文件夹";
            info[1] = Environment.GetEnvironmentVariable("WinDir");
            ListViewItem item2 = new ListViewItem(info, "Windows文件夹");
            lv.Items.Add(item2);

            info[0] = "系统文件夹";
            info[1] = Environment.SystemDirectory.ToString();
            ListViewItem item3= new ListViewItem(info, "系统文件夹");
            lv.Items.Add(item3);

            info[0] = "计算机名称";
            info[1] = Environment.MachineName.ToString();
            ListViewItem item4 = new ListViewItem(info, "计算机名称");
            lv.Items.Add(item4);

            info[0] = "本地日期时间";
            info[1] = DateTime.Now.ToString();
            ListViewItem item5 = new ListViewItem(info, "本地日期时间");
            lv.Items.Add(item5);

            string MyInfo = "";
            ManagementObjectSearcher MySearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject MyObject in MySearcher.Get())
            {
                MyInfo += MyObject["InstallDate"].ToString().Substring(0, 8);
            }
            MyInfo = MyInfo.Insert(4, "-");
            MyInfo = MyInfo.Insert(7,"-");
            info[0] = "系统安装日期";
            info[1] = MyInfo;
            ListViewItem item6 = new ListViewItem(info, "系统安装日期");
            lv.Items.Add(item6);


            String MyInfo1 = "";
            ManagementObjectSearcher MySearcher1 = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject MyObject in MySearcher1.Get())
            {
                MyInfo1 += MyObject["LastBootUpTime"].ToString().Substring(0, 8);
            }
            MyInfo1 = MyInfo1.Insert(4, "-");
            MyInfo1 = MyInfo1.Insert(7, "-");
            info[0] = "系统启动时间";
            info[1] = MyInfo1;
            ListViewItem item7 = new ListViewItem(info, "系统启动时间");
            lv.Items.Add(item7);

            Microsoft.VisualBasic.Devices.Computer My = new Microsoft.VisualBasic.Devices.Computer();
            info[0]="物理内存总量(M)";
            info[1] = (My.Info.TotalPhysicalMemory / 1024 / 1024).ToString();
            ListViewItem item8 = new ListViewItem(info, "物理内存总量(M)");
            lv.Items.Add(item8);

            info[0] = "虚拟内存总量(M)";
            info[1] = (My.Info.TotalVirtualMemory / 1024 / 1024).ToString();
            ListViewItem item9 = new ListViewItem(info, "虚拟内存总量(M)");
            lv.Items.Add(item9);

            info[0] = "可用物理内存总量(M)";
            info[1] =(My.Info.AvailablePhysicalMemory / 1024 / 1024).ToString();
            ListViewItem item10 = new ListViewItem(info, "可用物理内存总量(M)");
            lv.Items.Add(item10);

            info[0] = "可用虚拟内存总量(M)";
            info[1] = (My.Info.AvailableVirtualMemory / 1024 / 1024).ToString();
            ListViewItem item11 = new ListViewItem(info, "可用虚拟内存总量(M)");
            lv.Items.Add(item11);

            info[0] = "系统驱动器";
            info[1] = Environment.GetEnvironmentVariable("SystemDrive");
            ListViewItem item12 = new ListViewItem(info, "系统驱动器");
            lv.Items.Add(item12);

            info[0] = "桌面目录";
            info[1] = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            ListViewItem item13 = new ListViewItem(info, "系统驱动器");
            lv.Items.Add(item13);

            info[0] = "用户程序组目录";
            info[1] = Environment.GetFolderPath(Environment.SpecialFolder.Programs);
            ListViewItem item14 = new ListViewItem(info, "用户程序组目录");
            lv.Items.Add(item14);

            info[0] = "收藏夹目录";
            info[1] = Environment.GetFolderPath(Environment.SpecialFolder.Favorites);
            ListViewItem item15 = new ListViewItem(info, "收藏夹目录");
            lv.Items.Add(item15);

            info[0] = "Internet历史记录";
            info[1] = Environment.GetFolderPath(Environment.SpecialFolder.History);
            ListViewItem item16 = new ListViewItem(info, "Internet历史记录");
            lv.Items.Add(item16);

            info[0] = "Internet临时文件";
            info[1] = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache);
            ListViewItem item17 = new ListViewItem(info, "Internet临时文件");
            lv.Items.Add(item17);
            
 
        }

        public void getInfo4(ListView lv)
        {
            Process[] myprocesses = Process.GetProcesses();
            foreach (Process myprocess in myprocesses)
            {
                info[0] = myprocess.ProcessName;
                info[1] = "ID:" + myprocess.Id.ToString() + "," + "优先级:" + myprocess.BasePriority.ToString() + "," + "线程数量:" + myprocess.Threads.Count.ToString();
                ListViewItem item = new ListViewItem(info, "用户名称");
                lv.Items.Add(item);
            }
        }

    }

}
