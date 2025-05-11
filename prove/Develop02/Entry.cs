using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;

    public Entry(string prompt, string response)
    {
        _date = DateTime.Now.ToString("yyyy-MM-dd");
        _prompt = prompt;
        _response = response;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}\n");
    }

    public string GetEntryAsString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry CreateEntryFromString(string entryString)
    {
        string[] parts = entryString.Split('|');
        Entry entry = new Entry(parts[1], parts[2]);
        entry._date = parts[0];
        return entry;
    }
}
