using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for frmTemp.xaml
    /// </summary>
    public partial class frmTemperature : Window
    {
        public frmTemperature()
        {
            InitializeComponent();
        }

        private void btnConvertFtoC_Click(object sender, RoutedEventArgs e)
        {
            lblNewTempC.Content = ((Convert.ToInt32(txtTempF.Text) - 32) * 9 / 5) + "° C";
        }

        private void btnConvertCtoF_Click(object sender, RoutedEventArgs e)
        {
            lblNcewTempF.Content = (Convert.ToInt32(txtTempC.Text) * 1.8 + 32) + "° F";
        }
        
        private void txtTempF_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]"); //TODO add negative and singular period support
        }

        private void txtTempC_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]");
        }
    }
}
