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
            //try
            //{
                InitializeComponent();
            //}
            //catch (XamlParseException ex)
            //{
            //  if (ex.InnerException != null)
            //        MessageBox.Show(ex.InnerException.ToString());
            //}

            LoadCards();
        }

        private void SendButton(object sender, RoutedEventArgs e)
        {
            //try
            //{
            if (purchaseRadioButton.IsChecked == true && isReversal.IsChecked == false)
            {
                //Start transaction creation
                purchase = new PurchaseService();

                Transaction purchaseTransaction = purchase.MakePurchase(testCard.Text, transAmount.Text,
                    cardEnterMode.Text, deviceId.Text, transCurrency.Text);

                try
                {
                    TransactionSender transactionSender = new TransactionSender(ConfigurationManager.AppSettings["transactorPath"]);
                    transactionSender.SendTransaction(purchaseTransaction);
                    var result = transactionSender.GetTransactionResult();
                    MessageBox.Show("Test executed:\n" + result);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Such transaction type is not supported.");
            }
            //}
            //catch (System.ComponentModel.Win32Exception ex)
            //{
            //    if (ex.InnerException != null)
            //        MessageBox.Show(ex.InnerException.ToString());
            //}
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