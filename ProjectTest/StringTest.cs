using System;
using DemoConsole.Oefeningen;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTest {
  [TestClass]
  public class StringUnitTest {
 
    StringTest strTest = new StringTest();
    [TestMethod]
    public void TestRemove() {
      string testValue = "SyntraAB";
      int testPos = 6;
      string res = strTest.VerwijderChar(testValue,testPos);
      Assert.IsTrue(res == "SyntraB");
      testValue = "fout";
      testPos = 8;
      res = strTest.VerwijderChar(testValue,testPos);
      Assert.IsTrue(res == "fout");

    }
    [TestMethod]
    public void TestOmgekeerdeZin() {
      string input = "Voor elke oplossing is wel een probleem te vinden";
      Assert.IsTrue(strTest.Omgekeerd(input) == "vinden te probleem een wel is oplossing elke Voor");
    }
  [TestMethod]
    public void TestLangsteWoord() {
      string zin = "Wie met de stroom meedrijft, is het eerste bij het afvoerputje";
      Assert.IsTrue(strTest.LangsteWoord(zin) == "afvoerputje");
    }


  }
}
