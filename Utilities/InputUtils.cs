namespace Utilities;

public class InputUtils
{
    public static string? JsonOrConsole()
    {
        Console.WriteLine("Choose one of the option below:");
        Console.WriteLine("Press 1 to read data from console");
        Console.WriteLine("Press 2 to read data from Json file");
        Console.WriteLine(">>> ");

        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.WriteLine();
        
        return pressedKey;
    }
    
    public static str
    
    /// <summary>
    /// Ask user top or bot and returns user's choice as string.
    /// </summary>
    /// <returns>Input from user</returns>
    public static string? TopOrBottom()
    {
        Console.WriteLine("Choose one of the option below:");
        Console.WriteLine("Press to 1 to see data from the top");
        Console.WriteLine("Press to 2 to see data from the bottom");
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
        Console.WriteLine("What do you want to do with your data?");
        Console.WriteLine("Write 1 if you want to sort in alphabetical order by District");
        Console.WriteLine("Write 2 if you want to sort in reversed alphabetical order by District");
        Console.WriteLine("Write 3 if you want to filter by PaidServiceInfo");
        Console.WriteLine("Write 4 if you want to filter by AdmArea");
        Console.WriteLine("Write 5 if you want to filter by PaidServiceInfo and AdmArea");
        Console.Write(">>> ");

        string? pressedKey = Console.ReadKey().KeyChar.ToString();
        Console.WriteLine();
        
        return pressedKey;
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
                return correctInput;
            }

            Console.WriteLine("Invalid input. Try again");
            Console.Write(">>> ");
            input = Console.ReadLine();
            Console.WriteLine();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="len"></param>
    /// <returns></returns>
    public static int CorrNumOfRows(int len)
    {
        Console.Write("Enter the numbers of rows you want to see\n>>> ");

        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int rows) || rows < 1 || rows > len)
            {
                Console.WriteLine();
                Console.Write("Invalid number. Try again\n>>> ");
                continue;
            }

            Console.WriteLine();
            return rows;
        }
    }

    /// <summary>
    /// Asks for fields by which the lis is sorted.
    /// </summary>
    /// <param name="fields">1 or 2 fields</param>
    /// <param name="count">Number of fields in param="fields"</param>
    /// <returns>Correct names of fields</returns>
    public static string[] AskForField(string[] fields)
    {
        while (true)
        {
            Console.Write($"Enter {fields[0]}:\n>>> ");
            string? filterField = Console.ReadLine();

            if (!string.IsNullOrEmpty(filterField))
            {
                return new[] { filterField };
            }

            Console.WriteLine("Field can not be empty");
        }
    }

    /// <summary>
    /// Asks for path to the file and corrects it.
    /// </summary>
    /// <returns>Corrected file path</returns>
    public static string? ValidPath()
    {
        while (true)
        {
            Console.Write("Write path to the new file:\n>>> ");
            string? filePath = Console.ReadLine();

            if (string.IsNullOrEmpty(filePath) || !Path.IsPathFullyQualified(filePath))
            {
                Console.WriteLine("Wrong file path. Try again");
                Console.WriteLine();
            }

            Console.WriteLine();
            return filePath;
        }
    }
}