using EightQueen;


    int N = 4; // 8皇后問題
    int[,] board = new int[N, N];

    if (!EightQueensCS.LoopSetup(N, board, 0))
    {
        Console.WriteLine("沒有解決方案");
    }

    Console.ReadLine();

