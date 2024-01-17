namespace ClassLib;

public static class JsonParser
{
    public static void ReadJson(int choice, string filePath)
    {
        switch (choice)
        {
            case 1:
                using (var streamReader = new StreamReader(filePath))
                {
                    Console.SetIn(streamReader);
                    string json = Console.In.ReadToEnd();
                }

                break;
        }
    }
    
    public static void WriteJson()
    {
        
    }
}