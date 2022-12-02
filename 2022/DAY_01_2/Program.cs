string inputFile = "input.txt";
string newLine = "\r\n";

var sum = File.ReadAllText(inputFile)
              .Split($"{newLine}{newLine}")
              .Where(i => !string.IsNullOrEmpty(i))
              .Select(i => i.Split(newLine)
                            .Select(j => int.Parse(j))
                            .Sum())
              .OrderByDescending(_ => _)
              .Take(3)
              .Sum();

Console.WriteLine(sum);
