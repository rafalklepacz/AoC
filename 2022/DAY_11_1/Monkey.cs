namespace DAY_11_1;

internal class Monkey
{
    private MonkeysMediator _mediator;
    private long _inspectCount = 0;

    public Monkey()
    {

    }

    public Monkey(int no, IEnumerable<long> items, int testDivider, int throwOnTrueToMonkeyNo, int throwOnFalseToMonkeyNo, Func<long, long> operation)
    {
        No = no;
        Items = new Queue<long>(items);
        TestDivider = testDivider;
        ThrowOnTrueToMonkeyNo = throwOnTrueToMonkeyNo;
        ThrowOnFalseToMonkeyNo = throwOnFalseToMonkeyNo;
        Operation = operation;
    }

    public void InspectItems()
    {
        while (Items.Count > 0)
        {
            _inspectCount++;

            var item = Items.Dequeue();
            var operationResult = Operation(item) / 3;
            var isDivisible = operationResult % TestDivider == 0;

            ThrowItem(operationResult, isDivisible);
        }
    }

    public void CatchItem(long item)
        => Items.Enqueue(item);

    public void ThrowItem(long item, bool isDivisible)
    {
        var monkeyNo = isDivisible ? ThrowOnTrueToMonkeyNo: ThrowOnFalseToMonkeyNo;
        _mediator.TransferItem(monkeyNo, item);
    }

    public void SetMediator(MonkeysMediator mediator)
        => _mediator = mediator;

    public int No { get; }
    public Queue<long> Items { get; }
    public int TestDivider { get; }
    public int ThrowOnTrueToMonkeyNo { get; }
    public int ThrowOnFalseToMonkeyNo { get; }
    public Func<long, long> Operation { get; }

    public long InspectCount
        => _inspectCount;

    public override string ToString()
        => $"No: {No}; Items: {string.Join(',', Items)}; TestDivider: {TestDivider}; ThrowOnTrueToMonkeyNo: {ThrowOnTrueToMonkeyNo}; ThrowOnFalseToMonkeyNo: {ThrowOnFalseToMonkeyNo}; InspectCount: {InspectCount}";
}