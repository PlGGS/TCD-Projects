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
using System.Media;

namespace Projects
{
    /// <summary>
    /// Interaction logic for frmPopcorn.xaml
    /// </summary>
    public partial class frmPopcorn : Window
    {
        ImageBrush picPopped1 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Popped1.png")));
        ImageBrush picPopped2 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Popped2.png")));
        ImageBrush picPopped3 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Popped3.png")));
        ImageBrush[] IMGs;
        SoundPlayer sndPopped = new SoundPlayer(Properties.Resources.Pop);
        Random rnd = new Random();

        public frmPopcorn()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            IMGs = new ImageBrush[3];
            IMGs[0] = picPopped1;
            IMGs[1] = picPopped2;
            IMGs[2] = picPopped3;

            DispatcherTimer timPop = new DispatcherTimer();
            timPop.Interval = TimeSpan.FromMilliseconds(300);
            timPop.Tick += new EventHandler(timPop_Tick);
            timPop.Start();
        }

        private void timPop_Tick(object sender, EventArgs e)
        {
            //generate a random integer, x, between 0 and 800
            int rX = rnd.Next(0, 800);
            //generate a random integer, y, between 0 and 530
            int rY = rnd.Next(0, 530);

            int rPic = rnd.Next(0, 2);
            //use g's DrawImage function to draw a popcorn kernel image at x,y
            var popcorn = new Image();
            popcorn.Margin = new Thickness(rX, rY, 30 + rX, 30 + rY);
            popcorn.Source = IMGs[rPic].ImageSource;
            grdMain.Children.Add(popcorn);

            sndPopped.Play();
        }
    }
}
