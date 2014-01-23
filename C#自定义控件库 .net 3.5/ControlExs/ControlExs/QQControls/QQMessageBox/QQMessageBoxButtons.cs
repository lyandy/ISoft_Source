using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlExs
{
    /// <summary>
    /// 消息框QQMessageBox 上按钮枚举
    /// </summary>
    public enum QQMessageBoxButtons
    {
        /// <summary>
        /// 消息框包含“确定”按钮
        /// </summary>
        OK,
        /// <summary>
        /// 消息框包含“确定”与“取消”按钮
        /// </summary>
        OKCancel,
        /// <summary>
        /// 消息框包含“重试”与“取消”按钮
        /// </summary>
        RetryCancel
    }
}
