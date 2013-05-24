using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotsAndBoxes
{
    public class Igrac
    {
        public string Ime { get; set; }
        public System.Drawing.Color Boja { get; set;}
        public int Score;

        public Igrac(string ime, System.Drawing.Color boja, int score)
        {
            Ime = ime;
            Boja = boja;
            Score = score;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Ime, Boja.ToString(), Score);
        }
    }
}
