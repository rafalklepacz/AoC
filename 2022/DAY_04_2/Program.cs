using DAY_04_1;

var inputFile = "input.txt";

var result = File.ReadAllLines(inputFile)
                 .AsEnumerable()
                 .Select(LineParser.Parse)
                 .Count(pair => pair.HasOverlappedSection);

Console.WriteLine(result);
