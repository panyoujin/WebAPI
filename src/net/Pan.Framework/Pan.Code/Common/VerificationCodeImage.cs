using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;

namespace Pan.Code.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class VerificationCodeImage
    {

        private static string RandomNum()
        {
            var checkCode = String.Empty;
            Random random = new Random();
            string sCode = "23456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghjkmnpqrstuvwxyz";
            for (int i = 0; i < 4; i++)
            {
                checkCode += sCode.Substring(random.Next(sCode.Length), 1);
            }
            return checkCode;
        }
        private static int[] RandomPoint()
        {
            int[] intArray = new int[6];
            for (int i = 0; i < 6; i += 2)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                switch (i)
                {
                    case 0:
                        intArray[i] = random.Next(0, 10);
                        break;
                    case 2:
                        intArray[i] = random.Next(45, 55);
                        break;
                    case 4:
                        intArray[i] = random.Next(90, 100);
                        break;
                }
            }
            for (int i = 1; i < 6; i += 2)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                intArray[i] = random.Next(0, 42);
            }
            return intArray;
        }
        /// <summary>
        /// 绘制干扰线
        /// </summary>
        /// <param name="random"></param>
        /// <param name="bitmap"></param>
        /// <param name="graphics"></param>
        /// <param name="lineCount"></param>
        /// <param name="pointCount"></param>
        private static void Disturb(Random random, Bitmap bitmap, Graphics graphics, int lineCount, int pointCount)
        {

            var colors = new List<Color>
            {
                Color.AliceBlue,
                Color.Azure,
                Color.CadetBlue,
                Color.Beige,
                Color.Chartreuse
            };

            //干扰线
            for (var i = 0; i < lineCount; i++)
            {
                var x1 = random.Next(bitmap.Width);
                var x2 = random.Next(bitmap.Width);
                var y1 = random.Next(bitmap.Height);
                var y2 = random.Next(bitmap.Height);

                //Pen 类 定义用于绘制直线和曲线的对象。
                var pen = new Pen(colors[random.Next(0, colors.Count - 1)]);

                graphics.DrawLine(pen, x1, y1, x2, y2);
            }

            //干扰点
            for (var i = 0; i < pointCount; i++)
            {
                var x = random.Next(bitmap.Width);
                var y = random.Next(bitmap.Height);
                bitmap.SetPixel(x, y, Color.FromArgb(random.Next()));
            }
        }
        public static byte[] CreateImage(out string code)
        {
            int width = 100;
            int height = 40;

            code = RandomNum();
            var fontNames = new List<string>
            {
                "Helvetica","Arial","Lucida Family","Verdana","Tahoma","Trebuchet MS","Georgia","Times"
            };
            //Bitmap 类 封装 GDI+ 包含图形图像和其属性的像素数据的位图。 一个 Bitmap 是用来处理图像像素数据所定义的对象。
            //Bitmap 类 继承自 抽象基类 Image 类
            using (var bitmap = new Bitmap(width, height))
            {
                //Graphics 类 封装一个 GDI+ 绘图图面。
                using (var graphics = Graphics.FromImage(bitmap))
                {
                    //填充背景色 白色
                    graphics.Clear(Color.White);

                    var random = new Random();
                    //绘制干扰线和干扰点
                    Disturb(random, bitmap, graphics, width / 2, height);

                    //添加灰色边框
                    var pen = new Pen(Color.Silver);
                    graphics.DrawRectangle(pen, 0, 0, width - 1, height - 1);

                    var x = 1;
                    const int y = 5;

                    var rectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

                    var color = Color.FromArgb(random.Next(100, 122), random.Next(100, 122), random.Next(100, 122));

                    foreach (var c in code.ToCharArray())
                    {
                        //随机选择字符 字体样式和大小
                        var fontName = fontNames[random.Next(0, fontNames.Count - 1)];
                        var font = new Font(fontName, random.Next(15, 20));
                        //淡化字符颜色 
                        using (var brush = new LinearGradientBrush(rectangle, color, color, 90f, true))
                        {
                            brush.SetSigmaBellShape(0.5f);
                            graphics.DrawString(c.ToString(), font, brush, x + random.Next(-2, 2), y + random.Next(-5, 5));
                            x = x + width / code.Length;
                        }
                    }

                    using (var memoryStream = new MemoryStream())
                    {
                        //把图片存进内存流
                        bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                        //获取内存流的byte数组
                        byte[] buf = memoryStream.GetBuffer();
                        return buf;
                    }
                }
            }
        }
    }
}
