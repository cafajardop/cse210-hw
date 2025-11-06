public class Entry
{
    public string DateText { get; set; } = "";
    public string PromptText { get; set; } = "";
    public string EntryText { get; set; } = "";

    public string ToFileRecord(string sep = "|")
    {
        return $"{DateText}{sep}{PromptText}{sep}{EntryText}";
    }

    public static Entry FromFileRecord(string line, string sep = "|")
    {
        var parts = line.Split(sep);
        return new Entry
        {
            DateText = parts.Length > 0 ? parts[0] : "",
            PromptText = parts.Length > 1 ? parts[1] : "",
            EntryText = parts.Length > 2 ? parts[2] : ""
        };
    }

    public void Display()
    {
        Console.WriteLine($"Date: {DateText} - Prompt: {PromptText}\n{EntryText}");
    }
}