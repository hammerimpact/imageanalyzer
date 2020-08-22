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
        // Private variables
        string szDirectoryPath = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Init Data
            InitData_DirectoryPath();

            // Refresh UI
            RefreshUI_DirectoryPath();
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

            // Refresh Data
            RefreshUI_DirectoryPath();
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

                    for (int i = 0; i < 10; ++i)
                    {
                        sw.Append("Test");
                        sw.Append("\t");
                        sw.Append(string.Format("{0}", i));
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
            if (result == DialogResult.OK)
            {
                // Refresh Data
                szDirectoryPath = folderBrowserDialog.SelectedPath;

                // Refresh UI
                RefreshUI_DirectoryPath();
            }
        }

        private void InitData_DirectoryPath()
        {
            szDirectoryPath = string.Empty;
        }

        private void RefreshUI_DirectoryPath()
        {
            if (string.IsNullOrEmpty(szDirectoryPath) == false)
                textBoxFilePath.Text = szDirectoryPath;
            else
                textBoxFilePath.Text = "NONE";
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
