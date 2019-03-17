using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.Oefeningen {
  public class StringTest {
    public string VerwijderChar(string txt,int pos) {
      if(!string.IsNullOrEmpty(txt) && pos >= 0 && pos < txt.Length) {
        txt = txt.Remove(pos,1);
      }
      return txt;
    }
    public string LangsteWoord(string zin) {
      string[] woorden = zin?.Split(new char[] { ' ',',',';',':' });
      string langsteWoord = "";
      //int sz = 0;
      /*
       *  foreach(string woord in words) {
       *  => We voegen ' ?? new string[] { }' toe.
       *  als de var 'woorden' leeg is dan wordt er een lege array aangemaakt.
      */
      foreach(string woord in woorden ?? new string[] { }) {
  /*
   * ook een correcte oplossing, maar het kan iets korter:
        if(woord.Length > sz) {
          sz = woord.Length;
          langsteWoord = woord;
        }
        */
        if(woord.Length > langsteWoord.Length) {
          langsteWoord = woord;
        }
      }
      return langsteWoord;
    }
    public string Omgekeerd(string zin) {
      string[] woorden = zin.Split(' ');
      string omgekeerdeZin ="";
      for(int i = woorden.Length-1;i >= 0;i--) {
        omgekeerdeZin += woorden[i] + ((i == 0) ? "" : " ");
      }
      return omgekeerdeZin;
    }
  }
 
}
