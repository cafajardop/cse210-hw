using System;
using System.Threading;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity() {}

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity.\n");
        Console.WriteLine(_description);
        Console.Write("\nHow many seconds would you like for your session? ");

        string input = Console.ReadLine();
        if (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            _duration = 10;
        }

        Console.WriteLine("\nGet ready to begin...");
        ShowSpinner(3);
    }
    
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed {_duration} seconds of the {_name} activity.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        string[] frames = { "|", "/", "-", "\\" };
        int frameIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[frameIndex % frames.Length]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            frameIndex++;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
