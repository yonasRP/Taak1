using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.Oefeningen {
  public class Recept {
       public List<IFavoriet> favorietRecept = new List<IFavoriet>();
       //uy public List<IFavoriet> favorietRecept = new List<IFavoriet>();
        public delegate void MijnAanpassingenCb(Recept ikke);
    public enum ReceptTypes { Voorgerecht, Soep, Hoofdgerecht, Dessert }
        public void export()
        {
            //this neemt direct de naam.
            var filepath = "C:/Users/Yonas/Desktop/Data/" + this.Naam + ".csv";
            using (StreamWriter writer = new StreamWriter(new FileStream(filepath,
            FileMode.Create, FileAccess.Write)))

            {

                writer.WriteLine(this.Naam);
                writer.WriteLine(this.ReceptType);
                writer.WriteLine(this.Werkwijze);
                // declaratie functie result
                for (int i = 0; i < this.Ingredienten.Count; i++)

                    writer.WriteLine(this.Ingredienten[i]);

            }

        }

        
    public Recept(){ }
    public Recept(string naam,ReceptTypes myType,Ingredient [] ingredienten=null,string werkwijze = "") {
      Naam = naam;
      ReceptType = myType;
      Werkwijze = werkwijze;
      if(ingredienten != null) { Ingredienten.AddRange(ingredienten); }
    }
    public string Naam { get; set; }
    public ReceptTypes ReceptType { get; set; }
    public List<Ingredient> Ingredienten { get; set; } = new List<Ingredient>();
    public string Werkwijze { get; set; }
    //public MijnAanpassingenCb Aanpassingen { get; set; }
    public void Print() {
      Console.WriteLine(Naam);
      Console.WriteLine("\tIngrediënten:");
      foreach(Ingredient ingr in Ingredienten) {
        Console.WriteLine($"\t\t{ingr.Naam}");
      }
      Console.WriteLine("\tWerkwijze:");

      Console.WriteLine($"\t\t{Werkwijze}");
            Console.WriteLine();
            foreach (IFavoriet a in favorietRecept) {

                a.print();
                Console.WriteLine();
            }
    }
    }
  public class FavorietRecept : IFavoriet
    {
    public FavorietRecept(string mijnNaam,string mijnRecept) {
      VoorNaam =mijnNaam;
      recept = mijnRecept;
    }
    public string VoorNaam { get; set; }
    public string recept { get; set; }

        public void print()
        {
            Console.WriteLine($"Het favoriete recept van {VoorNaam} is:");
            Console.WriteLine(recept);
        }
    }
   public interface IFavoriet
    {
        void print();
    } 
}
