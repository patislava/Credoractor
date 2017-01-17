using System;
using System.Configuration;
using Credoractor.Models;
using Credoractor.TransactionClient;
using Autofac;
using DI;

namespace Credoractor.Services.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private readonly INumberGenerator stan;
        private readonly IRetRefNumberGenerator rrn;
        private readonly ITransactionSender transSender;

        public PurchaseService(INumberGenerator stan, IRetRefNumberGenerator retRefNumber,
            ITransactionSender transSender)
        {
            this.stan = stan;
            this.rrn = retRefNumber;
            this.transSender = transSender;          
        }

        public string MakePurchase(string testCard, string transactionAmount, string cardEntryMode,
            string terminalId, string transactionCurrency)
        {
            Transaction transaction = new Transaction();

            transaction.MessageTypeIdentifier = "200"; //Sale: Purchase Financial Messages (0200/0210)
            transaction.PAN = testCard;
            transaction.ProcessingCode = "000000"; //"00" - Goods/Services Purchase
            transaction.TransactionAmount = transactionAmount + "00";
            transaction.TransDateTime = DateTime.Now.ToString("MMddHHmmss");
            transaction.STAN = stan.GenerateUniqueNumber(DateTime.Now);
            transaction.TransactionTime = DateTime.Now.ToString("HHmmss");
            transaction.TransactionDate = DateTime.Now.ToString("MMdd");
            if (CardEnterMode.Ecommerce.ToString() == "Ecommerce")
            {
                cardEntryMode = "81";
                transaction.POSEntryMode = cardEntryMode + "0";
            }
            transaction.RRN = rrn.GenerateUniqueNumber(DateTime.Today);
            transaction.TerminalId = terminalId;
            //result.CardAcceptorId = "optional";
            //result.CardAcceptorNameLocation = "optional";
            //result.ProprieatryField46 = new TagField[] {};
            transaction.ProprieatryField47 = new TagField[]
            {new TagField("906", "5"), new TagField("909", "07"), new TagField("916", "0")};
            //Hardcoded for easy scenario: ecom without 3D sec, no CVV2
            //result.ProprieatryField48 -TODO later, only for MC
            if (TransactionCurrency.EUR.ToString() == "EUR")
            {
                transactionCurrency = "978";
                transaction.TransactionCurrency = transactionCurrency;
            }

            // Convert transaction to JSON and send via transactor.exe with result collection
            //DependencyContainer.Instance.Resolve<ITransactionSender>().SendTransaction(transaction);  ----- SHOULD BE HERE?!

            transSender.SendTransaction(transaction);
            var result = transSender.GetTransactionResult();

            return result;
        }
        ////TODO - implement through WPF custom converter on UI part, temporary solution
    }
}
