using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    public class Chunk
    {
        public bool Visited = false;
        Wall[] _walls = new Wall[4];
        public Wall[] Walls { get { return _walls; } set { _walls = value; } }
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
            for (int i = 0; i < _walls.Length; i++)
            {
                _walls[i] = new Wall(MazeSpot, Size)
                {
                    Built = true,
                    Type = (Wall.WallTypes)i
                };
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Wall wall in Walls)
            {
                wall.Draw(g);
            }
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
            Console.WriteLine($"MazeSpot: ({MazeSpot.X}, {MazeSpot.Y}), Visited: {Visited}");

            foreach (Wall wall in _walls)
            {
                wall.Print();
            }
        }
    }
}
