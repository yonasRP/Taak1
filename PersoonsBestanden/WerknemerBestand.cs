using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole {
  public class PersonenBestand {
    List<Persoon> _lijst = new List<Persoon>();
        public void ExportWerknemers()
        {
            var filepath = "C:/Users/Yonas/Desktop/Data/Werknemers.csv";//aanpassen
            using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
            FileMode.Create, FileAccess.Write)))
            {
                foreach (Werknemer w in Werknemers)
                {
                    writer.WriteLine(w.VoorNaam);
                }
            }
        }

        public void ExportKlanten()
        {
            var filepath = "C:/Users/Yonas/Desktop/Data/Klanten.csv";
            using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
            FileMode.Create, FileAccess.Write)))
            {
                foreach (Klant k in Klanten)
                {
                    writer.WriteLine(k.VoorNaam);
                }
            }
        }

    public List<Persoon> Lijst {
      get {
        return _lijst;
      }
      protected set {
        _lijst = value;
      }
    }
    public void Add(Persoon persoon) {
      Lijst.Add(persoon);
    }
    public bool Remove(Persoon persoon) {
      return Lijst.Remove(persoon);
    }
    public bool Remove(string achternaam) {
      return Remove(Find(achternaam));
    }
    public Persoon Find(string achternaam) {
      foreach(Persoon persoon in Lijst) {
        if(persoon.AchterNaam.ToLower() == achternaam.ToLower()) return persoon;
      }
      return null;
    }
    public List<Werknemer> Werknemers {
      get {
        List<Werknemer> werknemers = new List<Werknemer>();
        foreach(Persoon persoon in Lijst) {
          if(persoon is Werknemer mijnWerknemer)
          {
            werknemers.Add(mijnWerknemer);
          }
        }
        return werknemers;
      }
    } 
    public List<Klant> Klanten {
      get {
        List<Klant> klanten = new List<Klant>();
        foreach(Persoon persoon in Lijst) {
          if(persoon is Klant mijnKlant)
          {
            klanten.Add(mijnKlant);
          }
        }
        return klanten;
      }
    }
  }
}
