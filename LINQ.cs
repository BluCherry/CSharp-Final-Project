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

    public static void PrintByCreator(string path, string creator)
    {
        if (string.IsNullOrWhiteSpace(creator))
        {
            Console.WriteLine("Creator name cannot be empty.");
            return;
        }

        List<object> database = (List<object>)ReadXML(path);

        var matches = database.Where(item =>
        {
            var prop = item.GetType().GetProperty("Creator")?.GetValue(item) as string;
            return !string.IsNullOrEmpty(prop) && string.Equals(prop, creator, StringComparison.OrdinalIgnoreCase);
        }).ToList();

        if (!matches.Any())
        {
            Console.WriteLine($"No entries found for creator: {creator}");
            return;
        }

        matches.ForEach(Console.WriteLine);
    }

    public static void SortByRatingDesc(string path)
    {
        List<object> database = (List<object>)ReadXML(path);

        double ToDoubleRating(object o)
        {
            var val = o.GetType().GetProperty("Rating")?.GetValue(o);
            if (val == null) return 0.0;
            if (val is double d) return d;
            if (val is int i) return Convert.ToDouble(i);
            if (val is bool b) return b ? 1.0 : 0.0;
            try
            {
                return Convert.ToDouble(val);
            }
            catch
            {
                return 0.0;
            }
        }

        var sorted = database.OrderByDescending(item => ToDoubleRating(item)).ToList();
        sorted.ForEach(Console.WriteLine);
    }

    public static void SortByYearAsc(string path)
    {
        List<object> database = (List<object>)ReadXML(path);

        var sorted = database.OrderBy(item =>
        {
            var val = item.GetType().GetProperty("Year")?.GetValue(item);
            if (val == null) return int.MaxValue;
            return Convert.ToInt32(val);
        }).ToList();

        sorted.ForEach(Console.WriteLine);
    }

    public static void SortByTitleLex(string path)
    {
        List<object> database = (List<object>)ReadXML(path);

        var sorted = database.OrderBy(item =>
        {
            var val = item.GetType().GetProperty("Title")?.GetValue(item) as string;
            return val ?? string.Empty;
        }, StringComparer.InvariantCultureIgnoreCase).ToList();

        sorted.ForEach(Console.WriteLine);
    }

    public static void PrintByYear(string path, string yearInput)
    {
        if (!int.TryParse(yearInput, out int year))
        {
            Console.WriteLine("Invalid year provided.");
            return;
        }

        List<object> database = (List<object>)ReadXML(path);

        var matches = database.Where(item =>
        {
            var val = item.GetType().GetProperty("Year")?.GetValue(item);
            if (val == null) return false;
            return Convert.ToInt32(val) >= year;
        }).ToList();

        if (!matches.Any())
        {
            Console.WriteLine($"No entries found on or after year {year}.");
            return;
        }

        matches.ForEach(Console.WriteLine);
    }

    public static void Add<T>(string path)
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

        int year = 0;

        bool validInput = false;
        while (!validInput)
        {
            Console.WriteLine("Year: ");

            string yearInput = Console.ReadLine();
            if (int.TryParse(yearInput, out int yearValue))
            {
                if (yearValue < 1000 || yearValue > DateTime.Now.Year)
                {
                    Console.WriteLine("Invalid input. Please enter a valid year:");
                }
                else
                {
                    validInput = true;
                    year = yearValue;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
            }
        }

        double duration = 0.0;

        validInput = false;
        while (!validInput)
        {
            Console.WriteLine("Duration (Minutes): ");

            string durationInput = Console.ReadLine();
            if (double.TryParse(durationInput, out double durationValue))
            {
                validInput = true;
                duration = durationValue;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid duration.");
            }
        }

        if (typeof(T) == typeof(Track))
        {
            Console.WriteLine("Album: ");
            string album = textinfo.ToTitleCase(Console.ReadLine());

            double ratingT = 0.0;

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Rating (Decimal 1-5): ");

                string ratingInput = Console.ReadLine();
                if (double.TryParse(ratingInput, out double ratingValue))
                {
                    validInput = true;
                    ratingT = ratingValue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid rating.");
                }
            }

            XElement newTrack = new XElement("Entry",
                new XAttribute("Type", "Track"),
                new XElement("Title", title),
                new XElement("Creator", creator),
                new XElement("Album", album),
                new XElement("Year", year),
                new XElement("Duration", duration),
                new XElement("Rating", ratingT)
            );

            doc.Root?.Add(newTrack);
            doc.Save(path);
        }

        if (typeof(T) == typeof(Audio_Book))
        {
            bool ratingA = false;

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Rating (Thumbs Up/Thumbs Down): ) ");

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
                    Console.WriteLine("Invalid input. Please enter 'Thumbs Up' or 'Thumbs Down'.");
                }
            }

            XElement newAudiobook = new XElement("Entry",
                new XAttribute("Type", "Audiobook"),
                new XElement("Title", title),
                new XElement("Creator", creator),
                new XElement("Year", year),
                new XElement("Duration", duration),
                new XElement("Rating", ratingA)
            );

            doc.Root?.Add(newAudiobook);
            doc.Save(path);
        }

        if (typeof(T) == typeof(TV_Episode))
        {
            Console.WriteLine("Show Title:");
            string showTitle = textinfo.ToTitleCase(Console.ReadLine());

            int season = 0;

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Season Number: ");

                string seasonInput = Console.ReadLine();
                if (int.TryParse(seasonInput, out int seasonValue))
                {
                    validInput = true;
                    season = seasonValue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid season number.");
                }
            }

            int episode = 0;

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Episode Number: ");

                string episodeInput = Console.ReadLine();
                if (int.TryParse(episodeInput, out int episodeValue))
                {
                    validInput = true;
                    episode = episodeValue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid episode number.");
                }
            }

            int rating = 0;

            validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Rating (Integer 1-10): ");

                string ratingInput = Console.ReadLine();
                if (int.TryParse(ratingInput, out int ratingValue))
                {
                    validInput = true;
                    rating = ratingValue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid rating.");
                }
            }

            XElement newTV_Episode = new XElement("Entry",
                new XAttribute("Type", "TV_Episode"),
                new XElement("Title", title),
                new XElement("Creator", creator),
                new XElement("ShowTitle", showTitle),
                new XElement("Year", year),
                new XElement("SeasonNumber", season),
                new XElement("EpisodeNumber", episode),
                new XElement("Duration", duration),
                new XElement("Rating", rating)
            );

            doc.Root?.Add(newTV_Episode);
            doc.Save(path);
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
