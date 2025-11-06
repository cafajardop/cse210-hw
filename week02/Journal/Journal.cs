using System.IO;

public class Journal
{
    private readonly List<Entry> _entries = new();

    public void AddEntry(Entry e) => _entries.Add(e);

    public void DisplayAll()
    {
        if (_entries.Count == 0) { Console.WriteLine("No entries yet."); return; }
        foreach (var e in _entries) e.Display();
    }

    public void SaveToFile(string file, string sep = "|")
    {
        using var sw = new StreamWriter(file);
        foreach (var e in _entries) sw.WriteLine(e.ToFileRecord(sep));
        Console.WriteLine($"Saved {_entries.Count} entries to '{file}'.");
    }

    public void LoadFromFile(string file, string sep = "|")
    {
        _entries.Clear();
        foreach (var line in File.ReadAllLines(file))
            if (!string.IsNullOrWhiteSpace(line))
                _entries.Add(Entry.FromFileRecord(line, sep));
        Console.WriteLine($"Loaded {_entries.Count} entries from '{file}'.");
    }
}