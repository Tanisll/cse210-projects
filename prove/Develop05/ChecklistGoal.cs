public class ChecklistGoal : Goal
{
    private int _count, _target, _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus, int count = 0)
        : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
        _count = count;
    }

    public override int RecordEvent()
    {
        if (_count < _target)
        {
            _count++;
            return _count == _target ? _points + _bonus : _points;
        }
        return 0;
    }

    public override string Display()
    {
        return $"[{(_count >= _target ? "X" : " ")}] {_name} ({_description}) -- Completed {_count}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist:{_name},{_description},{_points},{_target},{_bonus},{_count}";
    }
}
