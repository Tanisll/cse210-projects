public class SimpleGoal : Goal
{
    private bool _completed;

    public SimpleGoal(string name, string desc, int points, bool completed = false)
        : base(name, desc, points)
    {
        _completed = completed;
    }

    public override int RecordEvent()
    {
        if (_completed)
            return 0;

        _completed = true;
        return _points;
    }

    public override string Display()
    {
        return $"[{(_completed ? "X" : " ")}] {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"Simple:{_name},{_description},{_points},{_completed}";
    }
}
