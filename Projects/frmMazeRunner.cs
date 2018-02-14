using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    public partial class frmMazeRunner : Form
    {
        const int maxChunksInRow = 3;
        const int chunkWidth = 20;
        const int chunkHeight = 20;
        const int mazeWidth = 20;
        const int mazeHeight = 20;
        enum Directions
        {
            Up,
            Down,
            Left,
            RIght
        }
        Chunk[,] maze = new Chunk[mazeWidth, mazeHeight];
        Random rnd = new Random();

        public frmMazeRunner()
        {
            InitializeComponent();
            LoadChunks();
        }

        private void LoadChunks()
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    maze[x, y] = new Chunk(x * chunkWidth, y * chunkHeight, chunkWidth, chunkHeight);
                }
            }
        }
    }
}
