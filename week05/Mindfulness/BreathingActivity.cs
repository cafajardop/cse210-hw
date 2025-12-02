using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing";
        _description = "This activity will help you relax by guiding you through slow breathing. Clear your mind and focus on your breath.";
    }

    public void Run()
    {        
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        bool inhale = true;
     
        while (DateTime.Now < endTime)
        {
            if (inhale)
            {
                Console.Write("\nBreathe in... ");
            }
            else
            {
                Console.Write("\nBreathe out... ");
            }

            ShowCountDown(4);
            inhale = !inhale;
        }

        DisplayEndingMessage();
        Console.WriteLine("\nPress ENTER to return to the menu...");
        Console.ReadLine();
    }
}
