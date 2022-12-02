using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Handler.Interfaces
{
    public interface IApiRequest
    {
        Task<BankCurrencyRates?> ApiRequest(DateTime dateTime);
    }
}
