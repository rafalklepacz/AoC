namespace DAY_10_1;

internal record Instruction(InstructionType Type, int Value = 0)
{
    public static Instruction[] CreateProcessorInstructions(Instruction[] instructions)
        => instructions.SelectMany(i => i.ToProcessorInstructions()).ToArray();

    private Instruction[] ToProcessorInstructions()
        => Type switch
        {
            InstructionType.Noop => new Instruction[] { Noop },
            InstructionType.Addx => new Instruction[] { Noop, this },
            _ => new Instruction[] { }
        };

    public static Instruction Noop
        => new(InstructionType.Noop);

    public override string ToString()
        => $"{Type}: {Value}";
}
