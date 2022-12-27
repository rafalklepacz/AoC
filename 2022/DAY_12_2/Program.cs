using DAY_12_2;

Console.WriteLine($"--------------------------------------------------------------------------------");
Console.WriteLine($"--- Day 12: Hill Climbing Algorithm (2) [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ---");
Console.WriteLine($"--------------------------------------------------------------------------------");

var inputFile = "input.txt";
var input = await File.ReadAllTextAsync(inputFile);
var grid = InputParser.Parse(input);
var distance = grid.CalculateDistance();

Console.WriteLine($"What is the fewest steps required to move starting from any square with elevation a to the location that should get the best signal?\nAnswer: {distance}");