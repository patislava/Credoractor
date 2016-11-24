using System;

namespace Credoractor.Services
{
    public class TransactionElements
    {
        // DE02
        public string PAN { get; set; }

        // DE03
        public string ProcessingCode { get; set; }

        // DE04
        public string TransactionAmount { get; set; }

        // DE07
        public string TransDateTime { get; set; }

        // DE11
        public string STAN { get; set; }

        // DE12
        public string TransactionTime { get; set; }

        // DE13
        public string TransactionDate { get; set; }

        // DE22
        public string POSEntryMode { get; set; }

        // DE37
        public string RRN { get; set; }

        // DE41
        public string TerminalId { get; set; }

        // DE42
        public string CardAcceptorId { get; set; }

        // DE43
        public string CardAcceptorNameLocation { get; set; }

        // DE46
        public string ProprieatryField46 { get; set; }

        // DE47
        public bool? ProprieatryField47 { get; set; }

        // DE48
        public string ProprieatryField48 { get; set; }

        // DE49
        public string TransactionCurrency { get; set; }

        public string ConcatenateTransactionData()
        {
            var result = string.Concat(PAN, ProcessingCode, TransactionAmount, POSEntryMode, RRN, TerminalId, CardAcceptorId, CardAcceptorNameLocation, ProprieatryField46, ProprieatryField47, ProprieatryField48, TransactionCurrency);
            return result;
        }
    }
}
