using System.Text;
using System.Text.RegularExpressions;


namespace ClassLib;

public static class JsonParser
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="choice"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public static List<Trip> ReadJson(bool choice, string? filePath = null)
    {
        try
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

                    json = input.ToString().Replace("\n", string.Empty);
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

            List<Trip> trips = new List<Trip>();

            string tripPattern =
                @"\s*\{\s*""trip_id""\s*:\s*(\d+)\s*,\s*""destination""\s*:\s*""([^""]+)""\s*,\s*""start_date""\s*:\s*""([^""]+)""\s*,\s*""end_date""\s*:\s*""([^""]+)""\s*,\s*""travelers""\s*:\s*\[([^\]]+)\]\s*,\s*""accommodation""\s*:\s*""([^""]+)""\s*,\s*""activities""\s*:\s*\[([^\]]+)\]\s*\}\s*";
            string travelerPattern = @"""([^""]+)""";

            MatchCollection tripMatches = Regex.Matches(json, tripPattern);
            foreach (Match tripMatch in tripMatches)
            {
                int tripId = int.Parse(tripMatch.Groups[1].Value);
                string destination = tripMatch.Groups[2].Value;
                string startDate = tripMatch.Groups[3].Value;
                string endDate = tripMatch.Groups[4].Value;
                string travelers = tripMatch.Groups[5].Value;
                string accommodation = tripMatch.Groups[6].Value;
                string activities = tripMatch.Groups[7].Value;

                var travelerMatches = Regex.Matches(travelers, travelerPattern);
                var travelerList = new string[travelerMatches.Count];
                for (int i = 0; i < travelerMatches.Count; i++)
                {
                    travelerList[i] = travelerMatches[i].Groups[1].Value;
                }

                var activityMatches = Regex.Matches(activities, travelerPattern);
                var activityList = new string[activityMatches.Count];
                for (int i = 0; i < activityMatches.Count; i++)
                {
                    activityList[i] = activityMatches[i].Groups[1].Value;
                }

                Trip trip = new Trip(tripId, destination, startDate, endDate, travelerList, accommodation,
                    activityList);
                trips.Add(trip);
            }
            
            return trips;
        }
        catch (Exception e)
        {
            throw new Exception("Wrong file format", e);
        }
    }

    public static void WriteJson()
    {
    }
}