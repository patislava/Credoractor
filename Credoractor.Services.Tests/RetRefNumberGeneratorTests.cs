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
            Assert.Throws<System.NullReferenceException>(() => new RetRefNumberGenerator(null));
        }

        [Test, System.ComponentModel.Description("Wrong length of Unique Number argument")]
        public void UniqueNumberWrongLength_ReturnedMessageError()
        {
            var result =
            "Passed argument does not satisfy requirements for RRN generation.";

            RetRefNumberGenerator rrn = new RetRefNumberGenerator("1234567");
            Assert.AreEqual(result, rrn.GenerateUniqueNumber(DateTime.Today));
        }

        [Test, System.ComponentModel.Description("Validate RRN value")]
        public void CorrectArgumentsPassed_ReturnedCorrectRrn()
        {
            var now = DateTime.Today;
            var yearLastDigit = now.Year % 10;
            var julianDate = new System.Globalization.JulianCalendar()
                .ToDateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second,
                now.Millisecond).DayOfYear.ToString().PadLeft(3, '0');
            var uniqueInterfaceId = "00";
            var result = yearLastDigit + julianDate + uniqueInterfaceId + "123456";

            RetRefNumberGenerator rrn = new RetRefNumberGenerator("123456");
            Assert.AreEqual(result, rrn.GenerateUniqueNumber(DateTime.Today));
        }
    }
}
