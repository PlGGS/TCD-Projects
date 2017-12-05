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
    /// Interaction logic for frmTortoiseAndHare.xaml
    /// </summary>
    public partial class frmTortoiseAndHare : Window
    {
        enum GameState { Ready, Go, Racing, Done };

        GameState state = GameState.Ready;
        Random r = new Random();
        int tortoiseX;
        int hareX;

        public frmTortoiseAndHare()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
        }

        void UpdateTortoise()
        {
            tortoiseX = (int)imgTortoise.Margin.Left;
            int rnd = r.Next(0, 9);

            if (rnd <= 4)
            {
                imgTortoise.Margin = new Thickness(imgTortoise.Margin.Left + 3, imgTortoise.Margin.Top, imgTortoise.Margin.Right, imgTortoise.Margin.Bottom);
            }
            else if (rnd >= 5 && rnd <= 6)
            {
                imgTortoise.Margin = new Thickness(imgTortoise.Margin.Left - 6, imgTortoise.Margin.Top, imgTortoise.Margin.Right, imgTortoise.Margin.Bottom);
            }
            else if (rnd >= 7)
            {
                imgTortoise.Margin = new Thickness(imgTortoise.Margin.Left + 1, imgTortoise.Margin.Top, imgTortoise.Margin.Right, imgTortoise.Margin.Bottom);
            }
            
            if (tortoiseX < 0)
            {
                imgTortoise.Margin = new Thickness(0, imgTortoise.Margin.Top, imgTortoise.Margin.Right, imgTortoise.Margin.Bottom);
            }
        }

        void UpdateHare()
        {
            hareX = (int)imgHare.Margin.Left;
            int rnd = r.Next(0, 9);

            if (rnd <= 4)
            {
                imgHare.Margin = new Thickness(imgHare.Margin.Left + 3, imgHare.Margin.Top, imgHare.Margin.Right, imgHare.Margin.Bottom);
            }
            else if (rnd >= 5 && rnd <= 6)
            {
                imgHare.Margin = new Thickness(imgHare.Margin.Left - 6, imgHare.Margin.Top, imgHare.Margin.Right, imgHare.Margin.Bottom);
            }
            else if (rnd >= 7)
            {
                imgHare.Margin = new Thickness(imgHare.Margin.Left + 1, imgHare.Margin.Top, imgHare.Margin.Right, imgHare.Margin.Bottom);
            }

            if (hareX < 0)
            {
                imgHare.Margin = new Thickness(0, imgHare.Margin.Top, imgHare.Margin.Right, imgHare.Margin.Bottom);
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (state == GameState.Ready)
            {
                lblGameState.Content = "Go!";
                state = GameState.Racing;
            }
            else if (state == GameState.Racing)
            {
                UpdateTortoise();
                UpdateHare();

                if (imgTortoise.Margin.Left == imgHare.Margin.Left)
                {
                    lblGameState.Content = "Ouch!";
                    imgHare.Margin = new Thickness(imgHare.Margin.Left - 2, imgHare.Margin.Top, imgHare.Margin.Right, imgHare.Margin.Bottom);
                }
                else
                {
                    lblGameState.Content = "";
                }
                
                if (imgTortoise.Margin.Left >= 850) //I don't like 70
                {
                    state = GameState.Done;
                    MessageBox.Show("The winner is the tortoise!");
                }

                if (imgHare.Margin.Left >= 850) //I don't like 70
                {
                    state = GameState.Done;
                    MessageBox.Show("The winner is the hare!");
                }
            }
        }
    }
}
