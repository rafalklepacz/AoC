namespace DAY_11_2;

internal class Monkey
{
    private MonkeysMediator _mediator;
    private ulong _inspectCount = 0;

    public Monkey()
    {

    }

    public Monkey(int no, IEnumerable<ulong> items, int testDivider, int throwOnTrueToMonkeyNo, int throwOnFalseToMonkeyNo, Func<ulong, ulong> operation)
    {
        No = no;
        Items = new Queue<ulong>(items);
        TestDivider = testDivider;
        ThrowOnTrueToMonkeyNo = throwOnTrueToMonkeyNo;
        ThrowOnFalseToMonkeyNo = throwOnFalseToMonkeyNo;
        Operation = operation;
    }

    public void InspectItems(ulong operationDivider)
    {
        while (Items.Count > 0)
        {
            _inspectCount++;

            var item = Items.Dequeue();
            var operationResult = Operation(item) % operationDivider;
            var isDivisible = operationResult % (ulong)TestDivider == 0;

            ThrowItem(operationResult, isDivisible);
        }
    }

    public void CatchItem(ulong item)
        => Items.Enqueue(item);

    public void ThrowItem(ulong item, bool isDivisible)
    {
        var monkeyNo = isDivisible ? ThrowOnTrueToMonkeyNo: ThrowOnFalseToMonkeyNo;
        _mediator.TransferItem(monkeyNo, item);
    }

    public void SetMediator(MonkeysMediator mediator)
        => _mediator = mediator;

    public int No { get; }
    public Queue<ulong> Items { get; }
    public int TestDivider { get; }
    public int ThrowOnTrueToMonkeyNo { get; }
    public int ThrowOnFalseToMonkeyNo { get; }
    public Func<ulong, ulong> Operation { get; }

    public ulong InspectCount
        => _inspectCount;

    public override string ToString()
        => $"No: {No}; Items: {string.Join(',', Items)}; TestDivider: {TestDivider}; ThrowOnTrueToMonkeyNo: {ThrowOnTrueToMonkeyNo}; ThrowOnFalseToMonkeyNo: {ThrowOnFalseToMonkeyNo}; InspectCount: {InspectCount}";
}