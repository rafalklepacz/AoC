namespace DAY_02_1;

public static class Extensions
{
    public static Shape ToFirstShape(this char c)
        => c switch
        {
            'A' => Shape.Rock,
            'B' => Shape.Paper,
            'C' => Shape.Scissor,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, "Unknown shape type.")
        };
    
    public static Result ToResultShape(this char c)
        => c switch
        {
            'X' => Result.Lose,
            'Y' => Result.Draw,
            'Z' => Result.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, "Unknown shape type.")
        };
}