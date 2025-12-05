using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. List goals");
            Console.WriteLine("  2. Create new goal");
            Console.WriteLine("  3. Record event");
            Console.WriteLine("  4. Save goals");
            Console.WriteLine("  5. Load goals");
            Console.WriteLine("  6. Quit");

            int choice = ReadInt("Select a choice from the menu: ");
            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    ListGoalDetails();
                    break;

                case 2:
                    CreateGoal();
                    break;

                case 3:
                    RecordEvent();
                    break;

                case 4:
                    SaveGoals();
                    break;

                case 5:
                    LoadGoals();
                    break;

                case 6:
                    quit = true;
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int choice = ReadInt("Which type of goal would you like to create? ");

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = ReadInt("What is the amount of points associated with this goal? ");

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case 3:
                int target = ReadInt("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = ReadInt("What is the bonus for accomplishing it that many times? ");
                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("Tipo de goal no válido.");
                break;
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        int index = ReadInt("Which goal did you accomplish? ") - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Índice no válido.");
            return;
        }

        Goal goal = _goals[index];
        int points = goal.RecordEvent();
        _score += points;

        Console.WriteLine($"Congratulations! You have earned {points} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(filename))
        {
            output.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] typeAndData = line.Split(':');
            string type = typeAndData[0];
            string[] parts = typeAndData[1].Split('|');

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2]),
                        bool.Parse(parts[3])
                    ));
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2])
                    ));
                    break;

                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(
                        parts[0],
                        parts[1],
                        int.Parse(parts[2]),
                        int.Parse(parts[4]),
                        int.Parse(parts[3]),
                        int.Parse(parts[5]) 
                    ));
                    break;
            }
        }

        Console.WriteLine("Goals loaded.");
    }

    
    private int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.WriteLine("Por favor escribe un número válido.");
        }
    }
}
