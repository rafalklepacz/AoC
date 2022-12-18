using DAY_10_1;

Console.WriteLine($"--- Day 10: Cathode-Ray Tube (1) [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ---");

var inputFile = "input.txt";
var input = await File.ReadAllTextAsync(inputFile);
var instructions = InputParser.Parse(input);
var processor = Processor.Create();
processor.Process(instructions);

Console.WriteLine($"What is the sum of these six signal strengths? Your puzzle answer is: {processor.SignalStrengthsSum}");
