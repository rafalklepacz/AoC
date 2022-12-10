using DAY_08_1;

var inputFile = "input.txt";

var result = await File.ReadAllTextAsync(inputFile);
MatrixTree[][] matrix = InputParser.Parse(result);

int bordersVisibleTreesCount = matrix.Length * 4 - 4;
matrix.SelectMany(m => m)
      .Where(m => m.Row > 0 && m.Row < matrix.Length - 1 &&
                  m.Column > 0 && m.Column < matrix.Length - 1)
      .ToList()
      .ForEach(t => t.UpdateVisibility(matrix));

var count = matrix.SelectMany(t => t)
                  .Where(t => t.Visible)
                  .Count();

Console.WriteLine(count + bordersVisibleTreesCount);
