using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Credoractor.Services.Tests
{
    [TestFixture, System.ComponentModel.Description("Stan generation tests")]
    class StanNumberGeneratorTests
    {
        [Test, System.ComponentModel.Description("Correct Unique Number argument is properly returned")]
        public void correctUniqueNumberPassed_ReturnedSameStan()
        {
            Mock<StanNumberGenerator> mockStanGenerator = new Mock<StanNumberGenerator>();
            mockStanGenerator.Setup(m => m.GenerateStan("123456")).Returns("123456");
        }
    }
}
