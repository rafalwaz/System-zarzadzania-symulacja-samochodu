using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektProgramSamochodu
{
    internal class Samochód
    {
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Typ { get; set; }
        public int RokProdukcji { get; set; }
        public int Przebieg { get; set; }
        public float Cena { get; set; }

        public int Prędkość { get; private set; }
        public int maxPrędkość;
        public float poziom_paliwa;
        public ZużyciePaliwa zużyciePaliwa;
        public Silnik silnik;
        public Parametry parametry;
        public Koszty koszty;
        public SkrzyniaBiegów skrzyniaBiegów;
        private List<float> historiaPrędkości;
        public float średniaPrędkość
        {
            get
            {
                float n = 0;
                for (int i = 0; i < historiaPrędkości.Count; i++)
                {
                    n += historiaPrędkości[i];
                }
                return n / historiaPrędkości.Count;
            }
        }
        public Samochód()
        {
            historiaPrędkości = new List<float>();
            zużyciePaliwa = new ZużyciePaliwa();
            silnik = new Silnik();
            parametry = new Parametry();
            koszty = new Koszty();
            skrzyniaBiegów = new SkrzyniaBiegów();
        }
        public Samochód(string marka, string model, string typ, int rokProdukcji, int przebieg, float cena, float spalanieMiastoNa100, float spalanieTrasaNa100, float pojemność, float moc, string rodzajPaliwa, bool stanTechniczny, int maksymalnaPrędkość, int pojemnośćBaku, float MaxOleju, float kosztPaliwa, float kosztUbezpieczenia, float kosztSerwisu, int ilośćBiegów)
        {
            historiaPrędkości = new List<float>();
            zużyciePaliwa = new ZużyciePaliwa(spalanieMiastoNa100, spalanieTrasaNa100);
            silnik = new Silnik(pojemność, moc, rodzajPaliwa, stanTechniczny, MaxOleju);
            parametry = new Parametry(maksymalnaPrędkość, (spalanieMiastoNa100 + spalanieTrasaNa100) / 2f, pojemnośćBaku);
            koszty = new Koszty(kosztPaliwa, kosztUbezpieczenia, kosztSerwisu);
            skrzyniaBiegów = new SkrzyniaBiegów(ilośćBiegów);
            Prędkość = 0;
            Marka = marka;
            Model = model;
            Typ = typ;
            RokProdukcji = rokProdukcji;
            Przebieg = przebieg;
            Cena = cena;
            maxPrędkość = maksymalnaPrędkość;
        }

        public void zatankuj(int ilosc_paliwa)
        {

            poziom_paliwa += ilosc_paliwa; // odwołanie do pola klasy!
            System.Console.WriteLine("Zatankowany o " + ilosc_paliwa + " litrów");
        }
        public void jedź()
        {
            if (poziom_paliwa < 1)
                System.Console.WriteLine("Zbiornik pusty, nigdzie nie jadę!");
            else
            {
                poziom_paliwa -= 10;
                System.Console.WriteLine("Jadę!");
            }
        }
        public void WyświetlInformacje()
        {
            Console.WriteLine(string.Format("Samochód posiada takie informacje jak: {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}",
                Marka, Model, Typ, RokProdukcji, Przebieg, silnik.Pojemność, silnik.Moc, silnik.RodzajPaliwa, Cena));
        }
        public void WyświetlParametry()
        {
            Console.WriteLine(string.Format("Marka: {0}", Marka));
            Console.WriteLine(string.Format("Model: {0}", Model));
            Console.WriteLine(string.Format("Typ: {0}", Typ));
            Console.WriteLine(string.Format("Rok produkcji: {0}", RokProdukcji));
            Console.WriteLine(string.Format("Przebieg: {0}", Przebieg));
            Console.WriteLine(string.Format("Pojemność silnika: {0} l", silnik.Pojemność));
            Console.WriteLine(string.Format("Moc silnika: {0} KM", silnik.Moc));
            Console.WriteLine(string.Format("Rodzaj paliwa: {0}", silnik.RodzajPaliwa));
            Console.WriteLine(string.Format("Cena: {0} zł", Cena));
            Console.WriteLine(string.Format("Poziom paliwa: {0} l", poziom_paliwa));
        }

        public void Przyśpiesz()
        {
            // Sprawdzenie, czy jest wystarczająco paliwa i czy nie osiągnięto maksymalnej prędkości
            if (poziom_paliwa > 0 && Prędkość < maxPrędkość)
            {
                // Przyśpieszenie o 10 km/h
                Prędkość += 10;
                if (Prędkość > maxPrędkość)
                {
                    Prędkość = maxPrędkość;
                }
                pal2();
            }
            else
            {
                Console.WriteLine("\nOsiągnięto maksymalną prędkość lub brak paliwa.");
            }
        }
        public void Przyśpiesz(int wartość)
        {
            if (silnik.SilnikWłączony)
            {
                Prędkość += wartość;
                if (Prędkość > maxPrędkość)
                {
                    Prędkość = maxPrędkość;
                }
                pal2();
            }
            else
            {
                Console.WriteLine("Prędkość wynosi zero kiedy silnik jest wyłączony.");
            }
        }
        private void pal2()
        {
            historiaPrędkości.Add(Prędkość);
            Trasa trasa = new Trasa("Rzeszów", "Kielnarowa", 17f, średniaPrędkość);
            // Obliczenie zużycia paliwa w zależności od prędkości
            float zużytePaliwo = 0f;
            if (Prędkość <= 80)
            {
                zużytePaliwo = parametry.SpalanieŚrednie / 15.6f;
            }
            else if (Prędkość <= 120)
            {
                zużytePaliwo = parametry.SpalanieŚrednie / 78f;
            }
            else
            {
                // Na prędkości powyżej 120km/h, spalanie rośnie mniej agresywnie
                zużytePaliwo = parametry.SpalanieŚrednie / 78f + (((float)Prędkość - 120f) * 0.05f); // Dla każdych dodatkowych 10 km/h, spalanie rośnie o 0.5 litra/100km
            }

            // Aktualizacja stanu paliwa
            poziom_paliwa = Math.Max(0f, Program.RoundTo(poziom_paliwa - zużytePaliwo, 2));

            // Przewidywana ilość kilometrów na aktualnym poziomie paliwa
            float przewidywaneKilometry = Program.RoundTo((poziom_paliwa / zużytePaliwo) + 52f, 2);

            // Aktualizacja obrotów w zależności od biegu
            skrzyniaBiegów.AutomatycznaZmianaBiegu(Prędkość);
            silnik.aktualneObroty = 1000 + (15 * Prędkość) + ((skrzyniaBiegów.AktualnyBieg + 1) * 100);

            Console.WriteLine("\nPrzyśpieszono. Aktualna prędkość: {0} km/h", Prędkość);
            Console.WriteLine("Zużyte paliwo: {0} litrów", zużytePaliwo);
            Console.WriteLine("Przewidywana ilość kilometrów na aktualnym poziomie paliwa: {0} km", przewidywaneKilometry);
            Console.WriteLine("Stan paliwa: {0} litrów", Math.Max(0, poziom_paliwa));
            trasa.WyświetlInformacje();
        }
        public void Hamuj()
        {
            if (Prędkość > 0)
            {
                Prędkość -= 10; // Hamowanie o 10 km/h
                if (Prędkość < 0)
                    Prędkość = 0;

                // Automatyczna zmiana biegów w zależności od prędkości
                skrzyniaBiegów.AutomatycznaZmianaBiegu(Prędkość);

                // Aktualizacja obrotów w zależności od biegu
                silnik.aktualneObroty = 1000 + (15 * Prędkość) + ((skrzyniaBiegów.AktualnyBieg + 1) * 100);

                Console.WriteLine("\nZahamowano. Aktualna prędkość: {0} km/h", Prędkość);
            }
            else
            {
                silnik.aktualneObroty = 1000;
                Console.WriteLine("\nSamochód stoi, hamowanie nie zmieniło prędkości");
            }
        }
        public void Hamuj(int wartość)
        {
            if (Prędkość > 0)
            {
                Prędkość -= wartość;
                if (Prędkość < 0)
                {
                    Prędkość = 0;
                }
                Console.WriteLine("\nZahamowano. Aktualna prędkość: {0} km/h", Prędkość);
            }
            else
            {
                Console.WriteLine("\nSamochód stoi, hamowanie nie zmieniło prędkości");
            }
        }
        public void WłączWyłączSilnik()
        {
            silnik.SilnikWłączony = !silnik.SilnikWłączony;
            if (!silnik.SilnikWłączony)
            {
                Console.WriteLine("\nSilnik wyłączony");
                return;
            }
            Console.WriteLine("\nSilnik włączony");

            // Ustawienie początkowych obrotów na 1000 RPM
            silnik.aktualneObroty = 1000;
            Prędkość = 0; // Resetowanie prędkości po włączeniu silnika

            // Sprawdzenie stanu oleju po uruchomieniu silnika

            Console.WriteLine("Stan oleju: {0}", silnik.OlejwNormie() ? "W normie" : "Brak oleju");
            Console.WriteLine("Stan paliwa: {0} litrów", Math.Max(0, poziom_paliwa));
            Console.WriteLine("Pojemność baku: {0} litrów", parametry.PojemnośćBaku);
        }

    }
}
