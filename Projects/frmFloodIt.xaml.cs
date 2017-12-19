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
    public partial class frmFloodIt : Window
    {
        const int rowColumnAmt = 15;
        Rectangle[,] board = new Rectangle[rowColumnAmt, rowColumnAmt];
        Random rnd = new Random();
        Brush[] colors = new SolidColorBrush[5];
        
        public frmFloodIt()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetColors();
            FillBoard();
        }

        private void SetColors()
        {
            colors[0] = new SolidColorBrush(Colors.Red);
            colors[1] = new SolidColorBrush(Colors.Blue);
            colors[3] = new SolidColorBrush(Colors.Yellow);
            colors[2] = new SolidColorBrush(Colors.Green);
            colors[4] = new SolidColorBrush(Colors.Orange);
        }

        private void FillBoard()
        {
            for (int c = 0; c < rowColumnAmt; c++)
            {
                for (int r = 0; r < rowColumnAmt; r++)
                {
                    board[c, r] = new Rectangle()
                    {
                        Margin = new Thickness(15 * c, 15 * r, 0, 0),
                        Height = 15,
                        Width = 15,
                        Fill = colors[rnd.Next(0, 5)]
                    };
                    canvas.Children.Add(board[c, r]);
                }
            }
        }

        private void FloodBoard(Color chosenColor)
        {
            Color ogColor = GetBrushColor(board[0, 0].Fill);
            bool plsBreak = false;

            for (int c = 0; c < rowColumnAmt; c++)
            {
                for (int r = 0; r < rowColumnAmt; r++)
                {
                    try
                    {
                        if (c == 0 && r == 0)
                            board[c, r].Fill = new SolidColorBrush(chosenColor);

                        if (board[c++, r].Fill != board[c, r].Fill && GetBrushColor(board[c++, r].Fill) != ogColor)
                        {
                            plsBreak = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(c);
                            board[c++, r].Fill.SetValue(SolidColorBrush.ColorProperty, chosenColor);
                            System.Threading.Thread.Sleep(50);
                        }

                        if (board[c, r++].Fill != board[c, r].Fill && GetBrushColor(board[c, r++].Fill) != ogColor)
                        {
                            plsBreak = true;
                            break;
                        }
                        else
                        {
                            Console.WriteLine(c);
                            board[c, r++].Fill.SetValue(SolidColorBrush.ColorProperty, chosenColor);
                            System.Threading.Thread.Sleep(50);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                if (plsBreak)
                {
                    break;
                }
            } //TODO replace with recursive algorithm
        }

        Color GetBrushColor(Brush brush)
        {
            return (Color)brush.GetValue(SolidColorBrush.ColorProperty);
        }
        
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            FloodBoard(Colors.Red);
        }

        private void Rectangle_MouseUp_1(object sender, MouseButtonEventArgs e)
        {
            FloodBoard(Colors.Blue);
        }

        private void Rectangle_MouseUp_2(object sender, MouseButtonEventArgs e)
        {
            FloodBoard(Colors.Yellow);
        }

        private void Rectangle_MouseUp_3(object sender, MouseButtonEventArgs e)
        {
            FloodBoard(Colors.Green);
        }

        private void Rectangle_MouseUp_4(object sender, MouseButtonEventArgs e)
        {
            FloodBoard(Colors.Orange);
        }
    }
}
