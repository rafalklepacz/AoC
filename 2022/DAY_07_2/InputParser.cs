namespace DAY_07_2;

public class InputParser
{
    public static Entry Parse(string input)
    {
        var commandGroups = input.Split("$")
                                 .AsEnumerable()
                                 .Where(line => !string.IsNullOrEmpty(line))
                                 .Skip(1);

        var currentEntry = Entry.CreateRoot("/");
        foreach (var commandGroup in commandGroups)
            currentEntry = ParseCommandGroup(commandGroup, currentEntry);

        return currentEntry.Root;
    }

    private static Entry ParseCommandGroup(string group, Entry currentEntry)
    {
        group = group.Trim();
        string[] lines = group.Split("\n");
        string commandLine = lines[0];

        bool isCd = commandLine.StartsWith("cd");
        if (isCd)
        {
            string arg = commandLine.Split(" ")[1];
            bool goUp = arg == "..";
            if (goUp)
            {
                currentEntry = currentEntry.Parent;
                return currentEntry;
            }

            currentEntry = currentEntry.GetChild(arg);
        }

        bool isLs = commandLine == "ls";
        if (isLs)
        {
            for (int i = 1; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(" ");
                bool isDirectory = line[0] == "dir";
                string name = line[1];
                int size = isDirectory ? 0 : int.Parse(line[0]);
                
                currentEntry?.AddChild(name, size, isDirectory);
            }
        }

        return currentEntry;
    }
}