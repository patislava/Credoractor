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
    class PayloadTests
    {
        [Test, Description("Null payload")]
        public void NullPathArgument_ReturnedArgumentNullException()
        {
            TransactionSender transactionSender = new TransactionSender(".\\transactor.exe");
            Assert.Throws<ArgumentException>(() => transactionSender.SendTransaction(null));
        }

        [Test, Description("Empty payload")]
        public void EmptyPathArgument_ReturnedArgumentException()
        {
            TransactionSender transactionSender = new TransactionSender(".\\transactor.exe");
            Assert.Throws<ArgumentException>(() => transactionSender.SendTransaction(""));
        }

        //[Test, Description("Invalid payload")]
        //TODO: check JSON - element by element? TBD
    }
}
