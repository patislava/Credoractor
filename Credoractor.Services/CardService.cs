using Credoractor.Models;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel.Attributes;

namespace Credoractor.Services
{
    public class CardService 
    {
        public List<string> pans = new List<string>() { "4123688840000000", "5266000000000008" };

        public IList<CardModel> GetCards()
        {
            IList<CardModel> result = new List<CardModel>();

            for (int i = 0; i < pans.Count; i++)
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

        //TODO - implement reading from Excel
        //public List<CardModel> GetCardBasicInfo(string dataPath) 
        //{
        //    ExcelQueryFactory data = new ExcelQueryFactory(dataPath);
        //    if (!File.Exists(dataPath))
        //        return null;

        //    var cardName = from row in data.Worksheet<CardExcelData>("CardData")
        //                   where !string.IsNullOrEmpty(row.CardName)
        //                   select row.CardName;
        //    var cardNumber = from row in data.Worksheet<CardExcelData>("CardData")
        //                     where !string.IsNullOrEmpty(row.PAN)
        //                     select row.PAN;

        //    var result = new List<CardModel>();
        //    var cardNumberArray = cardNumber.ToArray();
        //    var cardNameArray = cardName.ToArray();          
        //    for (int i = 0; i < cardNumberArray.Length; i++)
        //    {
        //        result.Add(new CardModel(cardNameArray[i], cardNumberArray[i]));
        //    }
        //    return result;
    }
}

