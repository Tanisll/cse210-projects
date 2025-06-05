using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _originalPrompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _originalQuestions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    private List<string> _promptPool;
    private List<string> _questionPool;

    public ReflectionActivity()
    {
        _name = "Reflection Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience.";

        _promptPool = new List<string>(_originalPrompts);
        _questionPool = new List<string>(_originalQuestions);
    }

    protected override void PerformActivity()
    {
        Random rand = new Random();

        // Display one random prompt and remove it from the list
        string prompt = GetRandomFromPool(_promptPool, rand);
        Console.WriteLine($"\n{prompt}");
        ShowSpinner(6); // Doubled from 3 seconds to 6 seconds

        int time = GetDuration();

        // Show reflection questions until time runs out or the pool is empty
        while (time > 0 && _questionPool.Count > 0)
        {
            string question = GetRandomFromPool(_questionPool, rand);
            Console.WriteLine($"\n> {question}");

            ShowSpinner(10); // Doubled from 5 seconds to 10 seconds

            time -= 12; // Previously 6 (5 + 1); now doubled to 12 (10 + 2 for pacing)
        }

        if (_questionPool.Count == 0)
        {
            Console.WriteLine("\nYou've reflected on all the questions this round!");
            ShowSpinner(6); // Doubled from 3 to 6 seconds
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
