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
    /// <summary>
    /// Interaction logic for frmNested.xaml
    /// </summary>
    public partial class frmNested : Window
    {
        public frmNested()
        {
            InitializeComponent();
        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {
            txbMain.Text = "";

            for (int i = 0; i < 10; i++)
            {
                for (int o = 0; o < 10; o++)
                {
                    txbMain.Text += "B";
                }
                txbMain.Text += "\n";
            }
        }

        private void btnTriangle1_Click(object sender, RoutedEventArgs e)
        {
            txbMain.Text = "";

            for (int i = 10; i > 0; i--)
            {
                for (int o = 0; o < i; o++)
                {
                    txbMain.Text += "B";
                }
                txbMain.Text += "\n";
            }
        }

        private void btnTriangle2_Click(object sender, RoutedEventArgs e)
        {
            txbMain.Text = "";

            for (int i = 10; i > 0; i--)
            {
                for (int s = 10; s > i; s--)
                {
                    txbMain.Text += " ";
                }

                for (int b = 0; b < i; b++)
                {
                    txbMain.Text += "B";
                }
                txbMain.Text += "\n";
            }
        }

        private void btnTriangle3_Click(object sender, RoutedEventArgs e)
        {
            txbMain.Text = "";

            for (int i = 10; i > 0; i--)
            {
                for (int s = 10; s > i; s--)
                {
                    txbMain.Text += "  ";
                }

                for (int b = 0; b < i; b++)
                {
                    txbMain.Text += "B";
                }
                txbMain.Text += "\n";
            }
        }
    }
}
