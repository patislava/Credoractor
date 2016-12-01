using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services.TransactionData
{
    public class StanNumberGenerator
    {
        public string STAN { get; set; }

        public string GenerateStan()
        {
            NumberGenerator sixDigits = new NumberGenerator();

            STAN = sixDigits.GenerateUniqueNumber();

            return STAN;
        }
    }
}
