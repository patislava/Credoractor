using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services.Purchase
{
    public interface IPurchaseService
    {
        TransactionElements MakePurchase(string pan, string transactionAmount, string cardEntryMode,
            string terminalId, string eciOne, bool? eciTwo, string transactionCurrency);

        TransactionElements ModifyMessage(TransactionElements message); //to be removed
    }
}
