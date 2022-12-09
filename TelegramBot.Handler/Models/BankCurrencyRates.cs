using Newtonsoft.Json;
using System.Text.Json.Serialization;
using TelegramBot.Handler.Enums;

namespace TelegramBot.Handler
{
    public class BankCurrencyRates
    {
        public string ArchiveDate { get; set; } = default!;
        public string Bank { get; set; } = default!;
        public CurrencyCodes? Currency { get; set; }
        public List<ExchangeRate>? ExchangeRate { get; set; }
    }
}
