using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class SkrzyniaBiegów
    {
        public int AktualnyBieg { get; private set; }
        public int IlośćBiegów { get; private set; }

        public SkrzyniaBiegów() { }
        public SkrzyniaBiegów(int ilośćBiegów)
        {
            AktualnyBieg = 0; // Ustawienie początkowego biegu na 0
            IlośćBiegów = ilośćBiegów;
        }
        public void UstawBieg(int nowyBieg)
        {
            int a = 0;
            while (a < IlośćBiegów)
            {
                Console.WriteLine(a);
                a++;
            }
            AktualnyBieg = nowyBieg;
            Console.WriteLine(string.Format("Zmieniam bieg na: {0}", nowyBieg));
        }

        public void ZmieńBieg(int ileDodać)
        {
            if (ileDodać + AktualnyBieg >= 0 && ileDodać + AktualnyBieg < IlośćBiegów)
            {
                AktualnyBieg += ileDodać;
                Console.WriteLine(string.Format("Zmieniono bieg na: {0}", AktualnyBieg));
            }
            else
            {
                Console.WriteLine(string.Format("Nie udało się zmienić biegu (poza zakresem), aktalny bieg: {0}", AktualnyBieg));
            }
        }

        public void AutomatycznaZmianaBiegu(int prędkość)
        {
            if (prędkość < 30)
            {
                AktualnyBieg = 1;
            }
            else if (prędkość < 50)
            {
                AktualnyBieg = 2;
            }
            else if (prędkość < 70)
            {
                AktualnyBieg = 3;
            }
            else if (prędkość < 100)
            {
                AktualnyBieg = 4;
            }
            else if (prędkość < 130)
            {
                AktualnyBieg = 5;
            }
            else
            {
                AktualnyBieg = 6;
            }
        }
    }
}
