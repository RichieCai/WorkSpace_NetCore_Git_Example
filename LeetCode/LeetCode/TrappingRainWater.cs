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

            int L = 0;
            int R = 1;
            int iResult = 0;
            List<int> list = new List<int>();

            for (int index = R; index < height.Length; index++)
            {
                if (index - L <= 1)
                    continue;

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
                    list.Add(iMin - height[j]);
                    iResult += iMin - height[j];
                }
                L = index;
            }
            return iResult;
        }
    }
}
