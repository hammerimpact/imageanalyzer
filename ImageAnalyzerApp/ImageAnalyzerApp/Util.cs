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
using OpenCvSharp;

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
        public string Path;
        public ResultTypeInfo ResultType;
    }

    public struct Rect
    {
        public int XMin;
        public int XMax;
        public int YMin;
        public int YMax;

        public System.Drawing.Point LeftTop         => new System.Drawing.Point(XMin, YMin);
        public System.Drawing.Point LeftBottom      => new System.Drawing.Point(XMin, YMax);
        public System.Drawing.Point RightTop        => new System.Drawing.Point(XMax, YMin);
        public System.Drawing.Point RightBottom     => new System.Drawing.Point(XMax, YMax);
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

        /// <summary>
        /// OpenCV4Window 4.4.0 Required
        /// </summary>
        /// <param name="bmp1"></param>
        /// <param name="bmp2"></param>
        /// <param name="DiffMax"></param>
        /// <returns></returns>
        public static bool CompareBitmapsSSIM(Bitmap bmp1, Bitmap bmp2, Double percent)
        {
            if (bmp1 == null || bmp2 == null)
                return false;
            if (object.Equals(bmp1, bmp2))
                return false;
            if (!bmp1.Size.Equals(bmp2.Size) || !bmp1.PixelFormat.Equals(bmp2.PixelFormat))
                return false;

            Mat img1 = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp1); 
            Mat img2 = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp2); 

            const double C1 = 6.5025, C2 = 58.5225;
            /***************************** INITS **********************************/
            MatType d = MatType.CV_32F;

            Mat I1 = new Mat(), I2 = new Mat();
            // cannot calculate on one byte large values
            img1.ConvertTo(I1, d);           
            img2.ConvertTo(I2, d);

            Mat I2_2 = I2.Mul(I2);        // I2^2
            Mat I1_2 = I1.Mul(I1);        // I1^2
            Mat I1_I2 = I1.Mul(I2);        // I1 * I2

            /***********************PRELIMINARY COMPUTING ******************************/

            Mat mu1 = new Mat(), mu2 = new Mat();   //
            Cv2.GaussianBlur(I1, mu1, new OpenCvSharp.Size(11, 11), 1.5);
            Cv2.GaussianBlur(I2, mu2, new OpenCvSharp.Size(11, 11), 1.5);

            Mat mu1_2 = mu1.Mul(mu1);
            Mat mu2_2 = mu2.Mul(mu2);
            Mat mu1_mu2 = mu1.Mul(mu2);

            Mat sigma1_2 = new Mat(), sigma2_2 = new Mat(), sigma12 = new Mat();

            Cv2.GaussianBlur(I1_2, sigma1_2, new OpenCvSharp.Size(11, 11), 1.5);
            sigma1_2 -= mu1_2;

            Cv2.GaussianBlur(I2_2, sigma2_2, new OpenCvSharp.Size(11, 11), 1.5);
            sigma2_2 -= mu2_2;

            Cv2.GaussianBlur(I1_I2, sigma12, new OpenCvSharp.Size(11, 11), 1.5);
            sigma12 -= mu1_mu2;

            ///////////////////////////////// FORMULA ////////////////////////////////
            Mat t1, t2, t3;

            t1 = 2 * mu1_mu2 + C1;
            t2 = 2 * sigma12 + C2;
            t3 = t1.Mul(t2);              // t3 = ((2*mu1_mu2 + C1).*(2*sigma12 + C2))

            t1 = mu1_2 + mu2_2 + C1;
            t2 = sigma1_2 + sigma2_2 + C2;
            t1 = t1.Mul(t2);               // t1 =((mu1_2 + mu2_2 + C1).*(sigma1_2 + sigma2_2 + C2))

            Mat ssim_map = new Mat();
            Cv2.Divide(t3, t1, ssim_map);      // ssim_map =  t3./t1;
            Scalar mssim = Cv2.Mean(ssim_map);// mssim = average of ssim map

            var ssimValue = (mssim[0] + mssim[1] + mssim[2]) / 3;

            // Dispose
            List<IDisposable> listDisposable = new List<IDisposable>();
            listDisposable.Add(img1);
            listDisposable.Add(img2);
            listDisposable.Add(I1);
            listDisposable.Add(I2);
            listDisposable.Add(I2_2);
            listDisposable.Add(I1_2);
            listDisposable.Add(I1_I2);
            listDisposable.Add(mu1);
            listDisposable.Add(mu2);
            listDisposable.Add(mu1_2);
            listDisposable.Add(mu2_2);
            listDisposable.Add(mu1_mu2);
            listDisposable.Add(sigma1_2);
            listDisposable.Add(sigma2_2);
            listDisposable.Add(sigma12);
            listDisposable.Add(t1);
            listDisposable.Add(t2);
            listDisposable.Add(t3);
            listDisposable.Add(ssim_map);
            foreach (var iDispose in listDisposable)
            {
                if (iDispose != null)
                    iDispose.Dispose();
            }

            return ssimValue > percent;
        }

        public static void Log(string log)
        {
            Form1.Instance.SetLog(log);
        }
    }
}