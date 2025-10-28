using System;

class Program
{
    static void Main(string[] args)
    {
        var numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Load with validation: repeats until the user enters 0
        while (true)
        {
            int userNumber;

            // Validation loop: keep asking until it is a valid integer
            while (true)
            {
                Console.Write("Enter number: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out userNumber))
                    break;

                Console.WriteLine("⚠️ Please enter a valid integer (no letters or symbols).");
            }

            if (userNumber == 0) break;
            numbers.Add(userNumber);
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers entered, exiting program.");
            return;
        }

        // 1) Sum
        int sum = 0;
        foreach (int n in numbers) sum += n;

        // 2) Average
        double average = (double)sum / numbers.Count;

        // 3) Maximum
        int max = numbers[0];
        foreach (int n in numbers) if (n > max) max = n;

        // Positive minor
        int? smallestPositive = null; 
        foreach (int n in numbers)
        {
            if (n > 0 && (smallestPositive == null || n < smallestPositive))
                smallestPositive = n;
        }

        // Ordered list
        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        if (smallestPositive != null)
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        else
            Console.WriteLine("The smallest positive number is: (none)");

        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers) Console.WriteLine(n);
    }
}