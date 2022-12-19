using DAY_11_2;

Console.WriteLine($"--- Day 11: Monkey in the Middle (2) [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ---");

var inputFile = "input.txt";
var input = await File.ReadAllTextAsync(inputFile);
var monkeys = InputParser.Parse(input);

var mediator = new MonkeysMediator(monkeys);
monkeys.ToList().ForEach(m => m.SetMediator(mediator));

ulong divider = (ulong)monkeys.Select(m => (long)m.TestDivider).Aggregate(1, (long x, long y) => x * y);

for (int i = 1; i <= 10000; i++)
{
    monkeys.ToList().ForEach(m => m.InspectItems(divider));
}

var items = monkeys.OrderByDescending(m => m.InspectCount).Take(2);
ulong result = items.First().InspectCount * items.Last().InspectCount;


Console.WriteLine($"What is the level of monkey business after 10000 rounds?\nAnswer: {result}");
