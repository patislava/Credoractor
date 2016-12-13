using System.Windows;
using Credoractor.Services;
using Credoractor.Services.Purchase;
using System;
using System.Linq;
using Credoractor.TransactionClient;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.IO;
using System.Management.Automation.Runspaces;
using System.Text;

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
            //throw new ArgumentNullException("test");
            LoadCards();
        }

        private void SendButton(object sender, RoutedEventArgs e)
        {
            if (purchaseRadioButton.IsChecked == true && isReversal.IsChecked == false)
            {
            //    //Prepare RRN, STAN Numbers
            //    string uniqueNumber = (new NumberGenerator() as INumberGenerator).GenerateUniqueNumber();

            //    StanNumberGenerator stanObj = new StanNumberGenerator();
            //    string stan = stanObj.GenerateStan(uniqueNumber);

            //    RetRefNumberGenerator rrnObj = new RetRefNumberGenerator();
            //    string rrn = rrnObj.GenerateRrn(uniqueNumber);

                //Start transaction creation
                purchase = new PurchaseService();

                Transaction purchaseTransaction = purchase.MakePurchase(testCard.Text.Split(' ')[1], transAmount.Text,
                    cardEnterMode.Text, deviceId.Text, transCurrency.Text);

                TransactionSender transactionSender = new TransactionSender(@".\send_json.bat");
                transactionSender.SendTransaction(purchaseTransaction);

                //TODO - launch transactor.exe and send transaction

                string logPath =
                     @"C: \Users\isadovskaya\Desktop\Tool\Credoractor\Credoractor\bin\Release\powerShellLog.txt";
                var text = File.ReadAllText(logPath, Encoding.UTF8);

                MessageBox.Show("Test executed:\n" + text);

                // using (var fs = File.OpenRead(logPath))
                // {
                //     fs.Position = previousFileLength;
                //     string line;

                //     using (var sr = new StreamReader(fs))
                //     {
                //         while (!sr.EndOfStream)
                //         {
                //             line = sr.ReadToEnd();
                //             MessageBox.Show("Message log is: \n" + line);
                //         }
                //     }
                //     //MessageBox.Show("Message log is: \n" + line);
                // }
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