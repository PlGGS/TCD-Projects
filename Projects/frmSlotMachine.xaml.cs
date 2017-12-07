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
        ImageBrush imgLever = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/lever.png")));
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
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-grape.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-orange.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-seven.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-bar.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-bell.png"))),
            new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/slot-machine-watermelon.png")))
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
            coinsTextBox.Text = coins.ToString();
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

            //TODO otherwise...if two rotors are the same, 
            //put the coin tray medium win image 
            //in the coinTrayPictureBox and call payout 2 times    


            //TODO otherwise...if any of the rotors is a SEVEN, 
            //put the coinTraySmallWin image in the cointray picture box 
            //and call payout once


        }

        void Payout()
        {
            coins += PAY_OUT;
            payoutSound.PlaySync();
            coinTrayPictureBox.Refresh();
        }

        private void imgLever_MouseUp(object sender, MouseButtonEventArgs e)
        {
            //TODO If coins is less than or equal to 0, 
            //display a MessageBox that says "You're broke" and 
            //call return to stop processing.



            //TODO Subtract 1 from coins


            //TODO Set the image property of the coin tray picture box to the 'empty' image



            //TODO Set the lever's picture box to the lever Down image


            //TODO - Call leverPictureBox's Refresh() function


            //TODO call the pullSound's PlaySync() function


            //TODO Set the lever's picture box to the lever up image


            //TODO - Call leverPictureBox's Refresh() function


            //TODO call SpinRotors function



            //TODO call CalculatePayout function


            //leave this alone    
            coinsTextBox.Text = coins.ToString();
        }
    }
}
