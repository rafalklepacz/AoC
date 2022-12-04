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

	public bool HasFullyOverlappedSections
        => (FirstRange.Sections.First() <= SecondRange.Sections.First() &&
            FirstRange.Sections.Last() >= SecondRange.Sections.Last()) ||
           (SecondRange.Sections.First() <= FirstRange.Sections.First() &&
            SecondRange.Sections.Last() >= FirstRange.Sections.Last());
}
