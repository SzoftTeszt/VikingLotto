using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kozos
{
    public class Szamok
    {
        public Szamok()
        {
        }

        public Szamok(string sor)
        {
            //var darabolt = sor.Split(';');
            string[] darabolt = sor.Trim().Split(';');
            if (darabolt.Length == 6)
            {
                int[] tombSzamok= new int[6];

                for (int i = 0; i < 6; i++)
                {
                    try {
                        tombSzamok[i]= Convert.ToInt32(darabolt[i].Trim());
                    }

                    catch (Exception ex)
                    {
                        throw new Exception("Hibás számformátum!");
                    }
                    if  ((tombSzamok[i]<1) || (tombSzamok[i]>48))
                        throw new Exception("A számnak 1 és 48 között kell lennie!");
                   
                    //if (!int.TryParse(darabolt[i], out int szam))

                }
                HashSet<int> szamokHalmaz = new HashSet<int>(tombSzamok);
                if (szamokHalmaz.Count != 6)
                {
                    throw new Exception("A számok nem lehetnek ismétlődőek!");
                }
                Szam1 = tombSzamok[0];
                Szam2 = tombSzamok[1];
                Szam3 = tombSzamok[2];
                Szam4 = tombSzamok[3];
                Szam5 = tombSzamok[4];
                Szam6 = tombSzamok[5];
            }
            else {
                throw new Exception("Hibás elemszám!");
            }
           
        }

        public int Id { get; set; }
        public int Szam1 { get; set; }
        public int Szam2 { get; set; }
        public int Szam3 { get; set; }
        public int Szam4 { get; set; }
        public int Szam5 { get; set; }
        public int Szam6 { get; set; }


    }
}
