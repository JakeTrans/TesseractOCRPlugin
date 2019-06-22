using System;
using System.Windows.Forms;
using TesseractOCRPlugin;

namespace TesseractPluginTest
{
    public partial class TestingForm : Form
    {
        private TesseractOCR TessOCR;

        public TestingForm()
        {
            InitializeComponent();
            TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
        }

        private void BtnOCRThis_Click(object sender, EventArgs e)
        {
            MessageBox.Show(TessOCR.OCRimage(txtPathToOCR.Text));
        }
    }
}