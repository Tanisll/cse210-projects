using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _originalPrompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _promptPool;
    private int _roundsCompleted = 0;

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by listing as many as you can. Press Enter on a blank line when you’re done.";
        _promptPool = new List<string>(_originalPrompts);
    }

    // Expose the number of prompts completed
    public int GetRoundsCompleted()
    {
        return _roundsCompleted;
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();
        bool continueListing = true;

        while (continueListing && _promptPool.Count > 0)
        {
            string prompt = GetRandomFromPool(_promptPool, rand);
            Console.WriteLine($"\n{prompt}");
            Console.WriteLine("Get ready...");
            Countdown(3);

            List<string> items = new();
            DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

            Console.WriteLine("\nStart listing! (Leave blank and press Enter to stop early.)");

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    break;

                items.Add(input);
            }

            _roundsCompleted++; // count this prompt as a completed round

            Console.WriteLine($"\nYou listed {items.Count} items!");
            ShowSpinner(3);

            if (_promptPool.Count > 0)
            {
                Console.Write("\nWould you like to do another listing prompt? (y/n): ");
                string response = Console.ReadLine().Trim().ToLower();
                continueListing = (response == "y" || response == "yes");
            }
            else
            {
                Console.WriteLine("\nYou've completed all listing prompts.");
                ShowSpinner(3);
            }
        }
    }

    private string GetRandomFromPool(List<string> pool, Random rand)
    {
        int index = rand.Next(pool.Count);
        string item = pool[index];
        pool.RemoveAt(index);
        return item;
    }
}
