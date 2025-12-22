using System;


class Program
{
    
    static void Main(string[] args)
    {
        // for now I created normal string arrays, I assume that later they need to be separate objects?
        string[] vegies = {"kale", "beet", "leek", "okra"};
        string[] fruits = {"date", "plum", "pear", "kiwi"};
        string[,] board = new string[12,12];
        
        Random rnd = new Random();
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                board[i, j] = vegies[rnd.Next(vegies.Length)];
            }
        }
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i, j] + "    ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}