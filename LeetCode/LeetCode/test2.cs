using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class test2
    {
        Dictionary<char, char[]> keypad = new Dictionary<char, char[]> {{'2', new char[]{'a', 'b', 'c'}},
    {'3', new char[]{'d', 'e', 'f'}}, {'4', new char[] {'g', 'h', 'i'}},
    {'5', new char[] {'j', 'k', 'l'}}, {'6', new char[] {'m', 'n', 'o'}},
    {'7', new char[] {'p', 'q', 'r', 's'}}, {'8', new char[] {'t', 'u', 'v'}},
    {'9', new char[] {'w', 'x', 'y', 'z'}}};
        public test2() { }
        public IList<string> LetterCombinations(string digits)
        {
            List<string> result = new List<string>();
            Add("", digits, 0, result);
            return result;
        }


        public void Add(string curr, string digits, int index, List<string> result)
        {
            if (index >= digits.Length) result.Add(curr);
            else
            {
                char[] chars = keypad[digits[index]];
                for (int i = 0; i < chars.Length; i++)
                {
                    string newCurr=curr+chars[i];
                    Add(newCurr, digits, index + 1, result);
                }

            }
        }
    }
}
