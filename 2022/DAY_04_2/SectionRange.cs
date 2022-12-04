namespace DAY_04_1;

public record SectionRange
{
    public SectionRange(int from, int to)
        => Sections = Enumerable.Range(from, to - from + 1);

    public IEnumerable<int> Sections { get; init; }
}