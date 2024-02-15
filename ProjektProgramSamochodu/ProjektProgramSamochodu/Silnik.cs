using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class Silnik
    {
        public float Pojemność { get; set; } // Pojemność silnika w litrach
        public float Moc { get; set; } // Moc silnika w KM
        public string RodzajPaliwa { get; set; } // Rodzaj paliwa (benzyna, diesel, etc.)
        public bool StanTechniczny { get; set; } // Stan techniczny silnika (czy sprawny)
        public int aktualneObroty = 0;
        public float MaxPozOleju;
        public float PozOleju;
        public bool SilnikWłączony { get; set; }

        public Silnik() { }
        public Silnik(float pojemność, float moc, string rodzajPaliwa, bool stanTechniczny, float maxPozOleju)
        {
            Pojemność = pojemność;
            Moc = moc;
            RodzajPaliwa = rodzajPaliwa;
            StanTechniczny = stanTechniczny;
            MaxPozOleju = maxPozOleju;
        }

        public void WyświetlInformacje()
        {
            Console.WriteLine(string.Format("Pojemność silnika: {0} l", Pojemność));
            Console.WriteLine(string.Format("Moc silnika: {0} KM", Moc));
            Console.WriteLine(string.Format("Rodzaj paliwa: {0}", RodzajPaliwa));
            Console.WriteLine(string.Format("Stan techniczny silnika: {0}", (StanTechniczny ? "sprawny" : "uszkodzony")));
        }
        public bool OlejwNormie()
        {
            float t = PozOleju / MaxPozOleju;
            return t <= 1f && t > 0.3f;
        }
        public static bool OlejwNormie(float PoziomOleju, float MaxPoziomOleju)
        {
            float t = PoziomOleju / MaxPoziomOleju;
            return t <= MaxPoziomOleju && t > 0.3f * MaxPoziomOleju;
        }
        public void DolejOleju(float val)
        {
            PozOleju += val;
            System.Console.WriteLine("Dolano " + val + " litrów oleju");
        }
    }
}
