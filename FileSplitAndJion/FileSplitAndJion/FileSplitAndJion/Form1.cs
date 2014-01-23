using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CSharpWin;
using System.IO;
using System.Threading;

namespace FileSplitAndJion
{
    public partial class Form1 : SkinForm
    {
        public Form1()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        Thread startSplit = null;
        Thread startCombine = null;
        public readonly int readSize=1024*512;
        bool isCancle = false;//值true时，停止线程
        bool isCancleCom = false;
        long fileLenth = 0;//文件的长度

        //初始化工作
        private void Form1_Load(object sender, EventArgs e)
        {
            //this.skinEngine1.SkinFile = "DiamondGreen.ssk";//设置皮肤
            this.rb_num.Checked = true;
            this.checkbox.Checked = false;

            this.comboBox1.SelectedItem = this.comboBox1.Items[0];//初始化组合框
        }
      
        //浏览切分文件的名称
        private void btn_show_Click(object sender, EventArgs e)
        {
            this.btn_start_split.Enabled = true;//是切分按钮有效
            this.progressBar1.Value = 0;//将进度条的值设为0

            OpenFileDialog mydlg = new OpenFileDialog();//初始化打开文件对话框
            mydlg.RestoreDirectory = true;
            mydlg.Title = "请选择要切分的文件";
            mydlg.Filter = "*.*|*.*|*.txt|*.txt|*.doc|*.doc|*.mp3|*.mp3|*.rmvb|*.rmvb";

            if (mydlg.ShowDialog()==DialogResult.OK)
            {
                string filename = mydlg.FileName;

                if(File.Exists(filename)==false)//检查文件是否存在
                {
                    MessageBox.Show(filename+"不存在!");
                    return;
                }

                this.tb_show_filename.Text = filename;//显示文件的绝对路径

                
                 using (FileStream fstream=new FileStream (filename,FileMode.Open,FileAccess.Read))
                 {
            
                     fileLenth= fstream.Length; 
                     this.tb_show_filelen.Text=fileLenth.ToString();//显示文件的长度
                 }
               
            }
                           

        }

        //5^1^a^s^p^x
        //开始切分线程
        private void btn_start_split_Click(object sender, EventArgs e)
        {
            if (this.tb_show_filename.Text==string.Empty)//判断是否文件名称是空
            {
                return;
            }
            if (this.tb_num.Text==string.Empty)//判断是否输入
            {
                return;
            }
            if (Int32.Parse(this.tb_num.Text)==0)//判断输入的数字是否为0
            {
                return;
            } 


            this.btn_start_split.Enabled = false;
            isCancle = false;

            startSplit = new Thread(new ThreadStart(Split));//初始化线程
            startSplit.Start();//启动线程
            
        }

