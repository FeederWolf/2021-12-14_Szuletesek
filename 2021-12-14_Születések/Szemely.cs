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
        //8.
        public DateTime SzületésiDátum { get; set; }

        private DateTime CreateSzületésiDátum(string sz)
        {
            int M = int.Parse(sz.Split('-')[0]);
            sz = sz.Split('-')[1];


            int year = int.Parse(sz.Substring(0, 2));
            int month = int.Parse(sz.Substring(2, 2));
            int day = int.Parse(sz.Substring(4, 2));

            if (M == 1 || M == 2) year += 1900;
            else year += 2000;

            //im szó szarri
            return new DateTime(year, month, day);
        }
        public bool CdvEll {
            get {
                string sz = SzemélyiSzám.Replace("-", "");
                int checkSum = int.Parse(sz.Last().ToString()); //levágjuk a végét (10. index) -> K és stringre alakítom
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
            SzemélyiSzám = Sor; //álmodtam egy világot magamnak
            SzületésiDátum = CreateSzületésiDátum(Sor.Substring(2,6));
        }
        
    }
}
