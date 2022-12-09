using AutoMapper;
using Newtonsoft.Json.Linq;
using TelegramBot.Handler.Enums;
using TelegramBot.Handler.Helpers;

namespace TelegramBot.Handler.AutoMapperProfiles
{
    public class BankCurrencyRatesProfile : Profile
    {
        public BankCurrencyRatesProfile()
        {
            CreateMap<JObject, ExchangeRate>()
                .ForMember("SaleRateNB", x => { x.MapFrom(j => (decimal)j["saleRateNB"]); })
                .ForMember("PurchaseRateNB", x => { x.MapFrom(j => (decimal)j["purchaseRateNB"]); })
                 .ForMember("SaleRate", x => { x.MapFrom(j => (decimal)j["saleRate"]); })
                .ForMember("PurchaseRate", x => { x.MapFrom(j => (decimal)j["purchaseRate"]); })
                .ForMember("Currency", x => { x.MapFrom(j => MapGrade((string)j["currency"])); }).ReverseMap();
            CreateMap<JObject, BankCurrencyRates>()
                .ForMember("ExchangeRate", x => { x.MapFrom(j => j["exchangeRate"].Cast<JObject>()); });
        }

        public static CurrencyCodes MapGrade(string currency)
        {
            return EnumHelper<CurrencyCodes>.Parse(currency);
        }
    }
}
