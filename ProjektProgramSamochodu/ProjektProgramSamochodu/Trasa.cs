using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class Trasa
    {
        public string MiejscePoczątkowe { get; set; }
        public string MiejsceDocelowe { get; set; }
        public float Odległość { get; set; }
        public TimeSpan CzasPodróży { get; set; }
        public float ŚredniaPrędkość { get; set; }

        public Trasa(string miejscePoczątkowe, string miejsceDocelowe, float odległość, TimeSpan czasPodróży)
        {
            MiejscePoczątkowe = miejscePoczątkowe;
            MiejsceDocelowe = miejsceDocelowe;
            Odległość = odległość;
            CzasPodróży = czasPodróży;
            ŚredniaPrędkość = odległość * czasPodróży.Seconds;
        }
        public Trasa(string miejscePoczątkowe, string miejsceDocelowe, float odległość, float średniaPrędkość)
        {
            MiejscePoczątkowe = miejscePoczątkowe;
            MiejsceDocelowe = miejsceDocelowe;
            Odległość = odległość;
            float h = odległość / średniaPrędkość;
            float m = h * 60f;
            CzasPodróży = new TimeSpan((int)h, (int)m, (int)((m - ((int)m)) * 60f));
            ŚredniaPrędkość = średniaPrędkość;
        }

        public void WyświetlInformacje()
        {
            Console.WriteLine(string.Format("Trasa z {0} do {1}:", MiejscePoczątkowe, MiejsceDocelowe));
            Console.WriteLine(string.Format("- Odległość: {0} km", Odległość));
            Console.WriteLine(string.Format("- Czas podróży: {0}", CzasPodróży));
            Console.WriteLine(string.Format("- Średnia prędkość: {0} km/h", ŚredniaPrędkość));
        }
    }
}
