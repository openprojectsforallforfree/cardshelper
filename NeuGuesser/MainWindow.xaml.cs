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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
           
            LoadAll();
        }

        private void LoadAll()
        {
            spade.Children.Clear();
            club.Children.Clear();
            diamond.Children.Clear();
            heart.Children.Clear();
            var forColor = Brushes.Black;
            var deck = new Deck();
            int cardcount = 0;
            for (int j = 1; j <= 4; j++)
            {
                StackPanel currntPanel = new StackPanel();
                switch (j)
                {
                    case 1:
                        currntPanel = spade;
                        forColor = Brushes.Black;
                        break;
                    case 2:
                        currntPanel = club;
                        forColor = Brushes.Black;
                        break;
                    case 3:
                        currntPanel = diamond;
                        forColor = Brushes.Red;
                        break;
                    case 4:
                        currntPanel = heart;
                        forColor = Brushes.Red;
                        break;
                    default:
                        break;
                }
                for (int i = 1; i <= 13; i++)
                {
                    CardButton cb = new CardButton();
                    cb.label.Foreground = forColor;
                    cb.Card = deck.Cards[cardcount++];
                    //cb.Card.Deck = deck;
                    cb.main = this;
                    currntPanel.Children.Add(cb);
                    cardButtoms.Add(cb);
                }
            }
        }
        List<CardButton> cardButtoms = new List<CardButton>();
        public void UpdateScreen()
        {
            foreach (var item in cardButtoms)
            {
                item.Update();
            }
        }

        private void cleanclicked(object sender, RoutedEventArgs e)
        {
            LoadAll();
        }
    }
}
