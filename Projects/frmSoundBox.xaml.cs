using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for frmSoundBox.xaml
    /// </summary>
    public partial class frmSoundBox : Window
    {
        public frmSoundBox()
        {
            InitializeComponent();
        }

        private void btnCoin_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Coin);
            player.Load();
            player.Play();
        }

        private void btnExplosion_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Explosion);
            player.Load();
            player.Play();
        }

        private void btnCarCrash_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.CarCrash);
            player.Load();
            player.Play();
        }

        private void btnPowerUp_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.PowerUp);
            player.Load();
            player.Play();
        }

        private void btnSword_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Sword_Swoosh);
            player.Load();
            player.Play();
        }

        private void btnChomp_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Chomp);
            player.Load();
            player.Play();
        }

        private void btnMarching_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Marching);
            player.Load();
            player.Play();
        }

        private void btnSiren_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Siren);
            player.Load();
            player.Play();
        }

        private void btnSplash_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Splash);
            player.Load();
            player.Play();
        }

        private void btnBalloon_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Properties.Resources.Balloon);
            player.Load();
            player.Play();
        }
    }
}
