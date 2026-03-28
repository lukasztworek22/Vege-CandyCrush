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

        for (int row = 1; row < rows; row++)
        {
            for (int col = 1; col < cols; col++)
            {
                if (board.Content[row, col] == null)
                {
                    continue;
                }

                if (IsHorizontalStart(row, col))
                {
                    List<(int, int)> run = GetHorizontalRun(row, col);
                    ExplosionType type = GetExplosionType(run.Count);

                    if (type != ExplosionType.NONE)
                    {
                        ExplosionCandidate candidate =
                            new ExplosionCandidate(CheckElementType(board.Content[row, col]), type, run);
                        explosionCandidates.Add(candidate);
                    }
                }

                if (IsVerticalStart(row, col))
                {
                    List<(int, int)> run = GetVerticalRun(row, col);
                    ExplosionType type = GetExplosionType(run.Count);

                    if (type != ExplosionType.NONE)
                    {
                        ExplosionCandidate candidate =
                            new ExplosionCandidate(CheckElementType(board.Content[row, col]), type, run);
                        explosionCandidates.Add(candidate);
                    }
                }
            }

           
        }

        

        return explosionCandidates;
    }

    private ElementType CheckElementType(string s)
    {
        if (s.Equals("🍠"))
        {
            return ElementType.Potato;
        }
        if (s.Equals("🥬"))
        {
            return ElementType.Lettuce;
        }
        if (s.Equals("🧅"))
        {
            return ElementType.Onion;
        }
        if (s.Equals("🌿"))
        {
            return ElementType.Thyme;
        }

        return ElementType.Lettuce;
    }
    
    
    private List<(int, int)> GetHorizontalRun(int row, int col)
    {
        List <(int, int)> result = new List<(int, int)>();
        string value = board.Content[row, col];
        if (value == null) return result;

        int c = col;
        int cols = board.Content.GetLength(1);

        while (c < cols && board.Content[row, c] == value)
        {
            result.Add((row, c));
            c++;
        }

        return result;
    }
    private List<(int, int)> GetVerticalRun(int row, int col)
    {
        List<(int, int)> result = new List<(int, int)>();
        string value = board.Content[row, col];
        if (value == null) return result;

        int r = row;
        int rows = board.Content.GetLength(0);

        while (r < rows && board.Content[r, col] == value)
        {
            result.Add((r, col));
            r++;
        }

        return result;
    }
    
    private bool IsHorizontalStart(int row, int col)
    {
        return col == 1 || board.Content[row, col - 1] != board.Content[row, col];
    }
    
    private bool IsVerticalStart(int row, int col)
    {
        return row == 1 || board.Content[row - 1, col] != board.Content[row, col];
    }
    
    private ExplosionType GetExplosionType(int count)
    {
        if (count >= 5) return ExplosionType.FIVE;
        if (count == 4) return ExplosionType.FOUR;
        if (count == 3) return ExplosionType.THREE;
        return ExplosionType.NONE;
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


    