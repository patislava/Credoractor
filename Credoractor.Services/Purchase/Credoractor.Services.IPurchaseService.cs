using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services.Purchase
{
    public interface IPurchaseService
    {
        TransactionData MakePurchase(string pan, string transactionAmount, string cardEntryMode,
            string terminalId, string eciOne, bool? eciTwo, string transactionCurrency);

        TransactionData ModifyMessage(TransactionData message);
    }
}
