using Converter.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Models
{
    public class CurrenciesDataProvider : ICurrenciesDataProvider
    {
        public string Data {get; private set;}
        public Dictionary<string, object> CurrenciesData { get; set;}
        public Currency [] CurrenciesArray { get; private set; }
        private Currency RubCurrency = new Currency { CharCode = "RUB", Nominal = 1, Name = "Российский рубль", Value = 1 };
        public CurrenciesDataProvider()
        {

        }
        public CurrenciesDataProvider(string jsonData)
        {
            this.Data = jsonData;
            InitializeProperties();
        }

        public void InitializeProperties()
        {
            this.CurrenciesData = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, object>>(this.Data);
            var currenciesDictionaryString = this.CurrenciesData["Valute"].ToString();
            Dictionary<string, Currency> CurrenciesDictionary = JsonConvert.DeserializeObject<Dictionary<string, Currency>>(currenciesDictionaryString);
            CurrenciesDictionary.Add("RUB", RubCurrency);
            this.CurrenciesArray = CurrenciesDictionary.Select(x => x.Value).ToArray();
        }

        public async Task<string> GetJsonData()
        {
            string ConnectionString = @"https://www.cbr-xml-daily.ru/daily_json.js";
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(ConnectionString))
                {
                    using (var content = response.Content)
                    {
                        this.Data = await content.ReadAsStringAsync();
                        return this.Data;
                    }
                }
            }

        }
    }
}
