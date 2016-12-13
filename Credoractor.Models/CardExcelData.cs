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
        [ExcelColumn("Name")]
        public string CardName { get; set; }

        [ExcelColumn("PAN")]
        public string PAN { get; set; }

        [ExcelColumn("ExpMonth")]
        public string ExpirationMonth { get; set; }

        [ExcelColumn("ExpYear")]
        public string ExpirationYear { get; set; }

        [ExcelColumn("CVV2")]
        public string CVV2 { get; set; }

        [ExcelColumn("UCAF")]
        public string UcafIndicator { get; set; }

        [ExcelColumn("TRACK2")]
        public string Track2Data { get; set; }

        [ExcelColumn("PIN_BLOCK")]
        public string PinBlock { get; set; }

        [ExcelColumn("ChipData")]
        public string ChipData { get; set; }
    }
}
