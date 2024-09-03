// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using TwoLinkNodeAddSum;

//TwoLinkNodeAddSum1();
//TwoLinkNodeAddSum2();

//LengthOfLongestSubstring();

//CombinationSum();

//LetterCombinations();
TwoSum();

Console.ReadLine();

static void LetterCombinations()
{
    string digits=Console.ReadLine();
    IList<string> result= LetterCombinationsofPhoneNumber.LetterCombinations(digits);
    foreach (var s in result)
    { 
        Console.WriteLine(s);
    }
}

    static void CombinationSum()
{
    //int[] data1= new int[] { 2, 3, 6, 7 };
    //int target1 = 7;
    //IList < IList<int> > result = CombinationSumCS.CombinationSum(data1, target1);
    int[] data2 = new int[] { 2, 3, 5 };
    int target2 = 8;
    IList<IList<int>> result2 = CombinationSumCS.CombinationSum(data2, target2);
}


static void LengthOfLongestSubstring()
{
    string sparm1 = "abcabcbb";
   int s1= LengthOfLongestSubstringCS.LengthOfLongestSubstring(sparm1);
    Console.WriteLine("LengthOfLongestSubstring_toString:"+s1);

    string sparm2 = "bbbbbb";
    int s2= LengthOfLongestSubstringCS.LengthOfLongestSubstring(sparm2);
    Console.WriteLine("LengthOfLongestSubstring_toString:" + s2);

    string sparm3 = "pwwkew";
    int s3= LengthOfLongestSubstringCS.LengthOfLongestSubstring(sparm3);
    Console.WriteLine("LengthOfLongestSubstring_toString:" + s3);

}

static void TwoLinkNodeAddSum2()
{
    TwoLinkNodeAddSum2 t = new TwoLinkNodeAddSum2();


    ListNode l3 = new ListNode();
    l3.val = 3;
    l3.next = null;
    ListNode l2 = new ListNode();
    l2.val = 4;
    l2.next = l3;
    ListNode l1 = new ListNode();
    l1.val = 2;
    l1.next = l2;



    ListNode k3 = new ListNode();
    k3.val = 4;
    k3.next = null;
    ListNode k2 = new ListNode();
    k2.val = 6;
    k2.next = k3;
    ListNode k1 = new ListNode();
    k1.val = 5;
    k1.next = k2;


    var vResult = t.AddTwoNumbers(l1, k1);
}
static void TwoLinkNodeAddSum1()
{
    TwoLinkNodeAddSum1 t = new TwoLinkNodeAddSum1();


    ListNode l3 = new ListNode();
    l3.val = 3;
    l3.next = null;
    ListNode l2 = new ListNode();
    l2.val = 4;
    l2.next = l3;
    ListNode l1 = new ListNode();
    l1.val = 2;
    l1.next = l2;



    ListNode k3 = new ListNode();
    k3.val = 4;
    k3.next = null;
    ListNode k2 = new ListNode();
    k2.val = 6;
    k2.next = k3;
    ListNode k1 = new ListNode();
    k1.val = 5;
    k1.next = k2;


    var vResult = t.AddTwoNumbers(l1, k1);
}



static void TwoSum()
{
    int[] nums = new int[] { 2, 7, 11, 15 };
    var target = 9;

  int[] result1=  TwoSumCS.TwoSum(nums,target);

    int[] nums2 = new int[] { 3, 2, 4 };
    var target2 = 6;

    int[] result2 = TwoSumCS.TwoSum(nums2, target2);

    int[] nums3 = new int[] { 3,3 };
    var target3 = 6;

    int[] result3 = TwoSumCS.TwoSum(nums3, target3);

    Console.WriteLine("2, 7, 11, 15 ");
    foreach (int i in result1)
    { 
    Console.WriteLine(i);
    }
    Console.WriteLine("3, 2, 4");
    foreach (int i in result2)
    {
        Console.WriteLine(i);
    }
    Console.WriteLine(" 3,3");
    foreach (int i in result3)
    {
        Console.WriteLine(i);
    }
}


