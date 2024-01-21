namespace Utilities;

public class InputUtils
{
    public static string? JsonOrConsole()
    {
        Console.WriteLine("Choose one of the option below:");
        Console.WriteLine("Press 1 to read data from console");
        Console.WriteLine("Press 2 to read data from Json file");
        Console.Write(">>> ");

        string? pressedKey = Console.ReadKey().KeyChar.ToString();
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

        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.WriteLine();
        
        return pressedKey;
    } 
    
    
    public static int CorrectChoice(string? input, int min, int max)
    {
        while (true)
        {
            if (int.TryParse(input, out int correctInput) && correctInput >= min && correctInput <= max)
            {
                return correctInput;
            }

            Console.WriteLine("Invalid input. Try again");
            Console.Write(">>> ");
            input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string AskForField(string message)
    {
        while (true)
        {
            Console.Write($"Choose and write field {message}:\n>>> ");
            string? field = Console.ReadLine();

            if (string.IsNullOrEmpty(field))
            {
                Console.WriteLine("Invalid field name\nTry again");
                continue;
            }

            return field;
        }
    }

    public static string AskForFieldValue(string field)
    {
        while (true)
        {
            Console.Write($"Write {field} value:\n>>> ");
            string? filterField = Console.ReadLine();

            if (!string.IsNullOrEmpty(filterField))
            {
                return filterField;
            }

            Console.WriteLine("Field can not be empty");
        }
    }
    

    /// <summary>
    /// Asks for path to the file and corrects it.
    /// </summary>
    /// <returns>Corrected file path</returns>
    public static string ValidPath()
    {
        while (true)
        {
            Console.Write("Write path to the new file:\n>>> ");
            string filePath = Console.ReadLine();

            if (string.IsNullOrEmpty(filePath) || !Path.IsPathFullyQualified(filePath) || !File.Exists(filePath))
            {
                Console.WriteLine("Invalid file path. Try again");
                Console.WriteLine();
            }

            Console.WriteLine();
            return filePath;
        }
    }
}