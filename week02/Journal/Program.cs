using System;

class Program
{
    static void Main(string[] args)
    {
        var journal = new Journal();
        var prompts = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.Write("What would you like to do? ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": 
                    var prompt = prompts.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    var text = Console.ReadLine() ?? "";
                    var entry = new Entry
                    {
                        DateText = DateTime.Now.ToShortDateString(),
                        PromptText = prompt,
                        EntryText = text
                    };
                    journal.AddEntry(entry);
                    Console.WriteLine();
                    break;

                case "2": 
                    journal.DisplayAll();
                    break;

                case "3": 
                    Console.Write("Enter filename to load: ");
                    var lf = Console.ReadLine();
                    if (File.Exists(lf)) journal.LoadFromFile(lf!);
                    else Console.WriteLine("File not found.");
                    break;

                case "4": 
                    Console.Write("Enter filename to save: ");
                    var sf = Console.ReadLine();
                    journal.SaveToFile(sf!);
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Please enter 1-5.");
                    break;
            }
        }
    }
}