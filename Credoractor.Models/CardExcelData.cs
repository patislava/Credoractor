using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToExcel;
using LinqToExcel.Attributes;

namespace Credoractor.Models
{
    public class CardExcelData
    {
        [ExcelColumn("CardName")]
        public string CardName { get; set; }

        [ExcelColumn("PAN")]
        public string PAN { get; set; }

        [ExcelColumn("ExpirationMonth")]
        public string ExpirationMonth { get; set; }

        [ExcelColumn("ExpirationYear")]
        public string ExpirationYear { get; set; }

        [ExcelColumn("CVV2")]
        public string CVV2 { get; set; }

        [ExcelColumn("UcafIndicator")]
        public string UcafIndicator { get; set; }

        [ExcelColumn("Track2Data")]
        public string Track2Data { get; set; }

        [ExcelColumn("PinBlock")]
        public string PinBlock { get; set; }

        [ExcelColumn("ChipData")]
        public string ChipData { get; set; }
    }
}
