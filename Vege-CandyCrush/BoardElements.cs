namespace Vege_CandyCrush;

public enum ElementType
{
    Lettuce, Potato, Onion, Thyme,
    Palm, Peach, Pear, Kiwi
}

public enum FillDirection
{
    Top,
    Bottom,
    Left,
    Right
}


public class BoardElement
{
    public string Symbol { get; set; }
    public int Points { get; set; }
    public ElementType Type { get; set; }

    public bool IsVegetable
    {
        get
        {
            return Type == ElementType.Lettuce || Type == ElementType.Potato ||
                   Type == ElementType.Onion || Type == ElementType.Thyme;
        }
    }

    public bool IsFruit
    {
        get
        {
            return !IsVegetable;
        }
    }
    
    protected BoardElement(string symbol, int points, ElementType type)
    {
        Symbol = symbol;
        Points = points;
        Type = type;
    }

    public FillDirection Direction
    {
        get
        {
            return Type switch
            {
                ElementType.Potato => FillDirection.Top,
                ElementType.Onion => FillDirection.Bottom,
                ElementType.Lettuce => FillDirection.Left,
                ElementType.Thyme => FillDirection.Right
            };
        }
    }
}

