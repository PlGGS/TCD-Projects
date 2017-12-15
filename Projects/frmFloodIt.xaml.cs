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

        public frmFloodIt()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillBoard();
        }

        private void FillBoard()
        {
            for (int c = 0; c < rowColumnAmt; c++)
            {
                for (int r = 0; r < rowColumnAmt; r++)
                {
                    board[c, r] = new Rectangle();
                    board[c, r].Margin = new Thickness(15 * c, 15 * r, 0, 0);
                    board[c, r].Height = 15;
                    board[c, r].Width = 15;
                    board[c, r].Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255), (byte)rnd.Next(0, 255)));
                    canvas.Children.Add(board[c, r]);
                }
            }
        }
    }
}
