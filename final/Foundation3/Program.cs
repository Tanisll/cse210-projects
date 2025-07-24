using System;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address("100 Tech Blvd", "Saint Anthony", "ID", "USA");
        Address address2 = new Address("99 Event Way", "Toronto", "ON", "Canada");
        Address address3 = new Address("500 Parkside Rd", "Boise", "ID", "USA");

        Lecture lecture = new Lecture(
            "AI and You",
            "How AI is changing the world.",
            "2025-08-12",
            "10:00 AM",
            address1,
            "Dr. Wallace Loveland",
            150
        );

        Reception reception = new Reception(
            "Tech Networking Night",
            "Meet professionals and tech enthusiasts.",
            "2025-08-14",
            "6:00 PM",
            address2,
            "rsvp@techconnect.com"
        );

        OutdoorGathering outdoor = new OutdoorGathering(
            "Family BBQ Bash",
            "Food, games, and fun!",
            "2025-08-16",
            "4:00 PM",
            address3,
            "Sunny with a light breeze"
        );

        Event[] events = { lecture, reception, outdoor };

        foreach (Event e in events)
        {
            Console.WriteLine("--- Standard Details ---");
            Console.WriteLine(e.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("--- Full Details ---");
            Console.WriteLine(e.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("--- Short Description ---");
            Console.WriteLine(e.GetShortDescription());
            Console.WriteLine("\n===========================\n");
        }
    }
}
