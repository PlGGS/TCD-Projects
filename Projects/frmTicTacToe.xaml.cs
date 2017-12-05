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

namespace Projects
{
    public partial class frmTicTacToe : Window
    {
        public bool p1Turn = true;

        public frmTicTacToe()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void TurnText()
        {
            if (p1Turn == false)
            {
                lblText.Content = "Player 2's turn!";
            }
            else
            {
                lblText.Content = "Player 1's turn!";
            }
        }

        private void lblTopLeft_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblTopLeft.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblTopLeft.Content = " X";
                }
                else
                {
                    lblTopLeft.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblTop_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblTop.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblTop.Content = " X";
                }
                else
                {
                    lblTop.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblTopRight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblTopRight.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblTopRight.Content = " X";
                }
                else
                {
                    lblTopRight.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblLeft_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblLeft.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblLeft.Content = " X";
                }
                else
                {
                    lblLeft.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblMid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblMid.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblMid.Content = " X";
                }
                else
                {
                    lblMid.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblRight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblRight.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblRight.Content = " X";
                }
                else
                {
                    lblRight.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblBotLeft_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblBotLeft.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblBotLeft.Content = " X";
                }
                else
                {
                    lblBotLeft.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblBot_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblBot.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblBot.Content = " X";
                }
                else
                {
                    lblBot.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }

        private void lblBotRight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (lblBotRight.Content.ToString() == "")
            {
                if (p1Turn)
                {
                    lblBotRight.Content = " X";
                }
                else
                {
                    lblBotRight.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }
        }
    }
}
