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
    /// Interaction logic for frmJokeGenerator.xaml
    /// </summary>
    public partial class frmJokeGenerator : Window
    {
        string[] jokes = new string[]
            {
                "Never trust atoms....they make up everything.",
                "A computer once beat me at chess, but it was \nno match for me at kick boxing.",
                "The furniture committee had several chairmen.",
                "I hate lying people, they're always in my way \nto the ocean.",
                "I want to die peacefully in my sleep, like my \ngrandfather. Not screaming and yelling like \nthe passengers in his car.",
                "I find it ironic that the colors red, white, \nand blue stand for freedom until they are \nflashing behind you.",
                "I used to think I was indecisive, but now \nI'm not too sure.",
                "Before I criticize a man, I like to walk a \nmile in his shoes. That way, when I do criticize \nhim, I'm a mile away and I have his shoes.",
                "There are three kinds of people: Those who \ncan count and those who can't.",
                "My mom said that if I don't get off my \ncomputer and do my homework she'll slam my head on the \nkeyboard, but I think she's jokinfjreoiwjrtwe4to8rkljreun8f4ny84c8y4t58lym4wthylmhawt4mylt4amlathnatyn"
            };
        Random rnd = new Random();

        public frmJokeGenerator()
        {
            InitializeComponent();
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            lblJoke.Content = jokes[rnd.Next(0, jokes.Length - 1)] + "\n\nClick anywhere for another joke!";
        }
    }
}
