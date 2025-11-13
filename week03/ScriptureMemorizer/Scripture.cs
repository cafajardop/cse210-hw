public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private static Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        foreach (string wordText in text.Split(' '))
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        List<Word> visibleWords = _words
        .Where(w => !w.IsHidden())
        .ToList();

        if (visibleWords.Count == 0)
        {
            return;
        }

        int toHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < toHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }

    }

    public string GetDisplayText()
    {
        string wordsText = string.Join(" ",
            _words.Select(w => w.GetDisplayText()));

        return $"{_reference.GetDisplayText()} - {wordsText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
