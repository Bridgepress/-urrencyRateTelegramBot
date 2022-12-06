using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace TelegramBot.Handler
{
    public class BankCurrencyRates
    {
        public string Date { get; set; } = default!;
        public string Bank { get; set; } = default!;
        public double BaseCurrency { get; set; }
        [JsonProperty(PropertyName = "BaseCurrencyLit")]
        public string BaseCurrencyAcronym { get; set; } = default!;
        public List<CurrencyData>? ExchangeRate { get; set; }
    }
}
