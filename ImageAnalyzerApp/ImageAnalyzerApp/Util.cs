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
    }
}
