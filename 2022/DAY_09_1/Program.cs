using DAY_09_1;

var inputFile = "input.txt";

var input = await File.ReadAllTextAsync(inputFile);
var moves = InputParser.Parse(input);
var rope = Rope.CreateAtDefaultPoint();

while (moves.Count > 0)
{
    rope.Move(moves.Dequeue());
}

Console.WriteLine(rope.TailPositions.Distinct().Count());
