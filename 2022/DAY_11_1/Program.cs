using DAY_11_1;

Console.WriteLine($"--- Day 11: Monkey in the Middle (1) [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ---");

var inputFile = "input.txt";
var input = await File.ReadAllTextAsync(inputFile);
var monkeys = InputParser.Parse(input);

var mediator = new MonkeysMediator(monkeys);
monkeys.ToList().ForEach(m => m.SetMediator(mediator));

for (int i = 1; i <= 20; i++)
{
    monkeys.ToList().ForEach(m => m.InspectItems());
}

var items = monkeys.OrderByDescending(m => m.InspectCount).Take(2);
long result = items.First().InspectCount * items.Last().InspectCount;

Console.WriteLine($"What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans?\nAnswer: {result}");
