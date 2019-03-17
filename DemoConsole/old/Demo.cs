using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.Exercises {
  public class CallbackDemo {
    public CallbackFunction myCallback = null;
    public CallbackDemo(CallbackFunction cb) { myCallback = cb; }
    public CallbackDemo() { }
    public void DoSomeWork() { if(myCallback != null) { myCallback(20,"Charel"); } }
  }
  public class PrintClass {
    public static void Print(int score,string name) {
      Console.WriteLine($"{name} heeft {score} punten!");
    }
  }
  public class SuperPrintClass {
    public static void Print(int score,string name) {
      Console.WriteLine($"Joepie voor de {name} want die heeft {score} punten!");
    }
  }



  public class Person {
    public string lastName;
    public string firstName;
    public string address;
  }
  public class Client:Person {
    public string clientID;
  }

}
