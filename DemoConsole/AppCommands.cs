using DemoConsole.Oefeningen;
using System;
using System.Collections.Generic;
using System.IO;

namespace DemoConsole
{

    public class AppCommands
    {
        Menu menu;
        Ingredient tomaat = new Ingredient { Naam = "tomaat" };
        Ingredient kaas = new Ingredient { Naam = "kaas" };
        Ingredient salami = new Ingredient { Naam = "salami" };
        public void InitBestand()
        {
            menu = new Menu() { voeding = new List<Voedingswaar> {new Drank { Naam = "cola", Prijs = 2}, new Drank{ Naam = "water", Prijs = 1}, new Maaltijd {Naam = "tomatensoep", Prijs = 5,
            recept = new Recept("tomatensoep", Recept.ReceptTypes.Soep, new Ingredient[] { tomaat }, "Stoof alles op, voeg water toe en kook tot het gaar is")},
           new Maaltijd {Naam = "pizza", Prijs = 8,
            recept = new Recept("pizza salami", Recept.ReceptTypes.Soep, new Ingredient[] { tomaat, salami, kaas }, "Maak het deeg en plaats alle ingredienten erop, dan in de oven voor 9 min")} } };
            personen.Add(new Klant() { AchterNaam = "Peeters", VoorNaam = "Lea", KortingsCode = 1, adres = new Adres("6649 N Blue Gum St",69,70116, "New Orleans","'Murrrica",2,"3"), Allergie = new List<Ingredient> {tomaat } });
            personen.Add(new Klant() { AchterNaam = "Vanderneffe", VoorNaam = "Leon", KortingsCode = 1, adres = new Adres("1268 N Red Gum St", 6969, 70116, "New Orleans", "'Murrrica", 2, "4") });
            
        }
        //  static AppCommands() { Console.WriteLine("CLI mounted"); }
        public PersonenBestand personen = new PersonenBestand();
        public bool Execute(string command)
        {
            bool isExit = false;
            Persoon persoon;
            InitBestand();
            IntTests intTst = new IntTests();
            StringTest strTest = new StringTest();
            try
            {
                string[] args = command?.Split(' ') ?? new string[] { };
                if (args.Length > 0)
                {
                    switch (args[0]?.ToLower().Trim())
                    {
                        case "recepten":
                            Recept mijnRecept = new Recept("tomatensoep", Recept.ReceptTypes.Soep, new Ingredient[] { }, "Stoof alles op, voeg water toe en kook tot het gaar is");
                            FavorietRecept mia = new FavorietRecept("Mia", "Ik stoof niet aan maar kook alles");
                            FavorietRecept jef = new FavorietRecept("Jef", "Ik doe er korstjes bij");

                            mijnRecept.favorietRecept.Add(mia);
                            mijnRecept.favorietRecept.Add(jef);
                            mijnRecept.Print();
                            break;
                        case "bestelling":
                            Recept recept = new Recept();
                            Console.WriteLine("---------------");
                            Console.WriteLine("Welkom in het Eethuisje");
                            Console.WriteLine("---------------");
                            Console.WriteLine();
                            bool test = false;
                            Klant klant = new Klant();
                            do {
                                Console.WriteLine("Wat is uw naam?");
                                string KlantNaam = Console.ReadLine();
                                
                                foreach (Klant kl in personen.Klanten)
                                {
                                    if (kl.VoorNaam == KlantNaam)
                                    {
                                        Console.WriteLine("Welkom " + kl.VoorNaam + "!");
                                        klant = kl;
                                        test = true;

                                    }
                                }

                            } while (test == false);
                            Console.WriteLine("Het menu");
                            Console.WriteLine("----------------------------");
                            foreach (Maaltijd mt in menu.Maaltijden)
                            {
                                Console.WriteLine(mt.Naam + " " + mt.Prijs + "eur");
                                Console.WriteLine("----------------------------");
                                for(int i = 0; i < mt.recept.Ingredienten.Count; i++ )
                                Console.WriteLine(mt.recept.Ingredienten[i].Naam);
                                
                                Console.WriteLine("Werkwijze:");
                                Console.WriteLine(mt.recept.Werkwijze);
                                Console.WriteLine("----------------------------");

                            }

                            foreach (Drank dr in menu.Drank)
                            {
                                Console.WriteLine(dr.Naam + ": " + dr.Prijs + "eur");
                                Console.WriteLine("----------------------------");
                            }

                            Console.WriteLine("Wat is de bestelling? (Type 'stop' om te stoppen)");
                            string bestelling = "";
                            List<Voedingswaar> vw = new List<Voedingswaar>();
                            
                            do
                            {bool added = false;
                                bestelling = Console.ReadLine();
                                foreach (Voedingswaar v in menu.voeding)
                                {
                                    if (bestelling == v.Naam)
                                    {
                                        added = true;
                                    vw.Add(v);
                                    }
                                }
                                if (!added && bestelling != "stop")
                                    Console.WriteLine("Niet gevonden.");

                            } while (bestelling != "stop");
                            Console.WriteLine();
                            if (vw != null)
                            {
                                foreach (string alergie in klant.Bestel(vw))
                                    Console.WriteLine(alergie);

                            }

                            
                            Console.WriteLine("De bestellingen zijn:");
                            int totaal = 0;
                            foreach (Voedingswaar v in vw)
                            {
                                Console.WriteLine(v.Naam);
                                totaal += v.Prijs;
                            }

                            Console.WriteLine($"Het totaal bedrag is : {totaal}eur.");
                            

                            


                            

                            break;
                        case "exit":
                            isExit = true;
                            break;
                        case "cls":
                        case "clear":
                            Console.Clear();
                            break;
                        case "find":
                            Console.WriteLine("achternaam : ");
                            persoon = personen.Find(Console.ReadLine());
                            if (persoon == null)
                            {
                                Console.WriteLine("Niet gevonden");
                            }
                            else
                            {
                                Console.WriteLine($"Naam: {persoon.VoorNaam} {persoon.AchterNaam}  Adres: {persoon.adres}");
                            }
                            break;
                        case "remove":
                            Console.Write("Wie? Geef de achternaam: ");
                            if (personen.Remove(Console.ReadLine()))
                            {
                                Console.WriteLine("Gelukt");
                            }
                            else
                            {
                                Console.WriteLine("Niet gevonden");
                            }
                            break;
                        case "getfiles":
                            Console.WriteLine("Geef Directory path");
                            string[] filePaths = Directory.GetFiles(Console.ReadLine());

                            if (filePaths == null)
                            {
                                Console.WriteLine("Geen Files");
                            }
                            else
                            {
                                foreach (string path in filePaths)
                                {
                                    FileInfo info = new FileInfo(path);
                                    Console.WriteLine(path);
                                    Console.WriteLine("My File's Name: \"" + info.Name + "\"");
                                    DateTime dtCreationTime = info.CreationTime;
                                    Console.WriteLine("Date and Time File Created: " + dtCreationTime.ToString());
                                    Console.WriteLine("myFile Extension: " + info.Extension);
                                    Console.WriteLine("myFile total Size: " + info.Length.ToString());
                                    Console.WriteLine("myFile filepath: " + info.DirectoryName);
                                    Console.WriteLine("My File's Full Name: \"" + info.FullName + "\"");
                                    Console.WriteLine();

                                }
                            }
                            break;
                        case "readcsv":
                            try
                            {
                                string csv = File.ReadAllText(@"C:\Users\Maxwell\Desktop\contacts.csv");
                                Console.WriteLine(csv);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("File kan niet gelezen worden");
                                Console.WriteLine(e.Message);
                            }
                            Console.Read();
                            break;
                        case "contacteer":
                            Console.Write("Achternaam: ");
                            persoon = personen.Find(Console.ReadLine());
                            if (persoon == null)
                            {
                                Console.WriteLine("Niet gevonden");
                            }
                            else
                            {
                                Console.Write("Geef uw boodschap: ");
                                persoon.Boodchap = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Geef uw naam: ");
                                persoon.Naam = Console.ReadLine();
                                Console.WriteLine();
                                Console.Write("Geef uw titel: ");
                                persoon.Titel = Console.ReadLine();
                                Console.WriteLine("--------------------");
                                Console.WriteLine(persoon.Contacteer(persoon.Boodchap, persoon.Naam, persoon.Titel));
                                Console.WriteLine("--------------------");
                            }
                            break;
                        case "listwerknemers":
                            foreach (Werknemer onderdaan in personen.Werknemers)
                            {
                                Console.WriteLine();
                                Console.WriteLine(onderdaan.VoorNaam);
                                Console.WriteLine(onderdaan.AchterNaam);
                                Console.WriteLine();
                                Console.WriteLine(onderdaan.adres);
                                Console.WriteLine();
                                Console.WriteLine("--------------------");
                            }
                            break;
                        case "listklanten":
                            foreach (Klant klnt in personen.Klanten)
                            {
                                Console.WriteLine();
                                Console.WriteLine(klnt.VoorNaam);
                                Console.WriteLine(klnt.AchterNaam);
                                Console.WriteLine();
                                Console.WriteLine(klnt.adres);
                                Console.WriteLine();
                                Console.WriteLine("--------------------");
                            }
                            break;
                        case "addwerknemer":
                            Werknemer deNieuweW = new Werknemer();
                            Console.Write("Voornaam: ");
                            deNieuweW.VoorNaam = Console.ReadLine();
                            Console.Write("Achternaam: ");
                            deNieuweW.AchterNaam = Console.ReadLine();
                            Console.Write("Geslacht: 1. Man / 2. Vrouw (geef getal): ");
                            deNieuweW.geslacht = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Land: ");
                            deNieuweW.adres.Land = Console.ReadLine();
                            Console.Write("Postcode: ");
                            deNieuweW.adres.Postcode = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Gemeente: ");
                            deNieuweW.adres.Gemeente = Console.ReadLine();
                            Console.Write("Straat: ");
                            deNieuweW.adres.Straat = Console.ReadLine();
                            Console.Write("Huisnummer: ");
                            deNieuweW.adres.Huisnummer = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Bus letter (Indien niet nodig, druk ENTER zonder iets in te vullen): ");
                            deNieuweW.adres.Busnr = Console.ReadLine();
                            if (deNieuweW.adres.Busnr == null)
                            {
                                deNieuweW.adres.Busnr = "";
                            }
                            Console.Write("Huistype: 1. Thuis / 2. Kantoor / 3. Buitenverblijf (geef getal): ");
                            deNieuweW.adres.Typenr = Convert.ToInt32(Console.ReadLine());
                            personen.Add(deNieuweW);
                            break;
                        case "addklant":
                            Klant deNieuweK = new Klant();
                            Console.Write("Voornaam: ");
                            deNieuweK.VoorNaam = Console.ReadLine();
                            Console.Write("Achternaam: ");
                            deNieuweK.AchterNaam = Console.ReadLine();
                            Console.Write("Geslacht: 1. Man / 2. Vrouw (geef getal): ");
                            deNieuweK.geslacht = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Land: ");
                            deNieuweK.adres.Land = Console.ReadLine();
                            Console.Write("Postcode: ");
                            deNieuweK.adres.Postcode = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Gemeente: ");
                            deNieuweK.adres.Gemeente = Console.ReadLine();
                            Console.Write("Straat: ");
                            deNieuweK.adres.Straat = Console.ReadLine();
                            Console.Write("Huisnummer: ");
                            deNieuweK.adres.Huisnummer = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Bus letter (Indien niet nodig, druk ENTER zonder iets in te vullen): ");
                            deNieuweK.adres.Busnr = Console.ReadLine();
                            if (deNieuweK.adres.Busnr == null)
                            {
                                deNieuweK.adres.Busnr = "";
                            }
                            Console.Write("Huistype: 1. Thuis / 2. Kantoor / 3. Buitenverblijf (geef getal): ");
                            deNieuweK.adres.Typenr = Convert.ToInt32(Console.ReadLine());
                            personen.Add(deNieuweK);
                            break;
                        default:
                            Console.WriteLine("Ongekend commando");
                            break;
                    }
                }
            }
            catch (Exception error) { Console.WriteLine(error.ToString()); }
            return isExit;
        }
    }
}
