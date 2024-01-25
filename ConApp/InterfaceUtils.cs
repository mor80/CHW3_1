using System.Threading.Channels;
using ClassLib;


namespace Utilities;

public class InterfaceUtils
{
    /// <summary>
    /// Writes in console user interface.
    /// </summary>
    /// <returns></returns>
    public static string? JsonOrConsole()
    {
        Console.WriteLine("Choose one of the option below:");
        Console.WriteLine("Press 1 to read data from console");
        Console.WriteLine("Press 2 to read data from Json file");
        Console.Write(">>> ");

        Console.ForegroundColor = ConsoleColor.Green;
        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.ResetColor();
        Console.WriteLine();

        return pressedKey;
    }

    /// <summary>
    /// Prints menu.
    /// </summary>
    /// <returns>Chosen option</returns>
    public static string? Menu()
    {
        Console.WriteLine("Choose one of the option below:");
        Console.WriteLine("Press 1 to sort data");
        Console.WriteLine("Press 2 to filter data");
        Console.Write(">>> ");

        Console.ForegroundColor = ConsoleColor.Green;
        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.ResetColor();
        Console.WriteLine();

        return pressedKey;
    }

    /// <summary>
    /// Writes in console user interface.
    /// </summary>
    /// <returns></returns>
    public static string? SortChoice()
    {
        Console.WriteLine("Choose the sorting type:");
        Console.WriteLine("Press 1 to sort in Alphabetical order");
        Console.WriteLine("Press 2 to sort in Descending order");
        Console.Write(">>> ");

        Console.ForegroundColor = ConsoleColor.Green;
        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.ResetColor();
        Console.WriteLine();

        return pressedKey;
    }

