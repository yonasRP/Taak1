using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole.Exercises {
  public class NumberTests {
    public string ConvertCelcius(int _celcius) { return $"{_celcius} °C = {ToFahrenheit(_celcius)}°F en {ToKelvin(_celcius)}°Kelvin"; }
    public int ToFahrenheit(int _celcius) { return _celcius * 18 / 10 + 32; }
    public int ToKelvin(int _celcius) { return _celcius + 273; }
    public bool IsMultipleOf(int _number,int _mul) { return _number % _mul == 0; }
    public long Power(long _num,long _pow) {
      if(_pow == 0) return 1;
      long _res=_num;
      for(int i = 1;i < _pow;i++) { _res *= _num; }
      return _res;
    }
    public decimal Power(decimal _num,decimal _pow) {
      if(_pow == 0) return 1;
      decimal _res = _num;
      for(int i = 1;i < _pow;i++) { _res *= _num; }
      return _res;
    }
    public double Power(double _num,double _pow) {
      if(_pow == 0) return 1;
      double _res = _num;
      for(int i = 1;i < _pow;i++) { _res *= _num; }
      return _res;
    }
    public int Power(int _num,int _pow) {
       checked{
        return  (int)Power((long)_num,(long)_pow);
      }
    }
    public float Power(float _num,float _pow) {
      checked {
        return (float)Power((double)_num,(double)_pow);
      }
    }
    public float MySpeedInKmU(float _distMeters,int _hours,int _min,int _sec) {
      int totalSec = (_hours * Power(60,2)) + (_min * 60) + _sec;
      float _distMetersSec =   _distMeters/ (float)totalSec;
      float _distMetersHour = _distMetersSec * Power(60,2);
      return _distMetersHour / 1000;/*M->Km*/   
    }
    public float MySpeedInMilesU(float _distMeters,int _hours,int _min,int _sec) {
      return MySpeedInKmU(_distMeters,_hours,_min,_sec) / 1.609f;
    }
      public string ToBinary(int _number) {
      string res = "";
      int pow;
      for(int i = 16;i >= 0;i--) {
        pow = Power(2,i);
        if(_number >= pow ) {
          res += "1" + ((i > 0) ? " " : "");
          _number -= pow; 
        } else if(!string.IsNullOrEmpty(res)) {
          res += "0" + ((i > 0) ? " " : "");
        }
      }
      return res.Length > 0 ? res + " (bin)" : "";
    }
  }
}
