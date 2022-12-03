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

    public static int ToPoints(this Shape shape)
        => shape switch
        {
            Shape.Rock => 1,
            Shape.Paper => 2,
            Shape.Scissor => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(shape), shape, null)
        };
    
    public static int ToPoints(this Result result)
        => result switch
        {
            Result.Win => 6,
            Result.Draw => 3,
            _ =>  0
        };
}