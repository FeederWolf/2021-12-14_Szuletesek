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

            személyek[0].CdvEll();
            
            Console.ReadKey();
        }
    }
}
