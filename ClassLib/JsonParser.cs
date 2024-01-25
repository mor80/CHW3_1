using System.Text;
using System.Text.RegularExpressions;


namespace ClassLib;

public static class JsonParser
{
    /// <summary>
    /// Method to read Json file using Regex.
    /// </summary>
    /// <param name="choice">Users choice of stream (Standart or File)</param>
    /// <param name="filePath">File path</param>
    /// <returns>List of Trip objects from Json file</returns>
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
                    TextReader oldInput = Console.In;
                    
                    using (var streamReader = new StreamReader(filePath))
                    {
                        Console.SetIn(streamReader);
                        json = Console.In.ReadToEnd();

                        Console.SetIn(oldInput);
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

    /// <summary>
    /// Writes data to json file depending on user choice of stream.
    /// </summary>
    /// <param name="trips">List of Trips</param>
    /// <param name="choice">User's choice of stream(true - standart; false - file)</param>
    /// <param name="filePath">File path</param>
    /// <exception cref="Exception"></exception>
    public static void WriteJson(List<Trip> trips, bool choice, string filePath)
    {
        try
        {
            StringBuilder output = new StringBuilder();
            output.Append("[\n");
            int count = 0;
            foreach (Trip trip in trips)
            {
                string str =
                    $"    \"trip_id\": {trip.TripId},\n    \"destination\": \"{trip.Destination}\",\n    \"start_date\":" +
                    $" \"{trip.StartDate}\",\n    \"end_date\": \"{trip.EndDate}\",\n    \"travelers\": [\n      \"" +
                    $"{string.Join("\",\n      \"", trip.Travelers)}\"\n    ],\n    \"accommodation\": \"{trip.Accommodation}\"," +
                    $"\n    \"activities\": [\n      \"{string.Join("\",\n      \"", trip.Activities)}\"\n    ]\n";
                count += 1;
                output.Append("  {\n");
                output.Append(str);
                output.Append("  }");
                if (count != trips.Count)
                {
                    output.Append(",\n");
                }
            }

            output.Append(']');
            
            switch (choice)
            {
                case true:
                    Console.WriteLine(output.ToString());
                    break;
                case false:
                    TextWriter oldOutput = Console.Out;
                    
                    using (StreamWriter streamWriter = new StreamWriter(filePath, false, Encoding.UTF8))
                    {
                        // streamWriter.AutoFlush = true;
        
                        Console.SetOut(streamWriter);
                        Console.WriteLine(output.ToString());
                        Console.SetOut(oldOutput);
                    }
                    break;
            }
        }
        catch (Exception e)
        {
            throw new Exception("Something went wrong while writing your data to file", e);
        }
    }
}