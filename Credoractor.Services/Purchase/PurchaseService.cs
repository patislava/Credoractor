
using System;
using System.Security.Cryptography;
using Credoractor.Models;
using Credoractor.Services;
using Credoractor.TransactionClient;

namespace Credoractor.Services.Purchase
{
    public class PurchaseService : IPurchaseService
    {
        private string stan;
        private string rrn;

        public PurchaseService()
        {
            string uniqueNumber = (new NumberGenerator() as INumberGenerator).GenerateUniqueNumber();

            StanNumberGenerator stanObj = new StanNumberGenerator();
            stan = stanObj.GenerateStan(uniqueNumber);

            RetRefNumberGenerator rrnObj = new RetRefNumberGenerator();
            rrn = rrnObj.GenerateRrn(uniqueNumber);
        }

        public Transaction MakePurchase(string testCard, string transactionAmount, string cardEntryMode,
            string terminalId, string transactionCurrency)
        {
            Transaction result = new Transaction();

            result.MessageTypeIdentifier = "200"; //Sale: Purchase Financial Messages (0200/0210)
            result.PAN = testCard;
            result.ProcessingCode = "000000"; //"00" - Goods/Services Purchase
            result.TransactionAmount = transactionAmount + "00";
            result.TransDateTime = DateTime.Now.ToString("MMddHHmmss");
            result.STAN = stan; //??????????
            result.TransactionTime = DateTime.Now.ToString("HHmmss");
            result.TransactionDate = DateTime.Now.ToString("MMdd");
            if (CardEnterMode.Ecommerce.ToString() == "Ecommerce")
            {
                cardEntryMode = "81";
                result.POSEntryMode = cardEntryMode + "0";
            }
            result.RRN = rrn; //??????????
            result.TerminalId = terminalId;
            //result.CardAcceptorId = "optional";
            //result.CardAcceptorNameLocation = "optional";
            //result.ProprieatryField46 = new TagField[] {};
            result.ProprieatryField47 = new TagField[] { new TagField("906", "5"), new TagField("909", "07"), new TagField("916", "0") }; //Hardcoded for easy scenario: ecom without 3D sec, no CVV2
            //result.ProprieatryField48 -TODO later, only for MC
            if (TransactionCurrency.EUR.ToString() == "EUR")
            {
                transactionCurrency = "978";
                result.TransactionCurrency = transactionCurrency;
            }

            return result;
        }
        ////TODO - implement through WPF custom converter on UI part, temporary solution
    }
}
