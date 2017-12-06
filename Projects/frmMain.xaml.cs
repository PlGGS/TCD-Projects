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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projects
{
    public partial class frmMain : Window
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi there!", "Blake's TCD Projects");
        }

        private void btnTemperature_Click(object sender, RoutedEventArgs e)
        {
            frmTemperature frmTemp = new frmTemperature();
            frmTemp.Show();
        }

        private void btnStoplight_Click(object sender, RoutedEventArgs e)
        {
            frmStopLight frmStopLight = new frmStopLight();
            frmStopLight.Show();
        }

        private void btnAutoStopLight_Click(object sender, RoutedEventArgs e)
        {
            frmAutoStopLight frmAutoStopLight = new frmAutoStopLight();
            frmAutoStopLight.Show();
        }

        private void btnTicTacToe_Click(object sender, RoutedEventArgs e)
        {
            frmTicTacToe frmTicTacToe = new frmTicTacToe();
            frmTicTacToe.Show();
        }

        private void btnMovingButton_Click(object sender, RoutedEventArgs e)
        {
            frmMovingButton frmMovingButton = new frmMovingButton();
            frmMovingButton.Show();
        }

        private void TortoiseAndHare_Click(object sender, RoutedEventArgs e)
        {
            frmTortoiseAndHare frmTortoiseAndHare = new frmTortoiseAndHare();
            frmTortoiseAndHare.Show();
        }

        private void btnTwentyOne_Click(object sender, RoutedEventArgs e)
        {
            frmTwentyOne frmTwentyOne = new frmTwentyOne();
            frmTwentyOne.Show();
        }

        private void btnSoundBox_Click(object sender, RoutedEventArgs e)
        {
            frmSoundBox frmSoundBox = new frmSoundBox();
            frmSoundBox.Show();
        }
    }
}
