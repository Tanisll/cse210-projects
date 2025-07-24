public class Running : Activity
{
    private double _distanceMiles;

    public Running(string date, int minutes, double distanceMiles)
        : base(date, minutes)
    {
        _distanceMiles = distanceMiles;
    }

    public override double GetDistance()
    {
        return _distanceMiles;
    }

    public override double GetSpeed()
    {
        return (_distanceMiles / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distanceMiles;
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Running ({GetMinutes()} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
