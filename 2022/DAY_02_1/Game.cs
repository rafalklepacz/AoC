namespace DAY_02_1;

class Game
{
    public int WonPoints { get; private set; }

    public static Game Create(Shape first, Shape second)
        => new(first, second);

    private Game(Shape first, Shape second)
    {
        _first = first;
        _second = second;

        SetResult();
        SetWonPoints();
    }

    private void SetResult()
        => _result = (_first, _second) switch
        {
            (Shape.Paper, Shape.Paper) => Result.Draw,
            (Shape.Rock, Shape.Rock) => Result.Draw,
            (Shape.Scissor, Shape.Scissor) => Result.Draw,

            (Shape.Paper, Shape.Scissor) => Result.Win,
            (Shape.Rock, Shape.Paper) => Result.Win,
            (Shape.Scissor, Shape.Rock) => Result.Win,

            _ => Result.Lose
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
    private readonly Shape _second;
    private Result _result;
}