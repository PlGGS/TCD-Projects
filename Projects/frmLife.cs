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
        int cellWidth = 20;
        int cellHeight = 20;
        Grid[] grids = new Grid[2];
        bool currentGrid = false;
        int cGrid
        {
            get
            {
                return Convert.ToInt32(currentGrid);
            }
            set
            {
                currentGrid = Convert.ToBoolean(value);
            }
        }
        List<Cell> aliveCells = new List<Cell>();
        Random rnd = new Random();

        public frmLife()
        {
            InitializeComponent();
            InitGrids();
        }

        void InitGrids()
        {
            Grid grid0 = new Grid();
            Grid grid1 = new Grid();

            grid0.Cells = new Cell[gridWidth, gridHeight];
            grid1.Cells = new Cell[gridWidth, gridHeight];
            grid0.Location = new Point(0, 0);
            grid1.Location = new Point(0, 0);
            grid0.Size = new Size(gridWidth * cellWidth, gridHeight * cellHeight);
            grid1.Size = new Size(gridWidth * cellWidth, gridHeight * cellHeight);
            grid0.TabStop = false;
            grid1.TabStop = false;
            grid0.BorderStyle = BorderStyle.FixedSingle;
            grid1.BorderStyle = BorderStyle.FixedSingle;
            grid0.BackColor = Color.White;
            grid1.BackColor = Color.White;
            grid0.Visible = true; //Swap between visibilty as game steps
            grid1.Visible = false;

            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    Cell cell = new Cell(false);

                    cell.Location = new Point(x * cellWidth, y * cellHeight);
                    cell.GridSpot = new Point(x, y);
                    cell.Size = new Size(cellWidth, cellHeight);
                    cell.TabStop = false;
                    cell.BorderStyle = BorderStyle.FixedSingle;
                    cell.BackColor = Color.White;
                    cell.Visible = true;
                    cell.MouseUp += Cell_MouseUp;

                    grid0.Cells[x, y] = cell;
                    grid1.Cells[x, y] = cell;

                    grid0.Controls.Add(cell);
                    grid1.Controls.Add(cell);
                }
            }

            grids[0] = grid0;
            grids[1] = grid1;

            Controls.Add(grid0);
            Controls.Add(grid1);
        }
        
        void SwitchCurrentGrid()
        {
            cGrid = Convert.ToInt32(!currentGrid);
        }

        private void timStep_Tick(object sender, EventArgs e)
        {
            Step();
        }

        void Step()
        {
            foreach (Cell cell in grids[cGrid].Cells)
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
                aliveCells.Clear();
            }

            Evolve();
        }

        private void Evolve()
        {
            foreach (Cell newCell in grids[cGrid].Cells)
            {
                if (newCell.OnDeathRow)
                {
                    grids[Convert.ToInt32(!currentGrid)].Cells[newCell.GridSpot.X, newCell.GridSpot.Y].BackColor = Color.LightBlue;
                }
                else if (newCell.GonnaSpawn)
                {
                    grids[Convert.ToInt32(!currentGrid)].Cells[newCell.GridSpot.X, newCell.GridSpot.Y].Alive = true;
                }
            }

            grids[cGrid].Clear();
            SwitchCurrentGrid();
        }
        
        private void AddNeighbors(Cell cell)
        {
            try { cell.Neighbors[0] = grids[cGrid].Cells[cell.GridSpot.X - 1, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[1] = grids[cGrid].Cells[cell.GridSpot.X, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[2] = grids[cGrid].Cells[cell.GridSpot.X + 1, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[3] = grids[cGrid].Cells[cell.GridSpot.X - 1, cell.GridSpot.Y]; } catch (Exception) { }
            try { cell.Neighbors[4] = grids[cGrid].Cells[cell.GridSpot.X + 1, cell.GridSpot.Y]; } catch (Exception) { }
            try { cell.Neighbors[5] = grids[cGrid].Cells[cell.GridSpot.X - 1, cell.GridSpot.Y + 1]; } catch (Exception) { }
            try { cell.Neighbors[6] = grids[cGrid].Cells[cell.GridSpot.X, cell.GridSpot.Y + 1]; } catch (Exception) { }
            try { cell.Neighbors[7] = grids[cGrid].Cells[cell.GridSpot.X + 1, cell.GridSpot.Y + 1]; } catch (Exception) { }
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
                        AddNeighbors(cell.Neighbors[i]);
                        CheckNeighborsOfDeadCell(cell.Neighbors[i]);
                    }
                    Console.WriteLine($"alive cell({cell.GridSpot.X}, {cell.GridSpot.Y})[{i}]: {cell.Neighbors[i].Alive}");
                }
            }

            Console.WriteLine($"Alive Neighbors: {aliveNeighbors}");
            Console.WriteLine();

            if (aliveNeighbors < 2)
            {
                cell.OnDeathRow = true;
            }
            else if (aliveNeighbors > 3)
            {
                cell.OnDeathRow = true;
            }
            else
            {
                cell.GonnaSpawn = true;
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
                cell.GonnaSpawn = true;
                cell.BackColor = Color.Green;
            }
        }

        void Cell_MouseUp(object sender, MouseEventArgs e)
        {
            Cell cell = (Cell)sender;
            if (cell.Visible)
            {
                cell.Alive = true;
                cell.BackColor = Color.Green;
            }
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
            grids[cGrid].Clear();
        }
    }
}
