using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TelegramBot.Handler.Enums
{
    public enum CurrencyCodes
    {
        [Description("UAH - Ukrainian hryvnia")]
        UAH = 980,
        [Description("CHF - Swiss franc")] 
        CHF = 756,
        [Description("EUR - Euro")]
        EUR = 978,
        [Description("GBP - Pound sterling")]
        GBP = 826,
        [Description("PLN - Polish złoty")]
        PLZ = 985,
        [Description("SEK - Swedish krona (plural: kronor)")] 
        SEK = 752,
        [Description("USD - United States dollar")]
        USD = 840,
        [Description("XAU - Gold (one troy ounce)")] 
        XAU = 959,
        [Description("Canadian dollar")]
        CAD = 124
    }
}
