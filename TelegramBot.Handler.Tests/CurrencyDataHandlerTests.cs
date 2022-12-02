using Moq;
using Telegram.Bot;
using Telegram.Bot.Polling;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler.Tests
{
    [TestClass]
    public class CurrencyDataHandlerTests
    {  
        [TestMethod]
        [DataRow("EUE 01.11.2022", "Currency code not supported")]
        [DataRow("EUEs 01.11.2022", "Invalid input")]
        [DataRow("", "Invalid input")]

        public async Task ErorrRequest(string testString, string expectedValue)
        {
            // Arrange
            IApiRequest loaderExchangeRates = new LoaderExchangeRates();
            CurrencyDataHandler currencyDataHandler = new CurrencyDataHandler();
            // Act
            string strResult = await currencyDataHandler.SerchEnterCurrencyData(testString, loaderExchangeRates);
            // Assert
            Assert.AreEqual(expectedValue, strResult);
        }

        [TestMethod]

        public async Task CurrencyRequest()
        {
            // Arrange
            Mock<IApiRequest> mock = new Mock<IApiRequest>();
            DateTime dateTime = new DateTime(2022, 11, 01);
            mock.Setup(m => m.ApiRequest(dateTime)).ReturnsAsync((new BankCurrencyRates
            {
                Bank = "PB",
                BaseCurrency = 1,
                BaseCurrencyLit = "UAH",
                ExchangeRate = new List<CurrencyData>
                {
                    new CurrencyData
                    {
                        Currency = "EUR",
                        BaseCurrency = "UAH",
                        SaleRate = 8,
                        PurchaseRate = 9,
                        PurchaseRateNB = 9
                    }
                }
            }));
            CurrencyDataHandler currencyDataHandler = new CurrencyDataHandler();
            // Act
            string strResult = await currencyDataHandler.SerchEnterCurrencyData("EUR 01.11.2022", mock.Object);
            // Assert
            Assert.AreEqual("UAH : EUR - Sale Rate: 8, Purchase Rate: 9", strResult);
        }
    }
}