//Basic FileReader, outputs something close to the correct format but could obviously look better.
//The parts are not parsed into the correct type, whoevers making the classes will decide which type each variable is, and we'll add it 
//when that has been finalized. The filewriter has nothing in it yet, we can worry about that later too.

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

    private static List<string> ReadCNoteSharpDataBase(string path)
    {
        if (!File.Exists(path))
        {
            throw new FileNotFoundException($"The file wasn't found!");
        }
        
        int lineCount = GetLineCount(path);
        List<string> lines = new List<string>(lineCount - 1);
        
        using StreamReader reader = new StreamReader("CNoteSharpDatabase.csv");
        reader.ReadLine();

        for (int i = 0; i < lineCount - 1; i++)
        {
            string line = reader.ReadLine();
            lines.Add(line);
        }
        return lines;
    }

    private static void WriteCNoteSharpDataBase()
    {
        using StreamWriter streamWriter = new StreamWriter("CNoteSharpDatabase.csv");
    }
    
    public static void Main()
    {
        string path = "CNoteSharpDatabase.csv";
        Console.WriteLine(string.Join(" , \n",  ReadCNoteSharpDataBase(path)));
    }
}
