using System.Text;

namespace DAY_10_2;

internal class Processor
{
    private int _registerX = 1;
    private StringBuilder _text = new StringBuilder();

    private const int _rows = 6;
    private const int _cols = 40;
    private const int _maxCycles = _rows * _cols;    

    private Processor()
    {
    }

    public static Processor Create()
        => new Processor();

    public void Process(Instruction[] instructions)
    {
        instructions = Instruction.CreateProcessorInstructions(instructions);

        for (int cycle = 0; cycle < _maxCycles; cycle++)
        {
            int charIndex = cycle % _cols;

            if (charIndex == 0)
                _text.AppendLine();

            char c = charIndex >= _registerX - 1 && charIndex <= _registerX + 1 ? '#' : '.';

            _text.Append(c);

            _registerX += instructions[cycle].Value;
        }
    }

    public string Image
        => _text.ToString();
}
