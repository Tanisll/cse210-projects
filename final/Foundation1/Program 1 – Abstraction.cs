using System;
using System.Collections.Generic;

// Represents a YouTube video with metadata and comments
class Video
{
    private string _title;
    private string _author;
    private int _length; // Length in seconds
    private List<Comment> _comments;

    // Constructor sets initial video info and initializes the comment list
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    // Adds a new comment to the video
    public void AddComment(string commenter, string text)
    {
        _comments.Add(new Comment(commenter, text));
    }

    // Returns the total number of comments
    public int GetCommentCount()
    {
        return _comments.Count;
    }

    // Displays the video details and all comments
    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        DisplayComments();
        Console.WriteLine();
    }

    // Loops through and displays each comment
    public void DisplayComments()
    {
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
        }
    }
}

// Represents a comment on a video
class Comment
{
    private string _name;
    private string _text;

    // Constructor sets the commenter's name and the comment text
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetText()
    {
        return _text;
    }
}

// Main program to test the abstraction concept
class Program
{
    static void Main(string[] args)
    {
        // Create first video and add comments
        Video video1 = new Video("Ironman Helmet Build", "Jacob", 420);
        video1.AddComment("Daniel", "This was super cool!");
        video1.AddComment("Oliver", "Nice work with the servos!");
        video1.AddComment("Brigham", "I want one!");

        // Create second video and add comments
        Video video2 = new Video("How to Sand PLA Smooth", "TechDad", 315);
        video2.AddComment("Ronin", "Can I help with this?");
        video2.AddComment("Milo", "That’s my dad!");

        // Display info for each video
        video1.DisplayVideoDetails();
        video2.DisplayVideoDetails();
    }
}
