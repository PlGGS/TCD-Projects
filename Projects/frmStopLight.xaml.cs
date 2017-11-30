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
    /// Interaction logic for StopLight.xaml
    /// </summary>
    public partial class frmStopLight : Window
    {
        ImageBrush lightRed = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/stoplight-red.png")));
        ImageBrush lightOrange = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/stoplight-orange.png")));
        ImageBrush lightGreen = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/stoplight-green.png")));

        public frmStopLight()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Background == lightRed)
            {
                this.Background = lightOrange;
            }
            else if (this.Background == lightOrange)
            {
                this.Background = lightGreen;
            }
            else if (this.Background == lightGreen)
            {
                this.Background = lightRed;
            }
        }
    }
}
