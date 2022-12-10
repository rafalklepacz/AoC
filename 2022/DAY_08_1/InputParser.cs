namespace DAY_08_1;

public class InputParser
{
    public static MatrixTree[][] Parse(string input)
        => input.Split("\n")
                .Select((line, rowIndex) =>
                    line.ToCharArray()
                        .Select((height, columnIndex) =>
                            new MatrixTree(int.Parse(height.ToString()), rowIndex, columnIndex))
                        .ToArray())
                .ToArray();
}