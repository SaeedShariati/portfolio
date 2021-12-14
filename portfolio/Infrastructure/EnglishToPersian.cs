using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace portfolio.Infrastructure
{
    public static class EnglishToPersian
    {
        public static string ToPersianDigits(this string Number)
        {
            char[] persianDigits = new char[] { '۰', '۱', '۲', '۳', '۴', '۵', '۶', '۷', '۸', '۹' };
            foreach(char c in Number)
            {
                Number = Number.Replace(c, persianDigits[Int32.Parse(c.ToString())]);
            }
            return Number;
        }

    }
}
