using Converter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
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
    public sealed partial class ChooseCurrencyPage : Page
    {
        private CurrencyIndexes TextboxIndexes { get; set;}
        public ChooseCurrencyPage()
        {
            this.InitializeComponent();
            CurrenciesDataProvider provider = new CurrenciesDataProvider();
            Task readingTask = Task.Run(async () => { await provider.GetJsonData(); provider.InitializeProperties(); });
            readingTask.Wait();
            СurrenciesList.ItemsSource = provider.CurrenciesArray;
        }

        private void СurrenciesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = СurrenciesList.SelectedIndex;
            if (TextboxIndexes.Indexes[0] == null)
            {
                TextboxIndexes.Indexes[0] = new CurrencyIndex { Index = index, TextboxIndex = 0 };
            }
            else
            {
                TextboxIndexes.Indexes[1] = new CurrencyIndex { Index = index, TextboxIndex = 1 };
            }
            this.Frame.Navigate(typeof(MainPage), TextboxIndexes);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.TextboxIndexes = (CurrencyIndexes)e.Parameter;
        }
    }
}
