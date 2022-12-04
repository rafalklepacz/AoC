namespace DAY_04_1;

public class SectionRangePair
{
    public SectionRangePair(SectionRange firstRange, SectionRange secondRange)
    {
        FirstRange = firstRange;
        SecondRange = secondRange;
    }

    public SectionRange FirstRange { get; init; }
    public SectionRange SecondRange { get; init; }

    public bool HasOverlappedSection
        => FirstRange.Sections.Any(s => SecondRange.Sections.Contains(s)) ||
           SecondRange.Sections.Any(s => FirstRange.Sections.Contains(s));
}