namespace Intermediate_CSharp_Final;

public class LINQ
{

    private static int GetLineCount(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"The file wasn't found!");
        }

        int lineCount = 0;
        using StreamReader reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            reader.ReadLine();
            lineCount++;
        }
        return lineCount;
    }

    public static IEnumerable<object> ReadXML(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"The file wasn't found!");
        }

        XDocument xmlDoc = XDocument.Load(path);

        List<object> database = new List<object>();

        foreach (XElement elem in xmlDoc.Descendants("Entry"))
        {
            string type = (string)elem.Attribute("Type");

            switch (type)
            {
                case "Track":
                    string title1 = (string)elem.Element("Title");
                    string creator1 = (string)elem.Element("Creator");
                    string album1 = (string)elem.Element("Album");
                    int year1 = (int?)elem.Element("Year") ?? 0;
                    double duration1 = (double?)elem.Element("Duration") ?? 0.0;
                    double rating1 = (double?)elem.Element("Rating") ?? 0.0;

                    database.Add(new Track(title1, creator1, album1, year1, duration1, rating1));

                    break;
                case "Audiobook":
                    string title2 = (string)elem.Element("Title");
                    string creator2 = (string)elem.Element("Creator");
                    int year2 = (int?)elem.Element("Year") ?? 0;
                    double duration2 = (double?)elem.Element("Duration") ?? 0.0;
                    bool rating2;
                    if ((string)elem.Element("Rating") == "Thumbs Up")
                    {
                        rating2 = true;
                    }
                    else
                    {
                        rating2 = false;
                    }

                    database.Add(new Audio_Book(title2, creator2, year2, duration2, rating2));

                    break;
                case "TV_Episode":
                    string title = (string)elem.Element("Title");
                    string showTitle = (string)elem.Element("ShowTitle");
                    string creator = (string)elem.Element("Creator");
                    int year = (int?)elem.Element("Year") ?? 0;
                    int seasonNumber = (int?)elem.Element("SeasonNumber") ?? 0;
                    int episodeNumber = (int?)elem.Element("EpisodeNumber") ?? 0;
                    double duration = (double?)elem.Element("Duration") ?? 0.0;
                    int rating = (int?)elem.Element("Rating") ?? 0;

                    database.Add(new TV_Episode(title, showTitle, creator, year, seasonNumber, episodeNumber, duration, rating));

                    break;
            }
        }

        return database;
    }

	public static void Print<T>()
	{
	    List<object> database = (List<object>)ReadXML("CNoteSharpDatabase.csv");
	    database.FindAll(item => item is T).ForEach(Console.WriteLine);
	}	

    public static void Add<T>(T choice, string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"The file wasn't found!");
        }

        XDocument doc = XDocument.Load(path);

        Console.WriteLine("Title: ");
        string title = textinfo.ToTitleCase(Console.ReadLine());

        Console.WriteLine("Creator: ");
        string creator = textinfo.ToTitleCase(Console.ReadLine());

        Console.WriteLine("Year: ");
        int year = 0;

        bool validInput = false;
        while (!validInput)
        {
            string yearInput = Console.ReadLine();
            if (int.TryParse(yearInput, out int yearValue))
            {
                validInput = true;
                year = yearValue;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid year:");
            }
        }

        Console.WriteLine("Duration (Minutes): ");
        double duration = 0.0;

        validInput = false;
        while (!validInput)
        {
            string durationInput = Console.ReadLine();
            if (double.TryParse(durationInput, out double durationValue))
            {
                validInput = true;
                duration = durationValue;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid duration in minutes:");
            }
        }

        switch (choice)
        {
            case Track t:
                Console.WriteLine("Album: ");
                string album = textinfo.ToTitleCase(Console.ReadLine());

                Console.WriteLine("Rating: ");
                double ratingT = 0.0;

                validInput = false;
                while (!validInput)
                {
                    string ratingInput = Console.ReadLine();
                    if (double.TryParse(ratingInput, out double ratingValue))
                    {
                        validInput = true;
                        ratingT = ratingValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid rating (numeric value):");
                    }
                }

                t = new Track(title, creator, album, year, duration, ratingT);

                doc.Root?.Add(t);
                doc.Save(path);
                break;

            case Audio_Book b:
                Console.WriteLine("Rating (Thumbs Up/Thumbs Down): ) ");
                bool ratingA = false;

                validInput = false;
                while (!validInput)
                {
                    if (string.Equals(Console.ReadLine(), "thumbs up", StringComparison.InvariantCultureIgnoreCase) || string.Equals(Console.ReadLine(), "up", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ratingA = true;
                    }
                    else if (string.Equals(Console.ReadLine(), "thumbs down", StringComparison.InvariantCultureIgnoreCase) || string.Equals(Console.ReadLine(), "down", StringComparison.InvariantCultureIgnoreCase))
                    {
                        ratingA = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'Thumbs Up' or 'Thumbs Down':");
                    }
                }

                b = new Audio_Book(title, creator, year, duration, ratingA);

                doc.Root?.Add(b);
                doc.Save(path); 
                break;

            case TV_Episode e:
                Console.WriteLine("Show Title:");
                string showTitle = textinfo.ToTitleCase(Console.ReadLine());

                Console.WriteLine("Season Number: ");
                int season = 0;

                validInput = false;
                while (!validInput)
                {
                    string seasonInput = Console.ReadLine();
                    if (int.TryParse(seasonInput, out int seasonValue))
                    {
                        validInput = true;
                        season = seasonValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid season number:");
                    }
                }

                Console.WriteLine("Episode Number: ");
                int episode = 0;

                validInput = false;
                while (!validInput)
                {
                    string episodeInput = Console.ReadLine();
                    if (int.TryParse(episodeInput, out int episodeValue))
                    {
                        validInput = true;
                        episode = episodeValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid episode number:");
                    }
                }

                Console.WriteLine("Rating: ");
                int rating = 0;

                validInput = false;
                while (!validInput)
                {
                    string ratingInput = Console.ReadLine();
                    if (int.TryParse(ratingInput, out int ratingValue))
                    {
                        validInput = true;
                        rating = ratingValue;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid rating (numeric value):");
                    }
                }

                e = new TV_Episode(title, showTitle, creator, year, season, episode, duration, rating);

                doc.Root?.Add(e);
                doc.Save(path); 
                break;

            default:
                throw new Exception($"Unknown item type!");
        }
    }

    public static void Remove(string path, string entry)
	{
    	if (!File.Exists(path))
    	{
   		     throw new FileNotFoundException($"The file wasn't found!");
	    }
	    if (entry == null)
  	    {
        	throw new ArgumentNullException($"The entry to be removed cannot be null!");
    	}

        
        var textinfo = new CultureInfo("en-US", false).TextInfo;

        try
        {
            XDocument doc = XDocument.Load(path);

            XElement elementToRemove = doc.Descendants("Entry")
                .FirstOrDefault(e => string.Equals((string?)e.Element("Title"),
                                                  entry,
                                                  StringComparison.OrdinalIgnoreCase));

            if (elementToRemove != null)
            {
                elementToRemove.Remove();
                doc.Save(path);
                Console.WriteLine($"{textinfo.ToTitleCase(entry)} has been removed from the database.");
            }
            else
            {
                Console.WriteLine("No matching element found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

	public static void Shuffle<T>(string path)
	{
      	List<object> database = (List<object>)LINQ.ReadXML("CNoteSharpDatabase.csv");
        var shuffledList = database.FindAll(item => item is T).OrderBy(item => Guid.NewGuid()).ToList(); /*Guid.NewGuid() assigns a unique identifier for each element [Globally Unique Identifier] 
                                                                                                         *OrderBy then sorts the elements based on these unique identifiers, effectively randomizing their order
                                                                                                         *ToList() converts the shuffled IEnumerable back into a List*/
        shuffledList.ForEach(Console.WriteLine);
    }
}
