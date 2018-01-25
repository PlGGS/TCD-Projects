using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projects
{
    class Cell : PictureBox
    {
        public bool Alive { get; set; }
        public bool Populated { get; set; }

        public Cell()
        {

        }
    }
}
