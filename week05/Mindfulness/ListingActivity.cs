using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;

    public ListingActivity()
    {
        _name = "Listing";
        _description = "This activity will help you reflect...";
        _prompts = new List<string>();
        _count = 0;
    }

    public void Run() {}
    public string GetRandomPrompt() { return ""; }
    public List<string> GetListFromUser() { return new List<string>(); }
}
