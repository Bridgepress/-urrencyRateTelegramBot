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
        [Description("Ukrainian hryvnia")]
        UAH = 980,
        [Description("Swiss franc")] 
        CHF = 756,
        [Description("Euro")]
        EUR = 978,
        [Description("Pound sterling")]
        GBP = 826,
        [Description("Polish złoty")]
        PLN = 985,
        [Description("Swedish krona (plural: kronor)")] 
        SEK = 752,
        [Description("United States dollar")]
        USD = 840,
        [Description("Gold (one troy ounce)")] 
        XAU = 959,
        [Description("Canadian dollar")]
        CAD = 124
    }
}
