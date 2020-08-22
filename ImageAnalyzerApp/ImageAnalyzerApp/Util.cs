using System;
using System.IO;
using System.Drawing;
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

        public Rect(int xmin, int ymin, int xmax, int ymax)
        {
            this.XMin = xmin;
            this.YMin = ymin;
            this.XMax = xmax;
            this.YMax = ymax;

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

        public static void Log(string log)
        {
            Form1.Instance.SetLog(log);
        }
    }
}
