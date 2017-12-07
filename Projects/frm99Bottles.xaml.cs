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
    /// Interaction logic for frm99Bottles.xaml
    /// </summary>
    public partial class frm99Bottles : Window
    {
        public frm99Bottles()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 99; i > 0; i--)
            {
                lbxBeer.Items.Add($"{i} bottles of beer on the wall.\n");
                lbxBeer.Items.Add($"{i} bottles of beer.\n");
                lbxBeer.Items.Add("Take one down, and pass it around.\n");
                lbxBeer.Items.Add($"{i - 1} bottles of beer on the wall.\n");
            }
        }
    }
}
