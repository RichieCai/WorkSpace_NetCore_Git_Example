using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class TrappingRainWater
    {
        public TrappingRainWater()
        {

        }

        public int Trap(int[] height)
        {

            int maxHeight = 0;
            int len = height.Length;
            int[] trap = new int[len];
            for (int i = 0; i < len; i++)
            {
                trap[i] = maxHeight;
                maxHeight = Math.Max(maxHeight, height[i]);
            }

            maxHeight = 0;
            int result = 0;
            for (int i = len - 1; i >= 0; i--)
            {
                trap[i] = Math.Max(Math.Min(trap[i], maxHeight) - height[i], 0);
                maxHeight = Math.Max(maxHeight, height[i]);

                result += trap[i];
            }

            return result;
        }

        public int CountData(int L, int R, int[] height, List<int> listResult)
        {
            int iResult = 0;
            for (int index = R; index < height.Length; index++)
            {
                listResult.Add(height[index]);
                if (index - L <= 1)
                {
                    if (height[L] <= height[index])
                        L++;
                    continue;
                }

                if (height[index] < height[L])
                {
                    continue;
                }
                if (height[index - 1] >= height[index])
                {
                    L = index - 1;
                    continue;
                }
                int iMin = Math.Min(height[index], height[L]);
                for (int j = L; j < index; j++)
                {
                    listResult.Add(iMin - height[j]);
                    iResult += iMin - height[j];
                }
                L = index;
            }
            return iResult;
        }
    }
}
