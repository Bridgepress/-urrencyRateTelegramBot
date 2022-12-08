using Moq;
using TelegramBot.Handler.Interfaces;

namespace TelegramBot.Handler.Tests
{
    [TestClass]
    public class CurrencyDataHandlerTests
    {
        [TestMethod]
        [DataRow("EUE 01.11.2022", "Currency code not supported")]
        [DataRow("EUEs 01.11.2022", "Bad request")]
        [DataRow("", "Bad request")]
        [DataRow("EUR 01.11.2022", "UAH : EUR - Sale Rate: 8, Purchase Rate: 9")]

        public async Task ErorrRequest(string testString, string expectedValue)
        {
            // Arrange
            BankCurrencyRates bankCurrencyRates = new BankCurrencyRates
            {
                Bank = "PB",
                Currency = Enums.CurrencyCodes.UAH,
                ArchiveDate = "01.11.2022",
                ExchangeRate = new List<ExchangeRate>
                {
                    new ExchangeRate
                    {
                        Currency = Enums.CurrencyCodes.EUR,
                        SaleRate = 8,
                        PurchaseRate = 9,
                        SaleRateNB = 8,
                        PurchaseRateNB = 9
                    }
                }
            };
            Mock<IApiRequest> mock = new Mock<IApiRequest>();
            mock.Setup(m => m.ApiRequest(It.IsAny<DateTime>())).Returns(Task.FromResult(bankCurrencyRates));
            CurrencyDataHandler currencyDataHandler = new CurrencyDataHandler();
            // Act
            string strResult = await currencyDataHandler.SearchEnterCurrencyData(testString, mock.Object);
            // Assert
            Assert.AreEqual(expectedValue, strResult);
        }
    }
}