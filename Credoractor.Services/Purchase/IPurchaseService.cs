using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services.Purchase
{
    public interface IPurchaseService
    {
        string MakePurchase(string testCard, string transactionAmount, string cardEntryMode,
            string terminalId, string transactionCurrency);
    }
}
