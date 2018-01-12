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
using System.Windows.Shapes;

namespace Projects
{
    public partial class frmConcentration : Window
    {
        public Dictionary<string, ImageBrush> CardTypes = new Dictionary<string, ImageBrush>
        {
            {"Blank", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/blank.png")))},
            {"Back", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_back.png")))},
            {"Coins", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_coins.png")))},
            {"Dynamite", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_dynamite.png")))},
            {"Knight", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_knight.png")))},
            {"Lamp", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_lamp.png")))},
            {"Shield", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_shield.png")))},
            {"Sword", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_sword.png")))},
            {"Torch", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_torch.png")))},
            {"Table", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/table_top.jpg")))}
        };
        Card[] cards = new Card[14];
        Card[] choices = new Card[2];
        Random rnd = new Random();

        public frmConcentration()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = new Card(rnd.Next(0, CardTypes.Count - 1)); //TODO make sure card has match
            }
        }

        private void FlipCard(int position)
        {
            if (choices[0] == null)
            {
                choices[0] = cards[position];
                cards[position].Show();
            }
            else
            {
                choices[1] = cards[position];
                cards[position].Show();
                System.Threading.Thread.Sleep(3000);
                CheckChoices();
            }
        }

        private void CheckChoices()
        {
            if (choices[0].CardType == choices[1].CardType)
            {
                foreach (Card choice in choices)
                {
                    choice.Matched = true;
                    choice.Hide();
                    //choice = null; WHY DOESNT THIS WORK
                }
                choices[0] = null; //fine
                choices[1] = null; //I'll do this
            }

            int tmpCounter = 0;
            foreach (Card card in cards)
            {
                if (card.Matched)
                {
                    tmpCounter++;
                }

                if (tmpCounter == 14)
                {
                    MessageBoxResult r = MessageBox.Show("Do you want to play again?", "Concentration", MessageBoxButton.YesNo);

                    if (r == MessageBoxResult.Yes)
                    {
                        frmConcentration frmConcentration = new frmConcentration();
                        frmConcentration.Show();
                    }
                    this.Close();
                }
            }
        }
        
        private void imgCard_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            switch (img.Name)
            {
                case "imgCard0":
                    FlipCard(0);
                    break;
                case "imgCard1":
                    FlipCard(1);
                    break;
                case "imgCard2":
                    FlipCard(2);
                    break;
                case "imgCard3":
                    FlipCard(3);
                    break;
                case "imgCard4":
                    FlipCard(4);
                    break;
                case "imgCard5":
                    FlipCard(5);
                    break;
                case "imgCard6":
                    FlipCard(6);
                    break;
                case "imgCard7":
                    FlipCard(7);
                    break;
                case "imgCard8":
                    FlipCard(8);
                    break;
                case "imgCard9":
                    FlipCard(9);
                    break;
                case "imgCard10":
                    FlipCard(10);
                    break;
                case "imgCard11":
                    FlipCard(11);
                    break;
                case "imgCard12":
                    FlipCard(12);
                    break;
                case "imgCard13":
                    FlipCard(13);
                    break;

                default:
                    break;
            }
        }
    }
}
