using System.Windows;
using Credoractor.Services;
using Credoractor.Services.Purchase;
using System;
using System.Linq;
using Credoractor.Services.TransactionData;
using Credoractor.TransactionClient;

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
                //Prepare RRN, STAN Numbers
                string uniqueNumber = (new NumberGenerator() as INumberGenerator).GenerateUniqueNumber();

                StanNumberGenerator stanObj = new StanNumberGenerator();
                string stan = stanObj.GenerateStan(uniqueNumber);

                RetRefNumberGenerator rrnObj = new RetRefNumberGenerator();
                string rrn = rrnObj.GenerateRrn(uniqueNumber);

                //Start transaction creation
                purchase = new PurchaseService();

                Transaction purchaseTransaction = purchase.MakePurchase(testCard.Text.Split(' ')[1], stan, transAmount.Text,
                    cardEnterMode.Text, rrn, deviceId.Text, transCurrency.Text);
                TransactionSender transactionSender = new TransactionSender(@".\transactor.exe");
                transactionSender.WriteJsonToFile(purchaseTransaction);

                //TODO - launch transactor.exe and send transaction

                MessageBox.Show("Purchase is successfully sent.");

                //TODO - use WPF custom converter
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