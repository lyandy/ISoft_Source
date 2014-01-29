using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;
using System.Net;

namespace ISoft
{
    public partial class ErrorCollection : Form
    {
        int ErrorFlag;

        public ErrorCollection(int errorFlag)
        {
            InitializeComponent();

            ErrorFlag = errorFlag;
        }

        //设置Smtp协议
        SmtpClient smtpClient = null;
        //设置发信人地址 需要密码
        MailAddress AddressFrom = null;
        //设置收信人地址 不需要密码
        MailAddress AddressTo = null;
        //邮件信息
        MailMessage Message = null;

        //设置Smtp服务器信息
        private void SetSmtpClient(string serverHost, int Port)
        {
            smtpClient = new SmtpClient();
            //指定Smtp服务名
            //QQ:smtp.qq.com
            //sina：smtp.sina.cn
            smtpClient.Host = serverHost;
            smtpClient.Port = Port;
            smtpClient.Timeout = 0;
        }

        //验证发件人信息
        private void SetAddressFrom(string mailAddress, string mailPwd)
        {
            //创建服务器验证
            NetworkCredential networkCreadential_My = new NetworkCredential(mailAddress, mailPwd);
            //实例化发件人地址
            AddressFrom = new MailAddress(mailAddress, "ISoft错误报告机器人");
            //指定发件人信息 邮箱地址和密码
            smtpClient.Credentials = new NetworkCredential(AddressFrom.Address, mailPwd);

        }

        private void lblErrorView_Click(object sender, EventArgs e)
        {
            if (lblErrorView.Text == "查看错误信息>>")
            {
                lblErrorView.Text = "关闭错误信息>>";
                if (ErrorFlag == 1)
                {
                    stopCode.Text = " 0x003B427DC";
                    stopDesc.Text = " 未知异常";
                    plError.Visible = true;
                }
                else
                    if (ErrorFlag == 2)
                    {
                        stopCode.Text = "0x000003EA7";
                        stopDesc.Text = "UI线程异常";
                        plError.Visible = true;
                    }
                    else
                    {
                        stopCode.Text = "0x03AF0069F";
                        stopDesc.Text = "非UI线程异常";
                        plError.Visible = true;
                    }
            }
            else
            {
                lblErrorView.Text = "查看错误信息>>";
                plError.Visible = false;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            try
            {
                //设置Smtp服务器信息
                SetSmtpClient("smtp." + "163" + ".com", 25);

                //设置发送地址信息
                SetAddressFrom("You Mail Address", "Your Mail Secret");

                //message信息
                Message = new MailMessage();

                //发信人地址
                Message.From = AddressFrom;
                //收信人地址
                AddressTo = new MailAddress("403760530" + "@qq.com");
                //添加收信人地址
                Message.To.Add(AddressTo);

                //信息的主题
                Message.Subject = "ISoft错误报告 " + DateTime.Now.ToLongTimeString();
                //主题的编码方式

                Message.SubjectEncoding = System.Text.Encoding.UTF8;

                Message.Attachments.Add(new Attachment("./ErrLog/error.log"));
                //发送
                smtpClient.SendAsync(Message, "000000");

            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }

            this.Close();
        }

        private void lblConnecQQ_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://wpa.qq.com/msgrd?v=3&uin=403760530&site=qq&menu=yes");
        }

    }
}
