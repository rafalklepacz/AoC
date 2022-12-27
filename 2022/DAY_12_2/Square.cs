namespace DAY_12_2;

public class Square
{
    private IEnumerable<Square> _availableSquares = Enumerable.Empty<Square>();

    public Square(char letter, int height, Point position)
    {
        Letter = letter;
        Height = height;
        Position = position;
    }

    public char Letter { get; init; }
    public int Height { get; init; }
    public Point Position { get; init; }

    public void SetAvailableSquares(IEnumerable<Square> availableSquares)
        => _availableSquares = availableSquares;

    public IEnumerable<Square> AvailableSquares
        => _availableSquares;

    public override string ToString()
        => $"{{ Letter: '{Letter}'; Height: '{Height}'; Position: {Position} }}";
}
