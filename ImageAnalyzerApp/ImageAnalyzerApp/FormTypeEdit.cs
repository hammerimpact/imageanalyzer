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
    public partial class FormTypeEdit : Form
    {
        // Private variables
        private int index = 0;
        private string typeName = string.Empty;
        private Bitmap bitmap = null;
        private Action<int, string> funcOnEditTypeName = null;
        private Func<int, ResultTypeInfo> funcGetResultTypeInfo = null;

        public FormTypeEdit()
        {
            InitializeComponent();
        }

        public void SetData(int index, Action<int, string> funcOnEditTypeName, Func<int, ResultTypeInfo> funcGetResultTypeInfo)
        {
            this.index = index;
            this.funcOnEditTypeName = funcOnEditTypeName;
            this.funcGetResultTypeInfo = funcGetResultTypeInfo;

            var info = this.funcGetResultTypeInfo?.Invoke(this.index);
            if (null != info)
            {
                this.typeName = info.typeName;
                this.bitmap = info.bitmap;
            }
            else
            {
                this.typeName = string.Empty;
                this.bitmap = null;
            }
        }

        private void FormTypeEdit_Load(object sender, EventArgs e)
        {
            // Refresh UI
            RefreshUI();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // RefreshData
            typeName = textBoxTypeName.Text;
            funcOnEditTypeName?.Invoke(index, typeName);
        }

        private void buttonIndexPrev_Click(object sender, EventArgs e)
        {
            var idx = index - 1;
            var info = funcGetResultTypeInfo?.Invoke(idx);

            if (null == info)
            {
                MessageBox.Show("First index", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Refresh Data
            index = idx;
            typeName = info.typeName;
            bitmap = info.bitmap;

            // Refresh UI
            RefreshUI();
        }

        private void buttonIndexNext_Click(object sender, EventArgs e)
        {
            var idx = index + 1;
            var info = funcGetResultTypeInfo?.Invoke(idx);

            if (null == info)
            {
                MessageBox.Show("Last index", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Refresh Data
            index = idx;
            typeName = info.typeName;
            bitmap = info.bitmap;

            // Refresh UI
            RefreshUI();
        }

        private void RefreshUI()
        {
            textBoxIndex.Text = index.ToString();
            textBoxTypeName.Text = typeName;
            pictureBoxImage.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Size.Width, bitmap.Size.Height), bitmap.PixelFormat);
        }
    }
}
