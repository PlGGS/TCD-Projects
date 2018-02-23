using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Projects
{
    public partial class frmMazeRunner : Form
    {
        const int maxChunksInRow = 3;
        const int chunkWidth = 20;
        const int chunkHeight = 20;
        const int mazeWidth = 25;
        const int mazeHeight = 25;
        public enum Directions
        {
            Up,
            Down,
            Left,
            Right
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
                Console.Write("Current Chunk: ");
                currentChunk.Print();
                AddNeighbors(currentChunk);
            }
        }
        Random rnd = new Random();
        List<Tuple<Point, Point>> path = new List<Tuple<Point, Point>>();
        Point prevRunnerPos;
        Point currentRunnerPos;
        Runner runner;

        public frmMazeRunner()
        {
            InitializeComponent();
            Console.WriteLine("********Maze Runner Debug Info********");
            LoadChunks();
        }

        private void frmMazeRunner_Load(object sender, EventArgs e)
        {
            runner = new Runner(new Size(chunkWidth / 2, chunkHeight / 2), this.Left, this.Top);
            prevRunnerPos = runner.MidPosition;
            CreateMaze();
        }

        private void LoadChunks()
        {
            for (int y = 0; y < mazeHeight; y++)
            {
                for (int x = 0; x < mazeWidth; x++)
                {
                    maze[x, y] = new Chunk(x, y, chunkWidth, chunkHeight);
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
            
            while (UnvisitedChunksExist())
            {
                if (ChunkHasUnvisitedNeighbors(currentChunk))
                {
                    Directions neighborDir = RemoveNeighboringWalls(currentChunk);
                    CurrentChunk = currentChunk.Neighbors[(int)neighborDir];
                }
                else
                {
                    CurrentChunk = RandomVisitedChunk();
                }
            }
        }

        private Chunk RandomVisitedChunk()
        {
            Chunk chunk;

            do
            {
                chunk = maze[rnd.Next(0, mazeWidth), rnd.Next(0, mazeHeight)];
            } while (chunk.Visited == false);
            
            return chunk;
        }

        private bool ChunkHasUnvisitedNeighbors(Chunk chunk)
        {
            foreach (Chunk neighbor in chunk.Neighbors)
            {
                if (neighbor != null)
                {
                    if (neighbor.Visited == false)
                    {
                        Console.WriteLine($"- -Neighbor Spot{neighbor.MazeSpot}");
                        return true;
                    }
                }
            }

            return false;
        }

        private Directions RemoveNeighboringWalls(Chunk chunk)
        {
            Directions neighborDir;
            Directions chunkDir;
            Chunk neighbor;

            do
            {
                neighborDir = ChooseRandomNeighborDirection(currentChunk);
                chunkDir = GetOppositeDirection(neighborDir);
                neighbor = currentChunk.Neighbors[(int)neighborDir];
            } while (neighbor == null);

            chunk.Walls[(int)neighborDir].Built = false;
            neighbor.Walls[(int)chunkDir].Built = false;

            return neighborDir;
        }

        private Directions GetOppositeDirection(Directions dir)
        {
            if ((int)dir % 2 == 0)
            {
                dir++;
            }
            else
            {
                dir--;
            }

            return dir;
        }

        private bool UnvisitedChunksExist()
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
            try { chunk.Neighbors[0] = maze[chunk.MazeSpot.X, chunk.MazeSpot.Y - 1];
                Console.Write("Neighbor: ");
                maze[chunk.MazeSpot.X, chunk.MazeSpot.Y - 1].Print(); } catch (Exception) { }
            try { chunk.Neighbors[1] = maze[chunk.MazeSpot.X, chunk.MazeSpot.Y + 1];
                Console.Write("Neighbor: ");
                maze[chunk.MazeSpot.X, chunk.MazeSpot.Y + 1].Print(); } catch (Exception) { }
            try { chunk.Neighbors[2] = maze[chunk.MazeSpot.X - 1, chunk.MazeSpot.Y];
                Console.Write("Neighbor: ");
                maze[chunk.MazeSpot.X - 1, chunk.MazeSpot.Y].Print(); } catch (Exception) { }
            try { chunk.Neighbors[3] = maze[chunk.MazeSpot.X + 1, chunk.MazeSpot.Y];
                Console.Write("Neighbor: ");
                maze[chunk.MazeSpot.X + 1, chunk.MazeSpot.Y].Print(); } catch (Exception) { }
        }

        Directions ChooseRandomNeighborDirection(Chunk chunk)
        {
            Directions dir;

            do
            {
                dir = (Directions)rnd.Next(0, 4);
            } while (chunk.Neighbors[(int)dir] == null || chunk.Neighbors[(int)dir].Visited == true);

            Console.WriteLine($"- - -Neighbor Direction: {dir}");
            return dir;
        }

        private void frmMazeRunner_Paint(object sender, PaintEventArgs e)
        {
            foreach (Chunk chunk in maze)
            {
                bool hasDestroyedWall = false;

                foreach (Wall wall in chunk.Walls)
                {
                    if (wall.Built == false)
                    {
                        hasDestroyedWall = true;
                    }
                }

                if (hasDestroyedWall)
                {
                    chunk.Draw(e.Graphics);
                }

                if (path.Count > 0)
                {
                    e.Graphics.DrawLine(Pens.Red, path.Last<Tuple<Point, Point>>().Item1, path.Last<Tuple<Point, Point>>().Item2);

                    if (IsInWinningChunk())
                    {
                        foreach (Tuple<Point, Point> line in path)
                        {
                            e.Graphics.DrawLine(Pens.Red, line.Item1, line.Item2);
                        }
                    }
                }

                runner.Draw(e.Graphics);
            }
        }

        private void frmMazeRunner_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsInWinningChunk())
            {
                switch (e.KeyValue)
                {
                    case (int)Keys.W:
                        if (!Colliding())
                        {
                            runner.Position = new Point(runner.Position.X, runner.Position.Y - 1);
                            currentRunnerPos = runner.MidPosition;
                            this.Refresh();
                        }
                        else
                        {
                            Reset();
                        }
                        break;
                    case (int)Keys.A:
                        if (!Colliding())
                        {
                            runner.Position = new Point(runner.Position.X - 1, runner.Position.Y);
                            currentRunnerPos = runner.MidPosition;
                            this.Refresh();
                        }
                        else
                        {
                            Reset();
                        }
                        break;
                    case (int)Keys.S:
                        if (!Colliding())
                        {
                            runner.Position = new Point(runner.Position.X, runner.Position.Y + 1);
                            currentRunnerPos = runner.MidPosition;
                            this.Refresh();
                        }
                        else
                        {
                            Reset();
                        }
                        break;
                    case (int)Keys.D:
                        if (!Colliding())
                        {
                            runner.Position = new Point(runner.Position.X + 1, runner.Position.Y);
                            currentRunnerPos = runner.MidPosition;
                            this.Refresh();
                        }
                        else
                        {
                            Reset();
                        }
                        break;
                    default:
                        break;
                }
            }

            void Reset()
            {
                runner.Position = runner.StartingPos;
                path.Clear();
                this.Refresh();
            }
        }

        private bool Colliding()
        {
            foreach (Chunk chunk in maze)
            {
                foreach (Wall wall in chunk.Walls)
                {
                    if (wall.Built)
                    {
                        if (wall.Rect.IntersectsWith(runner.Rect))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private void frmMazeRunner_KeyUp(object sender, KeyEventArgs e)
        {
            Tuple<Point, Point> line = new Tuple<Point, Point>(prevRunnerPos, currentRunnerPos);
            path.Add(line);
            this.Refresh();
            prevRunnerPos = currentRunnerPos;

            if (IsInWinningChunk())
            {
                this.Refresh();
                DialogResult msgWin = MessageBox.Show("You win! Would you like to play again?", "Maze Runner", MessageBoxButtons.YesNoCancel);

                switch (msgWin)
                {
                    case DialogResult.Yes:
                        frmMazeRunner frm = new frmMazeRunner();
                        frm.Show();
                        this.Close();
                        break;
                    case DialogResult.No:
                        this.Close();
                        break;
                    case DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(path.Count);
        }

        bool IsInWinningChunk()
        {
            if (runner.Rect.IntersectsWith(maze[mazeWidth - 1, mazeHeight - 1].Rect))
            {
                return true;
            }

            return false;
        }
    }
}
