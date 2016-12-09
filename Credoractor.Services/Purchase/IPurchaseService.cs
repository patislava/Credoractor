using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services.Purchase
{
    public interface IPurchaseService
    {
        Transaction MakePurchase(string testCard, string stan, string transactionAmount, string cardEntryMode,
            string rrn, string terminalId, string transactionCurrency);
    }
}
