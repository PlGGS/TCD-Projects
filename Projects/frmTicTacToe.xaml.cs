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
            if (lblTopLeft.Content.ToString() != "") spots[0, 0] = Convert.ToChar(lblTopLeft.Content.ToString().Substring(1, 1));
            if (lblTop.Content.ToString() != "") spots[1, 0] = Convert.ToChar(lblTop.Content.ToString().Substring(1, 1));
            if (lblTopRight.Content.ToString() != "") spots[2, 0] = Convert.ToChar(lblTopRight.Content.ToString().Substring(1, 1));
            if (lblLeft.Content.ToString() != "") spots[0, 1] = Convert.ToChar(lblLeft.Content.ToString().Substring(1, 1));
            if (lblMid.Content.ToString() != "") spots[1, 1] = Convert.ToChar(lblMid.Content.ToString().Substring(1, 1));
            if (lblRight.Content.ToString() != "") spots[2, 1] = Convert.ToChar(lblRight.Content.ToString().Substring(1, 1));
            if (lblBotLeft.Content.ToString() != "") spots[0, 2] = Convert.ToChar(lblBotLeft.Content.ToString().Substring(1, 1));
            if (lblBot.Content.ToString() != "") spots[1, 2] = Convert.ToChar(lblBot.Content.ToString().Substring(1, 1));
            if (lblBotRight.Content.ToString() != "") spots[2, 2] = Convert.ToChar(lblBotRight.Content.ToString().Substring(1, 1));
        }

        void PrintSpots()
        {
            foreach (char spot in spots)
            {
                Console.Write($"{spot} ");
            }

            Console.WriteLine();
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
                    lbl.Content = " X";
                }
                else
                {
                    lbl.Content = " O";
                }
                p1Turn = !p1Turn;
                TurnText();
            }

            SetSpots();
            PrintSpots();

            if (turns >= 5)
            {
                CheckWinner();
            }
        }

        private void CheckWinner()
        {
            int xCount = 0;
            int oCount = 0;
            
            void CheckCounts()
            {
                Console.WriteLine($"x: {xCount}, o: {oCount}");
                MessageBoxResult playAgain;
                void PlayAgain()
                {
                    if (playAgain == MessageBoxResult.Yes)
                    {
                        frmTicTacToe frmTicTacToe = new frmTicTacToe();
                        frmTicTacToe.Show();
                        this.Close();
                    }
                    else if (playAgain == MessageBoxResult.No)
                    {
                        this.Close();
                    }
                }

                if (xCount == 3)
                {
                    lblText.Content = "Player 1 has won!";
                    playAgain = MessageBox.Show("Player 1 has won! Would you like to play again?", "Tic Tac Toe", MessageBoxButton.YesNoCancel);
                    PlayAgain();
                }
                else if (oCount == 3)
                {
                    lblText.Content = "Player 2 has won!";
                    playAgain = MessageBox.Show("Player 2 has won! Would you like to play again?", "Tic Tac Toe", MessageBoxButton.YesNoCancel);
                    PlayAgain();
                }
                else if (turns >= 9)
                {
                    lblText.Content = "It's a cat's game!";
                    playAgain = MessageBox.Show("It's a cat's game! Would you like to play again?", "Tic Tac Toe", MessageBoxButton.YesNoCancel);
                    PlayAgain();
                }
            }

            //check rows
            Console.WriteLine($"check rows");
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    if (spots[x, y] != '\0' && spots[x, y] == 'X')
                    {
                        xCount++;
                    }

                    if (spots[x, y] != '\0' && spots[x, y] == 'O')
                    {
                        oCount++;
                    }

                    CheckCounts();
                }
                xCount = 0;
                oCount = 0;
            }
            
            //check columns
            Console.WriteLine($"check columns");
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (spots[x, y] != '\0' && spots[x, y] == 'X')
                    {
                        xCount++;
                    }

                    if (spots[x, y] != '\0' && spots[x, y] == 'O')
                    {
                        oCount++;
                    }

                    CheckCounts();
                }
                xCount = 0;
                oCount = 0;
            }

            //check topleft to botright
            Console.WriteLine($"check topleft to botright");
            for (int xy = 0; xy < 3; xy++)
            {
                if (spots[xy, xy] != '\0' && spots[xy, xy] == 'X')
                {
                    xCount++;
                }

                if (spots[xy, xy] != '\0' && spots[xy, xy] == 'O')
                {
                    oCount++;
                }

                CheckCounts();
            }
            xCount = 0;
            oCount = 0;

            //check topright to botleft
            Console.WriteLine($"check topright to botleft");
            for (int xy = 2; xy > 0; xy--)
            {
                if (spots[xy, xy] != '\0' && spots[xy, xy] == 'X')
                {
                    xCount++;
                }

                if (spots[xy, xy] != '\0' && spots[xy, xy] == 'O')
                {
                    oCount++;
                }

                CheckCounts();
            }
        }
    }
}
