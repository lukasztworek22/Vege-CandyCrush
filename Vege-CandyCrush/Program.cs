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
                
                
                matches = manager.FindMatchesThree(); 
                if (matches.Count > 0)
                {
                    manager.MatchesExplosion(matches);

                    var firstElement = board.Content[matches[0].row, matches[0].col]; 
                    firstElement?.Direction ?? FillDirection.Top;
                    manager.ApplyGravity(direction);

                }

            }
            
            board.ElementSwap();
            
            
            
            
            

        }
        
        
        
    }

    
}