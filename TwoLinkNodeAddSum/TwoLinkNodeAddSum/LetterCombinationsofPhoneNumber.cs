using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLinkNodeAddSum
{
    public class LetterCombinationsofPhoneNumber
    {
        public static IList<string> LetterCombinations(string digits)
        {
            if (string.IsNullOrWhiteSpace(digits))
                return new List<string>();

            var list = new List<string>();
            var map = new Dictionary<int, string>() {
            { 2, "abc" },
            { 3, "def" },
            { 4, "ghi" },
            { 5, "jkl" },
            { 6, "mno" },
            { 7, "pqrs" },
            { 8, "tuv" },
            { 9, "wxyz" }
        };

            LetterCombinationsUntil(digits, map, list, 0, "");
            return list;
        }

        private static void LetterCombinationsUntil(string digits, Dictionary<int, string> map, List<string> list, int idx, string str)
        {
            if (str.Length == digits.Length)
            {
                list.Add(str);
                return;
            }

            foreach (var chr in map[digits[idx] - '0'])
                LetterCombinationsUntil(digits, map, list, idx + 1, str + chr);
        }

    }
}
