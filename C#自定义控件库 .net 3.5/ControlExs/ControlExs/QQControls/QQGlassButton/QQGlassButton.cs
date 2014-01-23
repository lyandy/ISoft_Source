using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

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
    /// 仿QQ效果的GlassButton
    /// </summary>
    public class QQGlassButton : PictureBox, IButtonControl
    {
        #region  Fileds

        private DialogResult _DialogResult;
        private bool _isDefault = false;
        private bool _holdingSpace = false;

        private QQControlState _state = QQControlState.Normal;
        private Font _defaultFont = new Font("微软雅黑", 9);

        private Image _glassHotImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.QQGlassButton.Image.glassbtn_hot.png");
        private Image _glassDownImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.QQGlassButton.Image.glassbtn_down.png");

        private ToolTip _toolTip = new ToolTip();

        #endregion

        #region Constructor

        public QQGlassButton()
            : base()
        {
            this.BackColor = Color.Transparent;
            this.Size = new Size(75, 23);
            this.BorderStyle = BorderStyle.None;
            this.Font = _defaultFont;
        }

        #endregion

        #region IButtonControl Members

        public DialogResult DialogResult
        {
            get
            {
                return _DialogResult;
            }
            set
            {
                if (Enum.IsDefined(typeof(DialogResult), value))
                {
                    _DialogResult = value;
                }
            }
        }

        public void NotifyDefault(bool value)
        {
            if (_isDefault != value)
            {
                _isDefault = value;
            }
        }

        public void PerformClick()
        {
            base.OnClick(EventArgs.Empty);
        }

        #endregion

        #region  Properties

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The text associated with the control.")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The font used to display text in the control.")]
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
            }
        }

        [Description("当鼠标放在控件可见处的提示文本")]
        public string ToolTipText { get; set; }

        #endregion

        #region Description Changes
        [Description("Controls how the ImageButton will handle image placement and control sizing.")]
        public new PictureBoxSizeMode SizeMode { get { return base.SizeMode; } set { base.SizeMode = value; } }

        [Description("Controls what type of border the ImageButton should have.")]
        public new BorderStyle BorderStyle { get { return base.BorderStyle; } set { base.BorderStyle = value; } }
        #endregion

        #region Hiding

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageLayout BackgroundImageLayout { get { return base.BackgroundImageLayout; } set { base.BackgroundImageLayout = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image BackgroundImage { get { return base.BackgroundImage; } set { base.BackgroundImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new String ImageLocation { get { return base.ImageLocation; } set { base.ImageLocation = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image ErrorImage { get { return base.ErrorImage; } set { base.ErrorImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new Image InitialImage { get { return base.InitialImage; } set { base.InitialImage = value; } }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool WaitOnLoad { get { return base.WaitOnLoad; } set { base.WaitOnLoad = value; } }
        #endregion

        #region override

        protected override void OnMouseEnter(EventArgs e)
        {
            //show tool tip 
            if (ToolTipText != string.Empty)
            {
                HideToolTip();
                ShowTooTip(ToolTipText);
            }

            _state = QQControlState.Highlight;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _state = QQControlState.Normal;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _state = QQControlState.Down;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(e.Location))
                    _state = QQControlState.Highlight;
                else
                    _state = QQControlState.Normal;
            }
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {

            _state = QQControlState.Normal;
            Invalidate();
            _holdingSpace = false;
            base.OnLostFocus(e);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Rectangle imageRect, textRect;
            CalculateRect(out imageRect, out textRect);
            switch (_state)
            {
                case QQControlState.Highlight:
                    RenderHelper.DrawImageWithNineRect(
                         pe.Graphics,
                       _glassHotImg,
                        ClientRectangle,
                        new Rectangle(0, 0, _glassDownImg.Width, _glassDownImg.Height));
                    break;
                case QQControlState.Down:
                    RenderHelper.DrawImageWithNineRect(
                         pe.Graphics,
                        _glassDownImg,
                        ClientRectangle,
                        new Rectangle(0, 0, _glassDownImg.Width, _glassDownImg.Height));
                    break;
                default:
                    break;
            }

            if (Image != null)
            {
                pe.Graphics.DrawImage(
                    Image,
                    imageRect,
                    new Rectangle(0, 0, Image.Width, Image.Height),
                    GraphicsUnit.Pixel);
            }

            if (Text.Trim().Length != 0)
            {
                TextRenderer.DrawText(
                    pe.Graphics,
                    Text,
                    Font,
                    textRect,
                    SystemColors.ControlText);
            }
        }

        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == Win32.WM_KEYUP)
            {
                if (_holdingSpace)
                {
                    if ((int)msg.WParam == (int)Keys.Space)
                    {
                        OnMouseUp(null);
                        PerformClick();
                    }
                    else if ((int)msg.WParam == (int)Keys.Escape
                        || (int)msg.WParam == (int)Keys.Tab)
                    {
                        _holdingSpace = false;
                        OnMouseUp(null);
                    }
                }
                return true;
            }
            else if (msg.Msg == Win32.WM_KEYDOWN)
            {
                if ((int)msg.WParam == (int)Keys.Space)
                {
                    _holdingSpace = true;
                    OnMouseDown(null);
                }
                else if ((int)msg.WParam == (int)Keys.Enter)
                {
                    PerformClick();
                }
                return true;
            }
            else
                return base.PreProcessMessage(ref msg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_defaultFont != null)
                    _defaultFont.Dispose();
                if (_glassDownImg != null)
                    _glassDownImg.Dispose();
                if (_glassHotImg != null)
                    _glassHotImg.Dispose();
                if (_toolTip != null)
                    _toolTip.Dispose();
            }
            _defaultFont = null;
            _glassDownImg = null;
            _glassHotImg = null;
            _toolTip = null;
            base.Dispose(disposing);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            Refresh();
            base.OnTextChanged(e);
        }

        #endregion

        #region Private

        private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
        {
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            if (Image == null && !string.IsNullOrEmpty(Text))
            {
                textRect = new Rectangle(3, 0, Width - 6, Height);
            }
            else if (Image != null && string.IsNullOrEmpty(Text))
            {
                imageRect = new Rectangle((Width - Image.Width) / 2, (Height - Image.Height) / 2, Image.Width, Image.Height);
            }
            else if (Image != null && !string.IsNullOrEmpty(Text))
            {
                imageRect = new Rectangle(4, (Height - Image.Height) / 2, Image.Width, Image.Height);
                textRect = new Rectangle(imageRect.Right + 1, 0, Width - 4 * 2 - imageRect.Width - 1, Height);
            }
        }

        private void ShowTooTip(string toolTipText)
        {
            _toolTip.Active = true;
            _toolTip.SetToolTip(this, toolTipText);
        }

        private void HideToolTip()
        {
            _toolTip.Active = false;
        }

        #endregion
    }
}

