using DAY_08_2;

var inputFile = "input.txt";

var result = await File.ReadAllTextAsync(inputFile);
var matrix = InputParser.Parse(result);

matrix.SelectMany(m => m)
      .Where(m => m.Row > 0 && m.Row < matrix.Length - 1 &&
                  m.Column > 0 && m.Column < matrix.Length - 1)
      .ToList()
      .ForEach(tree => tree.UpdateScenicScore(matrix));

var max = matrix.SelectMany(t => t)
                .OrderByDescending(t => t.ScenicScore)
                .First().ScenicScore;

Console.WriteLine(max);
