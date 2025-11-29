//A test I made to allow user to write an entry to the file. 
//I'm unsure if it actually writes, but this is the template we can ubild more on.

using System.Net.Sockets;
using Intermediate_CSharp_Final;

public class Write
{
    public static void Main()
    {
        string path = "CNoteSharpDatabase.csv";
        
        var database = LINQ.Read(path).ToList();
        
        Console.WriteLine($"What type of entry do you want to add?\n" +
                          $"1. Track\n" +
                          $"2. Audiobook\n" +
                          $"3. TV Episodes");
        
        Console.WriteLine($"\nEnter your choice (1-3): ");
        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                AddTrack(database);
                break;
            case "2":
                AddAudiobook(database);
                break;
            case "3":
                AddTVEpisodes(database);
                break;
            default:
                Console.WriteLine("Invalid choice!");
                return;
        }
    }

    public static void AddTrack(List<Object> database)
    {
        Console.WriteLine("Title: ");
        string title = Console.ReadLine();
        
        Console.WriteLine("Creator: ");
        string creator = Console.ReadLine();
        
        Console.WriteLine("Album: ");
        string album = Console.ReadLine();
        
        Console.WriteLine("Year: ");
        int year = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Duration (Minutes): ");
        double duration = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Rating: ");
        double rating = double.Parse(Console.ReadLine());
        
        database.Add(new Track(title, creator, album, year, duration, rating));
    }
    
    public static void AddAudiobook(List<Object> database)
    {
        Console.WriteLine("Title: ");
        string title = Console.ReadLine();
        
        Console.WriteLine("Creator: ");
        string creator = Console.ReadLine();
        
        Console.WriteLine("Year: ");
        int year = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Duration (Minutes): ");
        double duration = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Rating (True/False): ) ");
        bool rating = bool.Parse(Console.ReadLine());
        
        database.Add(new Audio_Book(title, creator, year, duration, rating));
    }
    
    public static void AddTVEpisodes(List<Object> database)
    {
        Console.WriteLine("Title: ");
        string title = Console.ReadLine();
        
        Console.WriteLine("Show Title:");
        string showTitle = Console.ReadLine();
        
        Console.WriteLine("Creator: ");
        string creator = Console.ReadLine();
        
        Console.WriteLine("Year: ");
        int year = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Season Number: ");
        int season = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Episode Number: ");
        int episode = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Duration (Minutes): ");
        double duration = double.Parse(Console.ReadLine());
        
        Console.WriteLine("Rating: ");
        int rating = int.Parse(Console.ReadLine());
        
        database.Add(new TV_Episode(title, showTitle, creator, year, season , episode, duration, rating));
    }
}
