using DemoConsole.Oefeningen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTest {

  [TestClass]
  public class IntUnitTests {

    IntTests IntegerTest = new IntTests();
    [TestMethod]
    public void TestCelsius() {
      Assert.IsTrue(IntegerTest.CelsiusToFarenheit(0) == 32);
      Assert.IsTrue(IntegerTest.CelsiusToKelvin(0) == 273);
    }
    [TestMethod]
    public void TestVeelvoud() {
      Assert.IsTrue(IntegerTest.IsVeelvoud(20,10));
      Assert.IsFalse(IntegerTest.IsVeelvoud(20,7));
    }
    [TestMethod]
    public void TestMacht() {
      Assert.IsTrue(IntegerTest.Macht(2,0) == 1);
      Assert.IsTrue(IntegerTest.Macht(2,1) == 2);
      Assert.IsTrue(IntegerTest.Macht(2,2) == 4);
    }
  }
}
