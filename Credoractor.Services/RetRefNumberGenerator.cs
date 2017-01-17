using System;

namespace Credoractor.Services
{
    public class RetRefNumberGenerator : IRetRefNumberGenerator
    {
        private readonly string uniqueNumber;

        public RetRefNumberGenerator(string uniqueNumber)
        {
            if (string.IsNullOrEmpty(uniqueNumber.ToString()))
            {
                throw new System.NullReferenceException("Unique number was not passed to create RRN.");
            }

            this.uniqueNumber = uniqueNumber;
        }

        public string GenerateUniqueNumber(DateTime now)
        {
            const string uniqueInterfaceId = "00";

            if (uniqueNumber.ToString().Length != 6)
            {
                var result = "Passed argument does not satisfy requirements for RRN generation.";
                return result;
            }

            var yearLastDigit = now.Year % 10;

            var julianDate = new System.Globalization.JulianCalendar()
                .ToDateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second,
                now.Millisecond).DayOfYear.ToString().PadLeft(3, '0'); 

            var sixDigits = uniqueNumber;

            return yearLastDigit + julianDate + uniqueInterfaceId + sixDigits;
        }

    }
}
