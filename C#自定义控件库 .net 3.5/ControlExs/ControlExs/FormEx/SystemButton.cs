using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ControlExs
{

    /****************************************************************
    * 
    *           Author：苦笑
    *             Blog: http://www.cnblogs.com/Keep-Silence-/
    *             Date: 2013-2-22
    *
    *****************************************************************/



    //按钮事件委托
    public delegate void MouseDownEventHandler();

    internal class SystemButton
    {
        public SystemButtonState State { get; set; }
        public Rectangle LocationRect { get; set; }
        public Image NormalImg { get; set; }
        public Image HighLightImg { get; set; }
        public Image DownImg { get; set; }
        public string ToolTip { get; set; }

        public event MouseDownEventHandler OnMouseDownEvent;
        public void OnMouseDown()
        {
            if (OnMouseDownEvent != null)
            {
                OnMouseDownEvent();
            }
        }
    }
}
