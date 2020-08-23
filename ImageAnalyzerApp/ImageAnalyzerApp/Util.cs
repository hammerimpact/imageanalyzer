using System;
using System.IO;
using System.Drawing;
using System.Numerics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageAnalyzerApp
{
    public class ResultTypeInfo
    {
        public int index = 0;
        public string typeName = string.Empty;
        public Bitmap bitmap = null;
    }

    public struct AnalyzeResultInfo
    {
        public int index;
        public string Name;
        public ResultTypeInfo ResultType;
    }

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

        public static bool CompareBitmaps(Bitmap bmp1, Bitmap bmp2, double DiffMax)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return true;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            Color color1 = new Color();
            Vector3 point1 = new Vector3();

            Color color2 = new Color();
            Vector3 point2 = new Vector3();

            int diffCount = 5;

            //Compare bitmaps using GetPixel method
            for (int column = 0; column < bmp1.Width; column++)
            {
                for (int row = 0; row < bmp1.Height; row++)
                {
                    color1 = bmp1.GetPixel(column, row);
                    point1 = new Vector3(color1.R, color1.G, color1.B);

                    color2 = bmp2.GetPixel(column, row);
                    point2 = new Vector3(color2.R, color2.G, color2.B);

                    if (!color1.Equals(color2))
                    {
                        // check color diff (vector3's distance)
                        double dist = Vector3.Distance(point1, point2);
                        if (dist > DiffMax)
                        {
                            --diffCount;
                            if (diffCount < 0)
                                return false;
                        }
                    }
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