using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Utility
{
    internal static class Vat
    {
        public static double Get(string country)
        {
            double vat = 0;
            country = country.ToUpper();

            if (country == Enum.Parse(typeof(Country), country).ToString()) vat = 0.2d;

            return vat;
        }
    }
}
