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
        int gridWidth = 60;
        int gridHeight = 60;
        int cellWidth = 10;
        int cellHeight = 10;
        Cell[,] cells;
        List<Cell> aliveCells = new List<Cell>();
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
                    Cell cell = new Cell(false);

                    cell.Location = new Point(x * cellWidth, y * cellHeight);
                    cell.GridSpot = new Point(x, y);
                    cell.Size = new Size(cellWidth, cellHeight);
                    cell.TabStop = false;
                    cell.SizeMode = PictureBoxSizeMode.StretchImage;
                    cell.BorderStyle = BorderStyle.FixedSingle;
                    cell.BackColor = Color.White;
                    cell.Visible = true;

                    cells[x, y] = cell;
                    Controls.Add(cell);
                    cell.MouseUp += Cell_MouseUp;
                }
            }
        }

        private void timStep_Tick(object sender, EventArgs e)
        {
            Step();
        }

        void Step()
        {
            foreach (Cell cell in cells)
            {
                if (cell.Alive)
                {
                    aliveCells.Add(cell);
                }
            }

            for (int i = 0; i < aliveCells.Count; i++)
            {
                AddNeighbors(aliveCells[i]);
                CheckNeighborsOfAliveCell(aliveCells[i]);
                RemoveAliveCellsFromList();
            }
        }

        void ClearGrid()
        {
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    Controls.Remove(cells[x, y]);
                    cells[x, y] = new Cell(false);
                }
            }

            InitGrid();
        }
        
        void RemoveAliveCellsFromList()
        {
            for (int i = 0; i < aliveCells.Count; i++)
            {
                if (aliveCells[i].Alive == false)
                {
                    aliveCells.Remove(aliveCells[i]);
                }
            }
        }

        private void AddNeighbors(Cell cell)
        {
            try { cell.Neighbors[0] = cells[cell.GridSpot.X - 1, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[1] = cells[cell.GridSpot.X, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[2] = cells[cell.GridSpot.X + 1, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[3] = cells[cell.GridSpot.X - 1, cell.GridSpot.Y]; } catch (Exception) { }
            try { cell.Neighbors[4] = cells[cell.GridSpot.X + 1, cell.GridSpot.Y]; } catch (Exception) { }
            try { cell.Neighbors[5] = cells[cell.GridSpot.X - 1, cell.GridSpot.Y + 1]; } catch (Exception) { }
            try { cell.Neighbors[6] = cells[cell.GridSpot.X, cell.GridSpot.Y + 1]; } catch (Exception) { }
            try { cell.Neighbors[7] = cells[cell.GridSpot.X + 1, cell.GridSpot.Y + 1]; } catch (Exception) { }
        }

        void CheckNeighborsOfAliveCell(Cell cell)
        {
            int aliveNeighbors = 0;

            for (int i = 0; i < cell.Neighbors.Length; i++)
            {
                if (cell.Neighbors[i] != null)
                {
                    if (cell.Neighbors[i].Alive)
                    {
                        aliveNeighbors++;
                    }
                    else
                    {
                        AddNeighbors(cell);
                        CheckNeighborsOfDeadCell(cell.Neighbors[i]);
                    }
                    Console.WriteLine($"{i}: {cell.Neighbors[i].Alive}");
                }
            }

            Console.WriteLine($"Alive Neighbors: {aliveNeighbors}");
            Console.WriteLine();

            if (aliveNeighbors < 2)
            {
                cell.Alive = false;
                cell.BackColor = Color.LightBlue; //Represents previously alive cell
            }
            else if (aliveNeighbors > 3)
            {
                cell.Alive = false;
                cell.BackColor = Color.LightBlue; //Represents previously alive cell
            }
        }

        private void CheckNeighborsOfDeadCell(Cell cell)
        {
            int aliveNeighbors = 0;

            for (int i = 0; i < cell.Neighbors.Length; i++)
            {
                try
                {
                    if (cell.Neighbors[i].Alive)
                    {
                        aliveNeighbors++;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine($"Cell: {cell} is living on the edge!");
                }
            }

            if (aliveNeighbors == 3)
            {
                cell.Alive = true;
                cell.BackColor = Color.Green;
            }
        }

        void Cell_MouseUp(object sender, MouseEventArgs e)
        {
            Cell cell = (Cell)sender;
            cell.Alive = true;
            cell.BackColor = Color.Green;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            timStep.Start();
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            timStep.Stop();
            Step();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            timStep.Stop();
            ClearGrid();
        }
    }
}
