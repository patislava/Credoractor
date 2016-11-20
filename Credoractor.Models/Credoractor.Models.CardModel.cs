using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Models
{
    public class CardModel
    {
        public string CardType { get; set; }
        public string CardNumber { get; set; }

        public CardModel(string cardType, string cardNumber)
        {
            CardType = cardType;
            CardNumber = cardNumber;
        }

        public override string ToString()
        {
            return (CardType + " " + CardNumber);
        }
    }
}
