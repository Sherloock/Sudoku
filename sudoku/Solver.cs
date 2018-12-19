using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Solver
    {
        KillerSodokuPuzzle Puzzle;

        public Solver(KillerSodokuPuzzle puzzle)
        {
            this.Puzzle = puzzle;
        }

        public bool Solve()
        {
            while (!Puzzle.Solved)
            {
                 
                if(!TakeStep()) return false; //unsolveable
            }
            return true;
        }

        public bool TakeStep()
        {
            return ShowPossibles()
                || NakedCombos(2) 
                || NakedCombos(3)

                || NakedCombos(4);
        }
         
        private bool ShowPossibles()
        {
            bool successful = false;
            SetLog("Show Possibles:\n");

            foreach (Cell solvedCell in Puzzle.SolvedCells)
            {
                HashSet<Cell> connectedCells = new HashSet<Cell>(
                    Puzzle.GetBlock(solvedCell)
                        .Concat(Puzzle.GetCage(solvedCell).Cells)
                        .Concat(Puzzle.GetColumn(solvedCell))
                        .Concat(Puzzle.GetRow(solvedCell))
                        .ToList()
                );

                foreach(Cell connectedCell in connectedCells)
                {
                    int toRemove = solvedCell.Solution;
                    bool candidateRemoved = connectedCell.RemoveCandidate(toRemove);

                    if (candidateRemoved)
                    {
                        successful = true;
                        AppendLog(toRemove + " is removed from: " + connectedCell + "\n");
                    }
                }
            }
            return successful;
        }

        //private bool HiddenSingles()
        //{
        //    for (int i = 0; i < 9; i++)
        //    {
                
        //    }
        //}

        private bool LastRemaining(List<Cell> unit)
        {
            for (int num = 1; num <= 9; num++)
            {
                int count = 0;
                int index = 0;
                while(count < 2 && index < unit.Count)
                {
                    if (unit.ElementAt(index++).Candidates.Contains(num))
                    {
                        count += 1; 
                    }
                }
                if(count == 1)
                {
                    unit.ElementAt(index).SetSolution(num);

                    return true;
                }
            }
            return false;
        }


        private bool NakedCombos(int piece)
        {
            if(piece < 2 || piece > 4)
            {
                return false;
            }

            for (int i = 0; i < 9; i++)
            {
                if(NakedUnit(Puzzle.GetBlock(i), piece) || NakedUnit(Puzzle.GetColumn(i), piece) || NakedUnit(Puzzle.GetRow(i), piece))
                {
                    return true;
                }
            }
            return false;
        }

        private bool NakedUnit(List<Cell> unit, int piece)
        {
            List<Cell> PossibleNakedUnit = new List<Cell>();

            foreach (Cell cell in unit)
            {
                if(cell.Candidates.Count >= 2 || cell.Candidates.Count <= piece)
                {
                    PossibleNakedUnit.Add(cell);
                }
            }


            return false;
        }

        private void SetLog(String s) => Program.form.SetLogBox(s);

        private void AppendLog(String s) => Program.form.AppendLogBox(s);
    }
}
