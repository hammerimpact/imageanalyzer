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
    public partial class Form1 : Form
    {
        // Private variables
        int nTest = 1;

        public Form1()
        {
            InitializeComponent();

            nTest = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxFilePath.Text = "None";
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
            textBoxFilePath.Text = "button_Start_Click";
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBoxFilePath.Text = "button_Clear_Click";
        }
    }
}
