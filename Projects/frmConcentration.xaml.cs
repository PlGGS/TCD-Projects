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
        ImageBrush imgBlank = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/blank.png")));
        ImageBrush imgBack = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_back.png")));
        ImageBrush imgTable = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/table_top.jpg")));
        public Dictionary<string, ImageBrush> CardTypes = new Dictionary<string, ImageBrush>
        {
            {"Coins", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_coins.png")))},
            {"Dynamite", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_dynamite.png")))},
            {"Knight", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_knight.png")))},
            {"Lamp", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_lamp.png")))},
            {"Shield", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_shield.png")))},
            {"Sword", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_sword.png")))},
            {"Torch", new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/card_torch.png")))}
        };
        Card[] cards = new Card[14];
        Card[] choices = new Card[2];
        Random rnd = new Random();

        public frmConcentration()
        {
            InitializeComponent();

            CreateDeck();
        }
        
        private void CreateDeck()
        {
            int tmpCardNum = 0;
            for (int i = 0; i < CardTypes.Count; i++)
            {
                cards[tmpCardNum++] = new Card(i);
                cards[tmpCardNum++] = new Card(i);
            }
        }

        private void FlipCard(int position)
        {
            if (!cards[position].Matched)
            {
                if (choices[0] == null)
                {
                    cards[position].SetImage();
                    choices[0] = cards[position];
                }
                else
                {
                    cards[position].SetImage();
                    choices[1] = cards[position];
                    System.Threading.Thread.Sleep(3000);
                    CheckChoices();
                }
            }
        }

        private void ShowCard(int position, Image img)
        {
            img.Source = cards[position].IMG.ImageSource;
        }

        private void HideCards()
        {
            foreach (Image img in grdCards.Children)
            {
                if (choices[1] != null)
                {
                    if (img.Source != imgBlank.ImageSource)
                    {
                        img.Source = imgBack.ImageSource;
                    }
                }

                if (img.Source != imgBack.ImageSource)
                {
                    img.Source = imgBlank.ImageSource;
                }
            }
        }
        
        private bool CardMatched(int position)
        {
            if (cards[position].Matched)
            {
                return true;
            }

            return false;
        }

        private void CheckChoices()
        {
            if (choices[0].CardType == choices[1].CardType)
            {
                for (int i = 0; i < choices.Length; i++)
                {
                    choices[i].Matched = true;
                    choices[i] = null;
                }
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
                    ShowCard(0, img);
                    HideCards();
                    break;
                case "imgCard1":
                    FlipCard(1);
                    ShowCard(1, img);
                    HideCards();
                    break;
                case "imgCard2":
                    FlipCard(2);
                    ShowCard(2, img);
                    HideCards();
                    break;
                case "imgCard3":
                    FlipCard(3);
                    ShowCard(3, img);
                    HideCards();
                    break;
                case "imgCard4":
                    FlipCard(4);
                    ShowCard(4, img);
                    HideCards();
                    break;
                case "imgCard5":
                    FlipCard(5);
                    ShowCard(5, img);
                    HideCards();
                    break;
                case "imgCard6":
                    FlipCard(6);
                    ShowCard(6, img);
                    HideCards();
                    break;
                case "imgCard7":
                    FlipCard(7);
                    ShowCard(7, img);
                    HideCards();
                    break;
                case "imgCard8":
                    FlipCard(8);
                    ShowCard(8, img);
                    HideCards();
                    break;
                case "imgCard9":
                    FlipCard(9);
                    ShowCard(9, img);
                    HideCards();
                    break;
                case "imgCard10":
                    FlipCard(10);
                    ShowCard(10, img);
                    HideCards();
                    break;
                case "imgCard11":
                    FlipCard(11);
                    ShowCard(11, img);
                    HideCards();
                    break;
                case "imgCard12":
                    FlipCard(12);
                    ShowCard(12, img);
                    HideCards();
                    break;
                case "imgCard13":
                    FlipCard(13);
                    ShowCard(13, img);
                    HideCards();
                    break;

                default:
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Image img in grdCards.Children)
            {
                img.Source = imgBack.ImageSource;
            }
        }
    }
}
