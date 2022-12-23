namespace DAY_12_1;

internal static class InputParser
{
    public static Grid Parse(string input)
        => new(input.Split("\n")
                    .Select((l, y) => l.Select((c, x) =>
                    {
                        var p = new Point(x, y);
                        var h = c switch
                        {
                            'S' => 'a' - (96 + 1),
                            'E' => 'z' - (96 - 1),
                            _ => c - 96
                        };
                        return new Square(c, h, p);
                    }).ToArray())
                    .ToArray());
}