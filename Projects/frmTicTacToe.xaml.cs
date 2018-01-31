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
        public int turns = 0;

        public frmTicTacToe()
        {
            InitializeComponent();
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void TurnText()
        {
            if (p1Turn)
            {
                lblText.Content = "Player 1's turn!";
            }
            else
            {
                lblText.Content = "Player 2's turn!";
            }
        }

        private void lbl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Label lbl = (Label)sender;

            if (lbl.Content.ToString() == "")
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

            if (turns >= 5)
            {
                CheckWinner();
            }
        }

        private void CheckWinner()
        {
            //TODO check winner
        }
    }
}
