using System;
using Vege_CandyCrush;


class Program
{
    
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        
        Board board = new Board(6,6);
        BoardFiller filler = new BoardFiller(board);
        GameManager manager = new GameManager(board, filler);
        
        
        
        
        manager.Prepare();
        
        while (true)
        {
            
            Console.Clear();
            board.PrintBoard();
            
            var matches = manager.FindMatchesThree();
            if (matches.Count > 0)
            {
                manager.MatchesExplosion(matches);
                
                manager.ApplyGravity(FillDirection.Top);
                
                filler.FillNulls();
                
                Console.Clear();
                board.PrintBoard();
                Console.WriteLine("Press any button to continue");
                Console.ReadKey();
                continue;

            }
            
            board.ElementSwap();
            
            
            
            
            

        }
        
        
        
    }

    
}