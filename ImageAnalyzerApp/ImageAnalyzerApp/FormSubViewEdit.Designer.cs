namespace ImageAnalyzerApp
{
    partial class FormSubViewEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxOrigin = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIndex = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxTypeName = new System.Windows.Forms.TextBox();
            this.textBoxTypeIndex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxTypeIndexEdit = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigin)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOrigin
            // 
            this.pictureBoxOrigin.Location = new System.Drawing.Point(12, 136);
            this.pictureBoxOrigin.Name = "pictureBoxOrigin";
            this.pictureBoxOrigin.Size = new System.Drawing.Size(378, 411);
            this.pictureBoxOrigin.TabIndex = 0;
            this.pictureBoxOrigin.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "typeName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "typeIndex";
            // 
            // textBoxIndex
            // 
            this.textBoxIndex.Location = new System.Drawing.Point(106, 10);
            this.textBoxIndex.Name = "textBoxIndex";
            this.textBoxIndex.ReadOnly = true;
            this.textBoxIndex.Size = new System.Drawing.Size(100, 21);
            this.textBoxIndex.TabIndex = 5;
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(106, 38);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.ReadOnly = true;
            this.textBoxName.Size = new System.Drawing.Size(100, 21);
            this.textBoxName.TabIndex = 6;
            // 
            // textBoxTypeName
            // 
            this.textBoxTypeName.Location = new System.Drawing.Point(106, 67);
            this.textBoxTypeName.Name = "textBoxTypeName";
            this.textBoxTypeName.ReadOnly = true;
            this.textBoxTypeName.Size = new System.Drawing.Size(100, 21);
            this.textBoxTypeName.TabIndex = 7;
            // 
            // textBoxTypeIndex
            // 
            this.textBoxTypeIndex.Location = new System.Drawing.Point(106, 96);
            this.textBoxTypeIndex.Name = "textBoxTypeIndex";
            this.textBoxTypeIndex.ReadOnly = true;
            this.textBoxTypeIndex.Size = new System.Drawing.Size(100, 21);
            this.textBoxTypeIndex.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(212, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "▶";
            // 
            // textBoxTypeIndexEdit
            // 
            this.textBoxTypeIndexEdit.Location = new System.Drawing.Point(235, 96);
            this.textBoxTypeIndexEdit.Name = "textBoxTypeIndexEdit";
            this.textBoxTypeIndexEdit.Size = new System.Drawing.Size(100, 21);
            this.textBoxTypeIndexEdit.TabIndex = 10;
            this.textBoxTypeIndexEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTypeIndexEdit_KeyPress);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(346, 96);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(44, 23);
            this.buttonEdit.TabIndex = 11;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // FormSubViewEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 559);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxTypeIndexEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxTypeIndex);
            this.Controls.Add(this.textBoxTypeName);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.textBoxIndex);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBoxOrigin);
            this.Name = "FormSubViewEdit";
            this.Text = "FormSubViewEdit";
            this.Load += new System.EventHandler(this.FormSubViewEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrigin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOrigin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIndex;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxTypeName;
        private System.Windows.Forms.TextBox textBoxTypeIndex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTypeIndexEdit;
        private System.Windows.Forms.Button buttonEdit;
    }
}