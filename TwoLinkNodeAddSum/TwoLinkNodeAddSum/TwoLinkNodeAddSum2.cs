using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoLinkNodeAddSum
{
    public class TwoLinkNodeAddSum2
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode result = new ListNode();
            ListNode root = result;
            int sum = 0;
            while (l1 != null || l2 != null || sum > 0)
            {
                if (l1 != null)
                {
                    sum += l1.val;
                    l1=l1.next;
                }
                if (l2 != null)
                {
                    sum += l2.val;
                    l2=l2.next;
                }
                result.next = new ListNode(sum % 10);
                sum /= 10;
                result = result.next;
            }

            return root.next;
            
        }
    }
}
