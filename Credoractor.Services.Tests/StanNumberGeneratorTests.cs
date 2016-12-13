using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Credoractor.Services.Tests
{
    [TestFixture, System.ComponentModel.Description("Stan generation tests")]
    class StanNumberGeneratorTests
    {
        [Test, System.ComponentModel.Description("Null Unique Number argument")]
        public void NullUniqueNumberArgument_ReturnedArgumentNullException()
        {
            StanNumberGenerator rrn = new StanNumberGenerator();
            Assert.Throws<ArgumentNullException>(() => rrn.GenerateStan(null));
        }
    }
}
