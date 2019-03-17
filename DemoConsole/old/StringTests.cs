using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.Exercises {
  public class StringTests {
    public string RemoveChar(string _txt,int _charPos) {
      if(_charPos>=0 && _charPos < _txt?.Length) {
        return _txt?.Remove(_charPos,1);
      }
      return _txt;
    }
    public string LongestWord(string _text) {
      string[] words = _text.Split(' ');
      int pos = -1;
      int biggest = 0;
      for(int i = 0;i < words?.Length ;i++) {
        if(words[i]?.Length > biggest) {
          biggest = words[i].Length;
          pos = i;
        }
      }
      return pos >= 0 ? words[pos] : string.Empty;
    }

    public string ReverseWords(string _text) {
      string[] words = _text?.Split(' ');
      string res="";
      if(words?.Length > 0) {
        for(int i = words.Length-1;i >=0 ;i--) {
          res += words[i] + (i > 0 ? " " : "");
        }
      }
      return res;
    }
  }
}
