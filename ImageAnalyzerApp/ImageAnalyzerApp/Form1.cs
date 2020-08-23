using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ImageAnalyzerApp
{
    public partial class Form1 : Form
    {
        private static Form1 _instance = null;
        public static Form1 Instance => _instance;

        struct TargetFileInfo
        {
            public string Name;
            public string Path;
        }

        // Private variables
        private string szDirectoryPath = string.Empty;
        private List<TargetFileInfo> listTargetFileInfos = new List<TargetFileInfo>();
        private Rect rRectCrop = new Rect();
        private double ColorDiffMax = 0;

        // Private variables - results
        private List<ResultTypeInfo> listResultTypeInfo = new List<ResultTypeInfo>();
        private List<AnalyzeResultInfo> listAnalyzeResultInfo = new List<AnalyzeResultInfo>();

        public Form1()
        {
            _instance = this;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Init Data
            InitData_DirectoryPath();
            InitData_DirectoryFileNames();
            InitData_RectCrop();
            InitData_ColorDiffMax();
            InitData_ResultTypeInfo();
            InitData_AnalyzeResultInfo();

            // Refresh UI
            RefreshUI_DirectoryPath();
            RefreshUI_DirectoryFileNames();
            RefreshUI_RectCrop();
            RefreshUI_ColorDiffMax();
            RefreshUI_ResultTypeInfo();
            RefreshUI_AnalyzeResultInfo();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Ready to Start?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Yes:
                    ExecCropAndAnalizeAll();
                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            // Init Data
            InitData_DirectoryPath();
            InitData_DirectoryFileNames();
            InitData_RectCrop();
            InitData_ColorDiffMax();
            InitData_ResultTypeInfo();
            InitData_AnalyzeResultInfo();

            // Refresh Data
            RefreshUI_DirectoryPath();
            RefreshUI_DirectoryFileNames();
            RefreshUI_RectCrop();
            RefreshUI_ColorDiffMax();
            RefreshUI_ResultTypeInfo();
            RefreshUI_AnalyzeResultInfo();
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(szDirectoryPath) == false)
                saveResultFileDialog.InitialDirectory = szDirectoryPath;
            else
                saveResultFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            saveResultFileDialog.Filter = "Text File|*.txt";
            saveResultFileDialog.Title = "Save an Image File";
            var result = saveResultFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                // Create File
                using (Stream stream = saveResultFileDialog.OpenFile())
                {
                    var sw = new StringBuilder();

                    for (int i = 0; i < listAnalyzeResultInfo.Count; ++i)
                    {
                        sw.Append(listAnalyzeResultInfo[i].index);
                        sw.Append("\t");
                        sw.Append(listAnalyzeResultInfo[i].Name);
                        sw.Append("\t");
                        sw.Append(listAnalyzeResultInfo[i].ResultType.typeName);
                        sw.Append("\n");
                    }

                    var sz = Encoding.UTF8.GetBytes(sw.ToString());
                    stream.Write(sz, 0, sz.Length);
                }

                MessageBox.Show("Save Complete.", "Information", MessageBoxButtons.OK);
            }
        }

        private void button_Load_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

            var result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            if (Directory.Exists(folderBrowserDialog.SelectedPath) == false)
                return;

            // Refresh Data
            szDirectoryPath = folderBrowserDialog.SelectedPath;

            listTargetFileInfos.Clear();

            var paths = Directory.GetFiles(szDirectoryPath, "*.jpg");
            if (null != paths)
            {
                for (int i = 0; i < paths.Length; ++i)
                    listTargetFileInfos.Add(new TargetFileInfo() { Name = Path.GetFileName(paths[i]), Path = paths[i]});

                listTargetFileInfos.Sort((l, r)=> l.Name.CompareTo(r.Name));
            }

            // Refresh UI
            RefreshUI_DirectoryPath();
            RefreshUI_DirectoryFileNames();
        }

        private void listViewFiles_Click(object sender, EventArgs e)
        {
            if (listViewFiles.SelectedItems.Count == 0)
                return;

            var selectedItem = listViewFiles.SelectedItems[0];
            var key = selectedItem.Text;

            var _name = string.Empty;
            var _path = string.Empty;

            for (int i = 0; i < listTargetFileInfos.Count; ++i)
            {
                if (listTargetFileInfos[i].Name == key)
                {
                    _name = listTargetFileInfos[i].Name;
                    _path = listTargetFileInfos[i].Path;
                    break;
                }
            }

            if (string.IsNullOrEmpty(_name))
                return;

            var dlg = new FormImageView();
            dlg.SetData(_name, _path, rRectCrop, onFormImageView_Copy);
            dlg.Show();
        }


        private void listViewTypes_Click(object sender, EventArgs e)
        {
            if (listViewTypes.SelectedItems.Count == 0)
                return;

            var selectedItem = listViewTypes.SelectedItems[0];

            int key = 0;
            if (int.TryParse(selectedItem.Text, out key) == false)
                return;

            ResultTypeInfo pResultTypeInfo = null;
            for (int i = 0; i < listResultTypeInfo.Count; ++i)
            {
                if (listResultTypeInfo[i].index == key)
                {
                    pResultTypeInfo = listResultTypeInfo[i];
                    break;
                }
            }

            if (pResultTypeInfo == null)
                return;

            var dlg = new FormTypeEdit();
            dlg.SetData(pResultTypeInfo.index, onFormTypeEdit_Edit, _get_result_type_info_);
            dlg.Show();
        }

        private ResultTypeInfo _get_result_type_info_(int index)
        {
            if (index < 0 || index >= listResultTypeInfo.Count)
                return null;

            return listResultTypeInfo[index];
        }


        private void textBoxRectXMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            _check_textbox_keypress_allow_number_only_(e);
        }

        private void textBoxRectYMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            _check_textbox_keypress_allow_number_only_(e);
        }

        private void textBoxRectXMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            _check_textbox_keypress_allow_number_only_(e);
        }

        private void textBoxRectYMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            _check_textbox_keypress_allow_number_only_(e);
        }

        private void textBoxColorDiffMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete && textBoxColorDiffMax.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }

        private void _check_textbox_keypress_allow_number_only_(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete);
        }

        private void textBoxRectXMin_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            var target = textBoxRectXMin;
            if (string.IsNullOrEmpty(target.Text))
            {
                target.Text = 0.ToString();
                return;
            }

            if (int.TryParse(target.Text, out value) == false)
                return;

            // Refresh Data
            var prev = rRectCrop.XMin;
            rRectCrop.XMin = value;

            Util.Log(string.Format("XMin changed {0}=>{1}", prev, rRectCrop.XMin));
        }


        private void textBoxRectYMin_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            var target = textBoxRectYMin;
            if (string.IsNullOrEmpty(target.Text))
            {
                target.Text = 0.ToString();
                return;
            }

            if (int.TryParse(target.Text, out value) == false)
                return;

            // Refresh Data
            var prev = rRectCrop.YMin;
            rRectCrop.YMin = value;

            Util.Log(string.Format("YMin changed {0}=>{1}", prev, rRectCrop.YMin));
        }


        private void textBoxRectXMax_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            var target = textBoxRectXMax;
            if (string.IsNullOrEmpty(target.Text))
            {
                target.Text = 0.ToString();
                return;
            }

            if (int.TryParse(target.Text, out value) == false)
                return;

            // Refresh Data
            var prev = rRectCrop.XMax;
            rRectCrop.XMax = value;

            Util.Log(string.Format("XMax changed {0}=>{1}", prev, rRectCrop.XMax));
        }


        private void textBoxRectYMax_TextChanged(object sender, EventArgs e)
        {
            int value = 0;
            var target = textBoxRectYMax;
            if (string.IsNullOrEmpty(target.Text))
            {
                target.Text = 0.ToString();
                return;
            }

            if (int.TryParse(target.Text, out value) == false)
                return;

            // Refresh Data
            var prev = rRectCrop.YMax;
            rRectCrop.YMax = value;

            Util.Log(string.Format("YMax changed {0}=>{1}", prev, rRectCrop.YMax));
        }


        private void textBoxColorDiffMax_TextChanged(object sender, EventArgs e)
        {
            double value = 0;
            var target = textBoxColorDiffMax;
            if (string.IsNullOrEmpty(target.Text))
            {
                target.Text = 0.ToString();
                return;
            }

            if (double.TryParse(target.Text, out value) == false)
                return;

            // Refresh Data
            var prev = ColorDiffMax;
            ColorDiffMax = value;

            Util.Log(string.Format("ColorDiffMax changed {0}=>{1}", prev, ColorDiffMax));
        }

        private void onFormImageView_Copy(Rect rRect)
        {
            // Refresh Data
            rRectCrop.Copy(rRect);

            // Refresh UI
            RefreshUI_RectCrop();
        }

        private void onFormTypeEdit_Edit(int index, string typeName)
        {
            // Refresh Data
            var isChanged = false;
            for (int i = 0; i < listResultTypeInfo.Count; ++i)
            {
                if (listResultTypeInfo[i].index == index)
                {
                    isChanged = true;
                    listResultTypeInfo[i].typeName = typeName;
                    break;
                }
            }

            // Refresh UI
            if (isChanged)
                RefreshUI_ResultTypeInfo();
        }


        private void InitData_DirectoryPath()
        {
            szDirectoryPath = string.Empty;
        }

        private void InitData_DirectoryFileNames()
        {
            listTargetFileInfos.Clear();
        }

        private void InitData_RectCrop()
        {
            rRectCrop = new Rect();
        }

        private void InitData_ResultTypeInfo()
        {
            for (int i = 0; i < listResultTypeInfo.Count; ++i)
            {
                if (listResultTypeInfo[i].bitmap != null)
                {
                    listResultTypeInfo[i].bitmap.Dispose();
                    listResultTypeInfo[i].bitmap = null;
                }
            }

            listResultTypeInfo.Clear();
        }

        private void InitData_AnalyzeResultInfo()
        {
            listAnalyzeResultInfo.Clear();
        }

        private void InitData_ColorDiffMax()
        {
            ColorDiffMax = 0;
        }

        private void RefreshUI_DirectoryPath()
        {
            if (string.IsNullOrEmpty(szDirectoryPath) == false)
                textBoxFilePath.Text = szDirectoryPath;
            else
                textBoxFilePath.Text = "NONE";
        }

        private void RefreshUI_DirectoryFileNames()
        {
            listViewFiles.Clear();

            listViewFiles.BeginUpdate();

            for (int i = 0; i < listTargetFileInfos.Count; ++i)
            {
                var lvi = new ListViewItem(listTargetFileInfos[i].Name);
                listViewFiles.Items.Add(lvi);
            }
            listViewFiles.Columns.Add("FileName", 140);

            listViewFiles.EndUpdate();
        }

        private void RefreshUI_RectCrop()
        {
            textBoxRectXMin.Text = rRectCrop.XMin.ToString();
            textBoxRectXMax.Text = rRectCrop.XMax.ToString();
            textBoxRectYMin.Text = rRectCrop.YMin.ToString();
            textBoxRectYMax.Text = rRectCrop.YMax.ToString();
        }

        private void RefreshUI_ColorDiffMax()
        {
            textBoxColorDiffMax.Text = ColorDiffMax.ToString();
        }

        private void RefreshUI_ResultTypeInfo()
        {
            listViewTypes.Clear();

            listViewTypes.BeginUpdate();

            for (int i = 0; i < listResultTypeInfo.Count; ++i)
            {
                var data = listResultTypeInfo[i];
                var lvi = new ListViewItem(data.index.ToString());
                lvi.SubItems.Add(data.typeName.ToString());
                listViewTypes.Items.Add(lvi);
            }

            listViewTypes.Columns.Add("index", 80);
            listViewTypes.Columns.Add("TypeName", 140);

            listViewTypes.EndUpdate();
        }

        private void RefreshUI_AnalyzeResultInfo()
        {
            listViewResults.Clear();

            listViewResults.BeginUpdate();

            for (int i = 0; i < listAnalyzeResultInfo.Count; ++i)
            {
                var data = listAnalyzeResultInfo[i];
                var lvi = new ListViewItem(data.Name.ToString());
                if (null != data.ResultType)
                    lvi.SubItems.Add(data.ResultType.index.ToString());
                else
                    lvi.SubItems.Add("Type NULL");

                listViewResults.Items.Add(lvi);
            }

            listViewResults.Columns.Add("Name", 140);
            listViewResults.Columns.Add("TypeIndex", 100);

            listViewResults.EndUpdate();
        }

        private List<string> listLog = new List<string>();
        private StringBuilder sbLog = new StringBuilder();
        public void SetLog(string log)
        {
            if (string.IsNullOrEmpty(log))
                return;

            // Refresh Data
            if (listLog.Count >= 3)
                listLog.RemoveAt(0);

            listLog.Add(log);

            sbLog.Clear();
            for (int i = 0; i < listLog.Count; ++i)
                sbLog.AppendLine(listLog[i]);

            // Refresh UI
            textBoxLog.Text = sbLog.ToString();
        }

        // ExecCropAndAnalize
        private void ExecCropAndAnalizeAll()
        {
            // Refresh Data
            InitData_ResultTypeInfo();
            InitData_AnalyzeResultInfo();

            // Refresh UI
            RefreshUI_ResultTypeInfo();
            RefreshUI_AnalyzeResultInfo();

            // Refresh Data 2
            Util.Log("===============ExecCropAndAnalizeAll Start===============");

            bool bFailed = false;
            int nSuccess = 0;
            int nAll = listTargetFileInfos.Count;
            for (int i = 0; i < nAll; ++i)
            {
                var reason = ExecCropAnalize(i, listTargetFileInfos[i].Name, listTargetFileInfos[i].Path);
                if (reason == EnumFailedReason.None)
                    ++nSuccess;
                else
                {
                    bFailed = true;
                    Util.Log(string.Format("ExecCropAnalize Failed[{0}] : {1}", listTargetFileInfos[i].Name, reason));
                    break;
                }
            }

            if (bFailed == false)
            {
                Util.Log(string.Format("===============ExecCropAndAnalizeAll Complete[{0}/{1}]===============", nSuccess, nAll));
            }
            else
            {
                // Refresh Data
                InitData_ResultTypeInfo();
                InitData_AnalyzeResultInfo();
            }

            // Refresh UI
            RefreshUI_ResultTypeInfo();
            RefreshUI_AnalyzeResultInfo();

            //SaveResultType();
        }

        //private void SaveResultType()
        //{
        //    for (int i = 0; i < listResultTypeInfo.Count; ++i)
        //    {
        //        if (listResultTypeInfo[i].bitmap != null)
        //            listResultTypeInfo[i].bitmap.Save(szDirectoryPath + string.Format("\\image{0}.png", i), System.Drawing.Imaging.ImageFormat.Png);
        //    }
        //}

        private enum EnumFailedReason
        {
            None,
            FileNotExist,
            BitmapLoadFailed,
            RectCropInvalid,
            BitmapCloneFailed,
        }

        private EnumFailedReason ExecCropAnalize(int index, string Name, string path)
        {
            if (File.Exists(path) == false)
                return EnumFailedReason.FileNotExist;

            var rectCrop = new Rect(rRectCrop.XMin, rRectCrop.YMin, rRectCrop.XMax, rRectCrop.YMax);
            if (rectCrop.XMin == rectCrop.XMax || rRectCrop.YMin == rRectCrop.YMax)
                return EnumFailedReason.RectCropInvalid;

            var bitmapOrigin = Util.LoadBitmap(path);
            if (null == bitmapOrigin)
                return EnumFailedReason.BitmapLoadFailed;

            var cropRectangle = new Rectangle(rectCrop.XMin, rectCrop.YMin, rectCrop.Width, rectCrop.Height);
            var bitmapClone = bitmapOrigin.Clone(cropRectangle, bitmapOrigin.PixelFormat);
            if (null == bitmapClone)
            {
                bitmapOrigin.Dispose();
                return EnumFailedReason.BitmapCloneFailed;
            }

            ResultTypeInfo pResultTypeInfo = null;
            for (int i = 0; i < listResultTypeInfo.Count; ++i)
            {
                if (Util.CompareBitmaps(listResultTypeInfo[i].bitmap, bitmapClone, ColorDiffMax))
                {
                    pResultTypeInfo = listResultTypeInfo[i];
                    break;
                }
            }

            if (null == pResultTypeInfo)
            {
                pResultTypeInfo = new ResultTypeInfo();
                pResultTypeInfo.index = listResultTypeInfo.Count;
                pResultTypeInfo.typeName = string.Format("type{0}", pResultTypeInfo.index);
                pResultTypeInfo.bitmap = bitmapClone;

                listResultTypeInfo.Add(pResultTypeInfo);
            }

            var kAnalyzeResult = new AnalyzeResultInfo();
            kAnalyzeResult.index = index;
            kAnalyzeResult.Name = Name;
            kAnalyzeResult.ResultType = pResultTypeInfo;

            listAnalyzeResultInfo.Add(kAnalyzeResult);

            bitmapOrigin.Dispose();
            return EnumFailedReason.None;
        }

        #region Useless Callback
        private void folderBrowserDialog_HelpRequest(object sender, EventArgs e)
        {

        }

        private void saveResultFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
        #endregion

    }
}
