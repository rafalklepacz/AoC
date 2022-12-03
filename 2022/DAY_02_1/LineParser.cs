namespace DAY_02_1;

public class LineParser
{
    const string ExpectedChars = "ABCXYZ";
    const char Separator = ' ';
    const string ExceptionMessage = "The input string is in invalid format.";

    public static (Shape First, Shape Second) Parse(string line)
    {
        string[] splitted = line.Split(Separator);

        if (splitted.Length != 2)
            throw new FormatException(ExceptionMessage);

        string first = splitted[0];
        string second = splitted[1];

        bool invalid = first.Length != 1 ||
                       second.Length != 1 ||
                       !ExpectedChars.Contains(first) ||
                       !ExpectedChars.Contains(second);

        if (invalid)
            throw new FormatException(ExceptionMessage);

        var firstShape = char.Parse(first).ToFirstShape();
        var secondShape = char.Parse(second).ToSecondShape();

        return (firstShape, secondShape);
    }
}