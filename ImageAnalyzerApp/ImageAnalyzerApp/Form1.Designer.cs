namespace ImageAnalyzerApp
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.button_Load = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRectXMin = new System.Windows.Forms.TextBox();
            this.textBoxRectYMin = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxRectXMax = new System.Windows.Forms.TextBox();
            this.textBoxRectYMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listViewFiles = new System.Windows.Forms.ListView();
            this.listViewTypes = new System.Windows.Forms.ListView();
            this.listViewResults = new System.Windows.Forms.ListView();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveResultFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonTypesEdit = new System.Windows.Forms.Button();
            this.buttonResultsEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(906, 341);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(148, 37);
            this.button_Start.TabIndex = 2;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Clear
            // 
            this.button_Clear.Location = new System.Drawing.Point(906, 384);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(148, 37);
            this.button_Clear.TabIndex = 3;
            this.button_Clear.Text = "Clear";
            this.button_Clear.UseVisualStyleBackColor = true;
            this.button_Clear.Click += new System.EventHandler(this.button_Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Files";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(230, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Types";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(501, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Results";
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(29, 12);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(827, 21);
            this.textBoxFilePath.TabIndex = 8;
            // 
            // button_Load
            // 
            this.button_Load.Location = new System.Drawing.Point(862, 12);
            this.button_Load.Name = "button_Load";
            this.button_Load.Size = new System.Drawing.Size(84, 21);
            this.button_Load.TabIndex = 9;
            this.button_Load.Text = "Load";
            this.button_Load.UseVisualStyleBackColor = true;
            this.button_Load.Click += new System.EventHandler(this.button_Load_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.HelpRequest += new System.EventHandler(this.folderBrowserDialog_HelpRequest);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(904, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Rect";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(902, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "XMin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(900, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "YMin";
            // 
            // textBoxRectXMin
            // 
            this.textBoxRectXMin.Location = new System.Drawing.Point(940, 77);
            this.textBoxRectXMin.Name = "textBoxRectXMin";
            this.textBoxRectXMin.Size = new System.Drawing.Size(112, 21);
            this.textBoxRectXMin.TabIndex = 13;
            this.textBoxRectXMin.TextChanged += new System.EventHandler(this.textBoxRectXMin_TextChanged);
            this.textBoxRectXMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRectXMin_KeyPress);
            // 
            // textBoxRectYMin
            // 
            this.textBoxRectYMin.Location = new System.Drawing.Point(940, 114);
            this.textBoxRectYMin.Name = "textBoxRectYMin";
            this.textBoxRectYMin.Size = new System.Drawing.Size(112, 21);
            this.textBoxRectYMin.TabIndex = 14;
            this.textBoxRectYMin.TextChanged += new System.EventHandler(this.textBoxRectYMin_TextChanged);
            this.textBoxRectYMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRectYMin_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(896, 157);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "XMax";
            // 
            // textBoxRectXMax
            // 
            this.textBoxRectXMax.Location = new System.Drawing.Point(940, 154);
            this.textBoxRectXMax.Name = "textBoxRectXMax";
            this.textBoxRectXMax.Size = new System.Drawing.Size(112, 21);
            this.textBoxRectXMax.TabIndex = 16;
            this.textBoxRectXMax.TextChanged += new System.EventHandler(this.textBoxRectXMax_TextChanged);
            this.textBoxRectXMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRectXMax_KeyPress);
            // 
            // textBoxRectYMax
            // 
            this.textBoxRectYMax.Location = new System.Drawing.Point(940, 190);
            this.textBoxRectYMax.Name = "textBoxRectYMax";
            this.textBoxRectYMax.Size = new System.Drawing.Size(112, 21);
            this.textBoxRectYMax.TabIndex = 17;
            this.textBoxRectYMax.TextChanged += new System.EventHandler(this.textBoxRectYMax_TextChanged);
            this.textBoxRectYMax.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRectYMax_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(896, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "YMax";
            // 
            // listViewFiles
            // 
            this.listViewFiles.HideSelection = false;
            this.listViewFiles.Location = new System.Drawing.Point(29, 80);
            this.listViewFiles.Name = "listViewFiles";
            this.listViewFiles.Size = new System.Drawing.Size(166, 390);
            this.listViewFiles.TabIndex = 21;
            this.listViewFiles.UseCompatibleStateImageBehavior = false;
            this.listViewFiles.View = System.Windows.Forms.View.List;
            this.listViewFiles.Click += new System.EventHandler(this.listViewFiles_Click);
            // 
            // listViewTypes
            // 
            this.listViewTypes.HideSelection = false;
            this.listViewTypes.Location = new System.Drawing.Point(232, 80);
            this.listViewTypes.Name = "listViewTypes";
            this.listViewTypes.Size = new System.Drawing.Size(229, 341);
            this.listViewTypes.TabIndex = 22;
            this.listViewTypes.UseCompatibleStateImageBehavior = false;
            // 
            // listViewResults
            // 
            this.listViewResults.HideSelection = false;
            this.listViewResults.Location = new System.Drawing.Point(503, 80);
            this.listViewResults.Name = "listViewResults";
            this.listViewResults.Size = new System.Drawing.Size(244, 341);
            this.listViewResults.TabIndex = 23;
            this.listViewResults.UseCompatibleStateImageBehavior = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(906, 427);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(148, 37);
            this.buttonSave.TabIndex = 24;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // saveResultFileDialog
            // 
            this.saveResultFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveResultFileDialog_FileOk);
            // 
            // buttonTypesEdit
            // 
            this.buttonTypesEdit.Location = new System.Drawing.Point(232, 436);
            this.buttonTypesEdit.Name = "buttonTypesEdit";
            this.buttonTypesEdit.Size = new System.Drawing.Size(85, 34);
            this.buttonTypesEdit.TabIndex = 25;
            this.buttonTypesEdit.Text = "Edit";
            this.buttonTypesEdit.UseVisualStyleBackColor = true;
            // 
            // buttonResultsEdit
            // 
            this.buttonResultsEdit.Location = new System.Drawing.Point(503, 436);
            this.buttonResultsEdit.Name = "buttonResultsEdit";
            this.buttonResultsEdit.Size = new System.Drawing.Size(85, 34);
            this.buttonResultsEdit.TabIndex = 26;
            this.buttonResultsEdit.Text = "Edit";
            this.buttonResultsEdit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 489);
            this.Controls.Add(this.buttonResultsEdit);
            this.Controls.Add(this.buttonTypesEdit);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listViewResults);
            this.Controls.Add(this.listViewTypes);
            this.Controls.Add(this.listViewFiles);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxRectYMax);
            this.Controls.Add(this.textBoxRectXMax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxRectYMin);
            this.Controls.Add(this.textBoxRectXMin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Load);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Clear);
            this.Controls.Add(this.button_Start);
            this.Name = "Form1";
            this.Text = "Image Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Button button_Load;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRectXMin;
        private System.Windows.Forms.TextBox textBoxRectYMin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxRectXMax;
        private System.Windows.Forms.TextBox textBoxRectYMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView listViewFiles;
        private System.Windows.Forms.ListView listViewTypes;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.SaveFileDialog saveResultFileDialog;
        private System.Windows.Forms.Button buttonTypesEdit;
        private System.Windows.Forms.Button buttonResultsEdit;
    }
}

