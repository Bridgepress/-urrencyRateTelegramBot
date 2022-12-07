using TelegramBot.Handler.Enums;

namespace TelegramBot.Handler
{
    public class ExchangeRate
    {   
        public double SaleRateNB { get; set; }
        public double PurchaseRateNB { get; set; }
        public double SaleRate { get; set; }
        public double PurchaseRate { get; set; }
        public CurrencyCodes Currency { get; set; }
    }
}
