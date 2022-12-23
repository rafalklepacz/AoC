using DAY_12_1;

Console.WriteLine($"--------------------------------------------------------------------------------");
Console.WriteLine($"--- Day 12: Hill Climbing Algorithm (1) [{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ---");
Console.WriteLine($"--------------------------------------------------------------------------------");

var inputFile = "input.txt";

var input = await File.ReadAllTextAsync(inputFile);
var grid = InputParser.Parse(input);
var squares = grid.Squares;

// for (int i = 0; i < grid.ColumnsCount; i++)
// {
//     for (int j = 0; j < grid.RowsCount; j++)
//     {
//         Console.Write($"{squares[i][j]} ");
//     }
//     Console.WriteLine();
// }

var result = 0;

Console.WriteLine($"What is the fewest steps required to move from your current position to the location that should get the best signal?\nAnswer: {result}");