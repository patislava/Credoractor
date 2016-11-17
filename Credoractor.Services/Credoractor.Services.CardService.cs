using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services
{
    public class CardService 
    {
        // New solution using IEnumerable. How to deal with use of for? (line 36)
        private string cardName;
        private string cardNumber;

        public CardService()
        {
            cardName = "VISA_CLASSIC";
            cardNumber = "4123688840000000";
        }

        //public CardService(string cardName, string cardNumber)
        //{
        //    this.cardName = cardName;
        //    this.cardNumber = cardNumber;
        // }

        public IEnumerable<CardService> GetCards()
        {
            yield return new CardService(); //?? 2 arguments should be in constructor?
        }

       /*
        OLD SOLUTION
        *  //TODO: get cardsNames and pans from Excel file
       public List<string> cardNames = new List<string>(1) { "VISA_CLASSIC" , "MC CREDIT"};
       public List<string> pans = new List<string>(1) { "4123688840000000", "5266000000000008" };

       public string[] GetTestCards()
       {
           string[] testCards = new string[pans.Count];

           for (int i = 0; i < testCards.Length; i++)
           {
               testCards[i] = cardNames[i] + " " + pans[i];
           }

           return testCards;
        */
    }
}
