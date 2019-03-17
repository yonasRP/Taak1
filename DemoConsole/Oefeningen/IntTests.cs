using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.Oefeningen {
  public class IntTests {
    public int CelsiusToFarenheit(int celsius) {
      return celsius * (18 / 10) + 32;
    }
    public int CelsiusToKelvin(int celsius) {
      return celsius + 273;
    }
    public bool IsVeelvoud(int x,int y) {
      return (x % y == 0);
    }
    public float MijnSnelheidInKmU(float _distMeters,int _hours,int _min,int _sec) {
      int totalSec = (_hours * Macht(60,2)) + (_min * 60) + _sec;
      float _distMetersSec = _distMeters / (float)totalSec;
      float _distMetersHour = _distMetersSec * Macht(60,2);
      return _distMetersHour / 1000;/*M->Km*/
    }
    public float MijnSnelheidInMijlen(float _distMeters,int _hours,int _min,int _sec) {
      return MijnSnelheidInKmU(_distMeters,_hours,_min,_sec) / 1.609f;
    }
    public int Macht(int hetGetal,int deMacht) {
      if(deMacht == 0) return 1;
      int res = 1;
      for(int i = 1;i <= deMacht;i++) { res = res * hetGetal; }
      return res;
    }
    public string ToBinary(int eenGetal) {
      string res = "";
      for(int i = 16;i >= 0;i--) {
        int m = Macht(2,i);
        if(eenGetal >= m) {
          eenGetal -= m;
          res += "1 ";
        } else if(res.Length>0){
          res += "0 ";
        }
      }
      res += res.Length < 1 ? "0 (bin)" : "(bin)";
      return res;
    }
  }
}
