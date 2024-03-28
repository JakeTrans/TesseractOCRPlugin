using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System.ComponentModel;
using System.Threading.Tasks;

namespace TesseractPluginTester
{
    public partial class MainWindow : Window
    {
        private TesseractOCRPlugin.TesseractOCR TessOCR;

        public OCRResults OCRData { get; set; }

        public MainWindow()
        {
            OCRData = new OCRResults();
            InitializeComponent();
            this.DataContext = OCRData;
            TessOCR = new TesseractOCRPlugin.TesseractOCR("eng", TesseractOCRPlugin.TesseractOCR.Quality.High);

            //#if DEBUG
            //            this.AttachDevTools();
            //#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void RunOCR_Click(object sender, RoutedEventArgs e)
        {
            OCRData.OCRResulttext = TessOCR.OCRimage(OCRData.FilePath);
            OCRData.OnPropertyChanged(nameof(OCRData.OCRResulttext));
        }

        private async void Browse_Click(object sender, RoutedEventArgs e)
        {
            OCRData.FilePath = await GetFilepath();
            OCRData.OnPropertyChanged(nameof(OCRData.FilePath));
        }

        public async Task<string> GetFilepath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            // dialog.Filters.Add(new FileDialogFilter() { Name = "Text", Extensions = { "txt" } });

            string[] result = await dialog.ShowAsync(this);

            if (result != null)
            {
                string.Join(" ", "");
            }

            return string.Join(" ", result);
        }
    }

    public class OCRResults : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string? FilePath { get; set; }
        public string? OCRResulttext { get; set; }

        public void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}