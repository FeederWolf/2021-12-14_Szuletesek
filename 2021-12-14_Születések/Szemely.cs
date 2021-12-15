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
                int szum = 0;
                int Jackson = sz[sz.Length]; //levágjuk a végét (10. index) -> K
                for (int i = 0; i < SzemélyiSzám.Length; i++)
                {
                    szum += i * sz[i];
                }
                return false;            
            }
        }
        public Szemely(string Sor)
        {
            SzemélyiSzám = Sor;
        }
        
    }
}
