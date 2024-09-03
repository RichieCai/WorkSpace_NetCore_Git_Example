using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LongestValidParenthesesCS
    {
        public LongestValidParenthesesCS()
        {
        
        }
        public int LongestValidParentheses(string s)
        {
            int sLen = s.Length, longestValidParentheses = 0, left = -1, right = -1, leftBracketCounter = 0;
            // checking left to right
            while (++right < sLen)             // O(n)
            {
                leftBracketCounter += s[right] == '(' ? 1 : -1;
                // if balanced
                if (leftBracketCounter == 0)
                    longestValidParentheses = Math.Max(longestValidParentheses, right - left);
                else if (leftBracketCounter < 0)
                {
                    left = right;
                    leftBracketCounter = 0;
                }
            }
            // now check right to left
            left = sLen;
            right = sLen;
            leftBracketCounter = 0;
            while (--right >= 0)               // O(n)
            {
                leftBracketCounter += s[right] == ')' ? 1 : -1;
                // if balanced
                if (leftBracketCounter == 0)
                    longestValidParentheses = Math.Max(longestValidParentheses, left - right);
                else if (leftBracketCounter < 0)
                {
                    left = right;
                    leftBracketCounter = 0;
                }
            }
            return longestValidParentheses;
        }
    }
}
