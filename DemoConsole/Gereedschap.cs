using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoConsole
{
    public static class Gereedschap
    {
        public static bool IsNullOrEmpty(this Array test)
        {
            return test?.Length > 0;
        }

        public static bool IsNullOrEmpty(this string test)
        {
            return !string.IsNullOrEmpty(test);
            //return test?.Length > 0;
            
        }

        public static string ToCaps(this string test)
        {
            return test.Length > 0 ? test?.Substring(0,1).ToUpper() + test.Substring(1) : null;
        }
    }
}
