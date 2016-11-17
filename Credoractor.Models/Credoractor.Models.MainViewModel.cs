using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Models
{
    public class MainViewModel
    {
        public string PAN { get; set; }

        public string ProcessingCode { get; set; }

        public string TransactionAmount { get; set; }

        public string TransactionCurrency { get; set; }

        public string TerminalId { get; set; }

        public string CardEnterMode { get; set; }
       
        public string ECI { get; set; }

        public string CVV2 { get; set; }
    }
}
