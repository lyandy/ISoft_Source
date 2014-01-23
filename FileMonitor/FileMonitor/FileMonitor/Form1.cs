using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechLib;
using System.Threading;
using System.IO;

namespace FileMonitor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            AeroForm.AeroEffect(this);
            Form1.CheckForIllegalCrossThreadCalls = false;

        }

        Thread speak_Thread = null;

        string sendString = "";

        private string start_Time = "";
        DateTime start_Time1;

        private string stop_Time = "";
        DateTime stop_Time1;

        private void Form1_Load(object sender, EventArgs e)
        {

            SpVoice spv = new SpVoice();
            if (spv == null) return;
            ISpeechObjectTokens arrVoices = spv.GetVoices(string.Empty, string.Empty);
            List<string> arrlist = new List<string>();

            for (int i = 0; i < arrVoices.Count; i++)
            {
                arrlist.Add(arrVoices.Item(i).GetDescription(0));
            }
            cmbVoices.DataSource = arrlist;
        }

        private void MonitorSpeak()
        {
            SpVoice spv = new SpVoice();
            if (spv == null) return;

            spv.Voice = spv.GetVoices(string.Empty, string.Empty).Item(cmbVoices.SelectedIndex);
            spv.Volume = 100;

            spv.Speak(sendString, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);

            speak_Thread.Abort();
            speak_Thread.Join();
            speak_Thread = null;
        }

        private void btSelPath_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (startSpeakCheck.Checked == true)
                {
                    sendString = btSelPath.Text;
                    if (speak_Thread == null)
                    {
                        speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                        speak_Thread.Start();
                    }
                    else
                    {
                        speak_Thread.Abort();
                        speak_Thread.Join();
                        speak_Thread = null;
                        speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                        speak_Thread.Start();
                    }
                }

                //浏览文件夹
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.folderBrowserDialog1.SelectedPath.Trim() != "")
                    {
                        lbState.ForeColor = Color.Blue;
                        lbState.Text = "状态：准备监视 \"" + this.folderBrowserDialog1.SelectedPath.Trim() + "\"";

                        MonitorPath = this.folderBrowserDialog1.SelectedPath.Trim();

                        btStartService.Enabled = true;
                        btSelPath.Enabled = true;
                        btStopService.Enabled = false;
                        btExportLog.Enabled = false;

                        cntstartService.Enabled = true;
                        cntselPath.Enabled = true;
                        cntstopService.Enabled = false;
                        cntserviceLog.Enabled = false;
                    }
                }
            }

            else
            {
                //浏览文件夹
                if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (this.folderBrowserDialog1.SelectedPath.Trim() != "")
                    {
                        lbState.ForeColor = Color.Blue;
                        lbState.Text = "状态：准备监视 \"" + this.folderBrowserDialog1.SelectedPath.Trim() + "\"";

                        MonitorPath = this.folderBrowserDialog1.SelectedPath.Trim();

                        btStartService.Enabled = true;
                        btSelPath.Enabled = true;
                        btStopService.Enabled = false;
                        btExportLog.Enabled = false;

                        cntstartService.Enabled = true;
                        cntselPath.Enabled = true;
                        cntstopService.Enabled = false;
                        cntserviceLog.Enabled = false;

                        this.notifyIcon1.ShowBalloonTip(500, "提示", lbState.Text, ToolTipIcon.Info);
                    }
                }
            }
            
        }

        private string MonitorPath = "";

        private void btStartService_Click(object sender, EventArgs e)
        {
            fileSystemWatcher1.Path = MonitorPath;

            fileSystemWatcher1.EnableRaisingEvents = true;

            start_Time = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            start_Time1 = DateTime.Now;

            lbState.ForeColor = Color.Green;
            lbState.Text = "状态：正在监视 \"" + this.folderBrowserDialog1.SelectedPath.Trim() + "\"";



            btStopService.Enabled = true;
            btStartService.Enabled = false;
            btSelPath.Enabled = false;
            btExportLog.Enabled = false;

            cntstopService.Enabled = true;
            cntselPath.Enabled = false;
            cntstartService.Enabled = false;
            cntserviceLog.Enabled = false;

            if(this.WindowState == FormWindowState.Normal)
            {
                if (startSpeakCheck.Checked == true)
                {
                    sendString = "监视服务已经开启";
                    if (speak_Thread == null)
                    {
                        speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                        speak_Thread.Start();
                    }
                    else
                    {
                        speak_Thread.Abort();
                        speak_Thread.Join();
                        speak_Thread = null;
                        speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                        speak_Thread.Start();
                    }
                }
            }
            else
            {
                this.notifyIcon1.ShowBalloonTip(500, "提示", lbState.Text, ToolTipIcon.Info);
            }        
        }

        private int file_Create_count = 0;
        private int file_Delete_count = 0;
        private int file_Rename_count = 0;

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            string [] str = 
            {
                DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(),
                e.Name,
                
                "创建",
                e.FullPath.ToString()
            };
            ListViewItem item = new ListViewItem(str);
            lvMonitor.Items.Add(item);

            file_Create_count++;

            if (startSpeakCheck.Checked == true)
            {
                sendString = "创建 " + e.Name.Substring(0,e.Name.LastIndexOf("."));
                if (speak_Thread == null)
                {
                    speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                    speak_Thread.Start();
                }
                else
                {
                    speak_Thread.Abort();
                    speak_Thread.Join();
                    speak_Thread = null;
                    speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                    speak_Thread.Start();
                }
            }        
        }

        private void fileSystemWatcher1_Deleted(object sender, System.IO.FileSystemEventArgs e)
        {
            string[] str = 
            {
                DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(),
                e.Name,
                "删除",
                e.FullPath.ToString()
            };
            ListViewItem item = new ListViewItem(str);
            lvMonitor.Items.Add(item);

            file_Delete_count++;

            if (startSpeakCheck.Checked == true)
            {
                sendString = "删除 " + e.Name.Substring(0, e.Name.LastIndexOf("."));
                if (speak_Thread == null)
                {
                    speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                    speak_Thread.Start();
                }
                else
                {
                    speak_Thread.Abort();
                    speak_Thread.Join();
                    speak_Thread = null;
                    speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                    speak_Thread.Start();
                }
            }        
        }

        private void fileSystemWatcher1_Renamed(object sender, System.IO.RenamedEventArgs e)
        {
            string[] str = 
            {
                DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString(),
                e.Name,
                "重命名",
                e.FullPath.ToString()
            };
            ListViewItem item = new ListViewItem(str);
            lvMonitor.Items.Add(item);

            file_Rename_count++;

            if (startSpeakCheck.Checked == true)
            {
                sendString = "重命名 " + e.Name.Substring(0, e.Name.LastIndexOf("."));
                if (speak_Thread == null)
                {
                    speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                    speak_Thread.Start();
                }
                else
                {
                    speak_Thread.Abort();
                    speak_Thread.Join();
                    speak_Thread = null;
                    speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                    speak_Thread.Start();
                }
            }        
        }

        private void btStopService_Click(object sender, EventArgs e)
        {
            

            fileSystemWatcher1.EnableRaisingEvents = false;

            stop_Time = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
            stop_Time1 = DateTime.Now;

            btSelPath.Enabled = true;
            btExportLog.Enabled = true;
            btStartService.Enabled = false;
            btStopService.Enabled = false;

            cntselPath.Enabled = true;
            cntserviceLog.Enabled = true;
            cntstartService.Enabled = false;
            cntstopService.Enabled = false;
            

            lbState.ForeColor = Color.Red;
            lbState.Text = "状态：监视服务已经关闭，等待选择磁盘或文件夹";

            if (this.WindowState == FormWindowState.Normal)
            {
                if (startSpeakCheck.Checked == true)
                {
                    sendString = "监视服务已经关闭 ";
                    if (speak_Thread == null)
                    {
                        speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                        speak_Thread.Start();
                    }
                    else
                    {
                        speak_Thread.Abort();
                        speak_Thread.Join();
                        speak_Thread = null;
                        speak_Thread = new Thread(new ThreadStart(MonitorSpeak));
                        speak_Thread.Start();
                    }
                }
            }
            else
            {
                this.notifyIcon1.ShowBalloonTip(500, "提示", lbState.Text, ToolTipIcon.Info);
            }
        }

        private void btExportLog_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                if (btExportLog.Text == "导出监视日志")
                {
                    try
                    {
                        int total_Change_time = file_Create_count + file_Delete_count + file_Rename_count;

                        StreamWriter Ope = new StreamWriter(@"..\AdvancedFunctions\SysTools\FileMonitor\FileMonitor.log", true, Encoding.Unicode);
                        Ope.WriteLine("=============================================================================\r\n");
                        Ope.WriteLine("监视路径：" + MonitorPath);

                        Ope.WriteLine("\r\n总监视时间：" + (stop_Time1 - start_Time1).ToString().Substring(0, 8));
                        Ope.WriteLine("     监视服务开启时间：" + start_Time);
                        Ope.WriteLine("     监视服务关闭时间：" + stop_Time);

                        Ope.WriteLine("\r\n监视到文件(包括文件夹)变动次数   " + total_Change_time + " 次");
                        Ope.WriteLine("     文件(包括文件夹)创建次数   " + file_Create_count + " 次");
                        Ope.WriteLine("     文件(包括文件夹)删除次数   " + file_Delete_count + " 次");
                        Ope.WriteLine("     文件(包括文件夹)重命名次数   " + file_Rename_count + " 次\r\n");

                        for (int i = 0; i < lvMonitor.Items.Count; i++)
                        {
                            Ope.WriteLine("--------------------------------------------------");
                            Ope.WriteLine("时间：" + lvMonitor.Items[i].SubItems[0].Text);
                            Ope.WriteLine("名称：" + lvMonitor.Items[i].SubItems[1].Text);
                            Ope.WriteLine("动作：" + lvMonitor.Items[i].SubItems[2].Text);
                        }

                        Ope.WriteLine("\r\n=============================================================================\r\n");
                        Ope.Close();

                        btExportLog.Text = "定位日志文件";
                        cntserviceLog.Text = "定位日志文件";

                        CustomMessageBox.CustomMessageBox.Show("  监视日志导出完毕！", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
                    }
                    catch
                    {
                        CustomMessageBox.CustomMessageBox.Show("  监视日志导出错误！", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        System.Diagnostics.Process.Start(@"..\AdvancedFunctions\SysTools\FileMonitor\FileMonitor.log");
                    }
                    catch
                    {
                        CustomMessageBox.CustomMessageBox.Show("日志文件定位失败，请再次尝试导出", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                        btExportLog.Text = "导出监视日志";
                        cntserviceLog.Text = "导出监视日志";
                        return;
                    }
                }
            }
            else
            {
                if (cntserviceLog.Text == "导出监视日志")
                {
                    try
                    {
                        int total_Change_time = file_Create_count + file_Delete_count + file_Rename_count;

                        StreamWriter Ope = new StreamWriter(@"..\AdvancedFunctions\SysTools\FileMonitor\FileMonitor.log", true, Encoding.Unicode);
                        Ope.WriteLine("=============================================================================\r\n");
                        Ope.WriteLine("监视路径：" + MonitorPath);

                        Ope.WriteLine("\r\n总监视时间：" + (stop_Time1 - start_Time1).ToString().Substring(0, 8));
                        Ope.WriteLine("     监视服务开启时间：" + start_Time);
                        Ope.WriteLine("     监视服务关闭时间：" + stop_Time);

                        Ope.WriteLine("\r\n监视到文件(包括文件夹)变动次数   " + total_Change_time + " 次");
                        Ope.WriteLine("     文件(包括文件夹)创建次数   " + file_Create_count + " 次");
                        Ope.WriteLine("     文件(包括文件夹)删除次数   " + file_Delete_count + " 次");
                        Ope.WriteLine("     文件(包括文件夹)重命名次数   " + file_Rename_count + " 次\r\n");

                        for (int i = 0; i < lvMonitor.Items.Count; i++)
                        {
                            Ope.WriteLine("--------------------------------------------------");
                            Ope.WriteLine("时间：" + lvMonitor.Items[i].SubItems[0].Text);
                            Ope.WriteLine("名称：" + lvMonitor.Items[i].SubItems[1].Text);
                            Ope.WriteLine("动作：" + lvMonitor.Items[i].SubItems[2].Text);
                        }

                        Ope.WriteLine("\r\n=============================================================================\r\n");
                        Ope.Close();

                        btExportLog.Text = "定位日志文件";
                        cntserviceLog.Text = "定位日志文件";

                        CustomMessageBox.CustomMessageBox.Show("  监视日志导出完毕！", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
                    }
                    catch
                    {
                        CustomMessageBox.CustomMessageBox.Show("  监视日志导出错误！", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                        return;
                    }
                }
                else
                {
                    try
                    {
                        System.Diagnostics.Process.Start(@"..\AdvancedFunctions\SysTools\FileMonitor\FileMonitor.log");
                    }
                    catch
                    {
                        CustomMessageBox.CustomMessageBox.Show("日志文件定位失败，请再次尝试导出", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);

                        btExportLog.Text = "导出监视日志";
                        cntserviceLog.Text = "导出监视日志";

                        return;
                    }
                }
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

            cntshowMainform.Enabled = false;

            if (startSpeakCheck.Checked == true)
            {
                this.notifyIcon1.ShowBalloonTip(500, "提示", "语音提示已自动恢复", ToolTipIcon.Info);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.Visible = false;

                cntshowMainform.Enabled = true;

                if (startSpeakCheck.Checked == true)
                {
                    this.notifyIcon1.ShowBalloonTip(500, "提示", "窗口最小化，监视仍在运行，语音提示已自动停止，显示主界面可自动恢复语音提示", ToolTipIcon.Info);
                }
                else
                {
                    this.notifyIcon1.ShowBalloonTip(500, "提示", "窗口最小化，监视仍在运行", ToolTipIcon.Info);
                }
            }
        }

        private void cntExit_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.CustomMessageBox.Show("确定要退出 磁盘/文件夹监视 吗？", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OKCancel, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Question) == DialogResult.OK)
            {
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
            }
            else
                return;
        }

        private void cntshowMainform_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;

            cntshowMainform.Enabled = false;

            if (startSpeakCheck.Checked == true)
            {
                this.notifyIcon1.ShowBalloonTip(500, "提示", "语音提示已自动恢复", ToolTipIcon.Info);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cntExit_Click(null, null);
        }
    }
}
