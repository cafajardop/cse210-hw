using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine()?.Trim() ?? string.Empty;

        Console.WriteLine($"Hello, {firstName} {lastName}!");
    }
}