        //分割函数的是实现
        private void Split()
        {
            string filename = this.tb_show_filename.Text;
            long filelen=0;

            string exname= Path.GetExtension(filename);//得到文件的扩展名
            string drname = Path.GetDirectoryName(filename)+"\\";//得到目录名

            filelen = fileLenth;
 
            int num=getnum();//得到要切分的文件数目

            if (num==-1)
            {
                return;
            }
          
             filelen/=num;//得到每份文件的大小


            try
            {

                using(FileStream fread=new FileStream(filename,FileMode.OpenOrCreate,FileAccess.Read))
                {
                    
                    
                    for(int i=0;i<num;i++)
                    {
                        if (isCancle==true)
                        {
                            break;
                        }

                       int data = 0;
                       Byte []buf=new Byte [filelen];//缓冲

                        using (FileStream fwrite=new FileStream(drname+i.ToString()+exname,FileMode.Create,FileAccess.Write))//读文件
                        {
                           

                            data = fread.Read(buf, 0, (Int32)filelen);
                      
                             fwrite.Write(buf, 0, data);//写文件
                      
                            
                            fwrite.Close();//关闭文件
                            
                        }
                        this.progressBar1.Value =(int)(100.0/num*(i+1));//显示进度条

                    }
                     this.btn_start_split.Enabled = true;

                    if (isCancle==true)
                    {
                        this.progressBar1.Value = 0;
                    }
                }
                CustomMessageBox.CustomMessageBox.Show("文件分割完毕！", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
        }

        //返回要切分的文件数目
        private int  getnum()
        {
            try
            {
                if (this.rb_num.Checked == true)
                {
                    return Convert.ToInt32(this.tb_num.Text);
                }
                else
                {
                    int num =(int)(fileLenth/ Int32.Parse(this.tb_num.Text));
                    return num;
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.ToString());//5*1*aZ*s*p*x
                return -1;
            }
          
        }


        //取消线程
        private void btn_cancle_Click(object sender, EventArgs e)
        {
            isCancle = true;
            this.btn_start_split.Enabled = true;

        }


        //只能输入数字和退格键
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar<48||e.KeyChar>57)
            {
                e.Handled = true;

                if (e.KeyChar==8)
                {
                    e.Handled = false;

                }
            }

        }
        //单位换算
        private void selectChange(object sender, EventArgs e)
        {
            ComboBox cB = sender as ComboBox;
            if (cB==null)
            {
                return;
            }
            switch (cB.SelectedIndex)
            {
                case 0:
                    this.tb_show_filelen.Text = fileLenth.ToString();
                    break;
                case 1:
                    this.tb_show_filelen.Text = Math.Round((fileLenth / 1024.0),2).ToString();//保留两位小数
                    break;
                case 2:
                    this.tb_show_filelen.Text = Math.Round((fileLenth /1024/ 1024.0),2).ToString();
                    break;
            }
        }

        //关闭,退出程序

        private void FormClose(object sender, FormClosingEventArgs e)
        {
            isCancle = true;
            isCancleCom = true;
           
        }

       
        ///////////////////////////////////////////////////////////////////
        /*
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 文件的组合
         */
        /////////////////////////////////////////////////////////////////////
        //添加要组合的文件
        private void btnAdd_Click(object sender, EventArgs e)
        {

            OpenFileDialog mydlg = new OpenFileDialog();
            mydlg.Multiselect = true;
            mydlg.RestoreDirectory = true;
            mydlg.CheckFileExists = true;
            mydlg.CheckPathExists = true;
            mydlg.Filter = "*.*|*.*|*.txt|*.txt|*.doc|*.doc|*.mp3|*.mp3|*.rmvb|*.rmvb";
            mydlg.Title = "请选择组合的文件";


            this.progressBar2.Value = 0;
            if (mydlg.ShowDialog()==DialogResult.OK)
            {
                this.listBox1.Items.AddRange(mydlg.FileNames);
            }
           
            
        }

       
        //移除
        private void btnDelete_Click(object sender, EventArgs e)
        {
              int selectItem = this.listBox1.SelectedIndex;

                if (selectItem==-1)
                {
                    return;
                }
                this.listBox1.Items.RemoveAt(selectItem);

        }

        //清空
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();


        }

        //置顶
        private void btnSetTop_Click(object sender, EventArgs e)
        {
            int selectItem = this.listBox1.SelectedIndex;

            if (selectItem==-1)
            {
                return;
            }
            object temp=this.listBox1.SelectedItem;

            this.listBox1.BeginUpdate();
            this.listBox1.Items.RemoveAt(selectItem);
            this.listBox1.Items.Insert(0, temp);
            this.listBox1.SelectedIndex = 0;
            this.listBox1.EndUpdate();

        }

        //上移
        private void btnMoveTop_Click(object sender, EventArgs e)
        {
            int selectItem = this.listBox1.SelectedIndex;
           
            if (selectItem<=0)
            {
             
                return;
            }
            object temp=this.listBox1.SelectedItem;

            this.listBox1.BeginUpdate();
           
            this.listBox1.Items.Insert(selectItem-1,temp);
            this.listBox1.Items.RemoveAt(selectItem+1); 
            selectItem--;
            this.listBox1.SelectedIndex = selectItem;
            this.listBox1.EndUpdate();
        }



