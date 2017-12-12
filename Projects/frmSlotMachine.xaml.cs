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
    /// Interaction logic for frmSlotMachine.xaml
    /// </summary>
    public partial class frmSlotMachine : Window
    {
        int coins = 10; //how many coins the player has left
        const int payOut_ = 2; //how many coins per payout

        enum rotorValues
        {
            CHERRY,
            LEMON,
            GRAPE,
            ORANGE,
            SEVEN,
            BAR,
            BELL,
            WATERMELON
        };

        //lever images
        ImageBrush imgLeverUp = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/lever.png")));
        ImageBrush imgLeverDown = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/lever-down.png")));

        //coin tray images
        ImageBrush imgCoinTrayEmpty = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/coin-tray-empty.png")));
        ImageBrush imgCoinTraySmallWin = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/coin-tray-small-win.png")));
        ImageBrush imgCoinTrayMediumWin = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/coin-tray-med-win.png")));
        ImageBrush imgCoinTrayLargeWin = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/coin-tray-big-win.png")));

        ImageBrush imgCoin = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/coin-tray-big-win.png")));

        //array of images used to make drawing easier
        ImageBrush[] symbols = new ImageBrush[]
        {
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-cherry.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-lemon.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-berry.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-grapes.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-orange.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-seven.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-bar.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-bell.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-water-melon.png")))
        };

        //our sound effects
        SoundPlayer pullSound = new SoundPlayer(Properties.Resources.Lever_Pull);
        SoundPlayer payOutSound = new SoundPlayer(Properties.Resources.payout);
        SoundPlayer beepSound = new SoundPlayer(Properties.Resources.Beep);

        int rotor1 = -1;
        int rotor2 = -1;
        int rotor3 = -1;

        //our random number generator
        Random rnd = new Random();

        public frmSlotMachine()
        {
            InitializeComponent();
            lblCoins.Content = coins.ToString();
        }

        void SpinRotors()
        {

            for (int i = 0; i < 25; i++)
            {
                rotor1 = SpinRotor(imgRotor1);
                rotor2 = SpinRotor(imgRotor2);
                rotor3 = SpinRotor(imgRotor3);
                beepSound.PlaySync();
            }
        }


        //this function takes picture box control and puts a random
        //image in it. The return value is the code for that image.
        //Assign the return value to the variable which stores the state of a 
        //particular rotor
        int SpinRotor(Image img)
        {
            int r = rnd.Next(0, 9);
            img.Source = symbols[r].ImageSource;

            return r;
        }

        //figure out how much player wins (if anything)
        void CalculatePayout()
        {
            //TODO if all three rotors are the same
            //put the coinTrayLargeWin image in the cointray picture box 
            //and call payout 3 times
            if (rotor1 == rotor2 && rotor2 == rotor3)
            {
                imgCoinTray.Source = imgCoinTrayLargeWin.ImageSource;
                PayOut();
                PayOut();
                PayOut();
            }
            else if (rotor1 == rotor2 || rotor2 == rotor3 || rotor1 == rotor3)
            {
                imgCoinTray.Source = imgCoinTrayMediumWin.ImageSource;
                PayOut();
                PayOut();
            }
            else if (rotor1 == 5 || rotor2 == 5 || rotor3 == 5)
            {
                imgCoinTray.Source = imgCoinTraySmallWin.ImageSource;
                PayOut();
            }
        }

        void PayOut()
        {
            coins += payOut_;
            payOutSound.PlaySync();
        }

        private void imgLever_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (coins <= 0)
            {
                MessageBox.Show("You're broke");
                return;
            }

            coins--;

            imgCoinTray.Source = imgCoinTrayEmpty.ImageSource;

            imgLever.Source = imgLeverDown.ImageSource;

            pullSound.PlaySync();

            imgLever.Source = imgLeverUp.ImageSource;

            SpinRotors();
            CalculatePayout();

            lblCoins.Content = coins.ToString();
        }
    }
}
