using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotsAndBoxes
{
    public class KraenRez
    {
        public List<string> rundaRez;
        public List<int> Pobednici;

        public KraenRez()
        {
            rundaRez = new List<string>();
            Pobednici = new List<int>();
        }

        public void dodRezPob(string rez, int pob)
        {
            rundaRez.Add(rez);
            Pobednici.Add(pob);
        }

        public override string ToString()
        {
            string listaRez = "Rezultati \n";
            foreach (string r in rundaRez)
            {
                listaRez += r ;
            }
            return listaRez;
        }

        public int kraenPobednik()
        {
            int p1 = 0;
            int p2 = 0;
            foreach (int p in Pobednici)
            {
                if (p == 1)
                    p1++;
                else if (p == 2)
                    p2++;
            }
            if (p1 > p2)
                return 1;
            else return 2;
        }

    }
}