    /// <summary>
    /// Asks and writes sorted List of Trips considering the choice of the user.
    /// </summary>
    /// <param name="data">List of Trips</param>
    /// <exception cref="ArgumentException"></exception>
    /// /// <returns></returns>
    public static bool AskAndWriteInConsole(List<Trip> data)
    {
        if (data.Count == 0)
        {
            Console.WriteLine("Your data is empty");
            throw new ArgumentException("");
        }

        Console.WriteLine("Choose the writing type in console:");
        Console.WriteLine("Press 1 to write in Readable way");
        Console.WriteLine("Press 2 to write in Json format");
        Console.WriteLine("Press 3 to skip");
        Console.Write(">>> ");

        Console.ForegroundColor = ConsoleColor.Green;
        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.ResetColor();
        Console.WriteLine();

        int choice = CorrectChoice(pressedKey, 1, 3);
        switch (choice)
        {
            case 1:
                foreach (Trip trip in data)
                {
                    Console.WriteLine("----------------------------------------" +
                                      "----------------------------------------" +
                                      "----------------------------------------");
                    Console.WriteLine(trip.ToString());
                }

                Console.WriteLine("----------------------------------------" +
                                  "----------------------------------------" +
                                  "----------------------------------------");
                Console.WriteLine();
                
                return true;
            case 2:
                Console.WriteLine("[");
                int count = 0;
                foreach (Trip trip in data)
                {
                    string str =
                        $"    \"trip_id\": {trip.TripId},\n    \"destination\": \"{trip.Destination}\",\n    \"start_date\":" +
                        $" \"{trip.StartDate}\",\n    \"end_date\": \"{trip.EndDate}\",\n    \"travelers\": [\n      \"" +
                        $"{string.Join("\",\n      \"", trip.Travelers)}\"\n    ],\n    \"accommodation\": \"{trip.Accommodation}\"," +
                        $"\n    \"activities\": [\n      \"{string.Join("\",\n      \"", trip.Activities)}\"\n    ]";
                    count += 1;
                    Console.WriteLine("  {");
                    Console.WriteLine(str);
                    Console.Write("  }");
                    if (count != data.Count)
                    {
                        Console.WriteLine(",");
                    }
                }

                Console.WriteLine("\n]");
                Console.WriteLine();
                return true;
            case 3:
                return false;
        }

        return true;
    }

    /// <summary>
    /// Asks user to save file.
    /// </summary>
    public static string? AskToSave()
    {
        Console.WriteLine("Do you want to save file?");
        Console.WriteLine("Press 1 if YES");
        Console.WriteLine("Press 2 if NO");
        Console.Write(">>> ");

        Console.ForegroundColor = ConsoleColor.Green;
        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.ResetColor();
        Console.WriteLine();

        int choice = CorrectChoice(pressedKey, 1, 2);
        if (choice == 2)
        {
            return null;
        }

        string newFilePath = ValidPath();
        if (File.Exists(newFilePath))
        {
            Console.WriteLine("Oh, seems like the file already exists");
            Console.WriteLine("Your file will be rewrited");
            Console.WriteLine();
        }

        return newFilePath;
    }

    /// <summary>
    /// Checks user's input and if it is wrong asks for the new input.
    /// </summary>
    /// <param name="input">Input from previous methods</param>
    /// <param name="min">Minimum of numerical part of the variants</param>
    /// <param name="max">Maximum of numerical part of the variants</param>
    /// <returns>Corrected integer input</returns>
    public static int CorrectChoice(string? input, int min, int max)
    {
        while (true)
        {
            if (int.TryParse(input, out int correctInput) && correctInput >= min && correctInput <= max)
            {
                Console.WriteLine();
                return correctInput;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input. Try again");
            Console.ResetColor();

            Console.Write(">>> ");
            Console.ForegroundColor = ConsoleColor.Green;

            input = Console.ReadKey().KeyChar.ToString();
            Console.ResetColor();
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Asks user for field and writes user interface.
    /// </summary>
    /// <param name="message"></param>
    /// <returns>Field name</returns>
    public static string AskForField(string message)
    {
        while (true)
        {
            Console.WriteLine($"Choose the field {message}:");

            Console.WriteLine("1. Trip ID");
            Console.WriteLine("2. Destination");
            Console.WriteLine("3. Start Date");
            Console.WriteLine("4. End Date");
            Console.WriteLine("5. Travelers");
            Console.WriteLine("6. Accommodation");
            Console.WriteLine("7. Activities");
            Console.Write(">>> ");

            Console.ForegroundColor = ConsoleColor.Green;
            string? pressedKey = Console.ReadKey().KeyChar.ToString();
            string[] fields =
                { "trip_id", "destination", "start_date", "end_date", "travelers", "accommodation", "activities" };
            Console.ResetColor();

            int fieldIndex = CorrectChoice(pressedKey, 1, 7);

            Console.WriteLine();
            return fields[fieldIndex - 1];
        }
    }

    /// <summary>
    /// Asks user for field value and writes user interface.
    /// </summary>
    /// <param name="field">Field name</param>
    /// <returns>Field value</returns>
    public static string AskForFieldValue(string field)
    {
        while (true)
        {
            Console.Write($"Write {field.Replace("_", " ")} value:\n>>> ");
            Console.ForegroundColor = ConsoleColor.Green;

            string? filterField = Console.ReadLine();
            Console.ResetColor();

            if (!string.IsNullOrEmpty(filterField))
            {
                Console.WriteLine();
                return filterField;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Field can not be empty");
            Console.WriteLine();
            Console.ResetColor();
        }
    }


    /// <summary>
    /// Asks for path to the file and corrects it.
    /// </summary>
    /// <returns>Corrected file path</returns>
    public static string ValidPath(bool flag = false)
    {
        while (true)
        {
            Console.Write("Write path to the file:\n>>> ");
            Console.ForegroundColor = ConsoleColor.Green;

            string? filePath = Console.ReadLine();
            Console.ResetColor();

            if (flag)
            {
                if (string.IsNullOrEmpty(filePath) || !Path.IsPathFullyQualified(filePath) || !File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid file path. Try again");
                    Console.WriteLine();
                    Console.ResetColor();
                    continue;
                }
            }

            if (string.IsNullOrEmpty(filePath) || !Path.IsPathFullyQualified(filePath))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid file path. Try again");
                Console.WriteLine();
                Console.ResetColor();
                continue;
            }

            Console.WriteLine();
            return filePath;
        }
    }
}