using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        System.Net.Http.HttpClient _httpClient = new System.Net.Http.HttpClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DownloadHtml("https://www.microsoft.com/net/");
            Debug.WriteLine("Controllo restituito a ButtonClick handler...");
        }

        private async void DownloadHtml(string uri)
        {
            //IO
            try
            {
                Debug.WriteLine("Chiamo GetStringAsync...");
                myProgressBar.IsIndeterminate = true;
                string htmlString = await _httpClient.GetStringAsync(uri);

                myProgressBar.IsIndeterminate = false;
                Debug.WriteLine("GetStringAsync terminata!! Aggiorno UI...");
                myRichTextBox.AppendText(htmlString);
                Debug.WriteLine("UI aggiornata!!");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                Debug.WriteLine("Fine metodo Button_Click!");
            }
        }
    }
}
