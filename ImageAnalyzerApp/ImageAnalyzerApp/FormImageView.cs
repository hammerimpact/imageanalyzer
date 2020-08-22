using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageAnalyzerApp
{
    public partial class FormImageView : Form
    {
        private string fileName = string.Empty;
        private string path = string.Empty;
        private Rect rRect = new Rect();


        public void SetData(string fileName, string path, Rect rRect)
        {
            this.fileName = fileName;
            this.path = path;
            this.rRect = rRect;
        }

        public FormImageView()
        {
            InitializeComponent();
        }

        private void FormImageView_Load(object sender, EventArgs e)
        {
            labelName.Text = fileName;
            textBoxPath.Text = path;

            pictureBoxImage.Image = Util.LoadBitmap(path);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (Graphics g = pictureBoxImage.CreateGraphics())
            {
                var pen = new Pen(Color.Red, 1f);
                g.DrawLine(pen, rRect.LeftTop, rRect.LeftBottom);
                g.DrawLine(pen, rRect.LeftBottom, rRect.RightBottom);
                g.DrawLine(pen, rRect.RightBottom, rRect.RightTop);
                g.DrawLine(pen, rRect.RightTop, rRect.LeftTop);
            }
        }

        #region Useless Callback
        
        #endregion
    }
}
