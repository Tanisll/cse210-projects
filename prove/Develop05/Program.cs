using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> _goals = new List<Goal>();
    static int _score = 0;

    static void Main(string[] args)
    {
        LoadGoals();

        if (!File.Exists("quotes.txt"))
        {
            using (StreamWriter writer = new StreamWriter("quotes.txt"))
            {
                writer.WriteLine("Believe you can and you're halfway there.");
                writer.WriteLine("With God, all things are possible.");
                writer.WriteLine("Discipline is choosing between what you want now and what you want most.");
                writer.WriteLine("Spiritual progress requires consistent effort.");
                writer.WriteLine("The Lord loves effort because effort brings rewards.");
            }
            Console.WriteLine("quotes.txt was not found, so a new one was created with default quotes.");
        }

        ShowQuote();

        while (true)
        {
            Console.WriteLine($"\nCurrent Score: {_score} - Rank: {GetRank(_score)}");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Completion");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordGoal(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void ShowQuote()
    {
        string[] quotes = File.ReadAllLines("quotes.txt");
        Random rnd = new Random();
        Console.WriteLine("\nMotivational Quote of the Day:");
        Console.WriteLine(quotes[rnd.Next(quotes.Length)]);
    }

    static string GetRank(int score)
    {
        if (score >= 3000) return "Hero";
        if (score >= 2000) return "Warrior";
        if (score >= 1000) return "Disciple";
        return "Initiate";
    }

    static void CreateGoal()
    {
        Console.WriteLine("Goal type (1: Simple, 2: Eternal, 3: Checklist): ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Times to complete: ");
                int target = int.Parse(Console.ReadLine());

                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());

                _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default:
                Console.WriteLine("Invalid type.");
                break;
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Display()}");
        }
    }

    static void RecordGoal()
    {
        ListGoals();

        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index >= 0 && index < _goals.Count)
        {
            _score += _goals[index].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt"))
            return;

        _goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            _goals.Add(GoalFactory.Create(lines[i]));
        }
    }
}
