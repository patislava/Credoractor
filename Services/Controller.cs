using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    class Controller
    {
        public TransactionData CreateMessage(string testCard, string transAmount, string cardEntryMode,
            string deviceId, string eciOne, bool? eciTwo, string transCurrency)
        {
            var result = new TransactionData();

            result.DE02 = testCard;

            result.DE03 = "000000";

            result.DE04 = transAmount;

            result.DE07 = DateTime.Now.ToString("MMddHHmmss");

            result.DE11 = "STANnumber"; //TODO

            result.DE12 = DateTime.Now.ToString("HHmmss");
            result.DE13 = DateTime.Now.ToString("MMdd");

            // depends on transaction scenario
            result.DE22 = cardEntryMode;

            result.DE37 = "RRNnumber"; //TODO

            result.DE41 = deviceId;

            //result.DE42 - TODO later, optional
            //result.DE43 - TODO later, optional

            //depends on trans scenario: eci + cvv2
            result.DE46 = eciOne;
            result.DE47 = eciTwo;
            // result.DE48 - TODo later, only for MC

            result.DE49 = transCurrency;

            return result;
        }

        public TransactionData ModifyMessage(TransactionData message)
        {
            if(message.DE22 == CardEnterMode.Ecommerce.ToString())
            message.DE22 = "810";

            if (message.DE49 == TransactionCurrency.EUR.ToString())
                message.DE49= "978";

            return message;
        }
    }
}
