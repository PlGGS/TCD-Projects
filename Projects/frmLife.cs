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
    public partial class frmLife : Form
    {
        int gridWidth = 30;
        int gridHeight = 30;
        Cell[,] cells;
        Random rnd = new Random();

        public frmLife()
        {
            InitializeComponent();
            InitGrid();
        }

        void InitGrid()
        {
            cells = new Cell[gridWidth, gridHeight];

            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    Cell cell = new Cell();

                    cell.Location = new Point(x * 20, y * 20);
                    cell.Size = new Size(20, 20);
                    cell.TabStop = false;
                    cell.SizeMode = PictureBoxSizeMode.StretchImage;
                    cell.BorderStyle = BorderStyle.FixedSingle;
                    cell.BackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
                    cell.Visible = true;

                    cells[x, y] = cell;
                    Controls.Add(cell);
                    cell.MouseEnter += Cell_MouseEnter;
                }
            }
        }

        private void Cell_MouseEnter(object sender, EventArgs e)
        {
            Cell cell = (Cell)sender;
            cell.BackColor = Color.Green;
        }
    }
}
