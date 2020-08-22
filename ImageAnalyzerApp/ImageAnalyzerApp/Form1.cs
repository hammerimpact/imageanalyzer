using System;
using System.IO;
using System.Text;
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Init Data
            InitData_DirectoryPath();
            InitData_DirectoryFileNames();

            // Refresh UI
            RefreshUI_DirectoryPath();
            RefreshUI_DirectoryFileNames();
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

            // Refresh Data
            RefreshUI_DirectoryPath();
            RefreshUI_DirectoryFileNames();
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

        private void InitData_DirectoryPath()
        {
            szDirectoryPath = string.Empty;
        }

        private void InitData_DirectoryFileNames()
        {
            listTargetFileInfos.Clear();
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
