using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace ControlExs
{
    /****************************************************************
    * 
    *           Author：苦笑
    *             Blog: http://www.cnblogs.com/Keep-Silence-/
    *             Date: 2013-2-22
    *
    *****************************************************************/

    /// <summary>
    /// 实现仿QQ效果控件内部使用颜色表
    /// </summary>
    internal class ColorTable
    {
        public static Color QQBorderColor = Color.LightBlue;  //LightBlue = Color.FromArgb(173, 216, 230)
        public static Color QQHighLightColor =RenderHelper.GetColor(QQBorderColor,255,-63,-11,23);   //Color.FromArgb(110, 205, 253)
        public static Color QQHighLightInnerColor = RenderHelper.GetColor(QQBorderColor, 255, -100, -44, 1);   //Color.FromArgb(73, 172, 231);
    }
}