        //下移
        private void btnMoveBottom_Click(object sender, EventArgs e)
        {
            int selectItem = this.listBox1.SelectedIndex;

           
            if (selectItem<0||selectItem==this.listBox1.Items.Count-1)
            {

                return;
            }
         
                object temp = this.listBox1.SelectedItem;

                this.listBox1.BeginUpdate();
                this.listBox1.Items.Insert(selectItem + 2, temp);
                this.listBox1.Items.RemoveAt(selectItem);
                selectItem++;
                this.listBox1.SelectedIndex = selectItem;
              
                this.listBox1.EndUpdate();
            
         
           
        }

        //置底
        private void btnSetBottom_Click(object sender, EventArgs e)
        {
            int selectItem = this.listBox1.SelectedIndex;

            if (selectItem == -1)
            {
                return;
            }
            object temp = this.listBox1.SelectedItem;

            this.listBox1.BeginUpdate();
            this.listBox1.Items.Insert(this.listBox1.Items.Count,temp);
            this.listBox1.Items.RemoveAt(selectItem);
            this.listBox1.SelectedIndex = this.listBox1.Items.Count-1;
            this.listBox1.EndUpdate();

        }

        //文件存放的路径
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            SaveFileDialog mydlg = new SaveFileDialog();
            mydlg.Filter = "*.*|*.*|*.txt|*.txt|*.doc|*.doc|*.mp3|*.mp3|*.rmvb|*.rmvb";
            mydlg.CheckPathExists = true;
            mydlg.AddExtension = true;
            mydlg.RestoreDirectory = true;


            if (mydlg.ShowDialog()==DialogResult.OK)
            {
                this.tbSaveFileName.Text=mydlg.FileName;
                
            }
            
            

        }
           //排序
        private void check_Changed(object sender, EventArgs e)
        {
            if(this.checkbox.Checked==true)
            {
                this.listBox1.Sorted = true;

            }
            else
            {
                this.listBox1.Sorted =false;
            }
         }

        //组合
        private void btnCombine_Click(object sender, EventArgs e)
        {
            if (this.listBox1.Items.Count==0)//检验是否有要组合的文件
            {
                return;
            }

            if (this.tbSaveFileName.Text==string.Empty)
            {
                return;
            }

            string dirstr = this.tbSaveFileName.Text.Substring(0, this.tbSaveFileName.Text.LastIndexOf("\\"));

          if (Directory.Exists(dirstr)==false)//检验保存路径是否存在
            {
                CustomMessageBox.CustomMessageBox.Show("保存路径不存在！", "错误", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Error);
                return;
                
            }
            isCancleCom = false;
            startCombine = new Thread(new ThreadStart(Combine));//初始化线程
            this.btnCombine.Enabled = false;
            startCombine.Start();//启动线程
            

        }

        private void Combine()
        {
            int count = this.listBox1.Items.Count;
            string[] filenames = new string[count];
            this.listBox1.Items.CopyTo(filenames,0);//讲列表框中文件名赋予字符串数组
            using (FileStream fwrite =new FileStream(this.tbSaveFileName.Text,FileMode.Create,FileAccess.Write)) 
            {

                try
                {

                    for (int i = 0; i < count;i++)
                    {
                        int data = 0;
                        Byte []buf=new byte[readSize];
                        using(FileStream fread=new FileStream(filenames[i],FileMode.OpenOrCreate,FileAccess.Read))
                        {
                            data = fread.Read(buf,0,readSize);
                            while(data>0)
                            {
                                if (isCancleCom==true)
                                {
                                    return;
                                }
                                fwrite.Write(buf,0,data);
                                data = fread.Read(buf, 0, readSize);
                            }

                        }
                        this.progressBar2.Value = (int)(100.0 /count *(i+1));
                    }

                }
                catch
                {
                   
                }
                finally
                {
                    fwrite.Close();
                }
                CustomMessageBox.CustomMessageBox.Show("文件合并完毕！", "提示", CustomMessageBox.CustomMessageBox.MsgBoxButtons.OK, CustomMessageBox.CustomMessageBox.MsgBoxIcons.Info);
                
            }

            this.btnCombine.Enabled = true;


        }
        //取消线程
        private void btnCancleCom_Click(object sender, EventArgs e)
        {
            isCancleCom = true;
            this.btnCombine.Enabled = true;

        }           
    }
}
