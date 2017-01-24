using System.Windows;
using Credoractor.Services;
using Credoractor.Services.Purchase;
using Credoractor.TransactionClient;
using DI;

namespace Credoractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //private CardService testCards = new CardService();
        private IPurchaseService purchase;
        private readonly object purchaseServiceResolution;

        public MainWindow()
        {
            InitializeComponent();
            LoadCards();
        }

        private void SendButton(object sender, RoutedEventArgs e)
        {
            if (purchaseRadioButton.IsChecked == true && isReversal.IsChecked == false)
            {
                var purchaseServiceResolution = DependencyContainer.Instance.Resolve<IPurchaseService>();

                var purchaseResult = purchaseServiceResolution.MakePurchase(testCard.Text, transAmount.Text,
                    cardEnterMode.Text, deviceId.Text, transCurrency.Text);

                MessageBox.Show("The result is: " + purchaseResult);
            }
            else
            {
                MessageBox.Show("Such transaction type is not supported.");
            }
        }

        public void LoadCards()
        {
            var testCards = DependencyContainer.Instance.Resolve<ICardServiceExcel>();
            var result = testCards.GetCardBasicInfo(".\\CardData.xlsx");

            for (int i = 0; i < result.Count; i++)
            {
                testCard.Items.Add(result[i]);
            }
        }
        //public void LoadCards()
        //{
        //    var result = testCards.GetCards();

        //    for (int i = 0; i < result.Count; i++)
        //    {
        //        testCard.Items.Add(result[i]);
        //    }
        //}
    }
}