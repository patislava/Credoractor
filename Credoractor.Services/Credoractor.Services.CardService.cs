using Credoractor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services
{
    public class CardService 
    {
        //public List<CardType> cardNames = new List<CardType>(1) { "VISA_CLASSIC", "MC CREDIT" };
        public List<string> pans = new List<string>(1) { "4123688840000000", "5266000000000008" };

        public IList<CardModel> GetCards()
        {
            IList<CardModel> result = new List<CardModel>();

            for (int i = 0; i < result.Count; i++)
            {
                if (pans[i].StartsWith("4"))
                {
                    result.Add(new CardModel(CardType.Visa, pans[i]));
                }
                else
                {
                    result.Add(new CardModel(CardType.MasterCard, pans[i]));
                }
            }

            return result; 
        }
    }
}
