namespace ClassLib;

public static class JsonParser
{
    public static void ReadJson(int choice, string filePath)
    {
        switch (choice)
        {
            case 2:
                string json;
                
                using (var streamReader = new StreamReader(filePath))
                {
                    Console.SetIn(streamReader);
                    json = Console.In.ReadToEnd();
                    
                }

                Console.WriteLine(json);
                
                break;
        }
    }
    
    public static void WriteJson()
    {
        
    }
}