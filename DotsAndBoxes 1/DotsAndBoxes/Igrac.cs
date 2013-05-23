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

        public Igrac(string ime, System.Drawing.Color boja)
        {
            Ime = ime;
            Boja = boja;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Ime, Boja.ToString());
        }
    }
}
