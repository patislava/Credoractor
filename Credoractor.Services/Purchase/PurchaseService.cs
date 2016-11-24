
using System;

namespace Credoractor.Services.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        public TransactionElements MakePurchase(string testCard, string transactionAmount, string cardEntryMode,
            string terminalId, string eciOne, bool? eciTwo, string transactionCurrency)
        {
            var result = new TransactionElements();

            result.PAN = testCard;
            result.ProcessingCode = "000000";
            result.TransactionAmount = transactionAmount;
            result.TransDateTime = DateTime.Now.ToString("MMddHHmmss");
            result.STAN = "STAN number";
            result.TransactionTime = DateTime.Now.ToString("HHmmss");
            result.TransactionDate = DateTime.Now.ToString("MMdd");
            result.POSEntryMode = cardEntryMode;
            result.RRN = "RRN number";
            result.TerminalId = terminalId;
            //result.CardAcceptorId = "optional";
            //result.CardAcceptorNameLocation = "optional";
            result.ProprieatryField46 = eciOne;
            result.ProprieatryField47 = eciTwo;
            //result.ProprieatryField48 -TODO later, only for MC
            result.TransactionCurrency = transactionCurrency;

            return result;
        }

        //TODO - implement through WPF custom converter on UI part, temporary solution
        public TransactionElements ModifyMessage(TransactionElements message)

        {
            if (message.POSEntryMode == Services.TransactionData.CardEnterMode.Ecommerce.ToString()) //deal with enums
                message.POSEntryMode = "810";

            if (message.TransactionCurrency == Services.TransactionData.TransactionCurrency.EUR.ToString()) //deal with enums
                message.TransactionCurrency = "978";

            return message;
            }
        }
    }
