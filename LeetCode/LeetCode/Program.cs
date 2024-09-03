// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");



//test2 t2 = new test2();
//var result= t2.LetterCombinations("23");
//var result2 = t2.LetterCombinations("325");
//Console.WriteLine(result.ToList().ToString());
//Console.WriteLine(result2.ToList().ToString());

//var permutation = new next_permutation();
//permutation.NextPermutation([1, 2, 3]);
//permutation.NextPermutation([3, 2, 1]);
//permutation.NextPermutation([1, 1, 5]);
//Console.WriteLine("test NextPermutation");



//var result=NQueens.SolveNQueens(4);
//Console.WriteLine(result.ToList());


IntuitionAndApproach ia = new IntuitionAndApproach();
TreeNode tnode = ia.setTree();
var result = ia.MaxPathSum(tnode);
Console.WriteLine(result);


LongestValidParenthesesCS longestValidParentheses = new LongestValidParenthesesCS();
int iResult = longestValidParentheses.LongestValidParentheses(")()())");
Console.WriteLine(iResult);



//water
//var trappingRainWater = new TrappingRainWater();
//int iResult1=trappingRainWater.Trap([0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1]);
//int iResult2 = trappingRainWater.Trap([4, 2, 0, 3, 2, 5]);

//Console.WriteLine(iResult1.ToString());
//Console.WriteLine(iResult2.ToString());


Console.ReadLine();
