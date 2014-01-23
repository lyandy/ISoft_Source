using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.IO;
using System.Diagnostics;

namespace ISoft
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //处理未捕获的异常  
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常  
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常  
                AppDomain.CurrentDomain.UnhandledException += new System.UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                SingleInstanceManager manager = new SingleInstanceManager();//单实例管理器

                manager.Run(new string[] { });
            }
            catch (Exception ex)
            {
                string str = "";
                string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
                if (ex != null)
                {
                    str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                         ex.GetType().Name, ex.Message, ex.StackTrace);
                }
                else
                {
                    str = string.Format("应用程序线程错误:{0}", ex);
                }

                writeLog(str);

                ErrorCollection EC = new ErrorCollection(1);
                EC.ShowDialog();

                //MessageBox.Show("发生致命错误，程序即将关闭，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }

            //Application.Run(new frmMain()); //屏蔽掉了以前的加载头
        }

        /// <summary>
        ///这就是我们要在发生未处理异常时处理的方法，我这是写出错详细信息到文本，如出错后弹出一个漂亮的出错提示窗体，给大家做个参考
        ///做法很多，可以是把出错详细信息记录到文本、数据库，发送出错邮件到作者信箱或出错后重新初始化等等
        ///这就是仁者见仁智者见智，大家自己做了。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
           
            string str = "";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                     error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }
            writeLog(str);

            

            ErrorCollection EC = new ErrorCollection(2);
            EC.ShowDialog();

            //MessageBox.Show("发生致命错误，程序即将关闭，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.GetCurrentProcess().Kill();
            
        }

        static void CurrentDomain_UnhandledException(object sender, System.UnhandledExceptionEventArgs e)
        {
            string str = "";
            Exception error = e.ExceptionObject as Exception;
            
            
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            if (error != null)
            {
                str = string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application UnhandledError:{0}", e);
            }
            writeLog(str);

            ErrorCollection EC = new ErrorCollection(3);
            EC.ShowDialog();

            //MessageBox.Show("发生致命错误，程序即将关闭，请及时联系作者！", "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Process.GetCurrentProcess().Kill();
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str"></param>
        static void writeLog(string str)
        {
            if (!Directory.Exists("ErrLog"))
            {
                Directory.CreateDirectory("ErrLog");
            }
            using (StreamWriter sw = new StreamWriter(@"ErrLog\error.log", false))
            {
                sw.WriteLine(str);
                sw.WriteLine("---------------------------------------------------------------------------------------------------------------");
                sw.Close();
            }
        }


        

        #region 程序单实例运行模块

        // Using VB bits to detect single instances and process accordingly:

        // * OnStartup is fired when the first instance loads

        // * OnStartupNextInstance is fired when the application is re-run again

        //    NOTE: it is redirected to this instance thanks to IsSingleInstance

        public class SingleInstanceManager : WindowsFormsApplicationBase
        {
            MainForm app;

            public SingleInstanceManager()
            {
                this.IsSingleInstance = true;
            }

            protected override bool OnStartup(Microsoft.VisualBasic.ApplicationServices.StartupEventArgs e)
            {
                // First time app is launched

                //app = new SingleInstanceApplication();

                //app.Run();

                app = new MainForm();//改为自己的程序运行窗体

                Application.Run(app);

                return false;
            }

            protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
            {
                // Subsequent launches


                base.OnStartupNextInstance(eventArgs);
                app.Activate();
                app.Show();
               // MessageBox.Show(Application.ProductName + " 已经在运行了，不能重复运行", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);//给个对话框提示
                

            }
        }
        #endregion
    }
}
