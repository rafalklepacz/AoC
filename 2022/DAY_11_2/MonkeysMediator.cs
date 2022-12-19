namespace DAY_11_2;

internal class MonkeysMediator
{
    private Monkey[] _monkeys;

    public MonkeysMediator(Monkey[] monkeys)
    {
        _monkeys = monkeys;
    }

    public void TransferItem(int monkeyNo, ulong item)
    {
        var monkey = _monkeys.FirstOrDefault(m => m.No == monkeyNo);
        if (monkey is null)
            return;

        monkey.CatchItem(item);
    }
}
