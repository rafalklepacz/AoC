namespace DAY_06_1;

public sealed class InputParser
{
    private const int MarkerLength = 14;

    private InputParser(int processedCharactersCount)
    {
        ProcessedCharactersCount = processedCharactersCount;
    }

    public static InputParser Parse(string line)
    {
        int processedCharactersCount = GetProcessedCharactersCount(line);
        return new InputParser(processedCharactersCount);
    }

    public int ProcessedCharactersCount { get; init; }

    private static int GetProcessedCharactersCount(string line)
    {
        int result = 0;
        for(int index = 0; index < line.Length; index++)
        {
            string marker = line.Substring(index, MarkerLength);
            bool isMarker = marker.Distinct().Count() == MarkerLength;
            if (isMarker)
            {
                result = index + MarkerLength;
                break;
            }
        }

        return result;
    }
}
