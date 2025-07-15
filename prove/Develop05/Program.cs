using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static int score = 0;
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
            Console.WriteLine($"\nCurrent Score: {score} - Rank: {GetRank(score)}");
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
            case "1": goals.Add(new SimpleGoal(name, desc, points)); break;
            case "2": goals.Add(new EternalGoal(name, desc, points)); break;
            case "3":
                Console.Write("Times to complete: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
            default: Console.WriteLine("Invalid type."); break;
        }
    }

    static void ListGoals()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Display()}");
        }
    }

    static void RecordGoal()
    {
        ListGoals();
        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            score += goals[index].RecordEvent();
        }
    }

    static void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(score);
            foreach (var goal in goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    static void LoadGoals()
    {
        if (!File.Exists("goals.txt")) return;
        goals.Clear();
        string[] lines = File.ReadAllLines("goals.txt");
        score = int.Parse(lines[0]);
        for (int i = 1; i < lines.Length; i++)
        {
            goals.Add(GoalFactory.Create(lines[i]));
        }
    }
}

abstract class Goal
{
    public string Name, Description;
    protected int Points;
    public Goal(string name, string desc, int points)
    {
        Name = name; Description = desc; Points = points;
    }
    public abstract int RecordEvent();
    public abstract string Display();
    public abstract string GetStringRepresentation();
}

class SimpleGoal : Goal
{
    private bool Completed;
    public SimpleGoal(string name, string desc, int points, bool completed = false)
        : base(name, desc, points) { Completed = completed; }
    public override int RecordEvent() => Completed ? 0 : (Completed = true, Points).Item2;
    public override string Display() => $"[{(Completed ? "X" : " ")}] {Name} ({Description})";
    public override string GetStringRepresentation() => $"Simple:{Name},{Description},{Points},{Completed}";
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points) : base(name, desc, points) { }
    public override int RecordEvent() => Points;
    public override string Display() => $"[∞] {Name} ({Description})";
    public override string GetStringRepresentation() => $"Eternal:{Name},{Description},{Points}";
}

class ChecklistGoal : Goal
{
    private int Count, Target, Bonus;
    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int count = 0)
        : base(name, desc, points) { Target = target; Bonus = bonus; Count = count; }
    public override int RecordEvent()
    {
        if (Count < Target)
        {
            Count++;
            return Count == Target ? Points + Bonus : Points;
        }
        return 0;
    }
    public override string Display() => $"[{(Count >= Target ? "X" : " ")}] {Name} ({Description}) -- Completed {Count}/{Target}";
    public override string GetStringRepresentation() => $"Checklist:{Name},{Description},{Points},{Target},{Bonus},{Count}";
}

static class GoalFactory
{
    public static Goal Create(string line)
    {
        string[] parts = line.Split(":");
        string type = parts[0];
        string[] data = parts[1].Split(",");

        return type switch
        {
            "Simple" => new SimpleGoal(data[0], data[1], int.Parse(data[2]), bool.Parse(data[3])),
            "Eternal" => new EternalGoal(data[0], data[1], int.Parse(data[2])),
            "Checklist" => new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])),
            _ => throw new Exception("Unknown goal type")
        };
    }
}
