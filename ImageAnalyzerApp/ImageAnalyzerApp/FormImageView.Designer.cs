namespace ImageAnalyzerApp
{
    partial class FormImageView
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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonShowOriginRect = new System.Windows.Forms.Button();
            this.buttonToggleRect = new System.Windows.Forms.Button();
            this.textBoxCropState = new System.Windows.Forms.TextBox();
            this.buttonCopy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.Location = new System.Drawing.Point(15, 158);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(378, 418);
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseDown);
            this.pictureBoxImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxImage_MouseUp);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(13, 13);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(37, 12);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "name";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(15, 32);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.ReadOnly = true;
            this.textBoxPath.Size = new System.Drawing.Size(378, 21);
            this.textBoxPath.TabIndex = 2;
            // 
            // buttonShowOriginRect
            // 
            this.buttonShowOriginRect.Location = new System.Drawing.Point(15, 59);
            this.buttonShowOriginRect.Name = "buttonShowOriginRect";
            this.buttonShowOriginRect.Size = new System.Drawing.Size(133, 27);
            this.buttonShowOriginRect.TabIndex = 3;
            this.buttonShowOriginRect.Text = "ReturnOriginCrop";
            this.buttonShowOriginRect.UseVisualStyleBackColor = true;
            this.buttonShowOriginRect.Click += new System.EventHandler(this.buttonShowOriginRect_Click);
            // 
            // buttonToggleRect
            // 
            this.buttonToggleRect.Location = new System.Drawing.Point(15, 92);
            this.buttonToggleRect.Name = "buttonToggleRect";
            this.buttonToggleRect.Size = new System.Drawing.Size(133, 27);
            this.buttonToggleRect.TabIndex = 4;
            this.buttonToggleRect.Text = "ToggleRect";
            this.buttonToggleRect.UseVisualStyleBackColor = true;
            this.buttonToggleRect.Click += new System.EventHandler(this.buttonToggleRect_Click);
            // 
            // textBoxCropState
            // 
            this.textBoxCropState.Location = new System.Drawing.Point(186, 59);
            this.textBoxCropState.Multiline = true;
            this.textBoxCropState.Name = "textBoxCropState";
            this.textBoxCropState.ReadOnly = true;
            this.textBoxCropState.Size = new System.Drawing.Size(207, 60);
            this.textBoxCropState.TabIndex = 5;
            // 
            // buttonCopy
            // 
            this.buttonCopy.Location = new System.Drawing.Point(15, 125);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(133, 27);
            this.buttonCopy.TabIndex = 6;
            this.buttonCopy.Text = "Copy";
            this.buttonCopy.UseVisualStyleBackColor = true;
            this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
            // 
            // FormImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 593);
            this.Controls.Add(this.buttonCopy);
            this.Controls.Add(this.textBoxCropState);
            this.Controls.Add(this.buttonToggleRect);
            this.Controls.Add(this.buttonShowOriginRect);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.pictureBoxImage);
            this.Name = "FormImageView";
            this.Text = "FormImageView";
            this.Load += new System.EventHandler(this.FormImageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonShowOriginRect;
        private System.Windows.Forms.Button buttonToggleRect;
        private System.Windows.Forms.TextBox textBoxCropState;
        private System.Windows.Forms.Button buttonCopy;
    }
}