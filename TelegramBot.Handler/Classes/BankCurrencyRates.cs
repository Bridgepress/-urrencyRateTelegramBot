namespace TelegramBot.Handler
{
    public class BankCurrencyRates
    {
        public string Date { get; set; }
        public string Bank { get; set; }
        public double BaseCurrency { get; set; }
        public string BaseCurrencyLit { get; set; }

        public List<CurrencyData>? exchangeRate { get; set; }
    }
}
