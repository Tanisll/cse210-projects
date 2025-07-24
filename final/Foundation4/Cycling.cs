public class Cycling : Activity
{
    private double _speedMph;

    public Cycling(string date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetDistance()
    {
        return (GetSpeed() * GetMinutes()) / 60;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed();
    }

    public override string GetSummary()
    {
        return $"{GetDate()} Cycling ({GetMinutes()} min): Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
