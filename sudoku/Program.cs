using System;
using System.Windows.Forms;

namespace sudoku
{
    static class Program
    {

        public static KillerSodokuPuzzle ksdk;
        public static Form form;
        public static Solver solver;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string cageNums = "27 41 27 8 5 15 9 30 27 7 12 16 7 14 18 7 10 29 15 21 8 19 6 11 16";
            string cages = "AABBBBBCCAABDEFBCCAGHDEFIJCAGHKKKIJCLMHHNIIOPLMMHNIOOPQRRSSSTTUQRRVVVTTUWWRXXXTYY";
            ksdk = new KillerSodokuPuzzle(cageNums, cages);
            solver = new Solver(ksdk);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new Form();


            Application.Run(form);
        }
    }
}
