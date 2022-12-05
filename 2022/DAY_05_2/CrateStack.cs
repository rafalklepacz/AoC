namespace DAY_05_1;

public class CrateStack
{
    public CrateStack(int no, Stack<Crate>? stack = null)
    {
        No = no;
        Stack = stack ?? new Stack<Crate>();
    }

    public void PutCrate(Crate crate)
        => Stack.Push(crate);

    public Crate TakeCrate()
        => Stack.Pop();

    public Stack<Crate> Stack { get; init; }

    public int No { get; init; }

    public override string ToString()
        => $"{No} ({Stack.Count}): {string.Join(' ', Stack.Select(s => s.Label))}";
}
