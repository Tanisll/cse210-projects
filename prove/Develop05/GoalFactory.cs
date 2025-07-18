using System;

public static class GoalFactory
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
