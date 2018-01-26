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
        public Cell[,] Cells { get { return Cells; } set { Cells = value; } }

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
