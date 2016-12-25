using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Credoractor.Services
{
    class Autofac
    {
        public IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<NumberGenerator>().As<INumberGenerator>();
            return builder.Build();
        }
    }
}
