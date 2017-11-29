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

        }

        private void btnConvertCtoF_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtTempF_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.D0 || e.Key == Key.NumPad0 ||
                            e.Key == Key.D1 || e.Key == Key.NumPad1 ||
                            e.Key == Key.D2 || e.Key == Key.NumPad2 ||
                            e.Key == Key.D3 || e.Key == Key.NumPad3 ||
                            e.Key == Key.D4 || e.Key == Key.NumPad4 ||
                            e.Key == Key.D5 || e.Key == Key.NumPad5 ||
                            e.Key == Key.D6 || e.Key == Key.NumPad6 ||
                            e.Key == Key.D7 || e.Key == Key.NumPad7 ||
                            e.Key == Key.D8 || e.Key == Key.NumPad8 ||
                            e.Key == Key.D9 || e.Key == Key.NumPad9)
            {
                txtTempF.Text += e.Key; //TODO see if this works
            }
        }
    }
}
