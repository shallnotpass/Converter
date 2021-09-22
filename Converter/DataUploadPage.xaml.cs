using Converter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Converter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DataUploadPage : Page
    {
        public DataUploadPage()
        {
            this.InitializeComponent();
        }

        private async void UploadButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            CurrenciesDataProvider provider = new CurrenciesDataProvider();
            await provider.GetJsonData();
            if (provider.Data != null)
            {
                this.Frame.Navigate(typeof(MainPage), provider.Data);
            }
            else
            {
                TextBlock textBox = new TextBlock();
                textBox.Text = "Данные не были получены";
                textBox.HorizontalAlignment = HorizontalAlignment.Center;
                textBox.VerticalAlignment = VerticalAlignment.Center;
                textBox.Margin = new Thickness(0,60,0,0);
                DataUploadPageGrid.Children.Add(textBox);
            }
        }
    }
}
