namespace TesseractPluginTest
{
    partial class TestingForm
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
            this.txtPathToOCR = new System.Windows.Forms.TextBox();
            this.btnOCRThis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Path";
            // 
            // txtPathToOCR
            // 
            this.txtPathToOCR.Location = new System.Drawing.Point(81, 0);
            this.txtPathToOCR.Name = "txtPathToOCR";
            this.txtPathToOCR.Size = new System.Drawing.Size(549, 22);
            this.txtPathToOCR.TabIndex = 1;
            // 
            // btnOCRThis
            // 
            this.btnOCRThis.Location = new System.Drawing.Point(490, 28);
            this.btnOCRThis.Name = "btnOCRThis";
            this.btnOCRThis.Size = new System.Drawing.Size(140, 23);
            this.btnOCRThis.TabIndex = 2;
            this.btnOCRThis.Text = "OCR This File";
            this.btnOCRThis.UseVisualStyleBackColor = true;
            this.btnOCRThis.Click += new System.EventHandler(this.BtnOCRThis_Click);
            // 
            // TestingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 70);
            this.Controls.Add(this.btnOCRThis);
            this.Controls.Add(this.txtPathToOCR);
            this.Controls.Add(this.label1);
            this.Name = "TestingForm";
            this.Text = "OCR Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPathToOCR;
        private System.Windows.Forms.Button btnOCRThis;
    }
}