string inputFile = "input.txt";
string newLine = "\r\n";

var max = File.ReadAllText(inputFile)
              .Split($"{newLine}{newLine}")
              .Where(i => !string.IsNullOrEmpty(i))
              .Max(i => i.Split(newLine)
                         .Select(j => int.Parse(j))
                         .Sum());
Console.WriteLine(max);