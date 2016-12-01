using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services.TransactionData
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
        public int YearLastDigit { get; set; }
        public string JulianDate { get; set; }
        public string UniqueInterfaceId { get; set; }
        public string SixDigits { get; set; }
        public string RRN { get; set; }

        public string GenerateRRN()
        {
            YearLastDigit = DateTime.Now.Year % 10;
            
            JulianCalendar calendar = new System.Globalization.JulianCalendar();
            var today = DateTime.Today;
            var dateInJulian = calendar.ToDateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second, today.Millisecond);
            JulianDate = string.Format("{0}", dateInJulian.DayOfYear);

            UniqueInterfaceId = "00";

            NumberGenerator sixDigits = new NumberGenerator();

            SixDigits = sixDigits.GenerateUniqueNumber();

            RRN = YearLastDigit + JulianDate + UniqueInterfaceId + SixDigits;

            return RRN;
        }
    }
}
