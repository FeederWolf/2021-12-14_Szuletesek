using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2021_12_14_Születések
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Szemely> személyek = new List<Szemely>();
            foreach (var sor in File.ReadAllLines("vas.txt"))
            {
                személyek.Add(new Szemely(sor));
            }

            if (személyek[1].CdvEll)
            {
                Console.WriteLine("helyes: " + személyek[1].SzemélyiSzám);
            }
            Console.WriteLine($"4. feladat: Ellenőrzés");
            
            /*Linq típusu programozás*/
            személyek //lista
             .Where(x => !x.CdvEll).ToList() //HA HAMIS AKKOR BRUH 
              .ForEach(sz => Console.WriteLine($"\tHibás az {sz.SzemélyiSzám} személyi azonosító")); //az x elemeken menjen végig (előző paraméter) 
            int töröl = személyek.RemoveAll(x => !x.CdvEll);
            Console.WriteLine(személyek.Count);
            /*hagyományos típusu programozás*/
            /*
            foreach (var sz in személyek)
            {
                if (!sz.CdvEll) //hamis
                {
                    Console.WriteLine($"\tHibás az {sz.SzemélyiSzám} személyi azonosító");
                }
            }
            */
            /*hagyományos típusu programozás FOR-al*/
            /*
            for (int i = 0; i < személyek.Count; i++)
            {
                if (!személyek[i].CdvEll)
                {
                    Console.WriteLine($"\tHibás az {személyek[i].SzemélyiSzám} személyi azonosító");
                    személyek.Remove(személyek[i]);
            }
            }
            */
            //5.
            Console.WriteLine($"Szóra sem érdemes 5. feladat: Vas megyében a vizsgált évek {személyek.Count} csecsemő született");
            
            //6.
            int fiúk = személyek //a fiúkba tároljuk az adatot amit a Count() számol meg
            .Where(x => x.SzemélyiSzám.First() == '1' || x.SzemélyiSzám.First() == '3').ToList()  //fiú = 1/3 számmal kezdődik ,a változó neve mind1, A ToList() MINDIG KELL!!!
            .Count();
             Console.WriteLine($"6. feladat: Fiúk száma: {fiúk}");

            //7.
            /*
           int minÉv = 5000;
           int maxÉv = 0;
            foreach (var sz in személyek)
            {
                int akt = sz.SzületésiDátum.Year;
                if (akt >= 97 && akt <= 99) akt += 1900;
                else akt += 2000;
                if (akt < minÉv) minÉv = akt;
                if (akt > maxÉv) maxÉv = akt;
            }
            */
            //7.b SQL BE LIKE:
            int minÉv = személyek.Min(x => x.SzületésiDátum.Year);
            int maxÉv = személyek.Max(x => x.SzületésiDátum.Year);

            Console.WriteLine($"7. feladat: Vizsgált időszak: {minÉv} - {maxÉv}");

            //8. döntse el
            DateTime d = new DateTime(2004, 01, 01);
            DateTime.IsLeapYear(2004);
            Console.WriteLine($"{személyek[0].SzületésiDátum}"); 
            if (személyek.Any(x => DateTime.IsLeapYear(x.SzületésiDátum.Year) && x.SzületésiDátum.Month == 2 && x.SzületésiDátum.Day == 24))
            {
                Console.WriteLine("8. feladat: született");
            }
            else
            {
                Console.WriteLine("8. feladat: bruh");
            }
            //9. SQL BE LIKE:
            //i got one question for you
            /*
            Dictionary<string, int> statisztika = new Dictionary<string, int>();
            statisztika.Add("Dombóvár", 10011101);
            statisztika.Add("Dick", 10011100);
            statisztika.ContainsKey("Kapospula");
            */
            /*
            Console.WriteLine("9. feladat: statisztika");
            Dictionary<int, int> statisztika = new Dictionary<int, int>();
            foreach (var sz in személyek)
            {
                if (statisztika.ContainsKey(sz.SzületésiDátum.Year))
                {
                    statisztika[sz.SzületésiDátum.Year]++;
                }
                else
                {
                    statisztika.Add(sz.SzületésiDátum.Year, 1);
                }
            }
            foreach (var s in statisztika)
            {
                Console.WriteLine($"\t{s.Key} - {s.Value} fő");
            }
            */

            //9.b SQL BE LIKE:
            személyek
            .GroupBy(sz => sz.születésiDátum.Year) //évenként csoportosítsa
            .select(x => new { Évszám = x.Key, Darab = x.Count() }) //anonimuos object
            .ToList()
            .ForEach(y => Console.WriteLine($"\t{y.Évszám} - {y.Darab} fő"));

            Console.ReadKey();
        }
    }
}
