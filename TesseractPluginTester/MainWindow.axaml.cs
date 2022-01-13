using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace TesseractPluginTester
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        private void RunOCR_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.Print("test");
        }

        private void Browse_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Debug.Print("test");
        }
    }
}