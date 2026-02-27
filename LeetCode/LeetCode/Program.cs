// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using LeetCode;

Console.WriteLine("Hello, World!");

//GetLetterCombinations();

//Getpermutation();

//GetNQueens();

//water
//GettrappingRainWater();

///取得最大股票利潤
//GetBestTimetoBuyandSellStockIII();

//
GetSlidingWindowMaximum();

//GetMaxPathSum();

//GetLongestValidParenthesesCS();


void GetLetterCombinations()
{
    test2 t2 = new test2();
    var result = t2.LetterCombinations("23");
    var result2 = t2.LetterCombinations("325");
    Console.WriteLine(result.ToList().ToString());
    Console.WriteLine(result2.ToList().ToString());
}


void Getpermutation()
{
    var permutation = new next_permutation();
    permutation.NextPermutation([1, 2, 3]);
    permutation.NextPermutation([3, 2, 1]);
    permutation.NextPermutation([1, 1, 5]);
    Console.WriteLine("test NextPermutation");

}

void GetNQueens()
{
    var result = NQueens.SolveNQueens(4);
    Console.WriteLine(result.ToList());
}


void GettrappingRainWater()
{
    //water
    var trappingRainWater = new TrappingRainWater();
    int iResult1 = trappingRainWater.Trap([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]);
    int iResult2 = trappingRainWater.Trap([4, 2, 0, 3, 2, 5]);
    Console.WriteLine(iResult1.ToString());
    Console.WriteLine(iResult2.ToString());
}


///取得最大股票利潤
void GetBestTimetoBuyandSellStockIII()
{
    Console.WriteLine(BestTimetoBuyandSellStockIII.MaxProfit([1, 2, 4, 2, 5, 7, 2, 4, 9, 0]));
    Console.WriteLine(BestTimetoBuyandSellStockIII.MaxProfit([3, 2, 6, 5, 0, 3]));
    Console.WriteLine(BestTimetoBuyandSellStockIII.MaxProfit([3, 3, 5, 0, 0, 3, 1, 4]));
    Console.WriteLine(BestTimetoBuyandSellStockIII.MaxProfit([1, 2, 3, 4, 5]));
    Console.WriteLine(BestTimetoBuyandSellStockIII.MaxProfit([7, 6, 4, 3, 1]));
}

void GetSlidingWindowMaximum()
{
    var v1 = SlidingWindowMaximum.MaxSlidingWindow([1, 3, -1, -3, 5, 3, 6, 7], 3);
    Console.WriteLine(v1.ToString());
    var v2 = SlidingWindowMaximum.MaxSlidingWindow([1], 1);
    Console.WriteLine(v2.ToString());

    var v3 = SlidingWindowMaximum.MaxSlidingWindow([1, 3, -1, -3, -2, 3, 6, 7], 3);
    Console.WriteLine(v3.ToString());
}

    void GetMaxPathSum()
    {
        //IntuitionAndApproach ia = new IntuitionAndApproach();
        //TreeNode tnode = ia.setTree();
        //var result = ia.MaxPathSum(tnode);
        //Console.WriteLine(result);
    }


    void GetLongestValidParenthesesCS()
    {
        //LongestValidParenthesesCS longestValidParentheses = new LongestValidParenthesesCS();
        //int iResult = longestValidParentheses.LongestValidParentheses(")()())");
        //Console.WriteLine(iResult);
    }



    Console.ReadLine();
