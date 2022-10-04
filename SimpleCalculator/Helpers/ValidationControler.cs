using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using System.Data;

namespace bf.api.Helpers
{
#pragma warning disable
    public class ValidationControler
    {

        static Regex regexpress;

        public static bool isNumeric(string source)
        {
            try
            {
                regexpress = new Regex(@"^(\+|-)?[0-9][0-9]*(\.[0-9]*)?$");
                return regexpress.IsMatch(source) ? true : false;
            }
            catch (Exception)
            {			
                return false;
            }
        }

        public static bool isDouble(string source)
        {
            try
            {
                double dbl = new double();
                return Double.TryParse(source, out dbl) ? true : false;
            }
            catch (Exception)
            {				
                return false;
            }
        }

        public static bool isDecimal(string source)
        {
            try
            {
                decimal dec=new decimal();
                return Decimal.TryParse(source, out dec) ? true : false;
            }
            catch (Exception)
            {				
                return false;
            }
        }

        public static bool isPositiveNumeric(string source)
        {
            try
            {
                regexpress = new Regex(@"^[0-9][0-9]*(\.[0-9]*)?$");
                return regexpress.IsMatch(source) ? true : false;
            }
            catch (Exception)
            {				
                return false;
            }
        }

    }
}
