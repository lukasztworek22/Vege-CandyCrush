using System;
using Vege_CandyCrush;


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Board board = new Board(6, 6);
        BoardFiller filler = new BoardFiller(board);
        GameManager manager = new GameManager(board, filler);


        manager.Prepare();
        
        List<ExplosionCandidate> explosionCandidates;
        while (true)
        {
            Console.Clear();
            board.PrintBoard("Actual Board", false);
            
            explosionCandidates = manager.FindExplosions();
            
            if (explosionCandidates.Count == 0)
            {
                board.ElementSwap();
            }
            
            explosionCandidates = manager.FindExplosions();
            while (explosionCandidates.Count > 0)
            {
                explosionCandidates = manager.FindExplosions();
                if (explosionCandidates.Count == 0)
                {
                    board.PrintBoard("Filled Board #2", false);
                    break;
                }

                Console.Clear();
                manager.Explode(explosionCandidates);
                board.PrintBoard("After Explosion", true);
                manager.ApplyGravity(FillDirection.Top);
                board.PrintBoard("Gravity Applied", true);
                filler.FillBoardAfterExplosion();
                
                board.PrintBoard("Filled Board", true);
                
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
} 
        