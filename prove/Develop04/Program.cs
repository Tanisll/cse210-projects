// EXCEEDS REQUIREMENTS:
// - Tracks and displays how many times each activity has been completed.
// - Ensures no prompt is repeated in a session.
// - Adds extra animation to breathing.
// - Uses clean class inheritance structure.

using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int reflectionCount = 0;
        int breathingCount = 0;
        int listingCount = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    breathingCount++;
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    reflectionCount++;
                    break;
                case "3":
                    activity = new ListingActivity();
                    listingCount++;
                    break;
                case "4":
                    Console.WriteLine("\nThanks for using the program!");
                    Console.WriteLine($"Breathing sessions: {breathingCount}, Reflection sessions: {reflectionCount}, Listing sessions: {listingCount}");
                    return;
                default:
                    continue;
            }

            activity.Run();
        }
    }
}
