using DAY_09_2;

var inputFile = "input.txt";

var input = await File.ReadAllTextAsync(inputFile);
var moves = InputParser.Parse(input);
var rope = Rope.CreateAtDefaultPosition(10);

while (moves.Count > 0)
{
    rope.Move(moves.Dequeue());
}

Console.WriteLine(rope.LastKnotPositions.Distinct().Count());
