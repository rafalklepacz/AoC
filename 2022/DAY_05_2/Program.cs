using DAY_05_1;

var inputFile = "input.txt";
var text = File.ReadAllText(inputFile);
var parser = InputParser.Parse(text);

var stacksContainer = parser.StacksContainer;
var moves = parser.CrateMoves;

stacksContainer.MakeMoves(moves);

Console.WriteLine(stacksContainer.GetTopCratesLabels());
