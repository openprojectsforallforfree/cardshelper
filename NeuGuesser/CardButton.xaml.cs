using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NeuGuesser
{
    /// <summary>
    /// Interaction logic for CardButton.xaml
    /// </summary>
    public partial class CardButton : UserControl
    {
        public MainWindow main;
        private Card _card;
        public Card Card
        {
            get
            {
                return _card;
            }
            set
            {
                _card = value;
                Update();
            }
        }



        public void Update()
        {

            label.Content = _card.GetName();
            statusTh.Content = _card.ThrownOrNotPicked.ToString();
            statusPick.Content = _card.Picked.ToString();
            // probability.Content = _card.GetProbability();
            safety.ToolTip = _card.GetProbability();
            safety.Content = _card.UnSafeToThrowIndex.ToString();
            safety.Opacity = Math.Abs(_card.UnSafeToThrowIndex);
            if (_card.UnSafeToThrowIndex < 0)
            {
                safety.Background = Brushes.Green;
            }
            else
            {
                safety.Background = Brushes.Red;
            }

        }
        public CardButton()
        {
            InitializeComponent();
        }

       

        private void label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton== MouseButton.Left)
            {
                //thrown or not picked
                _card.ThrownOrNotPicked = _card.ThrownOrNotPicked + 1;
                _card.Deck.CardIsThrownorNotPicked(_card);
              
            }
            else
            {
                //picked
                _card.Picked = _card.Picked + 1;
                _card.Deck.CardIsPicked(_card);
            }
            main.UpdateScreen();
        }
    }
}
