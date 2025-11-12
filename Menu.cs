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
                          "that corresponds to your desired command. (Numbers 0-9)");
        Console.WriteLine("\t1. Print out all entries in the database\n" +
                          "\t2. Print out all music tracks\n" +
                          "\t3. Print out all audio books\n" +
                          "\t4. Print out all tv episodes\n" +
                          "\t5. Print out all the entries with a given creator\n" +
                          "\t6. Sort all entries by their rating in descending order\n" +
                          "\t7. Sort all entries in ascending order based on their year\n" +
                          "\t8. Sort all entries by the lexicographical order of their title\n" +
                          "\t9. Print out all entries released on or after a given year\n" +
                          "\t0. Quit");

        while (quit == false)
        {
            Console.Write("\nEnter your number here (0-9): ");
            command = Console.ReadLine();

            switch (command)
            {
                case "1":
                    //prints all entries
                    //quit = true;
                    break;
                case "2":
                    //prints out music tracks
                    //quit = true;
                    break;
                case "3":
                    //prints out all audiobooks
                    //quit = true;
                    break;
                case "4":
                    //prints out all TV episodes
                    //quit = true;
                    break;
                case "5":
                    //prints out entries of given creator
                    //quit = true;
                    break;
                case "6":
                    //sorts by rating in descending order
                    //quit = true;
                    break;
                case "7":
                    //sorts in ascending order by year
                    //quit = true;
                    break;
                case "8":
                    //Sorts entries lexicographically 
                    //quit = true;
                    break;
                case "9":
                    //prints out all entries released on or after a given year
                    //quit = true;
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
