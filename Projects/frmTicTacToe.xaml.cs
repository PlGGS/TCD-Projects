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
        public char[,] spots = new char[3, 3];
        public int turns = 0;

        public frmTicTacToe()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Sets Labels to their corresponding place in the spots array
        /// </summary>
        void SetSpots()
        {
            spots[0, 0] = (char)lblTopLeft.Content;
            spots[1, 0] = (char)lblTop.Content;
            spots[2, 0] = (char)lblTopRight.Content;
            spots[0, 1] = (char)lblLeft.Content;
            spots[1, 1] = (char)lblMid.Content;
            spots[2, 1] = (char)lblRight.Content;
            spots[0, 2] = (char)lblBotLeft.Content;
            spots[1, 2] = (char)lblBot.Content;
            spots[2, 2] = (char)lblBotRight.Content;
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
            turns++;

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
