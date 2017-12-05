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
    /// Interaction logic for frmMovingButton.xaml
    /// </summary>
    public partial class frmMovingButton : Window
    {
        public frmMovingButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Congrats! You got me!");
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            btnWoah.Margin = new Thickness(r.Next(0, 299 - (int)btnWoah.Width), r.Next(0, 299 - (int)btnWoah.Height), 0, 0);
        }
    }
}
