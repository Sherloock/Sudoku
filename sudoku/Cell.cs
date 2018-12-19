using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Cell
    {
        public readonly int X;
        public readonly int Y;

        internal HashSet<int> Candidates { get; set; }

        public Cell(int x, int y)
        {
            X = x; Y = y;
            Candidates = new HashSet<int>();
            for (int i = 1; i <= 9; i++)
            {
                Candidates.Add(i);
            }
        }

        //properties
        public int Block => (Y / 3) * 3 + (X / 3);

        public bool IsSolved => Candidates.Count() == 1;

        public int Solution
        {
            get
            {
                if (IsSolved)
                {
                    return Candidates.First();
                }
                else
                {
                    return 0;
                }
            }
        }

        //candidates
        public bool RemoveCandidate(int toRemove)
        {
            if (Candidates.Contains(toRemove) && !IsSolved)
            {
                Candidates.Remove(toRemove);
                Program.form.RefreshCandidates(X,Y);
                return true;
            }
            return false;
        }

        public void SetCandidates(String candidates)
        {
            HashSet<int> NewCandidates = new HashSet<int>();
            foreach (char c in candidates)
            {
                try
                {
                    int candidate = Int32.Parse(c + "");
                    if (candidate >= 1 && candidate <= 9)
                    {
                        NewCandidates.Add(candidate);
                    }
                }
                catch (Exception) { }

            }
            if (NewCandidates.Count != 0)
            {
                Candidates = NewCandidates;
            }
            Program.form.RefreshCandidates(X, Y);
        }

        public void SetSolution(int solution)
        {
            SetCandidates(solution + "");
        }

        //toStrings
        public string CandidatesToBtn()
        {
            if(IsSolved)
            {
                return Solution+ "";
            }
            else
            {
                string result = "";

                for (int i = 1; i <= 9; i++)
                {
                    result += Candidates.Contains(i) ? i + "" : " ";
                    result += i % 3 == 0 ? "\n" : " ";
                }

                return result;
            }
        }

        public string CandidatesToTF()
        {
            string result = "";
            foreach(int candidate in Candidates)
            {
                result += candidate + "";
            }
            return result;
        }

        public override string ToString()
        {
            return  (char)(Y + 'A') + "" + X;
        }

      
    }

}
