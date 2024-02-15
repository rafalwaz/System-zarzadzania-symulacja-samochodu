using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class ZużyciePaliwa
    {
        public double SpalanieWMieścieNa100Km { get; set; } // Zużycie paliwa w litrach na 100 km w mieście
        public double SpalanieNaTrasieNa100Km { get; set; } // Zużycie paliwa w litrach na 100 km na trasie

        public ZużyciePaliwa() { }
        public ZużyciePaliwa(double spalanieWMieścieNa100Km, double spalanieNaTrasieNa100Km)
        {
            this.SpalanieWMieścieNa100Km = spalanieWMieścieNa100Km;
            this.SpalanieNaTrasieNa100Km = spalanieNaTrasieNa100Km;
        }


        public double ObliczZużyciePaliwaNaPodstawieBaku(int pojemnośćBaku)
        {
            return pojemnośćBaku * (SpalanieWMieścieNa100Km + SpalanieNaTrasieNa100Km) / 100.0;
        }
    }
}
