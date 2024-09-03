using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEx
{
    public class RomanNumeral
    {
        public RomanNumeral()
        {
        }

        public string Get(int iInput)
        {
            string sMsg = "";
            Dictionary<int, ItemRoman> dic = new Dictionary<int, ItemRoman>();
            dic.Add(1, new ItemRoman() { Value = 1, Name = "I" });
            dic.Add(2, new ItemRoman() { Value = 4, Name = "IV" });
            dic.Add(3, new ItemRoman() { Value = 5, Name = "V" });
            dic.Add(4, new ItemRoman() { Value = 9, Name = "IX" });
            dic.Add(5, new ItemRoman() { Value = 10, Name = "X" });
            dic.Add(6, new ItemRoman() { Value = 40, Name = "XL" });
            dic.Add(7, new ItemRoman() { Value = 50, Name = "L" });
            dic.Add(8, new ItemRoman() { Value = 90, Name = "XC" });
            dic.Add(9, new ItemRoman() { Value = 100, Name = "C" });
            dic.Add(10, new ItemRoman() { Value = 400, Name = "CD" });
            dic.Add(11, new ItemRoman() { Value = 500, Name = "D" });
            dic.Add(12, new ItemRoman() { Value = 900, Name = "CM" });
            dic.Add(13, new ItemRoman() { Value = 1000, Name = "M" });

            while (dic.Count > 0)
            {
                ItemRoman ir = dic.GetValueOrDefault(dic.Count);

                //bool bResult = dic.TryGetValue(dic.Count, out ir);
                //int ipat = iInput / ir.Value;
                //iInput = iInput - (ipat * ir.Value);
                int iTotal = 0;
                sMsg += dd(iInput, ir.Value, ir.Name, out iTotal);
                iInput = iTotal;

               // sMsg += funPat(ir.Name, ipat);
                dic.Remove(dic.Count);
            }
            return sMsg;
        }
        public string dd(int iInput, int iValue,string sChar,out int total)
        {
            string sResult = "";
            total= 0;
            while (iInput >= iValue)
            {
                iInput= iInput - iValue;
                sResult += sChar;
            }
            total = iInput;
            return sResult;
        }

         public string funPat(string s, int ipat)
        {
            string sResult = "";
            for (int i = 1; i <= ipat; i++)
            {
                sResult += s;
            }
            return sResult;
        }
    }

    public class ItemRoman
    {
        public int Value { get; set; }

        public string Name { get; set; }

    }

}
