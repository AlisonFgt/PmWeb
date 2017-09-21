using System;
using System.Globalization;

namespace PmWeb.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool NotEquals(this DateTime dateTime, DateTime dateTime2)
        {
            return !dateTime.Equals(dateTime2);
        }

        public static string ToPtBr(this DateTime dateTime)
        {
            CultureInfo cult = new CultureInfo("pt-BR");
            string dta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", cult);
            return dta;
        }
    }
}
