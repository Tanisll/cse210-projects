public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    protected string GetTitle()
    {
        return _title;
    }

    protected string GetDate()
    {
        return _date;
    }

    public virtual string GetStandardDetails()
    {
        return $"Event: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nLocation:\n{_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"Event Type: General\nTitle: {_title}\nDate: {_date}";
    }
}
