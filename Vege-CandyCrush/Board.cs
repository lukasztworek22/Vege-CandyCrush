namespace Vege_CandyCrush;

public class Board
{
    public string[,] Content { get; set; }
    
    public Board(int width, int height)
    {
        Content = new string[height, width];
    }
    
    public void PrintBoard(string message)
    {
        Console.WriteLine(message + "\n");
        for (int j = 0; j < Content.GetLength(0); j++)
        {
            for (int i = 0; i < Content.GetLength(1); i++)
            {
                string symbol = Content[j, i] ?? ".";
                Console.Write(symbol.PadLeft(3));
            }
            Console.WriteLine();
        }
        
        Console.WriteLine("\n");
    }
    public void ElementSwap()
    {
        
        
        Console.WriteLine("Enter the first coordinate: ");
        string E1 = Console.ReadLine().ToUpper(); // first element you want to move
        
        if (!CorrectCoordinate(E1, out int elemRow1, out int elemCol1))
        {
            Console.WriteLine("Invalid coordinate! Press any key to try again...");
            Console.ReadKey();
            return;
        }
        Console.WriteLine("Enter the second coordinate: ");
        string E2 = Console.ReadLine().ToUpper(); // element you want switch places with
        
        if (!CorrectCoordinate(E2, out int elemRow2, out int elemCol2))
        {
            Console.WriteLine("Invalid coordinate! Press any key to try again...");
            Console.ReadKey();
            return;
        }
        
        //Move Validation
        int rowDiff = Math.Abs(elemRow1 - elemRow2);
        int colDiff = Math.Abs(elemCol1 - elemCol2);
        
        if (rowDiff + colDiff != 1)
        {
            Console.WriteLine("Incorrect move!!  Press any key to try again.....");
            Console.ReadKey();
            return;
        }
        // Swap
        string temp = Content[elemRow1, elemCol1];
        Content[elemRow1, elemCol1] = Content[elemRow2, elemCol2];
        Content[elemRow2, elemCol2] = temp;
        
       
    }

    private bool CorrectCoordinate(string input, out int row, out int col)
    {
        row = col = -1;
        if (string.IsNullOrWhiteSpace(input))
        {
            return false;
        }

        input = input.Trim().ToUpper();

        if (input.Length < 2)
        {
            return false;
        }

        char letter = input[0];
        if (letter < 'A' || letter >= 'A' + Content.GetLength(1))
        {
            return false;
        }

        if (!int.TryParse(input.Substring(1), out int number))
        {
            return false;
        }

        row = number;
        col = (letter - 'A') +1;

        if (row < 0 || row >= Content.GetLength(0))
        {
            return false;
        }
        return true;
    }
}