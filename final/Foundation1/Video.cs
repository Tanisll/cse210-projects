using System;
using System.Collections.Generic;

public class Video
{
    private string _title;
    private string _author;
    private int _length;
    private List<Comment> _comments;

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
        _comments = new List<Comment>();
    }

    public void AddComment(string commenter, string text)
    {
        _comments.Add(new Comment(commenter, text));
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void DisplayVideoDetails()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length} seconds");
        Console.WriteLine($"Comments ({GetCommentCount()}):");
        DisplayComments();
        Console.WriteLine();
    }

    private void DisplayComments()
    {
        foreach (Comment comment in _comments)
        {
            Console.WriteLine($"- {comment.GetName()}: {comment.GetText()}");
        }
    }
}
