using DAY_06_1;

var inputFile = "input.txt";

var input = await File.ReadAllTextAsync(inputFile);
var parser = InputParser.Parse(input);

Console.WriteLine(parser.ProcessedCharactersCount);
