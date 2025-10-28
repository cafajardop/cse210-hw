using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your grade percentage: ");
        string input = Console.ReadLine();

        // Valida que imput si le ingresan una letra o simbolo y no un numero devuelva un mensaje
        if (!int.TryParse(input, out _))
        {
            Console.WriteLine("Invalid input. Please enter a numeric grade percentage.");
            return;
        }

        int grade = int.Parse(input);

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.WriteLine($"Your grade is: {letter}");
        
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the class!");
        }
        else
        {
            Console.WriteLine("Better luck next time. Keep studying!");
        }
    }
}