using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoConsole.Oefeningen;

namespace DemoConsole
{
    public class Maaltijd : Voedingswaar
    {
        public Recept recept;
    }

    public class Drank : Voedingswaar
    {
    }

    public abstract class Voedingswaar
    {
        public string Naam;
        public int Prijs;
    }

    public class Ingredient
    {
        public string Naam;
    }
    
    public class Menu
    {
        public void export()
        {
            var filepath = "C:/Users/Yonas/Desktop/Data/Menu.csv";
            using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
            FileMode.Create, FileAccess.Write)))
            {
                foreach (Maaltijd m in Maaltijden)
                    writer.WriteLine(m.Naam + ": " + m.Prijs);
                foreach (Drank d in Drank)
                    writer.WriteLine(d.Naam + ": " + d.Prijs);

            }

        }
        public List<Voedingswaar> voeding = new List<Voedingswaar>();
        public List<Drank> Drank
        {
            get
            {
                List<Drank> drank = new List<Drank>();
                foreach (Voedingswaar vw in voeding)
                {
                    if (vw is Drank dr)
                    {
                        drank.Add(dr);
                    }
                }
                return drank;
            }
        }
        public List<Maaltijd> Maaltijden
        {
            get
            {
                List<Maaltijd> mt = new List<Maaltijd>();
                foreach (Voedingswaar vw in voeding)
                {
                    if (vw is Maaltijd ma)
                    {
                        mt.Add(ma);
                    }
                }
                return mt;
            }
        }
    }
}
