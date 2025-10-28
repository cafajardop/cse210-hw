using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "y";

        while (playAgain.ToLower() == "y")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int attempts = 0;

            int lowerBound = 1;
            int upperBound = 100;

            Console.WriteLine("I'm thinking of a magic number between 1 and 100!");

            while (guess != magicNumber)
            {
                Console.Write($"Enter your guess ({lowerBound}-{upperBound}): ");
                string input = Console.ReadLine();
                if (!int.TryParse(input.ToString(), out _))
                {
                    Console.WriteLine("Invalid input. Please enter a numeric guess.");
                    continue;
                }

                guess = int.Parse(input);

                // if the user's guess is out of bounds
                if (guess < lowerBound || guess > upperBound)
                {
                    Console.WriteLine($"Please enter a number within the range {lowerBound} to {upperBound}.");
                    continue;
                }

                attempts++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher!");
                    lowerBound = guess + 1;
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower!");
                    upperBound = guess - 1;
                }
                else
                {
                    Console.WriteLine($"🎉 Congratulations! You guessed the number {magicNumber} in {attempts} attempts.");
                }
            }

            Console.Write("Do you want to play again? (y/n): ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing! See you next time.");
    }
}