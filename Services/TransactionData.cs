using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class TransactionData
    {
        // DE02: Primary Account Number (PAN) 
        public string DE02 { get; set; }

        // DE03: Processing code
        public string DE03 { get; set; }

        // DE04: Amount, Transaction
        public string DE04 { get; set; }

        // DE07: Transmission Date and Time
        public string DE07 { get; set; }

        // DE11: System Trace Audit Number (STAN)
        public string DE11 { get; set; }

        // DE12: Time, Local Transaction
        public string DE12 { get; set; }

        // DE13: Date, Local Transaction
        public string DE13 { get; set; }

        // DE22: Point of Service Entry Mode
        public string DE22 { get; set; }

        // DE37: Retrieval Reference Number (RRN)
        public string DE37 { get; set; }

        // DE41: Card Acceptor Terminal Identification
        public string DE41 { get; set; }

        // DE42: Card Acceptor Identification Code
        public string DE42 { get; set; }

        // DE43: Card Acceptor Name/Location
        public string DE43 { get; set; }

        // DE46: Proprietary Field 46
        public string DE46 { get; set; }

        // DE47: Proprietary Field 47
        public bool? DE47 { get; set; }

        // DE48: Proprietary Field 48
        public string DE48 { get; set; }

        // DE49: Currency Code, Transaction
        public string DE49 { get; set; }

        public override string ToString()
        {
            string message = DE02 + ", " + DE03 + ", " + DE04 + ", " + DE07 + ", " + DE11 + ", " + DE12 + ", " + DE13 + ", "
                + DE22 + ", " + DE37 + ", " + DE41 + ", " + DE46 + ", " + DE47 + ", " + DE49 + ";";
            return message;
        }
    }

    public enum CardEnterMode
    {
        Ecommerce
    }

    public enum TransactionCurrency
    {
        EUR
    }
}
