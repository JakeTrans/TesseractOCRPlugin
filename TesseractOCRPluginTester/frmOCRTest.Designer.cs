namespace TesseractOCRPluginTester
{
    partial class frmOCRTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FileSelector = new System.Windows.Forms.OpenFileDialog();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.RTBResult = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // RTBResult
            // 
            this.RTBResult.Location = new System.Drawing.Point(12, 62);
            this.RTBResult.Name = "RTBResult";
            this.RTBResult.Size = new System.Drawing.Size(454, 226);
            this.RTBResult.TabIndex = 1;
            this.RTBResult.Text = "";
            // 
            // frmOCRTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 308);
            this.Controls.Add(this.RTBResult);
            this.Controls.Add(this.btnSelectFile);
            this.Name = "frmOCRTest";
            this.Text = "OCR Test Form";
            this.ResumeLayout(false);

        }

        #endregion

        private OpenFileDialog FileSelector;
        private Button btnSelectFile;
        private RichTextBox RTBResult;
    }
}