using System.Windows;
using Credoractor.Services;
using Credoractor.Services.Purchase;
using System;
using System.Linq;
using Credoractor.TransactionClient;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Configuration;
using System.IO;
using System.Management.Automation.Runspaces;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Markup;
using DI;

namespace Credoractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CardService testCards = new CardService();
        private IPurchaseService purchase;

        public MainWindow()
        {
            InitializeComponent();
            LoadCards();
        }

        private void SendButton(object sender, RoutedEventArgs e)
        {
            if (purchaseRadioButton.IsChecked == true && isReversal.IsChecked == false)
            {

                // Deal with DI for TransactionClientModule and ServicesModule
                new TransactionClientModule().Register(DependencyContainer.Instance);
                new ServicesModule().Register(DependencyContainer.Instance);
                DependencyContainer.Instance.Resolve<ITransactionSender>();

                var purchaseResult = DependencyContainer.Instance.Resolve<IPurchaseService>().MakePurchase(testCard.Text, transAmount.Text,
                    cardEnterMode.Text, deviceId.Text, transCurrency.Text);

                MessageBox.Show("The result is: " + purchaseResult);

                ////Start transaction creation
                //var stan = new NumberGenerator();
                //var now = DateTime.Now;
                //var stanNumber = stan.GenerateUniqueNumber(now);
                //var rrn = new RetRefNumberGenerator(stanNumber);

                //purchase = new PurchaseService(stan, rrn);

                //Transaction purchaseTransaction = purchase.MakePurchase(testCard.Text, transAmount.Text,
                //     cardEnterMode.Text, deviceId.Text, transCurrency.Text);

                // try
                // {
                //     //TransactionSender transactionSender = new TransactionSender(ConfigurationManager.AppSettings["transactorPath"]);
                //     //transactionSender.SendTransaction(purchaseTransaction);
                //     //var result = transactionSender.GetTransactionResult();
                //     //MessageBox.Show("Test executed:\n" + result);
                // }
                // catch (Exception ex)
                // {
                //     MessageBox.Show(ex.Message);
                // }
            }
            else
            {
                MessageBox.Show("Such transaction type is not supported.");
            }
        }

        public void LoadCards()
        {
            var result = testCards.GetCards();

            for (int i = 0; i < result.Count; i++)
            {
                testCard.Items.Add(result[i]);
            }
        }
    }
}