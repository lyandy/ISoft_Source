using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.Win32;
namespace RubbishCleaner
{
    class GeneralModule
    {

        #region 数据格式化
        public static string FormatBytes(double bytes)
        {
            string text;
            try
            {
                double expression;
                double num2 = bytes;
                if (num2 >= 1073741824)
                {
                    expression = bytes / 1073741824;
                    return (Math.Round(expression,2) + " GB");
                }
                if ((num2 >= 1048576) && (num2 <= 1073741823))
                {
                    expression = bytes / 1048576;
                    return (Math.Round(expression, 2) + " MB");
                }
                if ((num2 >= 1024) && (num2 <= 1048575))
                {
                    expression = bytes / 1024;
                    return (Math.Round(expression, 2) + " KB");
                }
                if ((num2 >= 0) && (num2 <= 1023))
                {
                    expression = bytes;
                    return (Math.Round(expression, 2) + " bytes");
                }
                text = "";
            }
            catch
            {
                text = "";
                return text;
            }
            return text;
        }
        public static string FormatHertz(double hertz)
        {
            string text;
            try
            {
                double expression;
                double num2 = hertz;
                if (num2 >= 1000000000)
                {
                    expression = hertz / 1000000000;
                    return (Math.Round(expression, 2) + " GHz");
                }
                if ((num2 >= 1048576) && (num2 <= 1073741823))
                {
                    expression = hertz / 1000000;
                    return (Math.Round(expression, 2) + " MHz");
                }
                if ((num2 >= 1024) && (num2 <= 1048575))
                {
                    expression = hertz / 1000;
                    return (Math.Round(expression, 2) + " KHz");
                }
                if ((num2 >= 0) && (num2 <= 1023))
                {
                    expression = hertz;
                    return (Math.Round(expression, 2) + " Hz");
                }
                text = "";
            }
            catch 
            {
                text = "";
                return text;
            }
            return text;
        }
        #endregion

