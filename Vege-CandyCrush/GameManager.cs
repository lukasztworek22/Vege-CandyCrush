namespace Vege_CandyCrush;

public class GameManager
{
    private Board board;
    private BoardFiller filler;
    
    public GameManager(Board board, BoardFiller filler)
    {
        this.board = board;
        this.filler = filler;
    }
    
    public List<(int row, int col)> FindMatchesThree()
    {
        List<(int, int)> matches = new List<(int, int)>();
        int rows = board.Content.GetLength(0);
        int cols = board.Content.GetLength(1);

        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols - 2; j++)
            {
                if (board.Content[i, j] == board.Content[i, j + 1] && board.Content[i, j] == board.Content[i, j + 2])
                {
                    matches.Add((i, j));
                    matches.Add((i, j + 1));
                    matches.Add((i, j + 2));
                    
                }
            }
        }

        for (int j = 1; j < cols; j++)
        {
            for (int i = 1; i < rows - 2; i++)
            {
                if (board.Content[i, j] == board.Content[i + 1, j] && board.Content[i, j] == board.Content[i + 2, j])
                {
                    matches.Add((i, j));
                    matches.Add((i + 1, j));
                    matches.Add((i + 2, j));
                    
                }
            }
        }

        return matches.Distinct().ToList();
    }

    public void MatchesExplosion(List<(int row , int col )> matches)
    {
        foreach (var (row, col) in matches)
        {
            board.Content[row, col] = null;
        }
    }

    public void ApplyGravity(FillDirection direction)
    {
        switch (direction)
        {
            case FillDirection.Top:
                ApplyGravityDown();
                break;
            case FillDirection.Bottom:
                ApplyGravityUp();
                break;
            case FillDirection.Left:
                ApplyGravityRight();
                break;
            case FillDirection.Right:
                ApplyGravityLeft();
                break;
        }
        
    }

    
    public void Prepare()
    {
        filler.VegieFill();
        filler.FillHeaders();
    }

    public void ApplyGravityDown()
    {
        int rows = board.Content.GetLength(0);
        int cols = board.Content.GetLength(1);


        for (int col = 1; col < cols; col++)
        {
            int writeRow = rows - 1;
            for (int row = rows - 1; row >= 1; row--)
            {
                if (board.Content[row, col] != null)
                {
                    board.Content[writeRow, col] = board.Content[row, col];
                    if (writeRow != row)
                    {
                        board.Content[row, col] = null;
                    }

                    writeRow--;
                }
            }

            for (; writeRow >= 1; writeRow--)
            {
                board.Content[writeRow, col] = null;
            }
        }
    }
    public void ApplyGravityUp()
    {
        int rows = board.Content.GetLength(0);
        int cols = board.Content.GetLength(1);


        for (int col = 1; col < cols; col++)
        {
            int writeRow = 1;
            for (int row = 1; row <rows ; row++)
            {
                if (board.Content[row, col] != null)
                {
                    board.Content[writeRow, col] = board.Content[row, col];
                    if (writeRow != row)
                    {
                        board.Content[row, col] = null;
                    }

                    writeRow++;
                }
            }

            for (; writeRow < rows; writeRow++)
            {
                board.Content[writeRow, col] = null;
            }
        }
    }
    public void ApplyGravityRight()
    {
        int rows = board.Content.GetLength(0);
        int cols = board.Content.GetLength(1);


        for (int row = 1; row < rows; row++)
        {
            int writeCol = cols - 1;
            for (int col = cols -1; col >= 1; col--)
            {
                if (board.Content[row, col] != null)
                {
                    board.Content[row, writeCol] = board.Content[row, col];
                    if (writeCol != col)
                    {
                        board.Content[row, col] = null;
                    }

                    writeCol--;
                }
            }

            for (; writeCol >= 1; writeCol--)
            {
                board.Content[row, writeCol] = null;
            }
        }
    }
    
    public void ApplyGravityLeft()
    {
        int rows = board.Content.GetLength(0);
        int cols = board.Content.GetLength(1);


        for (int row = 1; row < rows; row++)
        {
            int writeCol = 1;
            for (int col = 1; col < cols; col++)
            {
                if (board.Content[row, col] != null)
                {
                    board.Content[row, writeCol] = board.Content[row, col];
                    if (writeCol != col)
                    {
                        board.Content[row, col] = null;
                    }

                    writeCol++;
                }
            }

            for (; writeCol < cols; writeCol++)
            {
                board.Content[row, writeCol] = null;
            }
        }
    }
    
}