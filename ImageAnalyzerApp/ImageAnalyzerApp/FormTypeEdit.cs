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

        public FormTypeEdit()
        {
            InitializeComponent();
        }

        public void SetData(int index, string typeName, Bitmap bitmap, Action<int, string> funcOnEditTypeName)
        {
            this.index = index;
            this.typeName = typeName;
            this.bitmap = bitmap;
            this.funcOnEditTypeName = funcOnEditTypeName;
        }

        private void FormTypeEdit_Load(object sender, EventArgs e)
        {
            // Refresh UI
            textBoxIndex.Text = index.ToString();
            textBoxTypeName.Text = typeName;
            pictureBoxImage.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Size.Width, bitmap.Size.Height), bitmap.PixelFormat);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // RefreshData
            typeName = textBoxTypeName.Text;

            funcOnEditTypeName?.Invoke(index, typeName);

            MessageBox.Show("Edit Complete", "Information", MessageBoxButtons.OK);
        }
    }
}
