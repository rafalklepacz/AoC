namespace DAY_04_1;

public class LineParser
{
    const char PairSeparator = ',';
    const char RangesSeparator = '-';
    const string ExceptionMessage = "The input string is in invalid format.";

    public static SectionRangePair Parse(string line)
    {
        string[] splittedPair = line.Split(PairSeparator);

        if (splittedPair.Length != 2)
            throw new FormatException(ExceptionMessage);

        string firstPair = splittedPair[0];
        string secondPair = splittedPair[1];

        var firstSectionRange = ParseSectionRange(firstPair);
        var secondSectionRange = ParseSectionRange(secondPair);

        return new SectionRangePair(firstSectionRange, secondSectionRange);
    }

    private static SectionRange ParseSectionRange(string sectionPair)
    {
        string[] splittedSectionRange = sectionPair.Split(RangesSeparator);
        
        if (splittedSectionRange.Length != 2)
            throw new FormatException(ExceptionMessage);
        
        if (!int.TryParse(splittedSectionRange[0], out int from))
            throw new FormatException(ExceptionMessage);
        
        if (!int.TryParse(splittedSectionRange[1], out int to))
            throw new FormatException(ExceptionMessage);

        return new SectionRange(from, to);
    }
}