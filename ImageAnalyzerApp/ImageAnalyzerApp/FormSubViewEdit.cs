using System;
using System.IO;
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
    public partial class FormSubViewEdit : Form
    {
        // Private variables
        private AnalyzeResultInfo info = new AnalyzeResultInfo();
        private Func<int, int, bool> funcTryEditTypeIndex = null;
        private Action onCompleteEditTypeIndex = null;

        public FormSubViewEdit()
        {
            InitializeComponent();
        }

        public void SetData(AnalyzeResultInfo info, 
                            Func<int, int, bool> funcTryEditTypeIndex,
                            Action onCompleteEditTypeIndex)
        {
            this.info = info;
            this.funcTryEditTypeIndex = funcTryEditTypeIndex;
            this.onCompleteEditTypeIndex = onCompleteEditTypeIndex;
        }

        private void FormSubViewEdit_Load(object sender, EventArgs e)
        {
            textBoxTypeIndexEdit.Text = 0.ToString();
            RefreshUI_AnalyzeInfo();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int value = 0;
            var target = textBoxTypeIndexEdit;
            if (string.IsNullOrEmpty(target.Text))
            {
                target.Text = 0.ToString();
                return;
            }

            if (int.TryParse(target.Text, out value) == false)
                return;

            // Try Edit
            var result = funcTryEditTypeIndex?.Invoke(info.index, value) ?? false;
            if (!result)
                return;

            onCompleteEditTypeIndex?.Invoke();

            Close();
        }

        private void textBoxTypeIndexEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
            _check_textbox_keypress_allow_number_only_(e);
        }

        private void _check_textbox_keypress_allow_number_only_(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }

        private void RefreshUI_AnalyzeInfo()
        {
            if (info.ResultType == null)
                return;

            textBoxIndex.Text = info.index.ToString();
            textBoxName.Text = info.Name;
            textBoxTypeName.Text = info.ResultType.typeName;
            textBoxTypeIndex.Text = info.ResultType.index.ToString();

            if (File.Exists(info.Path))
                pictureBoxOrigin.Image = Util.LoadBitmap(info.Path);
        }
    }
}
