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
    
    public static Shape ToSecondShape(this char c)
        => c switch
        {
            'X' => Shape.Rock,
            'Y' => Shape.Paper,
            'Z' => Shape.Scissor,
            _ => throw new ArgumentOutOfRangeException(nameof(c), c, "Unknown shape type.")
        };
}