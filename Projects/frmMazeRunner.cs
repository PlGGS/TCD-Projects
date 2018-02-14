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
        Chunk currentChunk; //TODO reminder to always use public setter for this boi
        public Chunk CurrentChunk
        {
            get
            {
                return currentChunk;
            }
            set
            {
                currentChunk = value;
                currentChunk.Visited = true;
                AddNeighbors(currentChunk);
            }
        }
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

        void Reset()
        {
            foreach (Chunk chunk in maze)
            {
                chunk.Reset();
            }
        }

        public void CreateMaze()
        {
            Reset();
            CurrentChunk = maze[0, 0];

            while (UnvisitedCellsExist())
            {

            }
        }

        private bool UnvisitedCellsExist()
        {
            foreach (Chunk chunk in maze)
            {
                if (chunk.Visited == false)
                {
                    return true;
                }
            }

            return false;
        }

        private void AddNeighbors(Chunk chunk)
        {
            try { chunk.Neighbors[0] = maze[chunk.MazeSpot.X - 1, chunk.MazeSpot.Y - 1]; } catch (Exception) { }
            try { chunk.Neighbors[1] = maze[chunk.MazeSpot.X, chunk.MazeSpot.Y - 1]; } catch (Exception) { }
            try { chunk.Neighbors[2] = maze[chunk.MazeSpot.X + 1, chunk.MazeSpot.Y - 1]; } catch (Exception) { }
            try { chunk.Neighbors[3] = maze[chunk.MazeSpot.X - 1, chunk.MazeSpot.Y]; } catch (Exception) { }
            try { chunk.Neighbors[4] = maze[chunk.MazeSpot.X + 1, chunk.MazeSpot.Y]; } catch (Exception) { }
            try { chunk.Neighbors[5] = maze[chunk.MazeSpot.X - 1, chunk.MazeSpot.Y + 1]; } catch (Exception) { }
            try { chunk.Neighbors[6] = maze[chunk.MazeSpot.X, chunk.MazeSpot.Y + 1]; } catch (Exception) { }
            try { chunk.Neighbors[7] = maze[chunk.MazeSpot.X + 1, chunk.MazeSpot.Y + 1]; } catch (Exception) { }
        }

        void ChooseRandomNeighbor(Chunk chunk)
        {
            //TODO generate random number for chunk neighbor
        }

        private void frmMazeRunner_Load(object sender, EventArgs e)
        {

        }
    }
}
