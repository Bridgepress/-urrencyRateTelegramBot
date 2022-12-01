namespace TelegramBot.Handler
{
    public class CurrencyData
    {
        public string BaseCurrency { get; set; } = default!;
        public string Currency { get; set; } = default!;
        public double SaleRateNB { get; set; }
        public double PurchaseRateNB { get; set; }
        public double SaleRate { get; set; }
        public double PurchaseRate { get; set; }
    }
}
