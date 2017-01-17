using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using DI;

namespace Credoractor.TransactionClient
{
    public class TransactionClientModule : Module
    {
        public void Register(IDependencyContainer container)
        {
            container.Register<ITransactionSender, TransactionSender>();
        }
    }
}
