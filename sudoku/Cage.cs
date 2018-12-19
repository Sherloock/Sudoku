using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Cage
    {
        private static Random rnd = new Random();
        private readonly List<Cell> cells;
        public List<Cell> Cells { get { return cells; }  }


        private int sum;
        public int Sum => sum;

        public readonly Color Color;
    

        public Cage(int sum)
        {
            this.sum = sum;
            cells = new List<Cell>();
            Color = Color.FromArgb(rnd.Next(200)+56, rnd.Next(200) + 56, rnd.Next(200) + 56);
        }
        public void Add(Cell toAdd)
        {
            Cells.Add(toAdd);
        }

        public bool Remove(Cell toRemove)
        {
            if(Cells.Contains(toRemove) && toRemove.IsSolved)
            {
                Cells.Remove(toRemove);
                sum -= toRemove.Solution;
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
