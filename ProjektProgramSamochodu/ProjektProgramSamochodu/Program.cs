using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class Program
    {
        const float minimalneSpalanie = 0.5f; // Minimalne zużycie paliwa na kilometr w litrach (odpowiadające 20 km/h)
        static void Main(string[] args)
        {
            Samochód auto0 = new Samochód("Opel", "Astra GSI", "Hatchback", 1993, 200000, 4000f, 8.5f, 7.1f,
                1800f, 125f, "Benzyna", true, 204, 52, 3.7f, 6.58f, 470f, 1200f, 6);
            Silnik silnikAuta0 = auto0.silnik;
            auto0.zatankuj(52);
            silnikAuta0.DolejOleju(3f);
            SkrzyniaBiegów skrzyniaAuta0 = auto0.skrzyniaBiegów;

            Console.WriteLine("Symulacja działania samochodu");

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\nWybierz akcję:");

                if (!silnikAuta0.SilnikWłączony)
                {
                    Console.WriteLine("1. Włącz silnik");
                }
                else
                {
                    Console.WriteLine("2. Przyśpiesz");
                    Console.WriteLine("3. Hamuj");
                    Console.WriteLine("4. Wyłącz silnik");
                }

                ConsoleKeyInfo key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        auto0.WłączWyłączSilnik();
                        break;
                    case '2':
                        if (silnikAuta0.SilnikWłączony)
                        {
                            auto0.Przyśpiesz();
                        }
                        else
                        {
                            Console.WriteLine("\nNajpierw włącz silnik.");
                        }
                        break;
                    case '3':
                        if (silnikAuta0.SilnikWłączony)
                        {
                            auto0.Hamuj();
                        }
                        else
                        {
                            Console.WriteLine("\nNajpierw włącz silnik.");
                        }
                        break;
                    case '4':
                        if (silnikAuta0.SilnikWłączony)
                        {
                            auto0.WłączWyłączSilnik();
                        }
                        else
                        {
                            Console.WriteLine("\nSilnik jest już wyłączony.");
                        }
                        break;
                    default:
                        Console.WriteLine("\nNieprawidłowy wybór. Wybierz ponownie.");
                        break;
                }

                if (silnikAuta0.SilnikWłączony)
                {
                    Console.WriteLine("\nAktualny stan:");
                    Console.WriteLine("Silnik: Włączony");
                    Console.WriteLine("Aktualny bieg: {0}", skrzyniaAuta0.AktualnyBieg);
                    Console.WriteLine("Aktualna prędkość: {0} km/h", auto0.Prędkość);
                    Console.WriteLine("Aktualne obroty: {0} rpm", silnikAuta0.aktualneObroty);
                    Console.WriteLine("Stan paliwa: {0} litrów", auto0.poziom_paliwa);
                    Console.WriteLine("Pojemność baku: {0} litrów", auto0.parametry.PojemnośćBaku);
                    Console.ReadKey();
                }
            }
        }
        /// <summary>
        /// Przybliża do n cyfr po przecinku.
        /// </summary>
        /// <param name="val">wartość.</param>
        /// <param name="n">liczba cyfr po przecinku.</param>
        public static float RoundTo(float val, int n)
        {
            float e = int.Parse("1" + new string('0', n));
            return ((int)(val * e)) / e;
        }
    }
}
