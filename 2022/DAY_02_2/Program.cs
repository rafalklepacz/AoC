using DAY_02_1;

var inputFile = "input.txt";

var sum = File.ReadAllLines(inputFile)
              .AsEnumerable()
              .Select(line =>
              {
                  var parseResult = LineParser.Parse(line);
                  var game = Game.Create(parseResult.First, parseResult.Result);
                  return game;
              })
              .Select(game => game.WonPoints)
              .Sum();

Console.WriteLine(sum);
