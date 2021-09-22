using Converter.Models;
using Converter.View;
using Newtonsoft.Json;
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
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Converter
{
    public sealed partial class MainPage : Page
    {
        private CurrenciesDataProvider DataProvider;
        private CurrencyIndexes TextboxIndexes;
        public MainPage()
        {
            this.InitializeComponent();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            try
            {
                this.TextboxIndexes = (CurrencyIndexes) e.Parameter;
                this.DataProvider = new CurrenciesDataProvider();
                Task readingTask = Task.Run(async () => { await this.DataProvider.GetJsonData(); this.DataProvider.InitializeProperties(); });
                readingTask.Wait();
                ShowMessage($"Дата обновления данных на сервере: {this.DataProvider.CurrenciesData["Date"]}");
            }
            catch (InvalidCastException)
            {
                string jsonData = e.Parameter.ToString();
                this.DataProvider = new CurrenciesDataProvider(jsonData);
                this.TextboxIndexes = new CurrencyIndexes();
                ShowMessage($"Дата обновления данных на сервере: {this.DataProvider.CurrenciesData["Date"]}");
            }
            catch (Exception exception)
            {
                ShowMessage(exception.Message);
            }
            this.ViewModel.UpdateViewModel(this.DataProvider.CurrenciesArray, this.TextboxIndexes);
        }

        private void ShowMessage(string message)
        {
            MessageGrid.Children.Clear();
            TextBlock textBox = new TextBlock();
            textBox.Text = message;
            textBox.HorizontalAlignment = HorizontalAlignment.Center;
            textBox.VerticalAlignment = VerticalAlignment.Top;
            textBox.Margin = new Thickness(0, 10, 0, 0);
            MessageGrid.Children.Add(textBox);
        }

        private async void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

            await DataProvider.GetJsonData(); 
            DataProvider.InitializeProperties();
            var exchange = new Exchanger(this.DataProvider.CurrenciesArray, this.TextboxIndexes);
            this.ViewModel.UpdateExchanger(exchange);
            ShowMessage($"Дата обновления данных:  {this.DataProvider.CurrenciesData["Date"]}");

        }


        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            this.TextboxIndexes.Indexes[0] = null;
            this.Frame.Navigate(typeof(ChooseCurrencyPage), this.TextboxIndexes);
        }
        private void HyperlinkButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.TextboxIndexes.Indexes[1] = null;
            this.Frame.Navigate(typeof(ChooseCurrencyPage), this.TextboxIndexes);
        }
    }
}
