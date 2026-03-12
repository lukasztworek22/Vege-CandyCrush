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

        while (true)
        {
            Console.Clear();
            board.PrintBoard();

            List<ExplosionCandidate> explosionCandidates = manager.FindExplosions();
            if (explosionCandidates.Count > 0)
            {
                manager.Explode(explosionCandidates);
                board.PrintBoard();
                
                filler.FillBoardAfterExplosion();
                
                board.PrintBoard();
                // FillDirection fillDirection = firstElement?.Direction ?? FillDirection.Top;
                // manager.ApplyGravity(direction);
            }

            board.ElementSwap();
        }
    }
}