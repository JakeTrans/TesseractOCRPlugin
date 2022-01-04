namespace TesseractOCRPluginTester
{
    public partial class frmOCRTest : Form
    {
        private TesseractOCRPlugin.TesseractOCR TessOCR;

        public frmOCRTest()
        {
            TessOCR = new TesseractOCRPlugin.TesseractOCR("eng", TesseractOCRPlugin.TesseractOCR.Quality.High);
            InitializeComponent();
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            FileSelector.ShowDialog();
            RTBResult.Text = TessOCR.OCRimage(FileSelector.FileName);
        }
    }
}