using System.Text.RegularExpressions;

namespace DAY_11_2;

internal static class InputParser
{
    public static Monkey[] Parse(string input)
    {
        return input.Split("\r\n\r\n")
                            .Select(group =>
                            {
                                var lines = group.Split("\r\n");

                                var no = ParseNo(lines[0]);
                                var items = ParseItems(lines[1]);
                                var operation = ParseOperation(lines[2]);
                                var testDivider = ParseTestDivider(lines[3]);
                                var throwOnTrueToMonkeyNo = ParseThrowOnTrueToMonkeyNo(lines[4]);
                                var throwOnFalseToMonkeyNo = ParseThrowOnFalseToMonkeyNo(lines[5]);
                                
                                return new Monkey(no, items, testDivider, throwOnTrueToMonkeyNo, throwOnFalseToMonkeyNo, operation);
                            })
                            .ToArray();
    }

    private static int ParseNo(string line)
    {
        string s = RemovePrefix(line, "Monkey ");
        s = s.Substring(0, s.Length - 1);
        return int.Parse(s);
    }

    private static IEnumerable<ulong> ParseItems(string line)
    {
        string s = RemovePrefix(line, "Starting items: ");
        return s.Split(',').Select(ulong.Parse);
    }

    private static int ParseTestDivider(string line)
    {
        string s = RemovePrefix(line, "Test: divisible by ");
        return int.Parse(s);
    }

    private static int ParseThrowOnTrueToMonkeyNo(string line)
    {
        string s = RemovePrefix(line, "If true: throw to monkey ");
        return int.Parse(s);
    }

    private static int ParseThrowOnFalseToMonkeyNo(string line)
    {
        string s = RemovePrefix(line, "If false: throw to monkey ");
        return int.Parse(s);
    }

    private static Func<ulong, ulong> ParseOperation(string line)
    {
        string tmp1 = RemovePrefix(line, "Operation: new = old ");
        string[] tmp2 = tmp1.Split(' ');

        string @operator = tmp2.First();
        string operand = tmp2.Last();
        bool isUnaryOperation = operand.Trim().ToLower() == "old";
        ulong.TryParse(operand, out ulong operandValue);

        return @operator switch
        {
            "+" => (ulong oldValue) => oldValue + operandValue,
            "*" => (ulong oldValue) => isUnaryOperation ? oldValue * oldValue : oldValue * operandValue,
            _ => (ulong _) => 0
        };
    }

    private static string RemovePrefix(string s, string prefix)
    {
        s = s.Trim();
        if (s.Length < prefix.Length)
            return "";

        string result = s.Substring(prefix.Length);
        return result;
    }
}
