using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Reflection;

namespace ControlExs
{
    /// <summary>
    /// 窗体自绘辅助类
    /// </summary>
    public class RenderHelper
    {
        /// <summary>
        /// 设置窗体的圆角矩形
        /// </summary>
        /// <param name="form">需要设置的窗体</param>
        /// <param name="rgnRadius">圆角矩形的半径</param>
        public static void SetFormRoundRectRgn(Form form, int rgnRadius)
        {
            int hRgn = 0;
            hRgn = Win32.CreateRoundRectRgn(0, 0, form.Width + 1, form.Height + 1, rgnRadius, rgnRadius);
            Win32.SetWindowRgn(form.Handle, hRgn, true);
            Win32.DeleteObject(hRgn);
        }

        /// <summary>
        /// 移动窗体
        /// </summary>
        public static void MoveWindow(Form form)
        {
            Win32.ReleaseCapture();
            Win32.SendMessage(form.Handle, Win32.WM_NCLBUTTONDOWN, Win32.HTCAPTION, 0);
        }

        /// <summary>
        /// 取低位 X 坐标
        /// </summary>
        public static int LOWORD(int value)
        {
            return value & 0xFFFF;
        }

        /// <summary>
        /// 取高位 Y 坐标
        /// </summary>
        public static int HIWORD(int value)
        {
            return value >> 16;
        }

        /// <summary>
        /// 绘制窗体边框
        /// </summary>
        /// <param name="destForm">需要绘制边框的窗体</param>
        /// <param name="g">绘制边框所用的绘图对象</param>
        /// <param name="fringeImg">边框图片</param>
        /// <param name="radius">边框的圆角矩形</param>
        public static void DrawFormFringe(Form destForm, Graphics g, Image fringeImg, int radius)
        {
            DrawImageWithNineRect(
                g,
                fringeImg,
                new Rectangle(-radius, -radius, destForm.ClientSize.Width + 2 * radius, destForm.ClientSize.Height + 2 * radius),
                new Rectangle(0, 0, fringeImg.Width, fringeImg.Height));
        }

