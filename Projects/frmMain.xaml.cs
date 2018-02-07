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

        private void btn99Bottles_Click(object sender, RoutedEventArgs e)
        {
            frm99Bottles frm99Bottles = new frm99Bottles();
            frm99Bottles.Show();
        }
        
        private void btnSlotMachine_Click(object sender, RoutedEventArgs e)
        {
            frmSlotMachine frmSlotMachine = new frmSlotMachine();
            frmSlotMachine.Show();
        }

        private void btnJokeGenerator_Click(object sender, RoutedEventArgs e)
        {
            frmJokeGenerator frmJokeGenerator = new frmJokeGenerator();
            frmJokeGenerator.Show();
        }

        private void btnFibonacci_Click(object sender, RoutedEventArgs e)
        {
            frmFibonacci frmFibonacci = new frmFibonacci();
            frmFibonacci.Show();
        }

        private void btnSimon_Click(object sender, RoutedEventArgs e)
        {
            frmSimon frmSimon = new frmSimon();
            frmSimon.Show();
        }

        private void btnFloodIt_Click(object sender, RoutedEventArgs e)
        {
            frmFloodIt frmFloodIt = new frmFloodIt();
            frmFloodIt.Show();
        }

        private void btnConcentration_Click(object sender, RoutedEventArgs e)
        {
            frmConcentration frmConcentration = new frmConcentration();
            frmConcentration.Show();
        }

        private void btnWumpus_Click(object sender, RoutedEventArgs e)
        {
            frmWumpus frmWumpus = new frmWumpus();
            frmWumpus.Show();
        }

        private void btnLife_Click(object sender, RoutedEventArgs e)
        {
            frmLife frmLife = new frmLife();
            frmLife.Show();
        }

        private void btnPopcorn_Click(object sender, RoutedEventArgs e)
        {
            frmPopcorn frmPopcorn = new frmPopcorn();
            frmPopcorn.Show();
        }
    }
}
