using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Credoractor.TransactionClient.Tests
{
    [TestFixture, Description("Tests of what we are sending (json)")]
    public class PayloadTests
    {
        [Test, Description("Null payload")]
        public void NullPayloadArgument_ReturnedArgumentNullException()
        {
            TransactionSender transactionSender = new TransactionSender(@".\send_json.bat");
            Assert.Throws<System.NullReferenceException>(() => transactionSender.SendTransaction(null));
        }

        [Test, Description("Empty payload")]
        public void EmptyPayloadArgument_ReturnedArgumentException()
        {
            TransactionSender transactionSender = new TransactionSender(@".\send_json.bat");
            Assert.Throws<System.ComponentModel.Win32Exception>(() => transactionSender.SendTransaction(""));
        }
    }
}
