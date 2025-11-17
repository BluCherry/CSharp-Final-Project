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

        for (int i = 0; i < lineCount; i++)
        {
            string data =  reader.ReadLine();
            database.Add(data);
        }
        
        return database;
    }

    private static void WriteCNoteSharpDataBase()
    {
        using StreamWriter streamWriter = new StreamWriter("CNoteSharpDatabase.csv");
    }
}
