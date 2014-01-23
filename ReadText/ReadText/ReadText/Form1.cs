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

namespace ReadText
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        Thread speak_Thread = null;


        //Thread volume_Thread = null;

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

            AeroForm.AeroEffect(this);
        }

        private void start_Read_Click(object sender, EventArgs e)
        {
            if (txtSpeach.Text == "")
            {
                CustomMessageBox.CustomMessageBox.Show("空文本无法阅读", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                return;
            }
            else
            {
                speak_Thread = new Thread(new ThreadStart(start_Speak));
                speak_Thread.IsBackground = true;
                speak_Thread.Start();
            }
        }

        

        private void start_Speak()
        {
            SpVoice spv = new SpVoice();
            if (spv == null) return;    
       
            spv.Voice = spv.GetVoices(string.Empty, string.Empty).Item(cmbVoices.SelectedIndex);
            spv.Volume = trVolume.Value;

            spv.Speak(txtSpeach.Text, SpeechLib.SpeechVoiceSpeakFlags.SVSFDefault);

            if (closeFlag == 0)
            {
                CustomMessageBox.CustomMessageBox.Show("文本阅读完毕", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
            }

            if (speak_Thread.IsAlive)
            {
                speak_Thread.Abort();
                speak_Thread.Join();
                speak_Thread = null;
            }
        }

        private void trVolume_Scroll(object sender, EventArgs e)
        {
            ////if()
            //if (volume_Thread != null)
            //{
            //    if (volume_Thread.IsAlive || volume_Thread.ThreadState == ThreadState.Running || volume_Thread.ThreadState == ThreadState.Suspended || volume_Thread.ThreadState == ThreadState.Stopped)
            //    {
            //        volume_Thread.Abort();
            //        volume_Thread.Join();
            //        volume_Thread = null;
            //    }
            //}

            //else
            //{
            //    volume_Thread = new Thread(new ThreadStart(volume_Speak));
            //    volume_Thread.Start();
            //}
            
        }

        private int closeFlag = 0;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (speak_Thread != null)
            //{
            //    if (speak_Thread.IsAlive)
            //    {
            //        closeFlag = 1;
            //        CustomMessageBox.CustomMessageBox.Show("由于软件设计缺陷\r文本阅读完毕后自行关闭", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);

            //        speak_Thread.Abort();
            //        speak_Thread.Join();
            //        speak_Thread = null;
            //    }
            //}
            
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if(txtSpeach.Text == "")
            {
                CustomMessageBox.CustomMessageBox.Show("文本无内容，无法保存","错误",CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK,CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                return;
            }
            else
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "无损音乐格式(*.wav)|*.wav";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SpVoice spv = new SpVoice();
                    if (spv == null) return;
                    SpFileStream cpFileStream = new SpFileStream();
                    cpFileStream.Open(saveFileDialog1.FileName, SpeechStreamFileMode.SSFMCreateForWrite, false);
                    spv.AudioOutputStream = cpFileStream;
                    spv.Voice = spv.GetVoices(string.Empty, string.Empty).Item(cmbVoices.SelectedIndex);
                    spv.Volume = trVolume.Value;
                    spv.Speak(txtSpeach.Text, SpeechVoiceSpeakFlags.SVSFDefault);
                    cpFileStream.Close();

                    System.IO.FileInfo f = new System.IO.FileInfo(saveFileDialog1.FileName);

                    if (File.Exists(saveFileDialog1.FileName))
                    {
                        CustomMessageBox.CustomMessageBox.Show(f.Name + " 保存成功", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
                    }
                    else
                    {
                        CustomMessageBox.CustomMessageBox.Show(f.Name + " 保存失败", "警告", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                    }
               }

            }
        }

        

        //private void volume_Speak()
        //{
        //    spv.Voice = spv.GetVoices(string.Empty, string.Empty).Item(cmbVoices.SelectedIndex);
        //    spv.Volume = trVolume.Value;
        //}
    }
}
