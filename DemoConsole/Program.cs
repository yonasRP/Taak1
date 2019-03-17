using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole {

  class Program {
    
    static void Main(string[] args) {
      AppCommands commands= new AppCommands();
      bool isExit = false;
      string cmd;
      do {
        Console.Write(">"); // Write a prompt
        cmd=Console.ReadLine();
        isExit= commands.Execute(cmd);
        Console.WriteLine();
      } while(!isExit);

    }
  }
}
