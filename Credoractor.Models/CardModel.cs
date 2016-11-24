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
        public string CardNumber { get; set; }

        public CardModel(CardType cardType, string cardNumber)
        {
            if (CardNumber.Length <= 16 && CardNumber.Length >= 19)
            {
                throw new System.ArgumentException("Invalid card number. PAN can be 16-19 digits.");
            }

            CardType = cardType;
            CardNumber = cardNumber;
        }

        public override string ToString()
        {
            return (CardType + " " + CardNumber);
        }
    }
}
