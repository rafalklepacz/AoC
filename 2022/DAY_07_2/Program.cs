using DAY_07_2;

var inputFile = "input.txt";
var input = await File.ReadAllTextAsync(inputFile);

var entry = InputParser.Parse(input);

const int totalSpace = 70000000;
const int minUnusedSpace = 30000000;

int currentUnusedSpace = totalSpace - entry.Root.Size;
int spaceToFreeUp = minUnusedSpace - currentUnusedSpace;

int result = entry.Root.FlatList.Select(e => e.Size)
                                .OrderBy(_ => _)
                                .FirstOrDefault(e => e >= spaceToFreeUp);

Console.WriteLine(result);