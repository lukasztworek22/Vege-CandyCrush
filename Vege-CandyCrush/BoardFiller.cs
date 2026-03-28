namespace Vege_CandyCrush;

public class BoardFiller
{
    private Random rnd;
    private Board board;
    string[] vegies = { "🥬", "🍠", "🧅", "🌿" };   

    public BoardFiller(Board board)
    {
        this.board = board;
        rnd = new Random();
    }

    public void VegieFill()
    {
        for (int row = 1; row < board.Content.GetLength(0); row++)
        {
            for (int col = 1;  col < board.Content.GetLength(1); col++)
            {
                board.Content[row, col] = vegies[rnd.Next(vegies.Length)];
            }
        }
    }

    public void FillHeaders()
    {
        for (int col = 1; col < board.Content.GetLength(0); col++)
        {
            board.Content[0, col] = ((char)('A' + col - 1)).ToString();
        }
        
        for (int row = 1; row < board.Content.GetLength(0); row++)
        {
            board.Content[row, 0] = row.ToString();
        }
        board.Content[0, 0] = "%";
    }

    public void FillBoardAfterExplosion()
    {
        for (int row = 1; row < board.Content.GetLength(0); row++)
        {
            for (int col = 1; col < board.Content.GetLength(1); col++)
            {
                if (board.Content[row, col] == null)
                {
                    board.Content[row, col] = vegies[rnd.Next(vegies.Length)];
                }
            }
        }
    }
    
    
    
}