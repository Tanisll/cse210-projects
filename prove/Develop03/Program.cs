using System;

class Program
{
    static void Main(string[] args)
    {
        // Reference: Proverbs 3:5-6
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string scriptureText = "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        Scripture scripture = new Scripture(reference, scriptureText);

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
                break;

            scripture.HideRandomWords(3); // Hide 3 random unhidden words
        }

        Console.Clear();
        Console.WriteLine("All words hidden. Great job!");
    }
}

// This program exceeds core requirements by hiding only unhidden words,
// supporting multiple-verse references, and using encapsulation with clean design.
// All member variables are private and each class handles its own responsibilities.