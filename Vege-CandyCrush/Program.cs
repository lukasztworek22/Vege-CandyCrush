using System;


class Program
{
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        string[] vegies = { "🥬", "🍠", "🧅", "🌿" };   // kale, beet, leek, okra
        string[] fruits = { "🌴", "🍑", "🍐", "🥝" }; // palm, plum, pear, kiwi
        string[,] board = new string[13,13];
        
        Random rnd = new Random();
        Console.WriteLine("");
        for (int i = 1; i < board.GetLength(0); i++)
        {
            for (int j = 1; j < board.GetLength(1); j++)
            {
                board[i, j] = vegies[rnd.Next(vegies.Length)];
            }
        }

        for (int i = 1; i < board.GetLength(0); i++)
        {
            board[0, i] = ((char)('A' + i - 1)).ToString();
        }
        for (int i = 1; i < board.GetLength(0); i++)
        {
            board[i, 0] = i.ToString();
        }
        board[0, 0] = "%";
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i, j].PadLeft(3));
            }
            Console.WriteLine();
        }

        Console.WriteLine("Enter the first coordinate: ");
        string E1 = Console.ReadLine().ToUpper(); // first element you want to move
        
        int elemRow1 = int.Parse(E1.Remove(0, 1));
        int elemCol1 = E1[0] - 'A' + 1;
        
        Console.WriteLine("Enter the first coordinate: ");
        string E2 = Console.ReadLine().ToUpper(); // element you want switch places with
        
        int elemRow2 = int.Parse(E2.Remove(0, 1));
        int elemCol2 = E2[0] - 'A' + 1;

        string temp = board[elemRow1, elemCol1];
        board[elemRow1, elemCol1] = board[elemRow2, elemCol2];
        board[elemRow2, elemCol2] = temp;
        
        // I thought about putting the element movement in while, but I don't have clear idea where to put it exactly

        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                Console.Write(board[i, j].PadLeft(3));
            }
            Console.WriteLine();
        }
        
    }
}