using Credoractor.TransactionClient;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Credoractor.TransactionClient.Tests
{
  [TestFixture, Description("Tests to check launching of transator.exe")]
   public class TransactorLaunchingTests
   {

        [Test, Description("Null path")]
        public void NullPathArgument_ReturnedArgumentNullException()
        {
            Assert.Throws<ArgumentException>(() => new TransactionSender(null));
        }

        [Test, Description("Empty path")]
        public void EmptyPathArgument_ReturnedArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new TransactionSender(""));
        }

        //[Test, Description("Wrong path with no transactor.exe file")]
        //public void WrongPathArgument_ReturnedArgumentException()
        //{
        //    Assert.Throws<System.ComponentModel.Win32Exception>(() => new TransactionSender(@".\WrongFolderForTest\send_json.bat"));
        //}
    }
}
