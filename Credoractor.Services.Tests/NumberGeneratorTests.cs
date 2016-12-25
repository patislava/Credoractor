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
    class NumberGeneratorTests
    {
        [Test, System.ComponentModel.Description("Correct Unique Number argument is properly returned")]
        public void correctUniqueNumberPassed_ReturnedSameStan()
        {
            Mock<INumberGenerator> mockStanGenerator = new Mock<INumberGenerator>();
            var totalSeconds = DateTime.Now.TimeOfDay.TotalSeconds.ToString();
            mockStanGenerator.Setup(m => m.GenerateUniqueNumber(DateTime.Now)).Returns(totalSeconds);
        }
    }
}