        /// <summary>
        /// 利用九宫图绘制图像
        /// </summary>
        /// <param name="g">绘图对象</param>
        /// <param name="img">所需绘制的图片</param>
        /// <param name="targetRect">目标矩形</param>
        /// <param name="srcRect">来源矩形</param>
        public static void DrawImageWithNineRect(Graphics g, Image img, Rectangle targetRect, Rectangle srcRect)
        {
            int offset = 5;
            Rectangle NineRect = new Rectangle(img.Width / 2 - offset, img.Height / 2 - offset, 2 * offset, 2 * offset);
            int x = 0, y = 0, nWidth, nHeight;
            int xSrc = 0, ySrc = 0, nSrcWidth, nSrcHeight;
            int nDestWidth, nDestHeight;
            nDestWidth = targetRect.Width;
            nDestHeight = targetRect.Height;
            // 左上-------------------------------------;
            x = targetRect.Left;
            y = targetRect.Top;
            nWidth = NineRect.Left - srcRect.Left;
            nHeight = NineRect.Top - srcRect.Top;
            xSrc = srcRect.Left;
            ySrc = srcRect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 上-------------------------------------;
            x = targetRect.Left + NineRect.Left - srcRect.Left;
            nWidth = nDestWidth - nWidth - (srcRect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            nSrcHeight = NineRect.Top - srcRect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 右上-------------------------------------;
            x = targetRect.Right - (srcRect.Right - NineRect.Right);
            nWidth = srcRect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 左-------------------------------------;
            x = targetRect.Left;
            y = targetRect.Top + NineRect.Top - srcRect.Top;
            nWidth = NineRect.Left - srcRect.Left;
            nHeight = targetRect.Bottom - y - (srcRect.Bottom - NineRect.Bottom);
            xSrc = srcRect.Left;
            ySrc = NineRect.Top;
            nSrcWidth = NineRect.Left - srcRect.Left;
            nSrcHeight = NineRect.Bottom - NineRect.Top;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 中-------------------------------------;
            x = targetRect.Left + NineRect.Left - srcRect.Left;
            nWidth = nDestWidth - nWidth - (srcRect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);

            // 右-------------------------------------;
            x = targetRect.Right - (srcRect.Right - NineRect.Right);
            nWidth = srcRect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            nSrcWidth = srcRect.Right - NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);

            // 左下-------------------------------------;
            x = targetRect.Left;
            y = targetRect.Bottom - (srcRect.Bottom - NineRect.Bottom);
            nWidth = NineRect.Left - srcRect.Left;
            nHeight = srcRect.Bottom - NineRect.Bottom;
            xSrc = srcRect.Left;
            ySrc = NineRect.Bottom;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
            // 下-------------------------------------;
            x = targetRect.Left + NineRect.Left - srcRect.Left;
            nWidth = nDestWidth - nWidth - (srcRect.Right - NineRect.Right);
            xSrc = NineRect.Left;
            nSrcWidth = NineRect.Right - NineRect.Left;
            nSrcHeight = srcRect.Bottom - NineRect.Bottom;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nSrcWidth, nSrcHeight, GraphicsUnit.Pixel);
            // 右下-------------------------------------;
            x = targetRect.Right - (srcRect.Right - NineRect.Right);
            nWidth = srcRect.Right - NineRect.Right;
            xSrc = NineRect.Right;
            g.DrawImage(img, new Rectangle(x, y, nWidth, nHeight), xSrc, ySrc, nWidth, nHeight, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// 获取当前命名空间下嵌入的资源图片
        /// </summary>
        /// <param name="imagePath">嵌入的图片资源的路径</param>
        public static Image GetImageFormResourceStream(string imagePath)
        {
            return Image.FromStream(
                Assembly.GetExecutingAssembly().
                GetManifestResourceStream(
                MethodBase.GetCurrentMethod().DeclaringType.Namespace + "." + imagePath));
        }

        /// <summary>
        /// 获取绘制带有阴影的字符串的图像
        /// </summary>
        /// <param name="str">需要绘制的字符串</param>
        /// <param name="font">显示字符串的字体</param>
        /// <param name="foreColor">字符串的颜色</param>
        /// <param name="shadowColor">字符串阴影颜色</param>
        /// <param name="shadowWidth">阴影的宽度</param>
        /// <returns>绘有发光字符串的Image对象</returns>
        public static Image GetStringImgWithShadowEffect(string str, Font font, Color foreColor, Color shadowColor, int shadowWidth)
        {
            Bitmap bitmap = null;//实例化Bitmap类
            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))//实例化Graphics类
            {
                SizeF size = g.MeasureString(str, font);//对字符串进行测量
                using (Bitmap bmp = new Bitmap((int)size.Width, (int)size.Height))//通过文字的大小实例化Bitmap类
                using (Graphics Var_G_Bmp = Graphics.FromImage(bmp))//实例化Bitmap类
                using (SolidBrush Var_BrushBack = new SolidBrush(Color.FromArgb(16, shadowColor.R, shadowColor.G, shadowColor.B)))//根据RGB的值定义画刷
                using (SolidBrush Var_BrushFore = new SolidBrush(foreColor))//定义画刷
                {
                    Var_G_Bmp.SmoothingMode = SmoothingMode.HighQuality;//设置为高质量
                    Var_G_Bmp.InterpolationMode = InterpolationMode.HighQualityBilinear;//设置为高质量的收缩
                    Var_G_Bmp.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;//消除锯齿
                    Var_G_Bmp.DrawString(str, font, Var_BrushBack, 0, 0);//给制文字
                    bitmap = new Bitmap(bmp.Width + shadowWidth, bmp.Height + shadowWidth);//根据辉光文字的大小实例化Bitmap类
                    using (Graphics Var_G_Bitmap = Graphics.FromImage(bitmap))//实例化Graphics类
                    {
                        Var_G_Bitmap.SmoothingMode = SmoothingMode.HighQuality;//设置为高质量
                        Var_G_Bitmap.InterpolationMode = InterpolationMode.HighQualityBilinear;//设置为高质量的收缩
                        Var_G_Bitmap.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;//消除锯齿
                        //遍历辉光文字的各象素点
                        for (int x = 0; x <= shadowWidth; x++)
                        {
                            for (int y = 0; y <= shadowWidth; y++)
                            {
                                Var_G_Bitmap.DrawImageUnscaled(bmp, x, y);//绘制辉光文字的点
                            }
                        }
                        Var_G_Bitmap.DrawString(str, font, Var_BrushFore, shadowWidth / 2, shadowWidth / 2);//绘制文字
                    }
                }
            }

