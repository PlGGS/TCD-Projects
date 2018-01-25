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
        Cell[,] cells;
        Cell[,] newCells;
        List<Cell> aliveCells = new List<Cell>();
        Random rnd = new Random();

        public frmLife()
        {
            InitializeComponent();
            cells = InitGrid(cells);
        }

        Cell[,] InitGrid(Cell[,] pCells)
        {
            pCells = new Cell[gridWidth, gridHeight];

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

                    pCells[x, y] = cell;

                    Controls.Add(cell);
                    cell.MouseUp += Cell_MouseUp;
                }
            }

            return pCells;
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

            Evolve();
        }

        private void Evolve()
        {
            newCells = InitGrid(newCells);

            foreach (Cell newCell in newCells)
            {
                if (cells[newCell.GridSpot.X, newCell.GridSpot.Y].OnDeathRow)
                {
                    newCell.BackColor = Color.LightBlue;
                }
                else if (cells[newCell.GridSpot.X, newCell.GridSpot.Y].GonnaSpawn)
                {
                    newCell.Alive = true;
                }
            }

            cells = newCells;
            newCells = new Cell[gridWidth, gridHeight];
            ClearGrid();
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

            cells = InitGrid(cells);
        }
        
        void RemoveAliveCellsFromList()
        {
            for (int i = 0; i < aliveCells.Count; i++)
            {
                if (aliveCells[i].OnDeathRow == true)
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
