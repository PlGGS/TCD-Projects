using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    class Cell : Panel
    {
        public bool Alive { get; set; }
        public Point GridSpot { get; set; }
        Cell[] neighbors = new Cell[8];
        public Cell[] Neighbors { get { return neighbors; } set { neighbors = neighbors = value; } }

        public Cell(bool alive)
        {
            Alive = alive;

            for (int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = null;
            }
        }
    }
}
