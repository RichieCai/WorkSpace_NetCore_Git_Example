using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLinkNodeAddSum
{
    public static class CombinationSumCS
    {
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> result = new List<IList<int>>();

            //1
            var NewData = candidates.OrderByDescending(x => x).ToList();
            getData3(result, new List<int>(), NewData, 0, 0, target);


            ///2
            //for (int i = 0; i < NewData.Count(); i++)
            //{
            //    IList<int> ItemList = new List<int>();
            //    ItemList = getData2(ItemList, NewData, i, iResult);
            //    if (ItemList != null)
            //        result.Add(ItemList);
            //}

            return result;
        }

        public static void getData3(IList<IList<int>> result, IList<int> ItemList, List<int> SourceList, int i, int iSum, int iTarget)
        {
            if (iSum == iTarget)
            {
                result.Add(ItemList.ToArray());
                return ;
            }
            while (iSum<iTarget  && i < SourceList.Count())
            {
                ItemList.Add(SourceList[i]);
                getData3(result, ItemList, SourceList, i, iSum+ SourceList[i], iTarget);
               
                ItemList.RemoveAt(ItemList.Count-1);
                i++;
            }

        }


        //public static IList<IList<int>> getData(IList<IList<int>> result, IList<int> ItemList, List<int> SourceList, int i, int iResultRemainder, int iTarget)
        //{
        //    if (i >= SourceList.Count())
        //    {
        //        return null;
        //    }
        //    while (iResultRemainder > 0 && i < SourceList.Count())
        //    {
        //        iResultRemainder = iResultRemainder - SourceList[i];
        //        ItemList.Add(SourceList[i]);
        //        if (iResultRemainder == 0)
        //        {
        //            result.Add(ItemList);
        //            result = getData(result, new List<int>(), SourceList, i++, iTarget, iTarget);
        //        }
        //        if (iResultRemainder >= SourceList[i])
        //        {
        //            result = getData(result, new List<int>(), SourceList, i, iTarget, iTarget);
        //        }
        //        if (iResultRemainder < 0)
        //        {
        //            ItemList = null;
        //            i++;
        //        }
        //    }
        //    return result;
        //}


        public static IList<int> getData2(IList<int> ItemList, List<int> SourceList, int i, int iTarget)
        {
            if (i >= SourceList.Count())
            {
                return null;
            }
            int iResultRemainder = iTarget - SourceList[i];
            if (iResultRemainder < 0)
            {
                return null;
            }
            if (iResultRemainder == 0)
            {
                ItemList.Add(SourceList[i]);
                return ItemList;
            }
            if (iResultRemainder >= SourceList[i])
            {
                ItemList.Add(SourceList[i]);
                ItemList = getData2(ItemList, SourceList, i, iResultRemainder);
            }
            if (iResultRemainder < SourceList[i] && iResultRemainder != 0)
            {
                ItemList.Add(SourceList[i]);
                ItemList = getData2(ItemList, SourceList, i++, iResultRemainder);
            }
            return ItemList;
        }
    }
}
