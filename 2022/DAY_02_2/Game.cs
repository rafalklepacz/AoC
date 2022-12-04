namespace DAY_02_1;

class Game
{
    public int WonPoints { get; private set; }

    public static Game Create(Shape first, Result result)
        => new(first, result);

    private Game(Shape first, Result result)
    {
        _first = first;
        _result = result;

        SetSecondShape();
        SetWonPoints();
    }

    private void SetSecondShape()
        => _second = (_first, _result) switch
        {
            (Shape.Paper, Result.Draw) => Shape.Paper,
            (Shape.Rock, Result.Draw) => Shape.Rock,
            (Shape.Scissor, Result.Draw) => Shape.Scissor,

            (Shape.Paper, Result.Win) => Shape.Scissor,
            (Shape.Rock, Result.Win) => Shape.Paper,
            (Shape.Scissor, Result.Win) => Shape.Rock,

            (Shape.Paper, Result.Lose) => Shape.Rock,
            (Shape.Rock, Result.Lose) => Shape.Scissor,
            (Shape.Scissor, Result.Lose) => Shape.Paper,
            
            _ => throw new ArgumentOutOfRangeException()
        };

    private void SetWonPoints()
        => WonPoints = GetShapePoints() + GetResultPoints();

    private int GetShapePoints()
        => _second switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            Shape.Scissor => 3,
            _ => 0
        };

    private int GetResultPoints()
        => _result switch
        {
            Result.Win => 6,
            Result.Draw => 3,
            _ => 0
        };

    private readonly Shape _first;
    private Shape _second;
    private readonly Result _result;
}