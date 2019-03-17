using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole {
  public static class ExtensionHelper {
    public static string ArgsAsString(this string _cmd) {
      if(!string.IsNullOrEmpty(_cmd)) {
        int start = _cmd.IndexOf(' ');
        if(start > 0) { return _cmd.Substring(start); }
      }
      return _cmd;
    }
    public static bool HasParams(this string[] _args) { return _args?.Length > 1; }
    public static long Pow(this long _num,long _pow) {
      if(_pow == 0) return 1;
      long _res = _num;
      for(int i = 1;i < _pow;i++) { _res *= _num; }
      return _res;
    }
    public static decimal Pow(this decimal _num,decimal _pow) {
      if(_pow == 0) return 1;
      decimal _res = _num;
      for(int i = 1;i < _pow;i++) { _res *= _num; }
      return _res;
    }
    public static double Pow(this double _num,double _pow) {
      if(_pow == 0) return 1;
      double _res = _num;
      for(int i = 1;i < _pow;i++) { _res *= _num; }
      return _res;
    }
    public static int Pow(this int _num,int _pow) {
      checked {
        return (int)Pow((long)_num,(long)_pow);
      }
    }
    public static float Pow(this float _num,float _pow) {
      checked {
        return (float)Pow((double)_num,(double)_pow);
      }
    }
  }
}
