using DAY_07_1;

var inputFile = "input.txt";

var input = await File.ReadAllTextAsync(inputFile);
var entry = InputParser.Parse(input);

int max = 100000;
var sum = entry.FlatList
                    .Where(e => e.IsDirectory && e.Size < max)
                    .Select(e => e.Size)
                    .OrderBy(i => i)
                    .Sum();

Console.WriteLine(sum);