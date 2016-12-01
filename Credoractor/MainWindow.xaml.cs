using System.Windows;
using Credoractor.Services;
using Credoractor.Services.Purchase;
using System;
using System.Linq;
using Credoractor.Services.TransactionData;

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
            //LoadCards();
        }

        private void SendButton(object sender, RoutedEventArgs e)
        {
            if (purchaseRadioButton.IsChecked == true && isReversal.IsChecked == false)
            {
                purchase = new PurchaseService();
                // TODO - use WPF custom converter
                var purchaseBody = purchase.MakePurchase(testCard.Text.Split(' ')[1], transAmount.Text, cardEnterMode.Text, deviceId.Text,
                    eciValues.Text, hasCVV2.IsChecked, transCurrency.Text);
                purchaseBody = purchase.ModifyMessage(purchaseBody);
                MessageBox.Show("Message to be send is: " + purchaseBody);
            }   
            else
            {
                MessageBox.Show("Such transaction type is not supported.");
            }                    
        }

       // public void LoadCards()
     //   {
        //    var result = testCards.GetCards();
            /*
            for (int i = 0; i < result.Length; i++)
            {
                testCard.Items.Add(result[i]);               
            }
            */
            
        }
    }
