using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.Exercises {
  public delegate void CallbackFunction(int num,string txt);


  public class ConditionalExercise {
    public string EvaluateTemp(int temp) {
      if(temp < 10) {
        return "koud";
      } else if(temp < 20) {
        return "matig";
      } else if(temp < 30) {
        return "zalig";
      } else {
        return "heet";
      }
      /*
       * Vanaf C# 7 is dit ook mogelijk:
      switch(temp) {
        case int i when i < 10:
          return "koud";
        case int i when i < 20:
          return "matig";
        case int i when i < 30:
          return "zalig";
        default:
          return "heet";

      }
      */
    }
  }
}
