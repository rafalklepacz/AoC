namespace DAY_06_1;

public class LineParser
{
    private const int MarkerLength = 4;
    public static int GetMarkerCount(string line)
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
