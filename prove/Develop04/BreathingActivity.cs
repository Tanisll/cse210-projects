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
            Thread.Sleep(1000); // 1-second delay before countdown
            Countdown(3);       // Original 3-second inhale (can be adjusted if doubling timing)

            Console.Write("Breathe out...");
            Thread.Sleep(1000); // 1-second delay before countdown
            Countdown(3);       // Original 3-second exhale

            time -= 8; // 1 sec prep + 3 sec countdown x 2 = 8 total seconds per cycle
        }
    }
}
