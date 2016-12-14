using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Credoractor.Services.Tests
{
    [TestFixture, System.ComponentModel.Description("Retrival Reference Number generation tests")]
    public class RetRefNumberGeneratorTests
    {
        [Test, System.ComponentModel.Description("Null Unique Number argument")]
        public void NullUniqueNumberArgument_ReturnedArgumentNullException()
        {
            RetRefNumberGenerator rrn = new RetRefNumberGenerator();
            Assert.Throws<ArgumentNullException>(() => rrn.GenerateRrn(null));
        }

        //[Test, System.ComponentModel.Description("Null Unique Number argument")]
        //public void UniqueNumberWrongLength_ReturnedMessageError()
        //{
        //    RetRefNumberGenerator rrn = new RetRefNumberGenerator();
        //    rrn.GenerateRrn("1234567");
        //    //assert?
        //}
    }
}
