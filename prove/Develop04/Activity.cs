using System;
using System.Threading;

public abstract class Activity
{
    private int _duration;
    protected string _name;
    protected string _description;

    public void Run()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nPrepare to begin...");
        ShowSpinner(3); // pause with spinner before starting

        PerformActivity();

        Console.WriteLine("\nWell done!");
        ShowSpinner(2); // short pause after completion
        Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
        ShowSpinner(2); // final pause
    }

    // Abstract method implemented in derived classes
    protected abstract void PerformActivity();

    // Returns the duration input by the user
    protected int GetDuration() => _duration;

    // Updated spinner: shows one dot per second
    protected void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");     // display a single dot
            Thread.Sleep(1000);     // wait for 1 second
        }
        Console.WriteLine();        // move to the next line after spinner ends
    }

    // Countdown: shows the countdown in place (e.g., "3 2 1")
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
        }
        Console.WriteLine(); // move to the next line after countdown ends
    }
}
