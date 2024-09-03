using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLinkNodeAddSum
{
    public static class LengthOfLongestSubstringCS
    {
        public static int LengthOfLongestSubstring(string s)
        {
            if (s.Length == 1)
                return 1;
            int left=0;
            int right = 1;
            int MaxLength = 0;
            while (right < s.Length)
            {
                for (int i = left; i < right; i++)
                {
                    if (s[i] == s[right])
                    {
                        left = i + 1;
                    }
                }
                MaxLength = Math.Max(MaxLength, right - left + 1);
                right++;
            }
            return MaxLength;
        }

    }
}
