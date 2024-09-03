using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EightQueen
{
    public static class EightQueensCS
    {
        // 列印
        public static void PrintSolution(int[,] board,int N)
        {
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    Console.Write(board[i, j] == 1 ? "Q " : ".");

                Console.WriteLine();
            }
            Console.WriteLine();

        }

        // 檢查在 (row, col) 位置放置皇后是否安全
        public static bool IsSafe(int[,] board, int row, int col,int N)
        {
            // 檢查同一列上是否有皇后
            for (int i = 0; i < row; i++)
                if (board[i, col] == 1)
                    return false;
            // 檢查右上對角線是否有皇后
            for (int i = row, j = col; i >= 0 && j < N; i--, j++)
                if (board[i, j] == 1)
                    return false;

            // 檢查左上對角線是否有皇后
            for (int i = row, j = col; i >= 0 && j >= 0; i--, j--)
                if (board[i, j] == 1)
                    return false;

            return true;
        }

        
        public static bool LoopSetup(int N, int[,] board, int row)
        {
            if (row == N)
            {
                // 所有皇后都已經成功放置，打印解法
                PrintSolution(board, N);
                return true;
            }

            bool res = false;
            for (int i = 0; i < N; i++)
            {
                if (IsSafe(board, row, i, N))
                {
                    // 在 (row, i) 放置皇后
                    board[row, i] = 1;
                    res = LoopSetup(N,board, row + 1) || res;
                    // 如果在下一行放置皇后的所有選擇都導致無解，取消當前位置的皇后
                    board[row, i] = 0;
                }
            }
            return res;
        }
    }
}
