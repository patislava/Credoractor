using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services
{
    public class RetRefNumberGenerator
    {
        /*
            Field DE37 
            must be unique to link the messages belonging to the same transaction into a message chain. 
            The valid value for this field is YJJJXXNNNNNN, where:
            Y is the last digit of the year, 
            JJJ is a Julian date, 
            XX is a unique interface ID assigned by OpenWay, 
            and NNNNNN is a counter unique during the day.
         */
        private int yearLastDigit;
        private string julianDate;
        private string uniqueInterfaceId;
        private string sixDigits;
        public string Rrn { get; set; }

        public string GenerateRrn(string uniqueNumber)
        {
            if (string.IsNullOrEmpty(uniqueNumber))
            {
                throw new ArgumentNullException("Unique number was not passed to create RRN.");
            }

            if (uniqueNumber.Length != 6)
            {
                var result = "Passed argument does not satisfy requirements for RRN generation.";
                return result;
            }

            yearLastDigit = DateTime.Now.Year % 10;
            
            JulianCalendar calendar = new System.Globalization.JulianCalendar();
            var today = DateTime.Today;

            julianDate = calendar.ToDateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second,
                    today.Millisecond).DayOfYear.ToString();

            uniqueInterfaceId = "00";

            sixDigits = uniqueNumber;

            Rrn = yearLastDigit + julianDate + uniqueInterfaceId + sixDigits;

            return Rrn;
        }
    }
}
