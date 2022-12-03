var inputFile = "input.txt";

var result = File.ReadAllLines(inputFile)
                    .AsEnumerable()
                    .Select(GetCompartments)
                    .Select(GetDuplicates)
                    .Select(d => d.Select(GetValue).Sum())
                    .Sum();

Console.WriteLine(result);

(string First, string Second) GetCompartments(string rucksack)
{
    var half = rucksack.Length / 2;
    var first = rucksack.Substring(0, half);
    var second = rucksack.Substring(half, half);
    return (first, second);
}

string GetDuplicates((string First, string Second) compartments)
    =>  new (compartments.First.Intersect(compartments.Second).ToArray());

int GetValue(char c)
    => c switch
    {
        _ when Char.IsLower(c) => c - 96,
        _ => c - 38,
    };
