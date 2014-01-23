using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
namespace OSSpeed
{
    class ApiGetICON
    {
        /// <summary>
        /// 提取Icon图标
        /// </summary>
        /// <param name="hInst">要提取的目标句柄</param>
        /// <param name="lpsExeFileName">要提取的目标文件名 可以是exe，或者dll，ocx等</param>
        /// <param name="nIconIndex">Icon的编号</param>
        /// <returns>句柄</returns>
        [DllImport("shell32.dll")]
        static extern IntPtr ExtractIcon(IntPtr hInst,string lpsExeFileName,int nIconIndex);

        /// <summary>
        /// 销毁句柄
        /// </summary>
        /// <param name="hInst">要销毁的句柄</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern int DestroyIcon(IntPtr hInst);

        public static void GetIcon(string filepath,ImageList ImgIcon)
        {
            int i = 0;
            IntPtr ipIcon = IntPtr.Zero;
            while (true)
            {
                ipIcon = ExtractIcon(IntPtr.Zero, filepath, i);
                i++;
                if (ipIcon == (IntPtr)0)
                    break;
                //提取指定句柄中的Icon图标 生成Icon位图
                Icon InIndex = Icon.FromHandle(ipIcon);
                ///将提取到的Icon图标放入到图片列表里
                ImgIcon.Images.Add(InIndex);
            }
            DestroyIcon(ipIcon);// 销毁句柄
        }
    }
}
