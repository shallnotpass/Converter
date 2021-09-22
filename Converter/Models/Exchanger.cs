using Converter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Converter.Models
{
    public class Exchanger
    {
        public decimal ExchangeRate { get; set; }
        private decimal firstCurrencyValue;
        private decimal secondCurrencyValue;
        public decimal FirstCurrency
        {
            set
            {
                firstCurrencyValue = value;
                secondCurrencyValue = value * ExchangeRate;
            }
            get 
            {
                return firstCurrencyValue;
            }
        }
        public decimal SecondCurrency
        {
            set
            {
                secondCurrencyValue = value;
                firstCurrencyValue = value / ExchangeRate;
            }
            get
            {
                return secondCurrencyValue;
            }
        }

        public Exchanger(Currency[] currenciesArray, CurrencyIndexes indexes)
        {
            Currency firstCurrency = currenciesArray[indexes.Indexes[0].Index];
            Currency secondCurrency = currenciesArray[indexes.Indexes[1].Index];
            this.ExchangeRate = secondCurrency.Nominal * firstCurrency.Value / (firstCurrency.Nominal * secondCurrency.Value);
        }
    }
}
