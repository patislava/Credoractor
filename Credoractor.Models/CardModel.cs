using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Models
{
    public class CardModel
    {
        public CardType CardType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string CVV2 { get; set; }
        public string UcafIndicator { get; set; }
        public string Track2Data { get; set; }
        public string PinBlock { get; set; }
        public string ChipData { get; set; }

        public CardModel(CardType cardType, string cardNumber)
        {
            if (cardNumber.Length < 16 || cardNumber.Length > 19)
            {
                throw new System.ArgumentException("Invalid card number. PAN can be 16-19 digits.");
            }

            CardType = cardType;
            CardNumber = cardNumber;
        }

        public CardModel(string cardName, string cardNumber)
        {
            if (cardNumber.Length < 16 || cardNumber.Length > 19)
            {
                throw new System.ArgumentException("Invalid card number. PAN can be 16-19 digits.");
            }

            CardName = cardName;
            CardNumber = cardNumber;
        }

        public override string ToString()
        {
            return (CardName + " " + CardNumber);
        }
    }
}
