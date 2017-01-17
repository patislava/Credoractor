using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credoractor.Services
{
    public interface IRetRefNumberGenerator
    {
        string GenerateUniqueNumber(DateTime now);
    }
}
