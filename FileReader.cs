//Basic FileReader, outputs something close to the correct format but could obviously look better.
//The parts are not parsed into the correct type, whoevers making the classes will decide which type each variable is, and we'll add it 
//when that has been finalized. The filewriter has nothing in it yet, we can worry about that later too.

namespace Intermediate_CSharp_Final;

public class FileReader
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

    public static List<object> ReadCNoteSharpDataBase(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"The file wasn't found!");
        }
        
        int lineCount = GetLineCount(path);
        List<object> database = new List<object>(lineCount - 1);
        
        using StreamReader reader = new StreamReader(path); 
        reader.ReadLine();

        for (int i = 0; i < lineCount - 1; i++)
        {
            string line = reader.ReadLine();

            string[] cols = line.Split(',');

            string type = cols[0];

            if (type == "Track")
            {
                string title = cols[1];
                string creator = cols[3];
                string album = cols[4];
                int year = int.Parse(cols[5]);
                double duration = double.Parse(cols[8]);
                double rating = double.Parse(cols[9]);

                database.Add(new Track(title, creator, album, year, duration, rating));
            }
            if (type == "Audiobook")
            {
                string title = cols[1];
                string creator = cols[3];
                int year = int.Parse(cols[5]);
                double duration = double.Parse(cols[8]);
                string rating = cols[9];
        
                database.Add(new Audio_Book(title, creator, year, duration, rating));
            }
            if (type == "TV Episodes")
            {
                string title = cols[1];
                string showTitle = cols[2];
                string creator = cols[3];
                int year = int.Parse(cols[5]);
                int seasonNumber = int.Parse(cols[6]);
                int episodeNumber = int.Parse(cols[7]);
                double duration = double.Parse(cols[8]);
                int rating = int.Parse(cols[9]);
        
                database.Add(new TV_Episode(title, showTitle, creator, year, seasonNumber, episodeNumber, duration, rating));
            }
        }
        
        return database;
    }

    private static void WriteCNoteSharpDataBase()
    {
        using StreamWriter streamWriter = new StreamWriter("CNoteSharpDatabase.csv");
    }
}
