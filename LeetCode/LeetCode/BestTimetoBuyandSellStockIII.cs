using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class BestTimetoBuyandSellStockIII
    {
        public static int MaxProfit(int[] prices)
        {
            int cost1 = prices[0], profit1 = 0, cost2 = int.MaxValue, profit2 = 0;

            for (int i = 0; i < prices.Length; i++)
            {
                cost1 = Math.Min(cost1, prices[i]);
                profit1 = Math.Max(profit1, prices[i] - cost1);
                cost2 = Math.Min(cost2, prices[i] - profit1);
                profit2 = Math.Max(profit2, prices[i] - cost2);
            }

            return profit2;
        }

    }

}
