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
    public partial class frmSimon : Window
    {
        enum Outcomes
        {
            Green, 
            Red, 
            Blue, 
            Yellow,
            Buzzer
        }
        
        List<Outcomes> sequence = new List<Outcomes>();
        int colorBeingMatched = 0;

        SoundPlayer sndGreen = new SoundPlayer(Properties.Resources.tone_middle_c);
        SoundPlayer sndRed = new SoundPlayer(Properties.Resources.tone_high_a);
        SoundPlayer sndBlue = new SoundPlayer(Properties.Resources.tone_low_a);
        SoundPlayer sndYellow = new SoundPlayer(Properties.Resources.tone_middle_e);
        SoundPlayer sndBuzzer = new SoundPlayer(Properties.Resources.tone_Wrong_Guess);
        SoundPlayer sp = new SoundPlayer(Properties.Resources.Coin);

        ImageBrush imgGreenOn = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Green-On.png")));
        ImageBrush imgRedOn = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Red-On.png")));
        ImageBrush imgBlueOn = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Blue-On.png")));
        ImageBrush imgYellowOn = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Yellow-On.png")));

        ImageBrush imgGreenOff = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Green-Off.png")));
        ImageBrush imgRedOff = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Red-Off.png")));
        ImageBrush imgBlueOff = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Blue-Off.png")));
        ImageBrush imgYellowOff = new ImageBrush(new BitmapImage(new Uri(@"pack://siteoforigin:,,,/Resources/Simon-Yellow-Off.png")));

        Random rnd = new Random();

        void AddLights(int extra = 0)
        {
            int tmp = extra;

            do
            {
                sequence.Add((Outcomes)rnd.Next(0, 3));
                tmp--;
            } while (tmp > 0);
        }

        void PlaySound(Outcomes outcome)
        {
            switch (outcome)
            {
                case Outcomes.Green:
                    sndGreen.Play();
                    break;
                case Outcomes.Red:
                    sndRed.Play();
                    break;
                case Outcomes.Blue:
                    sndBlue.Play();
                    break;
                case Outcomes.Yellow:
                    sndYellow.Play();
                    break;
                case Outcomes.Buzzer:
                    sndBuzzer.Play();
                    break;
            }
        }

        void TurnLightOn(Outcomes outcome)
        {
            switch (outcome)
            {
                case Outcomes.Green:
                    imgTopLeft.Source = imgGreenOn.ImageSource;
                    break;
                case Outcomes.Red:
                    imgTopRight.Source = imgRedOn.ImageSource;
                    break;
                case Outcomes.Blue:
                    imgBotLeft.Source = imgBlueOn.ImageSource;
                    break;
                case Outcomes.Yellow:
                    imgBotRight.Source = imgYellowOn.ImageSource;
                    break;
            }
        }

        void TurnLightOff(Outcomes outcome)
        {
            switch (outcome)
            {
                case Outcomes.Green:
                    imgTopLeft.Source = imgGreenOff.ImageSource;
                    break;
                case Outcomes.Red:
                    imgTopRight.Source = imgRedOff.ImageSource;
                    break;
                case Outcomes.Blue:
                    imgBotLeft.Source = imgBlueOff.ImageSource;
                    break;
                case Outcomes.Yellow:
                    imgBotRight.Source = imgYellowOff.ImageSource;
                    break;
            }
        }

        void PreviewLight(Outcomes outcome, int milliseconds)
        {
            TurnLightOn(outcome);
            PlaySound(outcome);
            System.Threading.Thread.Sleep(milliseconds);
            TurnLightOff(outcome);
        }

        void PlaySequence()
        {
            foreach (Outcomes outcome in sequence)
            {
                PreviewLight(outcome, 500);
            }
        }

        void Restart()
        {
            sequence.Clear();
        }
        
        public frmSimon()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            sp.PlaySync();

            AddLights(2);
            PlaySequence();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Restart();
        }

        void HandleGuess(Outcomes guess)
        {
            if (sequence[colorBeingMatched] != guess)
            {
                PlaySound(Outcomes.Buzzer);
            }
            else
            {
                TurnLightOn(sequence[colorBeingMatched]);
                colorBeingMatched++;
                TurnLightOff(sequence[colorBeingMatched]);

                if (colorBeingMatched == sequence.Count)
                {
                    AddLights();
                    PlaySequence();
                }
            }
        }

        private void imgTopLeft_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HandleGuess(Outcomes.Green);
        }

        private void imgTopRight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HandleGuess(Outcomes.Red);
        }

        private void imgBotLeft_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HandleGuess(Outcomes.Blue);
        }

        private void imgBotRight_MouseUp(object sender, MouseButtonEventArgs e)
        {
            HandleGuess(Outcomes.Yellow);
        }
    }
}
