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
            board.PrintBoard("");

            explosionCandidates = manager.FindExplosions();
            if (explosionCandidates.Count > 0)
            {
                manager.Explode(explosionCandidates);
                board.PrintBoard("After Explosion");
                manager.ApplyGravity(FillDirection.Top);
                board.PrintBoard("Gravity Applied");
                filler.FillBoardAfterExplosion();

                
                board.PrintBoard("Filled Board");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                continue;
            }

            board.ElementSwap();
            // while (true)
            // {
            //     explosionCandidates = manager.FindExplosions();
            //     if (explosionCandidates.Count == 0) break;
            //     manager.Explode(explosionCandidates);
            //     manager.ApplyGravity(FillDirection.Top);
            //     filler.FillBoardAfterExplosion();
            //
            //     Console.Clear();
            //     board.PrintBoard("");
            //     Console.WriteLine("Press any key to continue...");
            //     Console.ReadKey();
            // }
        }
    }
}