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

        public bool WallUp = true;
        public bool WallDown = true;
        public bool WallLeft = true;
        public bool WallRight = true;

        public Point MazeSpot { get; set; }
        public Size Size { get; set; }
        public Rectangle Rect;

        Chunk[] neighbors = new Chunk[4];
        public Chunk[] Neighbors { get { return neighbors; } set { neighbors = neighbors = value; } }

        public Chunk(int x, int y, int width, int height)
        {
            MazeSpot = new Point(x, y);
            Size = new Size(width, height);
        }

        public void Draw(int x, int y, int width, int height, Graphics g)
        {
            Rect = new Rectangle(new Point(x, y), new Size(width, height));
            g.FillRectangle(Brushes.DimGray, Rect);
        }
        
        public void Reset()
        {
            Visited = false;
            WallUp = true;
            WallDown = true;
            WallLeft = true;
            WallRight = true;
            Neighbors = null;
        }
    }
}
