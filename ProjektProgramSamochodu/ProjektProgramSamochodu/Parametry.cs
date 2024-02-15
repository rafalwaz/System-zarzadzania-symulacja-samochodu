using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class Parametry
    {
        public int MaksymalnaPrędkość { get; set; } // Maksymalna prędkość samochodu w km/h
        public float SpalanieŚrednie { get; set; } // Średnie zużucie paliwa
        public int PojemnośćBaku { get; set; } // Pojemność baku paliwa w litrach

        public Parametry() { }
        public Parametry(int maksymalnaPrędkość, float spalanieŚrednie, int pojemnośćBaku)
        {
            MaksymalnaPrędkość = maksymalnaPrędkość;
            SpalanieŚrednie = spalanieŚrednie;
            PojemnośćBaku = pojemnośćBaku;
        }

        public void WyświetlInformacje()
        {
            Console.WriteLine(string.Format("Maksymalna prędkość: {0} km/h", MaksymalnaPrędkość));
            Console.WriteLine(string.Format("Średnie zużycie paliwa: {0} l/100km", SpalanieŚrednie));
            Console.WriteLine(string.Format("Pojemność baku paliwa: {0} l", PojemnośćBaku));
        }
    }
}
