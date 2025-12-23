using System;


class Program
{
    
    static void Main(string[] args)
    {
        // for now I created normal string arrays, I assume that later they need to be separate objects?
        string[] vegies = {"kale", "beet", "leek", "okra"};
        string[] fruits = {"date", "plum", "pear", "kiwi"};
        string[,] board = new string[12,12];
        
        ConsoleColor[] colors = {ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow }; 
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
                switch (board[i, j])
                {
                    /* for now I didn't add colors to fruits since they appear only after connecting a certain number of vegies so
                    at this point this the only way I knew how to do this
                    */
                    case "kale":
                        Console.ForegroundColor = colors[1];
                        break;
                    case "beet":
                        Console.ForegroundColor = colors[1];
                        break;
                    case "leek":
                        Console.ForegroundColor = colors[2];
                        break;
                    case "okra":
                        Console.ForegroundColor = colors[3];
                        break;
                }
                Console.Write(board[i, j].ToUpper().PadRight(6));
            }
            Console.WriteLine();
            Console.WriteLine();
            
            
        }
        Console.ResetColor();
    }
}