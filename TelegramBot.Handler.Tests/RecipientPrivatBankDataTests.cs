using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBot.Handler.Enums;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler.Tests
{
    [TestClass]
    public class RecipientPrivatBankDataTests
    {
        [TestMethod]
        public async Task ApiRequest()
        {
            // Arrange
            RecipientPrivatBankData recipientPrivatBankData = new RecipientPrivatBankData();
            // Act
            BankCurrencyRates bankCurrencyRates = await recipientPrivatBankData.ApiRequest(DateTime.Now);
            int countCurreny = Enum.GetNames(typeof(CurrencyCodes)).Length;
            // Assert
            Assert.AreEqual(bankCurrencyRates.ExchangeRate.Count, countCurreny);
        }
    }
}
