using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Runtime.InteropServices;
using System.ServiceProcess;

namespace OSSpeed
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //try
            //{
            initialStart();
            initialSevice();
            //}
            //catch
            //{
            //    MessageBox.Show("非常抱歉，发生未知错误，请联系作者", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    System.Diagnostics.Process.GetCurrentProcess().Kill();
            //}
        }

        #region 开机启动项优化模块

        private void initialStart()
        {
            lvStart.Items.Clear();
            ListViewItem item;
            RegistryKey run = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            RegistryKey run2 = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            foreach (string s in run.GetValueNames())
            {
                string startPath = run.GetValue(s).ToString();
                item = new ListViewItem(s);

                try
                {
                    int i = imageList1.Images.Count;

                    ApiGetICON.GetIcon(startPath.Substring(1, run.GetValue(s).ToString().LastIndexOf("\"") - 1), imageList1);
                    item.ImageIndex = i;
                }
                catch
                {

                }

                item.SubItems.Add(startPath);
                item.SubItems.Add(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                lvStart.Items.Add(item);

            }


            foreach (string s in run2.GetValueNames())
            {
                string startPath = run2.GetValue(s).ToString();

                item = new ListViewItem(s);

                try
                {
                    int i = imageList1.Images.Count;

                    ApiGetICON.GetIcon(startPath.Substring(1, run2.GetValue(s).ToString().LastIndexOf("/") - 1), imageList1);
                    item.ImageIndex = i;

                }
                catch
                {
                }

                item.SubItems.Add(run2.GetValue(s).ToString());
                item.SubItems.Add(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run");
                lvStart.Items.Add(item);

            }
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string regSite = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

                int confirmDeleteFlag = 0;

                for (int i = 0; i < lvStart.Items.Count; i++)
                {
                    if (lvStart.Items[i].Checked == true)
                    {
                        confirmDeleteFlag = 1;
                        break;
                    }
                }

                if (confirmDeleteFlag == 1)
                {
                    if (MessageBox.Show("您确定要删除选中的启动项吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        for (int i = 0; i < lvStart.Items.Count; i++)
                        {
                            if (lvStart.Items[i].Checked == true)
                                regDelete(regSite, lvStart.Items[i].Text);
                        }
                        initialStart();
                    }
                    else
                        return;
                }
                else
                    MessageBox.Show("未选中任何要删除的启动项", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("发生未知错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 删除注册表信息的方法
        /// </summary>
        /// <param name="lu">路径</param>
        /// <param name="name">名称</param>
        private void regDelete(string regSite, string name)
        {
            RegistryKey bot = Registry.LocalMachine;
            RegistryKey dr = bot.OpenSubKey(regSite, true);
            string[] dirs = dr.GetValueNames();
            foreach (string s in dr.GetValueNames())
            {
                if (s == name)
                    dr.DeleteValue(s, false);
            }

            RegistryKey bot1 = Registry.CurrentUser;
            RegistryKey dr1 = bot1.OpenSubKey(regSite, true);
            string[] dirs1 = dr1.GetValueNames();
            foreach (string s in dr1.GetValueNames())
            {
                if (s == name)
                    dr1.DeleteValue(s, false);
            }
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            initialStart();
            MessageBox.Show("开机启动项列表刷新完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region 服务优化模块

        private void initialSevice()
        {
            try
            {
                ServiceController[] Services = ServiceController.GetServices();
                lvService.Items.Clear();
                ListViewItem item;
                foreach (ServiceController s in Services)
                {
                    item = new ListViewItem(s.DisplayName);

                    int i = imageList2.Images.Count;

                    ApiGetICON.GetIcon(GetWindowsServicePath(s.ServiceName), imageList2);
                    item.ImageIndex = i;

                    if (s.Status.ToString() == "Stopped")
                        item.SubItems.Add("已停止");
                    else
                        item.SubItems.Add("已启动");
                    //item.SubItems.Add(s.ServiceType.ToString());
                    item.SubItems.Add(GetWindowsServicePath(s.ServiceName));

                    if (ServiceDes(s.ServiceName) == null)
                    {
                        item.SubItems.Add("未查到此服务的详细信息");
                    }
                    else
                    {
                        item.SubItems.Add(ServiceDes(s.ServiceName));
                    }

                    lvService.Items.Add(item);

                }
            }
            catch (Exception eK)
            {
                MessageBox.Show(eK.Message);
                return;
            }
        }

        [DllImport("Advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool QueryServiceConfig2(SafeHandle hService, int dwInfoLevel, IntPtr lpBuffer, int cbBufSize, ref int pcbBytesNeeded);

        private string ServiceDes(string ServiceName)
        {
            try
            {
                using (ServiceController sc = new ServiceController(ServiceName))
                {
                    const int SERVICE_CONFIG_DESCRIPTION = 1;
                    int bytesNeeded = 0;
                    QueryServiceConfig2(sc.ServiceHandle, SERVICE_CONFIG_DESCRIPTION, IntPtr.Zero, 0, ref bytesNeeded);

                    IntPtr buffer = Marshal.AllocHGlobal(bytesNeeded);
                    if (QueryServiceConfig2(sc.ServiceHandle, SERVICE_CONFIG_DESCRIPTION, buffer, bytesNeeded, ref bytesNeeded))
                    {
                        IntPtr str = Marshal.ReadIntPtr(buffer);
                        return (Marshal.PtrToStringUni(str));
                    }
                    else
                        return ("未查到此服务的详细信息");
                }
            }
            catch
            {
                return ("此服务详细信息拒绝查询，请咨询系统管理员");

            }
        }

        /// <summary>
        /// 获取服务路径
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <returns></returns>
        public static string GetWindowsServicePath(string ServiceName)
        {
            string key = @"SYSTEM\CurrentControlSet\Services\" + ServiceName;
            string path = Registry.LocalMachine.OpenSubKey(key).GetValue("ImagePath").ToString();
            //替换掉双引号   
            path = path.Replace("\"", string.Empty);

            //FileInfo fi = new FileInfo(path);
            //return fi.Directory.ToString();
            return path;
        }

        private void lvService_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvService.Items.Count; i++)
            {
                if (lvService.Items[i].Selected == true)
                {
                    servicePathtxt.Text = "执行路径：" + lvService.Items[i].SubItems[2].Text;
                    btOpenPath.Enabled = true;
                    btSearch.Enabled = true;
                    break;
                }
            }
        }

        private void btRefreshService_Click(object sender, EventArgs e)
        {
            int selFlag = 0;
            for (int i = 0; i < lvService.Items.Count; i++)
            {
                if (lvService.Items[i].Checked == true)
                {
                    ServiceController s = new ServiceController();
                    s.DisplayName = lvService.Items[i].SubItems[0].Text;
                    if (s.Status.ToString() == "Stopped")
                        lvService.Items[i].SubItems[1].Text = "已停止";
                    else
                        lvService.Items[i].SubItems[1].Text = "已启动";
                    selFlag = 1;
                }
            }

            if (selFlag == 0)
            {
                btOpenPath.Enabled = false;
                btSearch.Enabled = false;
                servicePathtxt.Text = "";
                MessageBox.Show("请至少选择一个服务进行刷新", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btOpenPath.Enabled = false;
                btSearch.Enabled = false;
                servicePathtxt.Text = "";
                MessageBox.Show("所选服务刷新完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void btServiceStart_Click(object sender, EventArgs e)
        {
            int selFlag = 0;
            for (int i = 0; i < lvService.Items.Count; i++)
            {
                if (lvService.Items[i].Checked == true)
                {
                    ServiceController s = new ServiceController();
                    s.DisplayName = lvService.Items[i].SubItems[0].Text;
                    s.Start();
                    selFlag = 1;
                }
            }

            if (selFlag == 0)
            {
                btOpenPath.Enabled = false;
                btSearch.Enabled = false;
                servicePathtxt.Text = "";
                MessageBox.Show("请至少选择一个服务进行启动", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btOpenPath.Enabled = false;
                btSearch.Enabled = false;
                servicePathtxt.Text = "";
                MessageBox.Show("所选服务已启动完毕，请点击刷新或者刷新列表查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btServiceStop_Click(object sender, EventArgs e)
        {
            int selFlag = 0;
            for (int i = 0; i < lvService.Items.Count; i++)
            {
                if (lvService.Items[i].Checked == true)
                {
                    ServiceController s = new ServiceController();
                    s.DisplayName = lvService.Items[i].SubItems[0].Text;
                    s.Stop();
                    selFlag = 1;
                }
            }

            if (selFlag == 0)
            {
                btOpenPath.Enabled = false;
                btSearch.Enabled = false;
                servicePathtxt.Text = "";
                MessageBox.Show("请至少选择一个服务进行启动", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btOpenPath.Enabled = false;
                btSearch.Enabled = false;
                servicePathtxt.Text = "";
                MessageBox.Show("所选服务已停止，请点击刷新或者刷新列表查看", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvService.Items.Count; i++)
            {
                if (lvService.Items[i].Selected == true)
                {
                    string result = System.Web.HttpUtility.UrlEncode(lvService.Items[i].SubItems[0].Text, System.Text.Encoding.GetEncoding("utf-8"));
                    System.Diagnostics.Process.Start(@"http://www.google.com.hk/search?q=" + result);
                    btOpenPath.Enabled = false;
                    btSearch.Enabled = false;
                    servicePathtxt.Text = "";
                }
            }
        }

        private void btOpenPath_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvService.Items.Count; i++)
            {
                if (lvService.Items[i].Selected == true)
                {
                    ServiceController s = new ServiceController();
                    s.DisplayName = lvService.Items[i].SubItems[0].Text;
                    System.Diagnostics.Process.Start(GetWindowsServiceInstallPath(s.ServiceName));
                    btOpenPath.Enabled = false;
                    btSearch.Enabled = false;
                    servicePathtxt.Text = "";
                }
            }
        }

        private void btUpdateService_Click(object sender, EventArgs e)
        {
            initialSevice();
            btOpenPath.Enabled = false;
            btSearch.Enabled = false;
            servicePathtxt.Text = "";
            MessageBox.Show("所有服务已更新完毕", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 获取服务安装路径
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <returns></returns>
        public static string GetWindowsServiceInstallPath(string ServiceName)
        {
            string key = @"SYSTEM\CurrentControlSet\Services\" + ServiceName;
            string path = Registry.LocalMachine.OpenSubKey(key).GetValue("ImagePath").ToString();
            //替换掉双引号   
            path = path.Replace("\"", string.Empty);

            FileInfo fi = new FileInfo(path);
            return fi.Directory.ToString();
        }

        #endregion

        private void lvService_DoubleClick(object sender, EventArgs e)
        {
            for (int i = 0; i < lvService.Items.Count; i++)
            {
                if (lvService.Items[i].Selected == true)
                {
                    lvService.Items[i].Checked = false;
                    MessageBox.Show("服务名称:\r\n     " + lvService.Items[i].SubItems[0].Text + "\r\n\r\n" + "状态:\r\n     " + lvService.Items[i].SubItems[1].Text + "\r\n\r\n" + "可执行文件路径:\r\n     "
                        + lvService.Items[i].SubItems[2].Text + "\r\n\r\n" + "详细描述:\r\n     " + lvService.Items[i].SubItems[3].Text, "服务详细", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    break;
                }
            }
        }

        private void lvService_MouseMove(object sender, MouseEventArgs e)
        {
            ListViewItem item = lvService.GetItemAt(e.X, e.Y);
            if (item != null)
            {
                tip.Show("服务详细：\r\n" + lvService.Items[item.Index].SubItems[3].Text, lvService, new Point(e.X + 20, e.Y + 20), 9000);
                //tip.Active = true;
            }
            else
            {
                //tip.Active = false;
            }
        }
    }
}
