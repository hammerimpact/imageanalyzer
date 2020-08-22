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
        // Private variables
        private string fileName = string.Empty;
        private string path = string.Empty;
        private Action<Rect> funcOnCopy = null;
        private Rect rRect = new Rect();
        private Rect rRectOrigin = new Rect();

        private bool isEditCropRectMode = false;


        public void SetData(string fileName, string path, Rect rRect, Action<Rect> funcOnCopy)
        {
            this.fileName = fileName;
            this.path = path;
            this.rRect = rRect;
            this.rRectOrigin = rRect;
            this.funcOnCopy = funcOnCopy;
        }

        public FormImageView()
        {
            InitializeComponent();
        }

        private void FormImageView_Load(object sender, EventArgs e)
        {
            // Refresh UI
            labelName.Text = fileName;
            textBoxPath.Text = path;
            pictureBoxImage.Image = Util.LoadBitmap(path);
            RefreshUI_CropState();
        }


        private void buttonShowOriginRect_Click(object sender, EventArgs e)
        {
            // Refresh Data
            rRect = rRectOrigin;

            // Refresh UI
            RefreshUI_DrawCropRect();
            RefreshUI_CropState();
        }

        private void buttonToggleRect_Click(object sender, EventArgs e)
        {
            // Refresh Data
            isEditCropRectMode = !isEditCropRectMode;

            // Refresh UI
            RefreshUI_CropState();
        }


        private void buttonCopy_Click(object sender, EventArgs e)
        {
            funcOnCopy?.Invoke(rRect);

            MessageBox.Show("Copy Complete", "Information", MessageBoxButtons.OK);
        }

        private Point kTempPointDown = new Point();
        private Point kTempPointUp = new Point();

        private void pictureBoxImage_MouseDown(object sender, MouseEventArgs e)
        {
            if (!isEditCropRectMode)
                return;

            kTempPointDown = pictureBoxImage.PointToClient(Cursor.Position);

            // Refresh UI
            pictureBoxImage.Invalidate(); // for cleanup lines
        }

        private void pictureBoxImage_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isEditCropRectMode)
                return;

            kTempPointUp = pictureBoxImage.PointToClient(Cursor.Position);

            // Refresh Data
            rRect = new Rect(kTempPointDown.X, kTempPointDown.Y, kTempPointUp.X, kTempPointUp.Y);

            // Refresh UI
            RefreshUI_DrawCropRect();
            RefreshUI_CropState();
        }

        private void RefreshUI_DrawCropRect()
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

        private StringBuilder sbCropState = new StringBuilder();
        private void RefreshUI_CropState()
        {
            sbCropState.Clear();

            sbCropState.AppendLine(string.Format("EditCropMode : {0}", isEditCropRectMode));
            sbCropState.AppendLine(string.Format("XMin : {0} / YMin : {1}", rRect.XMin, rRect.YMin));
            sbCropState.AppendLine(string.Format("XMax : {0} / YMax : {1}", rRect.XMax, rRect.YMax));

            textBoxCropState.Text = sbCropState.ToString();
        }

        #region Useless Callback
        #endregion

    }
}
