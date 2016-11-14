using System.Windows;
using Services;

namespace Credoractor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModelCardData testCards = new ModelCardData();
        private Controller controller;

        public MainWindow()
        {
            InitializeComponent();
            LoadCards();
        }


        private void SendButton(object sender, RoutedEventArgs e)
        {
            if ((bool)purchaseRadioButton.IsChecked && !(bool)isReversal.IsChecked)
            {
                controller = new Controller();
                var message = controller.CreateMessage(testCard.Text.Split(' ')[1], transAmount.Text, cardEnterMode.Text, deviceId.Text, 
                    eciValues.Text, hasCVV2.IsChecked, transCurrency.Text);
                message = controller.ModifyMessage(message);
                MessageBox.Show("Message to be send is: " + message);
            }
            else
                MessageBox.Show("Such transaction type is not supported.");
        }

        public void LoadCards()
        {
            var result = testCards.GetTestCards();

            for (int i = 0; i < result.Length; i++)
            {
                testCard.Items.Add(result[i]);               
            }
        }
    }
}
