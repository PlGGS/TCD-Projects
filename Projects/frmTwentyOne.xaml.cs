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
    public partial class frmTwentyOne : Window
    {
        ImageBrush brushDie1 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/die-1.png")));
        ImageBrush brushDie2 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/die-2.png")));
        ImageBrush brushDie3 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/die-3.png")));
        ImageBrush brushDie4 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/die-4.png")));
        ImageBrush brushDie5 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/die-5.png")));
        ImageBrush brushDie6 = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/die-6.png")));

        int playerTotal;
        int cpuTotal;
        int playerWins = 0;
        int cpuWins = 0;
        Random rnd = new Random();
        
        public frmTwentyOne()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            playerTotal = 0;
            cpuTotal = 0;
            lblDiePlayer.Content = "Player";
            lblDieCPU.Content = "CPU";
            imgDiePlayer.Source = brushDie1.ImageSource;
            imgDieCPU.Source = brushDie1.ImageSource;
        }

        private void SetImage(Image img)
        {
            int tmpR = rnd.Next(0, 5);

            if (img.Equals(imgDiePlayer))
            {
                playerTotal += tmpR;
                lblDiePlayer.Content = "Player: " + ++playerTotal;
            }
            else if (img.Equals(imgDieCPU))
            {
                cpuTotal += tmpR;
                lblDieCPU.Content = "CPU: " + ++cpuTotal;
            }

            switch (tmpR)
            {
                case 0:
                    img.Source = brushDie1.ImageSource;
                    break;
                case 1:
                    img.Source = brushDie2.ImageSource;
                    break;
                case 2:
                    img.Source = brushDie3.ImageSource;
                    break;
                case 3:
                    img.Source = brushDie4.ImageSource;
                    break;
                case 4:
                    img.Source = brushDie5.ImageSource;
                    break;
                case 5:
                    img.Source = brushDie6.ImageSource;
                    break;
            }
        }

        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            SetImage(imgDiePlayer);
            SetImage(imgDieCPU);

            if (playerTotal >= 21 && cpuTotal >= 21)
            {
                MessageBox.Show("It's a tie!");
                Reset();
            }
            else if (playerTotal >= 21)
            {
                MessageBox.Show("Player wins!");
                playerWins += 1;
                lblWinsPlayer.Content = "Wins: " + playerWins;
                Reset();
            }
            else if (cpuTotal >= 21)
            {
                MessageBox.Show("CPU wins!");
                cpuWins += 1;
                lblWinsCPU.Content = "Wins: " + cpuWins;
                Reset();
            }
        }
    }
}