            return bitmap;

        }


        /// <summary>
        /// 建立带有圆角样式的路径。
        /// </summary>
        /// <param name="rect">用来建立路径的矩形。</param>
        /// <param name="radius">圆角的大小。</param>
        /// <returns>建立的路径。</returns>
        public static GraphicsPath CreateRoundPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int radiusCorrection = 1;
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(
                rect.Right - radius - radiusCorrection,
                rect.Y,
                radius,
                radius,
                270,
                90);
            path.AddArc(
                rect.Right - radius - radiusCorrection,
                rect.Bottom - radius - radiusCorrection,
                radius,
                radius, 0, 90);
            path.AddArc(
                rect.X,
                rect.Bottom - radius - radiusCorrection,
                radius,
                radius,
                90,
                90);
            path.CloseFigure();
            return path;
        }

        /// <summary>
        /// 返回给定的颜色的ARGB的分量差值的颜色
        /// </summary>
        /// <param name="colorBase"></param>
        /// <param name="a">A</param>
        /// <param name="r">R</param>
        /// <param name="g">G</param>
        /// <param name="b">B</param>
        /// <returns></returns>
        public static Color GetColor(Color colorBase, int a, int r, int g, int b)
        {
            int a0 = colorBase.A;
            int r0 = colorBase.R;
            int g0 = colorBase.G;
            int b0 = colorBase.B;

            if (a + a0 > 255) { a = 255; } else { a = Math.Max(a + a0, 0); }
            if (r + r0 > 255) { r = 255; } else { r = Math.Max(r + r0, 0); }
            if (g + g0 > 255) { g = 255; } else { g = Math.Max(g + g0, 0); }
            if (b + b0 > 255) { b = 255; } else { b = Math.Max(b + b0, 0); }

            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// 绘制窗体主体部分白色透明层
        /// </summary>
        /// <param name="form"></param>
        /// <param name="g"></param>
        public static void DrawFromAlphaMainPart(Form form, Graphics g)
        {
            Color[] colors = 
            {
                Color.FromArgb(5, Color.White),
                Color.FromArgb(30, Color.White),
                Color.FromArgb(145, Color.White),
                Color.FromArgb(150, Color.White),
                Color.FromArgb(30, Color.White),
                Color.FromArgb(5, Color.White)
            };

            float[] pos = 
            {
                0.0f,
                0.04f,
                0.10f,
                0.90f,
                0.97f,
                1.0f      
            };

            ColorBlend colorBlend = new ColorBlend(6);
            colorBlend.Colors = colors;
            colorBlend.Positions = pos;

            RectangleF destRect = new RectangleF(0, 0, form.Width, form.Height);
            using (LinearGradientBrush lBrush = new LinearGradientBrush(destRect, colors[0], colors[5], LinearGradientMode.Vertical))
            {
                lBrush.InterpolationColors = colorBlend;
                g.FillRectangle(lBrush, destRect);
            }
        }
    }
}
