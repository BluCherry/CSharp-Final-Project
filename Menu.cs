//This is a basic menu that uses a user input, and a switch to handle exceptions. 
//When more of the project is complete, we can update this code to work as intended. :D

public class Menu
{
    public static void Main()
    {
        string command;
        Boolean quit = false;
        Console.WriteLine();
        Console.WriteLine("Welcome to CNoteSharp, your one stop station for finding new music, " +
                          "audio books and popular TV episodes!\nTo start your search, enter a number " +
                          "that corresponds to your desired command. (Numbers 0-12)");
        Console.WriteLine("\t1. Print out all entries in the database\n" +
                          "\t2. Print out all music tracks\n" +
                          "\t3. Print out all audio books\n" +
                          "\t4. Print out all tv episodes\n" +
                          "\t5. Print out all the entries with a given creator\n" +
                          "\t6. Sort all entries by their rating in descending order\n" +
                          "\t7. Sort all entries in ascending order based on their year\n" +
                          "\t8. Sort all entries by the lexicographical order of their title\n" +
                          "\t9. Print out all entries released on or after a given year\n" +
                          "\t10. Add an entry to the database\n" +
                          "\t11. Removes an entry by the title\n" +
                          "\t12. Print out a shuffled list of all music tracks\n" +
                          "\t0. Quit");

        while (quit == false)
        {
            Console.Write("\nEnter your number here (0-12): ");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    //prints out all entries
                    Console.WriteLine("Printing all entries in the database...");
                    List<object> database = (List<object>)LINQ.ReadXML("CNoteSharpDatabase.XML");
                    database.ForEach(Console.WriteLine);
                    break;
                case "2":
                    //prints out all music tracks
                    Console.WriteLine("Printing all music tracks in the database...");
                    LINQ.Print<Track>("CNoteSharpDatabase.XML");
                    break;
                case "3":
                    //prints out all audiobooks
                    Console.WriteLine("Printing all audiobooks in the database...");
                    LINQ.Print<Audio_Book>("CNoteSharpDatabase.XML"); 
                    break;
                case "4":
                    //prints out all TV episodes
                    Console.WriteLine("Printing all TV Episodes in the database...");
                    LINQ.Print<TV_Episode>("CNoteSharpDatabase.XML");
                    break;
                case "5":
                    //prints out entries of given creator
                    Console.WriteLine("Enter the creator's name: ");
                    string creator = Console.ReadLine();
                    LINQ.PrintByCreator("CNoteSharpDatabase.XML", creator);
                    break;

                case "6":
                    Console.WriteLine("Sorting all entries by rating in descending order...");
                    LINQ.SortByRatingDesc("CNoteSharpDatabase.XML");
                    //sorts by rating in descending order
                    break;
                case "7":
                    //sorts in ascending order by year
                    Console.WriteLine("Sorting all entries by year in ascending order...");
                    LINQ.SortByYearAsc("CNoteSharpDatabase.XML");
                    //quit = true;
                    break;
                case "8":
                    Console.WriteLine("Sorting all entries by title in lexicographical order...");
                    LINQ.SortByTitleLex("CNoteSharpDatabase.XML");
                    //Sorts entries lexicographically 
                    //quit = true;
                    break;
                case "9":
                    Console.WriteLine("Enter the year: ");
                    string yearInput = Console.ReadLine();
                    LINQ.PrintByYear("CNoteSharpDatabase.XML", yearInput);
                    //prints out all entries released on or after a given year
                    //quit = true;
                    break;
                case "10":
                    //Allows the user to add an entry to the database
                    Console.WriteLine($"What type of entry do you want to add?\n" +
                                      $"1. Track\n" +
                                      $"2. Audiobook\n" +
                                      $"3. TV Episodes");

                    string choice = "";

                    bool validChoice = false;
                    while (!validChoice)
                    {
                        Console.WriteLine($"\nEnter your choice (1-3): ");

                        if (int.TryParse(Console.ReadLine(), out int choiceNum) && choiceNum >= 1 && choiceNum <= 3)
                        {
                            validChoice = true;
                            choice = choiceNum.ToString();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                        }
                    }

                    switch (choice)
                    {
                        case "1":
                            LINQ.Add<Track>(path);
                            break;
                        case "2":
                            LINQ.Add<Audio_Book>(path);
                            break;
                        case "3":
                            LINQ.Add<TV_Episode>(path);
                            break;
                        default:
                            Console.WriteLine("Invalid choice!");
                            return;
                    }
                    break;
                case "11":
                    //Allows the user to remove an entry by title
                    Console.WriteLine("Enter the title of the entry you wish to remove: ");
                    string title = Console.ReadLine();
                    LINQ.Remove("CNoteSharpDatabase.XML", title);
                    break;
                case "12":
                    //Shuffles the entries in the database
                    Console.WriteLine("Shuffling the entries in the database...");
                    LINQ.Shuffle<Track>("CNoteSharpDatabase.XML");
                    break;
                case "0":
                    Console.WriteLine("Thank you for tuning into CNoteSharp. Have a nice day!");
                    quit = true;
                    break;
                default:
                    Console.WriteLine($"Input {command} invalid, please try again.");
                    break;
            }
        }
    }
}
