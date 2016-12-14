using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services
{
    public class StanNumberGenerator
    {
        public string STAN { get; set; }

        public virtual string GenerateStan(string uniqueNumber)
        {
            STAN = uniqueNumber;
            return STAN;
        }
    }
}
