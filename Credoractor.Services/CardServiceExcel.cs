using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using Credoractor.Models;
using LinqToExcel;

namespace Credoractor.Services
{
    public class CardServiceExcel : ICardServiceExcel
    {
        public IList<CardModel> GetCardBasicInfo(string dataPath)
        {
            ExcelQueryFactory data = new ExcelQueryFactory(dataPath);
            if (!File.Exists(dataPath))
                return null;

            var cardName = from row in data.Worksheet<CardExcelData>("CardData")
                           where !string.IsNullOrEmpty(row.CardName)
                           select row.CardName;

            var cardNumber = from row in data.Worksheet<CardExcelData>("CardData")
                             where !string.IsNullOrEmpty(row.PAN)
                             select row.PAN;

            var expMonth = from row in data.Worksheet<CardExcelData>("CardData")                         
                           select row.ExpirationMonth;

            var expYear = from row in data.Worksheet<CardExcelData>("CardData")
                           select row.ExpirationYear;

            var cvv2 = from row in data.Worksheet<CardExcelData>("CardData")
                          select row.CVV2;

            var ucafId = from row in data.Worksheet<CardExcelData>("CardData")
                       select row.UcafIndicator;

            var track2 = from row in data.Worksheet<CardExcelData>("CardData")
                       select row.Track2Data;

            var pinBlock = from row in data.Worksheet<CardExcelData>("CardData")
                         select row.PinBlock;

            var chipData = from row in data.Worksheet<CardExcelData>("CardData")
                         select row.ChipData;

            var result = new List<CardModel>();

            var cardNumberArray = cardNumber.ToArray();
            var cardNameArray = cardName.ToArray();

            var expMonthArray = expMonth.ToArray();
            var expYearArray = expYear.ToArray();
            var cvv2Array = cvv2.ToArray();
            var ucafIdArray = ucafId.ToArray();
            var track2Array = track2.ToArray();
            var pinBlockArray = pinBlock.ToArray();
            var chipDataArray = chipData.ToArray();

            for (int i = 0; i < cardNumberArray.Count(); i++)
            {
                result.Add(new CardModel(cardNameArray[i], cardNumberArray[i], expMonthArray[i], expYearArray[i], cvv2Array[i],
                ucafIdArray[i], track2Array[i], pinBlockArray[i], chipDataArray[i]));
            }

            return result;
        }
    }
}
