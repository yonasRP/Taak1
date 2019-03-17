using DemoConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest {
  [TestClass]
  public class TestPersonenBestand {
    PersonenBestand personen = new PersonenBestand();
    public void InitBestand() {
      personen.Add(new Werknemer() { AchterNaam = "Doe",VoorNaam = "John",InDienst = DateTime.Now,Adres = "Mechelen" });
      personen.Add(new Klant() { AchterNaam = "Peeters",VoorNaam = "Lea",KortingsCode=1,Adres = "Brussel" });
      personen.Add(new Klant() { AchterNaam = "Vanderneffe",VoorNaam = "Leon",KortingsCode = 1,Adres = "Zonnedorp" });
      personen.Add(new Werknemer() { AchterNaam = "Jansens",VoorNaam = "Jan",InDienst = DateTime.Now,Adres = "Antwerpen" });
    }

    [TestMethod]
    public void TestWerknemerslijst() {
      InitBestand();
      Assert.IsTrue(personen.Werknemers.Count == 2);
    }
  }
}
