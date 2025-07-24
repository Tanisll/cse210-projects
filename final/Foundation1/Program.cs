using System;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Ironman Helmet Build", "Jacob", 420);
        video1.AddComment("Daniel", "This was super cool!");
        video1.AddComment("Oliver", "Nice work with the servos!");
        video1.AddComment("Brigham", "I want one!");

        Video video2 = new Video("How to Sand PLA Smooth", "TechDad", 315);
        video2.AddComment("Ronin", "Can I help with this?");
        video2.AddComment("Milo", "That’s my dad!");

        video1.DisplayVideoDetails();
        video2.DisplayVideoDetails();
    }
}
