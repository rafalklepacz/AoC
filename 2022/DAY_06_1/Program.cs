using DAY_06_1;

var inputFile = "input.txt";

var result = File.ReadAllLines(inputFile)
                 .AsEnumerable()
                 .Select(LineParser.GetMarkerCount)
                 .FirstOrDefault();

Console.WriteLine(result);
