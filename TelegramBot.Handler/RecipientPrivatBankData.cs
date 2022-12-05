using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Handler
{
    public class RecipientPrivatBankData : BaseRecipientOfBankData
    {
        private readonly string _url = "https://api.privatbank.ua/p24api/";

        public RecipientPrivatBankData()
        {
            _httpClient.BaseAddress = new Uri(_url);
        }
    }
}
