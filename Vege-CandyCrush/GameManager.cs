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

    public List<ExplosionCandidate> FindExplosions()
    {
        List<ExplosionCandidate> explosionCandidates = new List<ExplosionCandidate>();
        
        int rows = board.Content.GetLength(0);
        int cols = board.Content.GetLength(1);

        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols - 2; j++)
            {
                ExplosionType atLeastThree = matchesAtLeastThree(i, j);
                if (atLeastThree != ExplosionType.NONE)
                {
                    List<(int, int)> matches = new List<(int, int)>();
                    matches.Add((i, j));
                    matches.Add((i, j + 1));
                    matches.Add((i, j + 2));
                    var explosionCandidate = new ExplosionCandidate(CheckElementType(board.Content[i, j]), atLeastThree, matches);
                    explosionCandidates.Add(explosionCandidate);
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

        return explosionCandidates;
    }

    private ElementType CheckElementType(string s)
    {
        return s.Equals()
    }
    //TODO: Think how to check if matches more then three. Maybe check if 4,5 is also the case and return

    private ExplosionType matchesAtLeastThree(int i, int j)
    {
        return board.Content[i, j] == board.Content[i, j + 1] && board.Content[i, j] == board.Content[i, j + 2] 
            ? ExplosionType.THREE 
            : ExplosionType.NONE;
    }

    public void Explode(List<ExplosionCandidate> candidates)
    {
        foreach (var candidate in candidates)
        {
            foreach (var coord in candidate.ExplosionCoordinates)
            {
                board.Content[coord.Item1, coord.Item2] = null;
            }
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

public class ExplosionCandidate
{
    public ElementType ElementType { get; set; }
    public ExplosionType Type { get; set; }
    public List<(int, int)> ExplosionCoordinates { get; set; }

    public ExplosionCandidate(ElementType elementType, ExplosionType type, List<(int, int)> explosionCoordinates)
    {
        ElementType = elementType;
        Type = type;
        ExplosionCoordinates = explosionCoordinates;
    }
}

public enum ExplosionType
{
    NONE, THREE, FOUR, FIVE
}