        #region 电源信息
        [return: MarshalAs(UnmanagedType.U1)]
        [DllImport("powrprof", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IsPwrHibernateAllowed();
        [return: MarshalAs(UnmanagedType.U1)]
        [DllImport("powrprof", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IsPwrShutdownAllowed();
        [return: MarshalAs(UnmanagedType.U1)]
        [DllImport("powrprof", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool IsPwrSuspendAllowed();

        public static bool CanHibernate()
        {
            return IsPwrHibernateAllowed();
        }

        public static bool CanShutdown()
        {
            return IsPwrShutdownAllowed();
        }

        public static bool CanSuspend()
        {
            return IsPwrSuspendAllowed();
        }
        #endregion

        #region 时间信息
        public static string GetCurrentTimeZone()
        {
            if (TimeZone.CurrentTimeZone.IsDaylightSavingTime(DateTime.Now.Date))
            {
                return TimeZone.CurrentTimeZone.DaylightName;
            }
            return TimeZone.CurrentTimeZone.StandardName;
        }

        public static string GetOSUptime()
        {
            string text;
            string text2 = "";
            string text3 = "";
            string text4 = "";
            string text5 = "";
            try
            {
                int num;
                int num2;
                int num3;
                int num4;
                int num5;
                int tickCount = Environment.TickCount;
                do
                {
                    num = (int)(tickCount / 0x5265c00);
                    num4 = tickCount % 0x5265c00;
                }
                while (num4 > 0x5265c00);
                do
                {
                    num2 = (int)(num4 / 0x36ee80);
                    num4 = num4 % 0x36ee80;
                }
                while (num4 > 0x36ee80);
                do
                {
                    num3 = (int)(num4 / 0xea60);
                    num4 = num4 % 0xea60;
                }
                while (num4 > 0xea60);
                do
                {
                    num5 = (int)(num4 / 0x3e8);
                    num4 = num4 % 0x3e8;
                }
                while (num4 > 0x3e8);
                if (num == 0)
                {
                    text2 = "";
                }
                else if (num.ToString().Trim().Length == 1)
                {
                    text2 = " " + num.ToString().Trim() + ":";
                }
                else if (num.ToString().Trim().Length == 2)
                {
                    text2 = num.ToString().Trim() + ":";
                }
                if ((num2 == 0) & (num == 0))
                {
                    text3 = "";
                }
                else if (num2.ToString().Trim().Length == 1)
                {
                    text3 = "0" + num2.ToString().Trim() + ":";
                }
                else if (num2.ToString().Trim().Length == 2)
                {
                    text3 = num2.ToString().Trim() + ":";
                }
                if (num3 == 0)
                {
                    text4 = "00:";
                }
                else if (num3.ToString().Trim().Length == 1)
                {
                    text4 = "0" + num3.ToString().Trim() + ":";
                }
                else if (num3.ToString().Trim().Length == 2)
                {
                    text4 = num3.ToString().Trim() + ":";
                }
                if (num5 == 0)
                {
                    text5 = "00";
                }
                else if (num5.ToString().Trim().Length == 1)
                {
                    text5 = "0" + num5.ToString().Trim();
                }
                else if (num5.ToString().Trim().Length == 2)
                {
                    text5 = num5.ToString().Trim();
                }
                text = text2 + text3 + text4 + text5;
            }
            catch
            {
                ;
                text = "";
                return text;
            }
            return text;
        }
        #endregion

        #region 环境变量
        public static void GetSystemVarToListView(System.Windows.Forms.ListView lvList)
        {
            RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SYSTEM\ControlSet001\Control\Session Manager\Environment\",true);
            foreach (string t in rk.GetValueNames())
            {
                System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem(t);
                lvi.SubItems.Add(rk.GetValue(t).ToString());
                lvList.Items.Add(lvi);
            }
            rk.Close();
        }
        public static void GetUserVarToListView(System.Windows.Forms.ListView lvList)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Environment\", true);
            foreach (string t in rk.GetValueNames())
            {
                System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem(t);
                lvi.SubItems.Add(rk.GetValue(t).ToString());
                lvList.Items.Add(lvi);
            }
            rk.Close();
        }
        #endregion

        #region 操作系统信息

        private static  RegistryKey rk = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\", true);
        public static string GetOSName()
        {
            return rk.GetValue("ProductName").ToString();
        }
        public static string GetOSVersion()
        {
            return rk.GetValue("CurrentVersion").ToString() + "Build" + rk.GetValue("CurrentBuildNumber").ToString() + "(" + rk.GetValue("CSDVersion").ToString() + ")";
        }
        public static string GetProductId()
        {
            return rk.GetValue("ProductId").ToString();
        }
        #endregion

        #region 内存信息
        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }
        private static MEMORY_INFO MemInfo = new MEMORY_INFO();
        /// <summary>
        /// 物理内存大小
        /// </summary>
        /// <returns></returns>
        public static string GetTotalPhys()
        {
            GlobalMemoryStatus(ref MemInfo);
            return FormatBytes(double.Parse(MemInfo.dwTotalPhys.ToString()));
        }
        /// <summary>
        /// 可用的物理内存大小
        /// </summary>
        /// <returns></returns>
        public static string GetAvailPhys()
        {
            GlobalMemoryStatus(ref MemInfo);
            return FormatBytes(double.Parse(MemInfo.dwAvailPhys.ToString()));
        }
        /// <summary>
        /// 交换文件总大小
        /// </summary>
        /// <returns></returns>
        public static string GetTotalPageFile()
        {
            GlobalMemoryStatus(ref MemInfo);
            return FormatBytes(double.Parse(MemInfo.dwTotalPageFile.ToString()));
        }
        /// <summary>
        /// 可交换文件大小
        /// </summary>
        /// <returns></returns>
        public static string GetAvailPageFile()
        {
            GlobalMemoryStatus(ref MemInfo);
            return FormatBytes(double.Parse(MemInfo.dwAvailPageFile.ToString()));
        }
        /// <summary>
        /// 虚拟内存大小
        /// </summary>
        /// <returns></returns>
        public static string GetTotalVirtual()
        {
            GlobalMemoryStatus(ref MemInfo);
            return FormatBytes(double.Parse(MemInfo.dwTotalVirtual.ToString()));
        }
        /// <summary>
        /// 可用虚拟内存大小
        /// </summary>
        /// <returns></returns>
        public static string GetAvailVirtual()
        {
            GlobalMemoryStatus(ref MemInfo);
            return FormatBytes(double.Parse(MemInfo.dwAvailVirtual.ToString()));
        }
        /// <summary>
        /// 内存使用情况
        /// </summary>
        /// <returns></returns>
        public static uint GetMemoryLoad()
        {
            GlobalMemoryStatus(ref MemInfo);
            return MemInfo.dwMemoryLoad;
        }
        #endregion

    }
}
