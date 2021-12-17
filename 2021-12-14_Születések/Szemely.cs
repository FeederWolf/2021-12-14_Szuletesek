using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_12_14_Születések
{
    class Szemely
    {
        public string SzemélyiSzám { get; set; }
        public bool CdvEll {
            get {
                string sz = SzemélyiSzám.Replace("-", "");
                int checkSum = int.Parse(sz.Last().ToString()); //levágjuk a végét (10. index) -> K és stringre alakítom
                Console.WriteLine(checkSum);
                int szum = 0;

                //sz = sz.Reverse().ToString();

                for (int i = 0; i < 10; i++)
                {
                    szum += (10 - i) * int.Parse(sz[i].ToString()); //10 - i: 10,9,8,7...
                }
                return checkSum == szum % 11;            
            }
        }
        public Szemely(string Sor)
        {
            SzemélyiSzám = Sor;
        }
        
    }
}
