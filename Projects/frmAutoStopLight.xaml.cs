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
using System.Windows.Threading;

namespace Projects
{
    /// <summary>
    /// Interaction logic for AutoStopLight.xaml
    /// </summary>
    public partial class frmAutoStopLight : Window
    {
        ImageBrush lightRed = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/stoplight-red.png")));
        ImageBrush lightOrange = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/stoplight-orange.png")));
        ImageBrush lightGreen = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/stoplight-green.png")));
        sbyte bytBoi = 2;

        public frmAutoStopLight()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (bytBoi == 0)
            {
                this.Background = lightOrange;
                bytBoi = 1;
            }
            else if (bytBoi == 1)
            {
                this.Background = lightGreen;
                bytBoi = 2;
            }
            else if (bytBoi == 2)
            {
                this.Background = lightRed;
                bytBoi = 0;
            }
        }
    }
}
