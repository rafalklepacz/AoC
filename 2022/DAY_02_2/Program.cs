var inputFile = "input.txt";
var drawLines = new[] { "A X", "B Y", "C Z" };
var winLines = new[] { "A Y", "B Z", "C X" };

string GetResultLine(string line)
{
    string[] splitted = line.Split(' ');
    string first = splitted[0];
    string second = splitted[1];

    string tmp = second switch
    {
        "X" when first == "A" => "Z",
        "X" when first == "B" => "X",
        "X" when first == "C" => "Y",
        "Y" when first == "A" => "X",
        "Y" when first == "B" => "Y",
        "Y" when first == "C" => "Z",
        "Z" when first == "A" => "Y",
        "Z" when first == "B" => "Z",
        "Z" when first == "C" => "X",
        _ => ""
    };

    return $"{first} {tmp}";
}

var sum = File.ReadAllLines(inputFile)
    .AsEnumerable()
    .Sum(line =>
    {
        line = GetResultLine(line);
        return line switch
            {
                _ when winLines.Contains(line) => 6,
                _ when drawLines.Contains(line) => 3,
                _ => 0
            }
            + line.Split(' ')[1] switch
            {
                "X" => 1,
                "Y" => 2,
                "Z" => 3,
                _ => 0
            };
    });

Console.WriteLine(sum);