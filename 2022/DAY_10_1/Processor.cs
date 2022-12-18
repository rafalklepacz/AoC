namespace DAY_10_1;

internal class Processor
{
    private int _registerX = 1;

    private Processor()
    {
    }

    public static Processor Create()
        => new Processor();

    public void Process(Instruction[] instructions)
    {
        instructions = Instruction.CreateProcessorInstructions(instructions);
        int maxCycles = _signalStrengthByCycles.Max(kv => kv.Key);

        for (int cycle = 1, index = 0; cycle <= maxCycles; cycle++, index++)
        {
            if (_signalStrengthByCycles.ContainsKey(cycle))
                _signalStrengthByCycles[cycle] = _registerX;

            _registerX += instructions[index].Value;
        }
    }

    public int SignalStrengthsSum
        => _signalStrengthByCycles.Sum(kv => kv.Key * kv.Value);

    public Dictionary<int, int> SignalStrengthByCycles => _signalStrengthByCycles;

    private Dictionary<int, int> _signalStrengthByCycles = new()
    {
        { 20, 0 },
        { 60, 0 },
        { 100, 0 },
        { 140, 0 },
        { 180, 0 },
        { 220, 0 }
    };
}
