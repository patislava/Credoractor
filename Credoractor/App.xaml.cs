using System.Windows;
using Credoractor.Services;
using Credoractor.Services.Purchase;
using Credoractor.TransactionClient;
using DI;

namespace Credoractor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Deal with DI for TransactionClientModule and ServicesModule
            new TransactionClientModule().Register(DependencyContainer.Instance);
            new ServicesModule().Register(DependencyContainer.Instance);
            DependencyContainer.Instance.Resolve<ITransactionSender>();
        }
    }
}
