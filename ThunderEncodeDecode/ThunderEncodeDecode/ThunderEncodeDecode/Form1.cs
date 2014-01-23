using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ThunderEncodeDecode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string ThunderEncode(string Address)
        {
            string pattern = @"^http://([\w-]+\.)+[\w-]+(/[\w-./?%&=]*)?$";
            Regex addressRegex = new Regex(pattern);
            Match m = addressRegex.Match(Address);
            try
            {
                if (m.Success)
                {
                    string newAddress = OperAddress(Address);
                    byte[] b = Encoding.GetEncoding(0).GetBytes(newAddress);
                    return @"thunder://" + Convert.ToBase64String(b);
                }
                else
                {
                    MessageBox.Show("请输入正确地址!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public string ThunderDecode(string ThunderAddress)
        {
            string pattern = @"^thunder://";
            Regex thunderAddressRegex = new Regex(pattern);
            Match m = thunderAddressRegex.Match(ThunderAddress);
            try
            {
                if (m.Success)
                {
                    byte[] b = Convert.FromBase64String(ReplaceThunder(ThunderAddress));
                    string Address = ReplaceAAZZ(Encoding.GetEncoding(0).GetString(b));
                    return Address;
                }
                else
                {
                    MessageBox.Show("请输入正确的地址!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }

        public string OperAddress(string Address)
        {
            return "AA" + Address + "ZZ";
        }

        public string ReplaceThunder(string ThunderAddress)
        {
            string pattern = @"^thunder://";
            return Regex.Replace(ThunderAddress, pattern, "");
        }

        public string ReplaceAAZZ(string AAZZAddress)
        {
            string pattern1 = "AA";
            string pattern2 = "ZZ";
            string replaceAA = Regex.Replace(AAZZAddress, pattern1, "");
            return Regex.Replace(replaceAA, pattern2, "");
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {
            this.outputTxb.Text = ThunderEncode(inputTxb.Text);
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            this.inputTxb.Text = "";
            this.outputTxb.Text = "";
        }

        private void decodeBtn_Click(object sender, EventArgs e)
        {
            this.outputTxb.Text = ThunderDecode(inputTxb.Text);
        }
    }
}
