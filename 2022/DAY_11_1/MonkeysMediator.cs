namespace DAY_11_1;

internal class MonkeysMediator
{
    private Monkey[] _monkeys;

    public MonkeysMediator(Monkey[] monkeys)
    {
        _monkeys = monkeys;
    }

    public void TransferItem(int monkeyNo, long item)
    {
        var monkey = _monkeys.FirstOrDefault(m => m.No== monkeyNo);
        if (monkey is null)
            return;

        monkey.CatchItem(item);
    }
}
