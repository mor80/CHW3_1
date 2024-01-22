namespace Utilities;

public class InputUtils
{
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
    /// 
    /// </summary>
    /// <param name="input"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
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
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string AskForField(string message)
    {
        while (true)
        {
            Console.Write($"Choose and write field {message}:\n>>> ");
            Console.ForegroundColor = ConsoleColor.Green;
            
            string? field = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrEmpty(field))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid field name\nTry again");
                Console.WriteLine();
                Console.ResetColor();
                continue;
            }

            Console.WriteLine();
            return field;
        }
    }

    public static string AskForFieldValue(string field)
    {
        while (true)
        {
            Console.Write($"Write {field} value:\n>>> ");
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
    public static string ValidPath()
    {
        while (true)
        {
            Console.Write("Write path to the file:\n>>> ");
            Console.ForegroundColor = ConsoleColor.Green;
            
            string? filePath = Console.ReadLine();
            Console.ResetColor();

            if (string.IsNullOrEmpty(filePath) || !Path.IsPathFullyQualified(filePath) || !File.Exists(filePath))
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