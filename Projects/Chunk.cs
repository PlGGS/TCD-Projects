using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects
{
    public class Chunk
    {
        public bool Visited = false;
        bool[] walls = new bool[4];
        public bool[] Walls { get { return walls; } set { walls = value; } }
        public Point MazeSpot { get; set; }
        public Size Size { get; set; }
        public Rectangle Rect;

        Chunk[] neighbors = new Chunk[4];
        public Chunk[] Neighbors { get { return neighbors; } set { neighbors = neighbors = value; } }

        public Chunk(int x, int y, int width, int height)
        {
            MazeSpot = new Point(x, y);
            Size = new Size(width, height);
            PlaceWalls();
        }

        void PlaceWalls()
        {
            for (int i = 0; i < walls.Length; i++)
            {
                walls[i] = true;
            }
        }

        public void Draw(Graphics g)
        {
            Rect = new Rectangle(MazeSpot, Size);
            g.FillRectangle(Brushes.DimGray, Rect);
        }
        
        public void Reset()
        {
            Visited = false;
            PlaceWalls();
            NullNeighbors();
        }

        private void NullNeighbors()
        {
            for (int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = null;
            }
        }

        public void Print()
        {
            Console.WriteLine($"MazeSpot: ({MazeSpot.X}, {MazeSpot.Y}), Visited: {Visited}, Walls: {Walls}");
        }
    }
}
