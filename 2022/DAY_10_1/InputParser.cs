namespace DAY_10_1;

internal class InputParser
{
    public static Instruction[] Parse(string input)
        => input.Split("\n")
                    .Select(line => line.Split(' '))
                    .Select(s =>
                    {
                        var type = (InstructionType)Enum.Parse(typeof(InstructionType), s.First(), true);
                        int value = int.TryParse(s.Last(), out var tmp) ? tmp : 0;
                        return new Instruction(type, value);
                    })
                    .ToArray();
}
