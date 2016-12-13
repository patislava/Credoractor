using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Credoractor.Services.Tests
{
    [TestFixture, System.ComponentModel.Description("Retrival Reference Number generation tests")]
    public class Class1
    {
        [Test, System.ComponentModel.Description("Null Unique Number argument")]
        public void NullPayloadArgument_ReturnedArgumentNullException()
        {
            RetRefNumberGenerator rrn = new RetRefNumberGenerator();        
            Assert.Throws<System.ComponentModel.Win32Exception>(() => rrn.GenerateRrn(null)); //think about exception type
        }
    }
}
