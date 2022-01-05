namespace TesseractOCRPluginTester
{
    public partial class frmOCRTest : Form
    {
        private TesseractOCRPlugin.TesseractOCR TessOCR;

        public frmOCRTest()
        {
            //startup of OCR
            TessOCR = new TesseractOCRPlugin.TesseractOCR("eng", TesseractOCRPlugin.TesseractOCR.Quality.High);
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            //show Dialog
            FileSelector.ShowDialog();
            //Run OCR
            RTBResult.Text = TessOCR.OCRimage(FileSelector.FileName);
        }
    }
}