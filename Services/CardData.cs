using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ModelCardData
    {
        //TODO: get cardsNames and pans from Excel file
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
        }
    }
}
 