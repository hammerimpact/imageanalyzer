namespace ImageAnalyzerApp
{
    partial class FormTypeEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIndex = new System.Windows.Forms.TextBox();
            this.textBoxTypeName = new System.Windows.Forms.TextBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.buttonIndexPrev = new System.Windows.Forms.Button();
            this.buttonIndexNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "index";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "typeName";
            // 
            // textBoxIndex
            // 
            this.textBoxIndex.Location = new System.Drawing.Point(99, 10);
            this.textBoxIndex.Name = "textBoxIndex";
            this.textBoxIndex.ReadOnly = true;
            this.textBoxIndex.Size = new System.Drawing.Size(166, 21);
            this.textBoxIndex.TabIndex = 2;
            // 
            // textBoxTypeName
            // 
            this.textBoxTypeName.Location = new System.Drawing.Point(99, 42);
            this.textBoxTypeName.Name = "textBoxTypeName";
            this.textBoxTypeName.Size = new System.Drawing.Size(166, 21);
            this.textBoxTypeName.TabIndex = 3;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(294, 39);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(99, 24);
            this.buttonEdit.TabIndex = 4;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(15, 77);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(378, 411);
            this.pictureBoxImage.TabIndex = 5;
            this.pictureBoxImage.TabStop = false;
            // 
            // buttonIndexPrev
            // 
            this.buttonIndexPrev.Location = new System.Drawing.Point(294, 10);
            this.buttonIndexPrev.Name = "buttonIndexPrev";
            this.buttonIndexPrev.Size = new System.Drawing.Size(37, 23);
            this.buttonIndexPrev.TabIndex = 6;
            this.buttonIndexPrev.Text = "◀";
            this.buttonIndexPrev.UseVisualStyleBackColor = true;
            this.buttonIndexPrev.Click += new System.EventHandler(this.buttonIndexPrev_Click);
            // 
            // buttonIndexNext
            // 
            this.buttonIndexNext.Location = new System.Drawing.Point(356, 10);
            this.buttonIndexNext.Name = "buttonIndexNext";
            this.buttonIndexNext.Size = new System.Drawing.Size(37, 23);
            this.buttonIndexNext.TabIndex = 7;
            this.buttonIndexNext.Text = "▶";
            this.buttonIndexNext.UseVisualStyleBackColor = true;
            this.buttonIndexNext.Click += new System.EventHandler(this.buttonIndexNext_Click);
            // 
            // FormTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 500);
            this.Controls.Add(this.buttonIndexNext);
            this.Controls.Add(this.buttonIndexPrev);
            this.Controls.Add(this.pictureBoxImage);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.textBoxTypeName);
            this.Controls.Add(this.textBoxIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormTypeEdit";
            this.Text = "FormTypeEdit";
            this.Load += new System.EventHandler(this.FormTypeEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIndex;
        private System.Windows.Forms.TextBox textBoxTypeName;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Button buttonIndexPrev;
        private System.Windows.Forms.Button buttonIndexNext;
    }
}