using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    class Grid : Panel
    {
        Cell[,] cells;
        public Cell[,] Cells { get { return cells; } set { cells = value; } }

        public Grid()
        {

        }

        public  void Clear()
        {
            foreach (Cell cell in Cells)
            {
                cell.Reset();
            }
        }
    }
}
