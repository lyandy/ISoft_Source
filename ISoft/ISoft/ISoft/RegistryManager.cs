using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

//51Aspx.com 下载
namespace ISoft
{
    class RegistryManager
    {
        private static string keyName = "ISoft";
        private static string keyPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        private static string keyValue = System.Reflection.Assembly.GetExecutingAssembly().Location + " /s";

        /// <summary>
        /// 添加启动项
        /// </summary>
        public static void AddKey()
        {
            RegistryKey k;
            k = Registry.CurrentUser.CreateSubKey(keyPath);
            k.SetValue(keyName, keyValue);
            k.Close();
        }

        /// <summary>
        /// 检查键是否存在
        /// </summary>
        /// <returns></returns>
        public static bool ExistKey()
        {
            string[] aimnames;
            RegistryKey aimdir = Registry.CurrentUser.OpenSubKey(keyPath);
            aimnames = aimdir.GetValueNames();
            foreach (string aimKey in aimnames)
            {
                if (aimKey == keyName)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// 删除启动项
        /// </summary>
        public static void DeleteKey()
        {
            string[] aimnames;
            RegistryKey aimdir = Registry.CurrentUser.OpenSubKey(keyPath, true);
            aimnames = aimdir.GetValueNames();
            foreach (string aimKey in aimnames)
            {
                if (aimKey == keyName)
                {
                    aimdir.DeleteValue(keyName);
                    aimdir.Close();
                    break;
                }
            }
        }

        /// <summary>
        /// 检查启动项是否正常
        /// </summary>
        /// <param name="addReg">如果没有,是否添加?</param>
        public static void CheckAutoRun(bool addReg)
        {
            try
            {
                //检查是否已有启动项
                if (ExistKey())
                {
                    //重新写入//增加新项
                    AddKey();
                }
                else
                {
                    if (addReg)
                    {
                        //增加新项
                        AddKey();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("检查启动项时出现错误!\n" + ex.Message);
            }
        }
    }
}
