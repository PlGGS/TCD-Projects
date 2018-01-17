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
    /// Interaction logic for frmWumpus.xaml
    /// </summary>
    public partial class frmWumpus : Window
    {
        int currentRoom = 0; //the index of the room the player is in
        Room[] rooms = new Room[20]; //the rooms in the caves 

        public void Run()
        {

            //TODO: Put your name here
            WriteLine("Welcome to Hunt the Wumpus.");
            WriteLine("C# WPF version by Blake Boris.");
            WriteLine("");

            while (true)
            {
                //TODO Write the main game loop using the flowchart in the PDF

            }
        }

        /// <summary>
        /// Initializes the room connections
        /// </summary>
        /// <param name="room"></param>
        /// <param name="neighbor1"></param>
        /// <param name="neighbor2"></param>
        /// <param name="neighbor3"></param>
        public void SetNeighbors(int room, int neighbor1, int neighbor2, int neighbor3)
        {
            rooms[room].neighbors[0] = rooms[neighbor1];
            rooms[room].neighbors[1] = rooms[neighbor2];
            rooms[room].neighbors[2] = rooms[neighbor3];
        }

        /// <summary>
        /// Creates the names and initial connections
        /// </summary>
        public void SetupRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                rooms[i] = new Room(this);
                rooms[i].name = i.ToString(); ;
            }

            SetNeighbors(1, 2, 5, 8);
            SetNeighbors(2, 1, 3, 10);
            SetNeighbors(3, 2, 4, 12);
            SetNeighbors(4, 3, 5, 14);
            SetNeighbors(5, 1, 4, 6);
            SetNeighbors(6, 5, 7, 15);
            SetNeighbors(7, 6, 8, 17);
            SetNeighbors(8, 1, 7, 9);
            SetNeighbors(9, 8, 10, 18);
            SetNeighbors(10, 2, 9, 11);
            SetNeighbors(11, 10, 12, 19);
            SetNeighbors(12, 3, 11, 13);
            SetNeighbors(13, 12, 14, 20);
            SetNeighbors(14, 4, 13, 15);
            SetNeighbors(15, 6, 14, 16);
            SetNeighbors(16, 15, 17, 20);
            SetNeighbors(17, 7, 18, 18);
            SetNeighbors(18, 9, 17, 19);
            SetNeighbors(19, 11, 18, 20);
            SetNeighbors(20, 13, 16, 19);

        }

        /// <summary>
        /// Clears all the rooms
        /// Then repositions the bats,pits,wumpus,and player
        /// </summary>
        void ResetGame()
        {
            Random rand = new Random();
            int r;

            for (int i = 0; i < rooms.Length; i++)
            {
                rooms[i].Reset();
            }

            rooms[rand.Next(0, 19)].hasWumpus = true;
            rooms[rand.Next(0, 19)].hasPit = true;
            rooms[rand.Next(0, 19)].hasPit = true;
            rooms[rand.Next(0, 19)].hasBats = true;
            rooms[rand.Next(0, 19)].hasBats = true;

            do
            {
                r = rand.Next(0, 19);
                currentRoom = r;
            } while (rooms[r].hasWumpus || rooms[r].hasPit);
        }

        /// <summary>
        /// Reads a char from the console
        /// If not char is entered, ' ' is returned
        /// </summary>
        /// <returns></returns>
        char ReadChar()
        {
            string s = Console.ReadLine();
            if (s.Length > 0)
            {
                return s[0];
            }
            return ' ';
        }

        /// <summary>
        /// Reads an integer from the console
        /// If the input is not a valid it, -1 is returned
        /// </summary>
        /// <returns></returns>
        int ReadInt()
        {
            Console.WriteLine("Which room?");

            string s = Console.ReadLine();
            try
            {
                return Convert.ToInt32(s);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Moves the player into newRoom
        /// </summary>
        /// <param name="newRoom"></param>
        void Move(int newRoom)
        {
            if (rooms[newRoom].hasWumpus)
            {
                WriteLine("Oh no! You've been eaten by the wild Carso- I mean Wumpus!");
                //TODO play again messagebox?
            }
            else if (rooms[newRoom].hasPit)
            {
                WriteLine("fall or something blah do this later")
            }
        }

        void Shoot(int r)
        {
            //TODO Complete this function based on the flowchart in the PDF


        }

        /// <summary>
        /// Returns true if room r is a neighbor of the current room
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        bool IsNeighbor(int r)
        {

            for (int i = 0; i < 3; i++)
            {
                int val = Convert.ToInt32(rooms[currentRoom].neighbors[i].name);

                if (val == r)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// This function dumps the rooms to the console
        /// for testing/debugging
        /// </summary>
        void DumpGame()
        {
            for (int i = 1; i < rooms.Length; i++)
            {
                Console.Write("Room " + i + ":");
                if (rooms[i].hasBats)
                    Console.Write(" bats");
                if (rooms[i].hasPit)
                    Console.Write(" pit");
                if (rooms[i].hasWumpus)
                    Console.Write(" wumpus");
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Asks the player 
        /// </summary>
        void PlayAgain()
        {
            //TODO - ask the player to play again
            //if the answer is 'y' call ResetGame()
            //otherwise, call Environment.Exit(0);

        }

        public frmWumpus()
        {
            InitializeComponent();
        }

        public void ScrollToBottom()
        {
            lbxGameText.ScrollIntoView(lbxGameText.Items[lbxGameText.Items.Count - 1]);
        }

        public void WriteLine(string text)
        {
            lbxGameText.Items.Add(text);
            ScrollToBottom();
        }

        public void Write(string text)
        {
            lbxGameText.Items.Add(text);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetupRooms();
            ResetGame();
        }
    }
}
