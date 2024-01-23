using System.Text;

namespace ClassLib;

public static class JsonParser
{
    public static void ReadJson(bool choice, string filePath)
    {
        string json;
        string stopText = "$$$";
        switch (choice)
        {
            case true:
                StringBuilder input = new StringBuilder();
                string? userInput = string.Empty;

                while ((userInput = Console.ReadLine()) is not null &&
                       (stopText is null || userInput != stopText))
                {
                    input.Append(userInput);
                }

                json = input.ToString();
                break;
            case false:
                using (var streamReader = new StreamReader(filePath))
                {
                    Console.SetIn(streamReader);
                    json = Console.In.ReadToEnd();

                    Console.SetIn(new StreamReader(Console.OpenStandardInput()));
                }
                break;
        }

        Console.WriteLine(json);
    }
    
    public static void WriteJson()
    {
        
    }
}