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

    private static void Write()
    {
        using StreamWriter streamWriter = new StreamWriter("CNoteSharpDatabase.csv");
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
