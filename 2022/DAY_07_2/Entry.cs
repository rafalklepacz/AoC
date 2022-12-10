namespace DAY_07_2;

public class Entry
{
    private Entry(string name, bool isDirectory = false, int size = 0, Entry parent = null)
    {
        Name = name;
        Size = size;
        IsDirectory = isDirectory;
        Parent = parent;
    }

    public static Entry CreateRoot(string name)
        => new(name, true);

    public void AddChild(string name, int size = 0, bool isDirectory = false)
    {
        if (!IsDirectory)
            return;

        var entry = new Entry(name, isDirectory, size, this);
        _children.Add(entry);

        IncreaseSize(entry.Size);
    }
    
    public Entry Root
        => Parent is null ? this : Parent.Root;

    public Entry GetChild(string name)
        => _children.SingleOrDefault(c => c.Name == name);

    public string Name { get; init; }
    public bool IsDirectory { get; init; }
    public Entry Parent { get; init; }
    public int Size { get; private set; }

    private void IncreaseSize(int size)
    {
        Size += size;
        Parent?.IncreaseSize(size);
    }

    private readonly HashSet<Entry> _children = new();
    public IEnumerable<Entry> Children
        => _children;

    public IEnumerable<Entry> FlatList
        => Children.SelectMany(ch => ch.FlatList).Concat(new[] { this });
}
