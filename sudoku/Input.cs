using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku
{
    class Input
    {
        ArrayList ReadToArrayList(String filename)
        {
            ArrayList AL = new ArrayList();
            TextReader tr = File.OpenText(filename);

            string Actor;
            while ((Actor = tr.ReadLine()) != null)
            {
                AL.Add(Actor);
            }
            return AL;
        }
    }
}
