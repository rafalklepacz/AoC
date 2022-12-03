var inputFile = "input.txt";

var result = File.ReadAllLines(inputFile)
                    .AsEnumerable()
                    .Chunk(3)
                    .Select(GetDuplicates)
                    .Select(d => d.Select(GetValue).Sum())
                    .Sum();

Console.WriteLine(result);

string GetDuplicates(string[] group)
    => new(group[0].Intersect(group[1].Intersect(group[2]).Distinct()).ToArray());

int GetValue(char c)
    => c switch
    {
        _ when Char.IsLower(c) => c - 96,
        _ => c - 38,
    };
