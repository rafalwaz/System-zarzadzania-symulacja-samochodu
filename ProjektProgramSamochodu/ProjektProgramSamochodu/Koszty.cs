using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class Koszty
    {
        public float KosztPaliwa { get; set; }
        public float KosztUbezpieczenia { get; set; }
        public float KosztSerwisu { get; set; }

        public Koszty() { }
        public Koszty(float kosztPaliwa, float kosztUbezpieczenia, float kosztSerwisu)
        {
            KosztPaliwa = kosztPaliwa;
            KosztUbezpieczenia = kosztUbezpieczenia;
            KosztSerwisu = kosztSerwisu;
        }

        public float ObliczCałkowityKoszt()
        {
            return KosztPaliwa + KosztUbezpieczenia + KosztSerwisu;
        }
    }
}
