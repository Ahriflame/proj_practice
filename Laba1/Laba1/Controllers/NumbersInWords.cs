using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Laba1.Controllers
{

    [ApiController]
    [Route("number/{index}")]

    public class NumbersInWords : ControllerBase
    {

        private static string EndUnitsAndTens(byte Dek, bool IsMale)
        {
            if ((Dek > 2) || (Dek == 0)) return "";
            else if (Dek == 1)
            {
                if (IsMale) return "ин"; else return "на";
            }
            else
            {
                if (IsMale) return "а"; else return "е";
            }
        }

        private static string EndLargeDischarges(byte ThNum, byte Dek)
        {
            bool In234 = ((Dek >= 2) && (Dek <= 4));
            bool More4 = ((Dek > 4) || (Dek == 0));
            if (((ThNum > 2) && In234) || ((ThNum == 2) && (Dek == 1))) return "а";
            else if ((ThNum > 2) && More4) return "ов";
            else if ((ThNum == 2) && In234) return "и";
            else return "";
        }
        public static string GetWords(ulong Value, bool IsMale)
        {
            if (Value == 0UL) return "Ноль";
            string[] UnitsAndTens = { "", " од", " дв", " три", " четыре", " пять", " шесть", " семь", " восемь", " девять", " десять", " одиннадцать", " двенадцать", " тринадцать", " четырнадцать", " пятнадцать", " шестнадцать", " семнадцать", " восемнадцать", " девятнадцать" };
            string[] Tens = { "", "", " двадцать", " тридцать", " сорок", " пятьдесят", " шестьдесят", " семьдесят", " восемьдесят", " девяносто" };
            string[] Hundreds = { "", " сто", " двести", " триста", " четыреста", " пятьсот", " шестьсот", " семьсот", " восемьсот", " девятьсот" };
            string[] LargeDischarges = { "", "", " тысяч", " миллион", " миллиард", " триллион", " квадрилион", " квинтилион" };
            string str = "";
            for (byte th = 1; Value > 0; th++)
            {
                ushort gr = (ushort)(Value % 1000);
                Value = (Value - gr) / 1000; if (gr > 0)
                {
                    byte d3 = (byte)((gr - gr % 100) / 100); byte d1 = (byte)(gr % 10); byte d2 = (byte)((gr - d3 * 100 - d1) / 10);
                    if (d2 == 1) d1 += (byte)10; 
                    bool ismale = (th > 2) || ((th == 1) && IsMale); 
                    str = Hundreds[d3] + Tens[d2] + UnitsAndTens[d1] + EndUnitsAndTens(d1, ismale) + LargeDischarges[th] + EndLargeDischarges(th, d1) + str;
                }
            }
            str = str.Substring(1, 1).ToUpper() + str.Substring(2); return str;
        }
        
        public string GetNumber(int index)
        {
 
            return GetWords(Convert.ToUInt64(index), false).ToString();
        }
    }
}
