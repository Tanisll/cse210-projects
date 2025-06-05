using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly.";
    }

    protected override void PerformActivity()
    {
        int time = GetDuration();
        while (time > 0)
        {
            Console.Write("\nBreathe in...");
            Countdown(3);
            Console.Write("Breathe out...");
            Countdown(3);
            time -= 6;
        }
    }
}
