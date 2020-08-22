﻿using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageAnalyzerApp
{
    public partial class Form1 : Form
    {
        struct TargetFileInfo
        {
            public string Name;
            public string Path;
        }

        // Private variables
        private string szDirectoryPath = string.Empty;
        private List<TargetFileInfo> listTargetFileInfos = new List<TargetFileInfo>();
        private Rect rRectCrop = new Rect();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Init Data
            InitData_DirectoryPath();
            InitData_DirectoryFileNames();
            InitData_RectCrop();

            // Refresh UI
            RefreshUI_DirectoryPath();
            RefreshUI_DirectoryFileNames();
            RefreshUI_RectCrop();
        }

        //private void button_hello_Click(object sender, EventArgs e)
        //{
        //    //var result = MessageBox.Show(string.Format("isTest : {0}", nTest), "뻐큐", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
        //    //switch (result)
        //    //{
        //    //    case DialogResult.Yes:
        //    //        ++nTest;
        //    //        break;

        //    //    case DialogResult.No:
        //    //        --nTest;
        //    //        break;
        //    //}
        //}

        private void button_Start_Click(object sender, EventArgs e)
        {
            
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            // Init Data
            InitData_DirectoryPath();
            InitData_DirectoryFileNames();
            InitData_RectCrop();

            // Refresh Data
            RefreshUI_DirectoryPath();
            RefreshUI_DirectoryFileNames();
            RefreshUI_RectCrop();
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

                    for (int i = 0; i < listTargetFileInfos.Count; ++i)
                    {
                        sw.Append(listTargetFileInfos[i].Name);
                        sw.Append("\t");
                        sw.Append(listTargetFileInfos[i].Path);
                        sw.Append("\n");
                    }

                    var sz = Encoding.UTF8.GetBytes(sw.ToString());
                    stream.Write(sz, 0, sz.Length);
                }
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

            var _name = string.Empty;
            var _path = string.Empty;

            for (int i = 0; i < listTargetFileInfos.Count; ++i)
            {
                if (listTargetFileInfos[i].Name == selectedItem.Text)
                {
                    _name = listTargetFileInfos[i].Name;
                    _path = listTargetFileInfos[i].Path;
                    break;
                }
            }

            if (string.IsNullOrEmpty(_name))
                return;

            var dlg = new FormImageView();
            dlg.SetData(_name, _path, rRectCrop);
            dlg.Show();
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

        private void _check_textbox_keypress_allow_number_only_(KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back);
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
            rRectCrop.XMin = value;
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
            rRectCrop.YMin = value;
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
            rRectCrop.XMax = value;
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
            rRectCrop.YMax = value;
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

        private void RefreshUI_DirectoryPath()
        {
            if (string.IsNullOrEmpty(szDirectoryPath) == false)
                textBoxFilePath.Text = szDirectoryPath;
            else
                textBoxFilePath.Text = "NONE";
        }

        private void RefreshUI_DirectoryFileNames()
        {
            listViewFiles.BeginUpdate();
            listViewFiles.Items.Clear();

            for (int i = 0; i < listTargetFileInfos.Count; ++i)
            {
                var item = new ListViewItem(listTargetFileInfos[i].Name);
                listViewFiles.Items.Add(item);
            }
            listViewFiles.EndUpdate();
        }

        private void RefreshUI_RectCrop()
        {
            textBoxRectXMin.Text = rRectCrop.XMin.ToString();
            textBoxRectXMax.Text = rRectCrop.XMax.ToString();
            textBoxRectYMin.Text = rRectCrop.YMin.ToString();
            textBoxRectYMax.Text = rRectCrop.YMax.ToString();
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
