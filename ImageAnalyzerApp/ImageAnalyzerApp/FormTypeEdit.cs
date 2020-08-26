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

        private Func<int, int, bool> funcTryEditTypeIndex = null;
        private Func<int, List<AnalyzeResultInfo>> funcGetAnalyzeResultInfo = null;
        private List<AnalyzeResultInfo> listAnalyzeResultInfo = new List<AnalyzeResultInfo>();

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

        public void SetDataTryEdit(Func<int, int, bool> funcTryEditTypeIndex,
                                   Func<int, List<AnalyzeResultInfo>> funcGetAnalyzeResultInfo)
        {
            this.funcTryEditTypeIndex = funcTryEditTypeIndex;
            this.funcGetAnalyzeResultInfo = funcGetAnalyzeResultInfo;
        }

        private void FormTypeEdit_Load(object sender, EventArgs e)
        {
            // Refresh Data
            RefreshData_AnalyzeResultList();

            // Refresh UI
            RefreshUI_Type();
            RefreshUI_AnalyzeResultList();
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
            RefreshData_AnalyzeResultList();

            // Refresh UI
            RefreshUI_Type();
            RefreshUI_AnalyzeResultList();
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
            RefreshData_AnalyzeResultList();

            // Refresh UI
            RefreshUI_Type();
            RefreshUI_AnalyzeResultList();
        }


        private void listTypeDataList_Click(object sender, EventArgs e)
        {
            if (listTypeDataList.SelectedItems.Count == 0)
                return;

            var selectedItem = listTypeDataList.SelectedItems[0];

            int key = 0;
            if (int.TryParse(selectedItem.Text, out key) == false)
                return;

            var pAnalyzeResultInfo = new AnalyzeResultInfo();
            for (int i = 0; i < listAnalyzeResultInfo.Count; ++i)
            {
                if (listAnalyzeResultInfo[i].index == key)
                {
                    pAnalyzeResultInfo = listAnalyzeResultInfo[i];
                    break;
                }
            }

            if (pAnalyzeResultInfo.ResultType == null)
                return;

            var dlg = new FormSubViewEdit();
            dlg.SetData(pAnalyzeResultInfo, funcTryEditTypeIndex, _on_complete_edit_type_index_);
            dlg.Show();
        }

        private void _on_complete_edit_type_index_()
        {
            // Refresh Data
            RefreshData_AnalyzeResultList();

            // Refresh UI
            RefreshUI_AnalyzeResultList();
        }

        private void RefreshData_AnalyzeResultList()
        {
            listAnalyzeResultInfo.Clear();

            var list = funcGetAnalyzeResultInfo?.Invoke(index) ?? null;
            if (null != list)
                listAnalyzeResultInfo.AddRange(list);
        }

        private void RefreshUI_Type()
        {
            textBoxIndex.Text = index.ToString();
            textBoxTypeName.Text = typeName;
            pictureBoxImage.Image = bitmap.Clone(new Rectangle(0, 0, bitmap.Size.Width, bitmap.Size.Height), bitmap.PixelFormat);
        }

        private void RefreshUI_AnalyzeResultList()
        {
            listTypeDataList.Clear();

            listTypeDataList.BeginUpdate();

            for (int i = 0; i < listAnalyzeResultInfo.Count; ++i)
            {
                var data = listAnalyzeResultInfo[i];
                var lvi = new ListViewItem(data.index.ToString());
                lvi.SubItems.Add(data.Name.ToString());
                listTypeDataList.Items.Add(lvi);
            }

            listTypeDataList.Columns.Add("index", 80);
            listTypeDataList.Columns.Add("Name", 130);

            listTypeDataList.EndUpdate();
        }

    }
}
