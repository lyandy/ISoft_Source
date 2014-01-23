using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

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
    /// 仿QQ效果的Button
    /// </summary>
    public class QQButton : Button
    {
        #region Field

        private Image _normalImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.QQButton.Image.qqbtn_normal.png");
        private Image _highlightImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.QQButton.Image.qqbtn_highlight.png");
        private Image _focusImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.QQButton.Image.qqbtn_focus.png");
        private Image _downImg = RenderHelper.GetImageFormResourceStream("ControlExs.QQControls.QQButton.Image.qqbtn_down.png");

        private QQControlState _state = QQControlState.Normal;
        private Font _defaultFont = new Font("微软雅黑", 9);

        #endregion

        #region Constructor

        public QQButton()
        {
            SetStyles();
            this.Font = _defaultFont;
            this.Size = new Size(68, 23);
        }

        #endregion

        #region Properites

        private int ImageWidth
        {
            get
            {
                if (Image == null)
                {
                    return 16;
                }
                else
                {
                    return Image.Width;
                }
            }

        }

        #endregion

        #region Override

        protected override void OnMouseEnter(EventArgs e)
        {
            _state = QQControlState.Highlight;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            if (_state == QQControlState.Highlight && Focused)
            {
                _state = QQControlState.Focus;
            }
            else if (_state == QQControlState.Focus)
            {
                _state = QQControlState.Focus;
            }
            else
            {
                _state = QQControlState.Normal;
            }
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                _state = QQControlState.Down;
            }
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            if (mevent.Button == MouseButtons.Left)
            {
                if (ClientRectangle.Contains(mevent.Location))
                {
                    _state = QQControlState.Highlight;
                }
                else
                {
                    _state = QQControlState.Focus;
                }
            }
            base.OnMouseUp(mevent);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            _state = QQControlState.Normal;
            base.OnLostFocus(e);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
            {
                _state = QQControlState.Normal;
            }
            else
            {
                _state = QQControlState.Disabled;
            }
            base.OnEnabledChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBilinear;

            Rectangle imageRect, textRect;
            CalculateRect(out imageRect, out textRect);

            if (!Enabled)
            {
                _state = QQControlState.Disabled;
            }
            switch (_state)
            {
                case QQControlState.Normal:

                    RenderHelper.DrawImageWithNineRect(
                        g, _normalImg,
                        ClientRectangle,
                        new Rectangle(0, 0, _normalImg.Width, _normalImg.Height));
                    break;
                case QQControlState.Highlight:

                    RenderHelper.DrawImageWithNineRect(
                        g, _highlightImg,
                        ClientRectangle,
                        new Rectangle(0, 0, _highlightImg.Width, _highlightImg.Height));
                    break;
                case QQControlState.Focus:

                    RenderHelper.DrawImageWithNineRect(
                        g, _focusImg,
                        ClientRectangle,
                        new Rectangle(0, 0, _focusImg.Width, _focusImg.Height));
                    break;
                case QQControlState.Down:
                    RenderHelper.DrawImageWithNineRect(
                       g, _downImg,
                       ClientRectangle,
                       new Rectangle(0, 0, _downImg.Width, _downImg.Height));
                    break;
                case QQControlState.Disabled:
                    DrawDisabledButton(g);
                    break;
                default:
                    break;
            }

            if (Image != null)
            {
                g.DrawImage(Image, imageRect, 0, 0, Image.Width, Image.Height, GraphicsUnit.Pixel);
            }

            Color textColor = Enabled ? ForeColor : SystemColors.GrayText;
            TextRenderer.DrawText(
                  g,
                  Text,
                  Font,
                  textRect,
                  textColor,
                  GetTextFormatFlags(TextAlign, RightToLeft == RightToLeft.Yes));

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_normalImg != null) { _normalImg.Dispose(); }
                if (_highlightImg != null) { _highlightImg.Dispose(); }
                if (_downImg != null) { _downImg.Dispose(); }
                if (_focusImg != null) { _focusImg.Dispose(); }
                if (_defaultFont != null) { _defaultFont.Dispose(); }
            }

            _normalImg = null;
            _highlightImg = null;
            _focusImg = null;
            _downImg = null;
            _defaultFont = null;
            base.Dispose(disposing);
        }

        #endregion

        #region Private

        private void SetStyles()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();
        }

        private void CalculateRect(out Rectangle imageRect, out Rectangle textRect)
        {
            imageRect = Rectangle.Empty;
            textRect = Rectangle.Empty;
            if (Image == null)
            {
                textRect = new Rectangle(
                   3,
                   0,
                   Width - 6,
                   Height);
                return;
            }
            switch (TextImageRelation)
            {
                case TextImageRelation.Overlay:
                    imageRect = new Rectangle(
                        3,
                        (Height - ImageWidth) / 2,
                        ImageWidth,
                        ImageWidth);
                    textRect = new Rectangle(
                        3,
                        0,
                        Width - 6,
                        Height);
                    break;
                case TextImageRelation.ImageAboveText:
                    imageRect = new Rectangle(
                        (Width - ImageWidth) / 2,
                        3,
                        ImageWidth,
                        ImageWidth);
                    textRect = new Rectangle(
                        3,
                        imageRect.Bottom,
                        Width - 6,
                        Height - imageRect.Bottom - 2);
                    break;
                case TextImageRelation.ImageBeforeText:
                    imageRect = new Rectangle(
                        3,
                        (Height - ImageWidth) / 2,
                        ImageWidth,
                        ImageWidth);
                    textRect = new Rectangle(
                        imageRect.Right + 3,
                        0,
                        Width - imageRect.Right - 6,
                        Height);
                    break;
                case TextImageRelation.TextAboveImage:
                    imageRect = new Rectangle(
                        (Width - ImageWidth) / 2,
                        Height - ImageWidth - 3,
                        ImageWidth,
                        ImageWidth);
                    textRect = new Rectangle(
                        0,
                        3,
                        Width,
                        Height - imageRect.Y - 3);
                    break;
                case TextImageRelation.TextBeforeImage:
                    imageRect = new Rectangle(
                        Width - ImageWidth - 6,
                        (Height - ImageWidth) / 2,
                        ImageWidth,
                        ImageWidth);
                    textRect = new Rectangle(
                        3,
                        0,
                        imageRect.X - 3,
                        Height);
                    break;
            }

            if (RightToLeft == RightToLeft.Yes)
            {
                imageRect.X = Width - imageRect.Right;
                textRect.X = Width - textRect.Right;
            }
        }

        private void DrawDisabledButton(Graphics g)
        {
            int radius = 4;
            //此处让其宽度减1，让其由Normal态平滑自然的过渡到Disabled态，保持按钮高度一致。
            using (GraphicsPath borderPath = RenderHelper.CreateRoundPath(new Rectangle(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height -1), radius))
            {
                using (Pen disalbedPen = new Pen(Color.FromArgb(156, 165, 177)))
                {
                    g.DrawPath(disalbedPen, borderPath);
                }

                //背景层渐变,向内缩小1个像素
                Rectangle backRect = new Rectangle(ClientRectangle.X + 1, ClientRectangle.Y + 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2 -1);
                using (GraphicsPath innerPath = RenderHelper.CreateRoundPath(backRect, radius))
                {
                    using (LinearGradientBrush lBrush = new LinearGradientBrush(backRect, Color.FromArgb(247, 252, 254), Color.FromArgb(230, 240, 243), LinearGradientMode.Vertical))
                    {
                        g.FillPath(lBrush, innerPath);
                    }
                }
            }
        }

        internal static TextFormatFlags GetTextFormatFlags(ContentAlignment alignment, bool rightToleft)
        {
            TextFormatFlags flags = TextFormatFlags.WordBreak |
                TextFormatFlags.SingleLine;
            if (rightToleft)
            {
                flags |= TextFormatFlags.RightToLeft | TextFormatFlags.Right;
            }

            switch (alignment)
            {
                case ContentAlignment.BottomCenter:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.BottomLeft:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Left;
                    break;
                case ContentAlignment.BottomRight:
                    flags |= TextFormatFlags.Bottom | TextFormatFlags.Right;
                    break;
                case ContentAlignment.MiddleCenter:
                    flags |= TextFormatFlags.HorizontalCenter |
                        TextFormatFlags.VerticalCenter;
                    break;
                case ContentAlignment.MiddleLeft:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Left;
                    break;
                case ContentAlignment.MiddleRight:
                    flags |= TextFormatFlags.VerticalCenter | TextFormatFlags.Right;
                    break;
                case ContentAlignment.TopCenter:
                    flags |= TextFormatFlags.Top | TextFormatFlags.HorizontalCenter;
                    break;
                case ContentAlignment.TopLeft:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Left;
                    break;
                case ContentAlignment.TopRight:
                    flags |= TextFormatFlags.Top | TextFormatFlags.Right;
                    break;
            }
            return flags;
        }

        #endregion
    }
}
