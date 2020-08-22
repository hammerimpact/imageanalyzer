using System;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnalyzerApp
{
    public struct Rect
    {
        public int XMin;
        public int XMax;
        public int YMin;
        public int YMax;

        public Point LeftTop => new Point(XMin, YMin);
        public Point LeftBottom => new Point(XMin, YMax);
        public Point RightTop => new Point(XMax, YMin);
        public Point RightBottom => new Point(XMax, YMax);
        public int Width => XMax - XMin;
        public int Height => YMax - YMin;

        public Rect(int xmin, int ymin, int xmax, int ymax)
        {
            this.XMin = xmin;
            this.YMin = ymin;
            this.XMax = xmax;
            this.YMax = ymax;

            Invalidate();
        }

        public void Copy(Rect rect)
        {
            this.XMin = rect.XMin;
            this.YMin = rect.YMin;
            this.XMax = rect.XMax;
            this.YMax = rect.YMax;

            Invalidate();
        }

        private void Invalidate()
        {
            int _xmin = Math.Min(XMin, XMax);
            int _xmax = Math.Max(XMin, XMax);
            int _ymin = Math.Min(YMin, YMax);
            int _ymax = Math.Max(YMin, YMax);

            XMin = _xmin;
            XMax = _xmax;
            YMin = _ymin;
            YMax = _ymax;
        }
    }

    public static class Util
    {
        public static Bitmap LoadBitmap(string path)
        {
            if (File.Exists(path) == false)
                return null;

            using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    var memoryStream = new MemoryStream(reader.ReadBytes((int)stream.Length));
                    return new Bitmap(memoryStream);
                }
            }
        }

        public static bool CompareBitmapsFast(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;

            if (object.Equals(bmp1, bmp2))
                return true;

            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            int bytes = bmp1.Width * bmp1.Height * (Image.GetPixelFormatSize(bmp1.PixelFormat) / 8);

            bool result = true;
            byte[] b1bytes = new byte[bytes];
            byte[] b2bytes = new byte[bytes];

            BitmapData bitmapData1 = bmp1.LockBits(new Rectangle(0, 0, bmp1.Width, bmp1.Height), ImageLockMode.ReadOnly, bmp1.PixelFormat);
            BitmapData bitmapData2 = bmp2.LockBits(new Rectangle(0, 0, bmp2.Width, bmp2.Height), ImageLockMode.ReadOnly, bmp2.PixelFormat);

            Marshal.Copy(bitmapData1.Scan0, b1bytes, 0, bytes);
            Marshal.Copy(bitmapData2.Scan0, b2bytes, 0, bytes);

            for (int n = 0; n <= bytes - 1; n++)
            {
                if (b1bytes[n] != b2bytes[n])
                {
                    result = false;
                    break;
                }
            }

            bmp1.UnlockBits(bitmapData1);
            bmp2.UnlockBits(bitmapData2);

            return result;
        }

        public static bool CompareBitmapsLazy(Bitmap bmp1, Bitmap bmp2)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            //Compare bitmaps using GetPixel method
            for (int column = 0; column < bmp1.Width; column++)
            {
                for (int row = 0; row < bmp1.Height; row++)
                {
                    if (!bmp1.GetPixel(column, row).Equals(bmp2.GetPixel(column, row)))
                        return false;
                }
            }

            return true;
        }

        public static void Log(string log)
        {
            Form1.Instance.SetLog(log);
        }
    }
}