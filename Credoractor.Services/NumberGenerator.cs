using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services
{
    public class NumberGenerator : INumberGenerator
    {
        public int lastUsedSecond;
        public int lastDigit = 0;

        public string GenerateUniqueNumber(DateTime now) 
        {
            int passedSeconds = (int) now.TimeOfDay.TotalSeconds;
            string uniqueNumber;

            if (passedSeconds == lastUsedSecond)
            {
                lastDigit++;
            }

            //To compare and check if there were two unique numbers generated per second.
            lastUsedSecond = passedSeconds;

            uniqueNumber = (passedSeconds.ToString().PadLeft(5, '0') + lastDigit);

            return uniqueNumber;
        }
    }
}
