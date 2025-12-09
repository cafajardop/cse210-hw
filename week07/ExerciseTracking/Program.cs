using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {

        List<Activity> activities = new List<Activity>
        {
            new Running("09 Dic 2025", 30, 5.0),
            new Cycling("09 Dic 2025", 45, 20.0),
            new Swimming("09 Dic 2025", 60, 40)
        };
        foreach (Activity a in activities)
        {
            Console.WriteLine(a.GetSummary());
        }
    }
}