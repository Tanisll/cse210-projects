using System;

public abstract class Goal
{
    protected string _name, _description;
    protected int _points;

    public Goal(string name, string desc, int points)
    {
        _name = name;
        _description = desc;
        _points = points;
    }

    public abstract int RecordEvent();
    public abstract string Display();
    public abstract string GetStringRepresentation();
}
