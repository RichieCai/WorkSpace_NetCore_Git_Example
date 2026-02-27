using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class SlidingWindowMaximum
    {
        public SlidingWindowMaximum()
        { 
        
        }

        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            var queue = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));

            int i;
            for (i = 0; i < k; ++i)
            {
                queue.Enqueue(i, nums[i]);
            }

            var solution = new int[nums.Length - k + 1];
            var j = 0;

            // because nums.length >=1 && k >= 1, it's guaranteed we have at least one element to peek
            queue.TryPeek(out _, out var value);
            solution[j++] = value;

            for (/**/; i < nums.Length; ++i)
            {
                queue.Enqueue(i, nums[i]);

                // we peek the max, and we remove it as long as it's outside of the window
                queue.TryPeek(out var z, out value);
                while (z < j)
                {
                    queue.Dequeue();
                    queue.TryPeek(out z, out value);
                }

                solution[j++] = value;
            }

            return solution;

        }
    }
}
