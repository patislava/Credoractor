using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Credoractor.Services;

namespace Credoractor.TransactionClient
{
    interface ITransactionSender
    {
        void SendTransaction(Transaction payload);
    }
}
