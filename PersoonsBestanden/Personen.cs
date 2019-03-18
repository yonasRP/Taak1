using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole
{

    public class Persoon
    {
        public string VoorNaam { get; set; } = "";
        public string Boodchap { get; set; } = "";
        public string Naam { get; set; } = "";
        public string Titel { get; set; } = "";
        public string AchterNaam { get; set; } = "";
        public Adres adres;
        public enum Geslacht {mijnheer = 1, mevrouw = 2 };
        public int geslacht;

        public string Contacteer(string boodschap, string naam, string titel)
        {
            boodschap = Boodchap;
            naam = Naam;
            titel = Titel;

            if (this is Klant)
            return $@"Aan: {adres.ToString()} 
                    
Beste {(Geslacht)geslacht} {VoorNaam}, 

{boodschap} 

Hoogachtend, 

{naam} 
{titel} ";
           else
                return $@"Aan: {adres.ToString()} 
                    
Beste {VoorNaam}, 

{boodschap} 

Met vriendelijke groet, 

{naam} 
{titel} ";
        }
    }
    public class Werknemer : Persoon
    {
        DateTime _inDienst = DateTime.Now;
        public DateTime InDienst { get { return _inDienst; } set { _inDienst = value; } }
    }
    public class Klant : Persoon
    {
        public short KortingsCode { get; set; }

        public List<Ingredient> Allergie = new List<Ingredient>(); 

        public List<string> Bestel(List<Voedingswaar> bestelling)
        {
            List<string> alergien = new List<string>();
            foreach (Ingredient ingridient in Allergie)
            {
                foreach (Voedingswaar vw in bestelling) {
                    if(vw is Maaltijd malt)
                    foreach (Ingredient i in malt.recept.Ingredienten)
                    {
                        if (ingridient == i)
                        {
                            alergien.Add(vw.Naam + ": zal zonder " + ingridient.Naam + " worden bereidt; ");
                        }

                    }
                }
            }
            return alergien;
        }
        public void mail()
        {
            //geen idee wat we moeten doen hiermee?
        }
    }
    public class Adres
    {
        public enum AdresType { Thuisadres = 1, Kantooradres = 2, Buitenverblijf = 3 };

        public string Straat = "";
        public int Huisnummer;
        public int Postcode;
        public string Gemeente = "";
        public string Land = "";
        public int Typenr;
        public string Busnr = "";
        
        public Adres (string straat, int huisnummer, int postcode, string gemeente, string land, int typenr, string busnr)
        {
            Straat = straat;
            Huisnummer = huisnummer;
            Postcode = postcode;
            Gemeente = gemeente;
            Land = land;
            Typenr = typenr;
            Busnr = busnr;
        }


        public override string ToString()
        {
            return $@"Locatie: {(AdresType)Typenr} 

{Straat}
{Huisnummer}{Busnr}
{Postcode} {Gemeente}
{Land}";
        }
    }
}
