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
        Cell[,] currentGen;
        Cell[,] nextGen;
        List<Cell> aliveCells = new List<Cell>();
        Random rnd = new Random();

        public frmLife()
        {
            InitializeComponent();
        }

        void InitGrid()
        {
            currentGen = new Cell[gridWidth, gridHeight];
            nextGen = new Cell[gridWidth, gridHeight];

            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    Cell cell = new Cell(false)
                    {
                        Location = new Point(x * cellWidth, y * cellHeight),
                        GridSpot = new Point(x, y),
                        Size = new Size(cellWidth, cellHeight),
                        TabStop = false,
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White,
                        Visible = true
                    };
                    cell.MouseUp += Cell_MouseUp;

                    currentGen[x, y] = cell;
                    nextGen[x, y] = cell;

                    pnlCells.Controls.Add(currentGen[x, y]);

                    pnlCells.Refresh();
                    cell.Refresh();
                }
            }
        }
        
        private void timStep_Tick(object sender, EventArgs e)
        {
            Step();
        }

        void Step()
        {
            foreach (Cell cell in currentGen)
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
            }
            
            aliveCells.Clear();
            Evolve();
        }

        private void Evolve()
        {
            foreach (Cell oldCell in currentGen)
            {
                if (oldCell.OnDeathRow)
                {
                    oldCell.Alive = false;
                    nextGen[oldCell.GridSpot.X, oldCell.GridSpot.Y].BackColor = Color.LightBlue;
                }
                else if (oldCell.GonnaSpawn)
                {
                    nextGen[oldCell.GridSpot.X, oldCell.GridSpot.Y].Alive = true;
                }

                nextGen[oldCell.GridSpot.X, oldCell.GridSpot.Y].OnDeathRow = false;
                nextGen[oldCell.GridSpot.X, oldCell.GridSpot.Y].GonnaSpawn = false;
            }

            currentGen = nextGen;
            pnlCells.Refresh();
        }
        
        void Clear(Cell[,] gen)
        {
            foreach (Cell cell in currentGen)
            {
                cell.Reset();
            }

            pnlCells.Refresh();
        }

        private void AddNeighbors(Cell cell)
        {
            try { cell.Neighbors[0] = currentGen[cell.GridSpot.X - 1, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[1] = currentGen[cell.GridSpot.X, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[2] = currentGen[cell.GridSpot.X + 1, cell.GridSpot.Y - 1]; } catch (Exception) { }
            try { cell.Neighbors[3] = currentGen[cell.GridSpot.X - 1, cell.GridSpot.Y]; } catch (Exception) { }
            try { cell.Neighbors[4] = currentGen[cell.GridSpot.X + 1, cell.GridSpot.Y]; } catch (Exception) { }
            try { cell.Neighbors[5] = currentGen[cell.GridSpot.X - 1, cell.GridSpot.Y + 1]; } catch (Exception) { }
            try { cell.Neighbors[6] = currentGen[cell.GridSpot.X, cell.GridSpot.Y + 1]; } catch (Exception) { }
            try { cell.Neighbors[7] = currentGen[cell.GridSpot.X + 1, cell.GridSpot.Y + 1]; } catch (Exception) { }
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
                    //Console.WriteLine($"alive cell({cell.GridSpot.X}, {cell.GridSpot.Y})[{i}]: {cell.Neighbors[i].Alive}");
                }
            }

            //Console.WriteLine($"Alive Neighbors: {aliveNeighbors}");
            //Console.WriteLine();

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
                if (cell.Neighbors[i] != null)
                {
                    if (cell.Neighbors[i].Alive)
                    {
                        aliveNeighbors++;
                    }
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

            Console.WriteLine($"Alive: {cell.Alive}, OnDeathRow: {cell.OnDeathRow}, GonnaSpawn: {cell.GonnaSpawn}");

            if (cell.Alive)
            {
                cell.Alive = false;
                cell.BackColor = Color.White;
            }
            else
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
            Clear(currentGen);
        }

        private void frmLife_Load(object sender, EventArgs e)
        {
            InitGrid();
        }
    }
}
