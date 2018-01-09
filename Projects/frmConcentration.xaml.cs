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
        Card[] cards = new Card[14];
        Card[] choices = new Card[2];

        public frmConcentration()
        {
            InitializeComponent();
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
                    FlipCard(0); //TODO set all card info randomly on application startup
                    break;

                default:
                    break;
            }
        }
    }
}
