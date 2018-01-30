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
        public bool OnDeathRow { get; set; }
        public bool GonnaSpawn { get; set; }

        public Cell(bool alive)
        {
            Alive = alive;
            OnDeathRow = false;
            GonnaSpawn = false;

            for (int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = null;
            }
        }

        public void Reset()
        {
            Alive = false;
            OnDeathRow = false;
            GonnaSpawn = false;
            BackColor = Color.White;

            for (int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = null;
            }
        }
    }
}
