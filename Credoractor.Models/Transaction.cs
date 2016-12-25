using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Credoractor.Services
{
    public class Transaction
    {
        [JsonProperty(PropertyName = "MTID")]
        public string MessageTypeIdentifier { get; set; }

        [JsonProperty(PropertyName = "DE02")]
        public string PAN { get; set; }

        [JsonProperty(PropertyName = "DE03")]
        public string ProcessingCode { get; set; }

        [JsonProperty(PropertyName = "DE04")]
        public string TransactionAmount { get; set; }

        [JsonProperty(PropertyName = "DE07")]
        public string TransDateTime { get; set; }

        [JsonProperty(PropertyName = "DE11")]
        public string STAN { get; set; }

        [JsonProperty(PropertyName = "DE12")]
        public string TransactionTime { get; set; }

        [JsonProperty(PropertyName = "DE13")]
        public string TransactionDate { get; set; }

        [JsonProperty(PropertyName = "DE22")]
        public string POSEntryMode { get; set; }

        [JsonProperty(PropertyName = "DE37")]
        public string RRN { get; set; }

        [JsonProperty(PropertyName = "DE41")]
        public string TerminalId { get; set; }

        [JsonProperty(PropertyName = "DE42")]
        public string CardAcceptorId { get; set; }

        [JsonProperty(PropertyName = "DE43")]
        public string CardAcceptorNameLocation { get; set; }

        [JsonProperty(PropertyName = "DE46")]
        public TagField[] ProprieatryField46 { get; set; }

        [JsonProperty(PropertyName = "DE47")]
        public TagField[] ProprieatryField47 { get; set; }

        [JsonProperty(PropertyName = "DE48")]
        public TagField[] ProprieatryField48 { get; set; }

        [JsonProperty(PropertyName = "DE49")]
        public string TransactionCurrency { get; set; }

        public string ConcatenateTransactionData()
        {
            var result = string.Concat(MessageTypeIdentifier, PAN, ProcessingCode, TransactionAmount, POSEntryMode, RRN, TerminalId, CardAcceptorId, CardAcceptorNameLocation, ProprieatryField46, ProprieatryField47, ProprieatryField48, TransactionCurrency);
            return result;
        }

        public override string ToString()
        {
            return ConcatenateTransactionData();
        }
    }
}
