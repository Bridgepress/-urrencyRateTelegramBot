namespace TelegramBot.Handler.Interfaces
{
    public interface IApiRequest
    {
        Task<BankCurrencyRates> ApiRequest(DateTime dateTime);
    }
}
