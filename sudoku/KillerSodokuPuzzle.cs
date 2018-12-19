using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class KillerSodokuPuzzle
    {
        public readonly List<Cell> AllCells = new List<Cell>();
        public readonly List<Cage> Cages = new List<Cage>();

        public List<Cell> SolvedCells
        {
            get
            {
                List<Cell> SolvedCell = new List<Cell>();
                foreach (Cell cell in AllCells)
                {
                    if (cell.IsSolved)
                    {
                        SolvedCell.Add(cell);
                    }
                }
                return SolvedCell;
            }
        }

        public List<Cell> UnsolvedCells
        {
            get
            {
                List<Cell> UnsolvedCells = new List<Cell>();
                foreach (Cell cell in AllCells)
                {
                    if (!cell.IsSolved)
                    {
                        UnsolvedCells.Add(cell);
                    }
                }
                return UnsolvedCells;
            }
        }



        public KillerSodokuPuzzle(string cageNums, string cages)
        {
            // create cells
            for (int y = 0; y <= 8; y++)
            {
                for (int x = 0; x <= 8; x++)
                {
                    Cell tempCell = new Cell(x, y);
                    AllCells.Add(tempCell);
                    UnsolvedCells.Add(tempCell);
                }
            }
            // create cages
            int[] CageNums = Array.ConvertAll(cageNums.Split(' '), s => int.Parse(s));
            foreach(int sum in CageNums)
            {
                Cage tempCage = new Cage(sum);
                Cages.Add(tempCage);
            }
            //add cells to cages
            for(int i = 0; i < cages.Length; i++)
            {
                Cages[CharToInt(cages[i])].Add(AllCells[i]);
            }
        }



        public bool RemoveCandidateFromGroup(int candidate, List<Cell> cells)
        {
            bool removed = false;
            foreach(Cell cell in cells)
            {
                if (cell.RemoveCandidate(candidate))
                {
                    removed = true;
                }
            }
            return removed;
        }

        public void SetCandidates(int x, int y, string candidates) => GetCell(x, y).SetCandidates(candidates);



        public List<Cell> GetRow(Cell cell) => GetRow(cell.Y);

        public List<Cell> GetRow(int row)
        {
            if (row < 0 || row > 8)
            {
                return null;
            }
            List<Cell> Row = new List<Cell>();
            foreach(Cell cell in AllCells)
            {
                if(cell.Y == row)
                {
                    Row.Add(cell);
                }
            }
            return Row;
        }

        public List<Cell> GetColumn(Cell cell) => GetColumn(cell.X);

        public List<Cell> GetColumn(int col)
        {
            if (col < 0 || col > 8)
            {
                return null;
            }

            List<Cell> Col = new List<Cell>();
            foreach (Cell cell in AllCells)
            {
                if (cell.X == col)
                {
                    Col.Add(cell);
                }
            }
            return Col;
        }

        public List<Cell> GetBlock(Cell cell) => GetBlock(cell.Block);

        public List<Cell> GetBlock(int block)
        {
            List<Cell> Block = new List<Cell>();

            foreach (Cell cell in AllCells)
            {
                if(block == cell.Block)
                {
                    Block.Add(cell);
                }
            }
            return Block;
        }

        public Cell GetCell(int x, int y) => AllCells[(y * 9) + x];

        public Cage GetCage(int x, int y) => GetCage(GetCell(x, y));

        public Cage GetCage(Cell cell)
        {
            foreach(Cage cage in Cages)
            {
                if (cage.Cells.Contains(cell))
                {
                    return cage;
                }
            }
            return null;
        }

      

        public bool Solved => UnsolvedCells.Capacity == 0;

        /// <summary>
        /// A-Za-z
        /// 0->
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private int CharToInt(char c)
        {
            if (char.IsUpper(c))
            {
                return c - 'A';
            }
            else if (char.IsLower(c))
            {
                return c - 'a' + CharToInt('Z') + 1;
            }
            else
            {
                return -1;
            }
        }
    }
}
