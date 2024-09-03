using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLinkNodeAddSum
{
    public  class TwoLinkNodeAddSum1
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            string sResult = "";
            ulong n1 = NodeToInt(l1, sResult);
            Console.WriteLine("value:"+n1.ToString());
            ulong n2 = NodeToInt(l2, sResult);
            Console.WriteLine("value:" + n2.ToString());
            ulong nResult = n1 + n2;
            Console.WriteLine("value:" + nResult.ToString());
            ListNode Result = new ListNode();
             List<char> listchar = nResult.ToString().ToCharArray().ToList();
            var vResult= strToNode(listchar, Result);
            return vResult;
        }

        public ulong NodeToInt(ListNode source, string sResult)
        {
            sResult = source.val.ToString() + sResult;
            if (source.next == null)
            {
                return Convert.ToUInt64(sResult);
            }
          return  NodeToInt(source.next, sResult);
        }

        public ListNode strToNode(List<char> source, ListNode Result)
        {
            if (source.Count == 0)
            {
                return null;
            }
            var vnode = new ListNode();
            Result.val = Convert.ToInt32(source[source.Count - 1].ToString());
            source.RemoveAt(source.Count - 1);
            Result.next = strToNode(source, vnode);
            return Result;
        }
    }
}
