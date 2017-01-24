using Autofac;
using DI;
using Credoractor.Services.Purchase;

namespace Credoractor.Services
{
    public class ServicesModule : Module
    {
        public void Register(IDependencyContainer container)
        {
            container.Register<ICardServiceExcel, CardServiceExcel>();

            container.Register<INumberGenerator, NumberGenerator>();
            container.Register<IRetRefNumberGenerator, RetRefNumberGenerator>();

            container.Register<IPurchaseService, PurchaseService>();
        }
    }
}
