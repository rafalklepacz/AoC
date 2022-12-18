using DAY_10_2;

Console.WriteLine($"--- Day 10: Cathode-Ray Tube (2) [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ---");

var inputFile = "input.txt";
var input = await File.ReadAllTextAsync(inputFile);
var instructions = InputParser.Parse(input);
var processor = Processor.Create();
processor.Process(instructions);

Console.WriteLine($"What eight capital letters appear on your CRT?\n{processor.Image}");
