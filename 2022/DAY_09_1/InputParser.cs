namespace DAY_09_1;

public class InputParser
{
    public static Queue<Point> Parse(string input)
        => new(input.Split("\n")
                    .Select(line => line.Split(' '))
                    .SelectMany(s => GetMoves(char.Parse(s.First()), int.Parse(s.Last()))));
    private static IEnumerable<Point> GetMoves(char direction, int stepsNumber)
    {
        var point = direction switch
        {
            'U' => new Point(0, 1),
            'D' => new Point(0, -1),
            'L' => new Point(-1, 0),
            'R' => new Point(1, 0),
            _ => new Point(0, 0)
        };

        return Enumerable.Repeat(point, stepsNumber);
    }
}