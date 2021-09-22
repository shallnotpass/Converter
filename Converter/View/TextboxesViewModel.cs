using Converter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Converter.View
{
    public class TextboxesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Exchanger Exchange;
        public string FirstCharCode { get; set; }
        public string FirstName { get; set; }
        public string SecondCharCode { get; set; }
        public string SecondName { get; set; }
        public string FirstValue
        {
            set
            {
                try
                {
                    Exchange.FirstCurrency = decimal.Parse(value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstValue)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondValue)));
                }
                catch (FormatException)
                {
                }
            }
            get
            {
                return Exchange.FirstCurrency.ToString();
            }
        }
        public string SecondValue
        {
            set
            {
                try
                {
                    Exchange.SecondCurrency = decimal.Parse(value);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FirstValue)));
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondValue)));
                }
                catch (FormatException)
                {
                }
            }
            get
            {
                    return Exchange.SecondCurrency.ToString();
            }
        }
        public void UpdateViewModel(Currency[] currenciesArray, CurrencyIndexes indexes)
        {
            this.Exchange = new Exchanger(currenciesArray, indexes);
            Currency firstCurrency = currenciesArray[indexes.Indexes[0].Index];
            this.FirstCharCode = firstCurrency.CharCode;
            this.FirstName = firstCurrency.Name;
            this.FirstValue = firstCurrency.Value.ToString();
            Currency secondCurrency = currenciesArray[indexes.Indexes[1].Index];
            this.SecondCharCode = secondCurrency.CharCode;
            this.SecondName = secondCurrency.Name;
        }

        public void UpdateExchanger(Exchanger exchanger)
        {
            this.Exchange = exchanger;
        }
    }
}
