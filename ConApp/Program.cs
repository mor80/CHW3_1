﻿using ClassLib;
using Utilities;


namespace ConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repeatFlag = true;

            while (repeatFlag)
            {
                try
                {
                    Console.Clear();
                    bool streamChoice = InterfaceUtils.CorrectChoice(InterfaceUtils.JsonOrConsole(), 1, 2) == 1;
                    string? filePath = streamChoice ? null : InterfaceUtils.ValidPath(true);

                    if (streamChoice)
                    {
                        Console.WriteLine(
                            "Write your json file in console (ctr + C ctr + V). After you are done write in console $$$ to stop.");
                    }

                    List<Trip> trips = JsonParser.ReadJson(streamChoice, filePath);
                    if (trips.Count == 0)
                    {
                        throw new ArgumentNullException("", "Your json file is empty");
                    }

                    List<Trip> sortedTrips = new List<Trip>();

                    int dataChange = InterfaceUtils.CorrectChoice(InterfaceUtils.Menu(), 1, 2);
                    switch (dataChange)
                    {
                        case 1:
                            string field1 = InterfaceUtils.AskForField("to sort by");
                            bool sortChoice = InterfaceUtils.CorrectChoice(InterfaceUtils.SortChoice(), 1, 2) == 2;

                            sortedTrips = Trip.Sorting(trips, field1, sortChoice);
                            break;
                        case 2:
                            string field2 = InterfaceUtils.AskForField("to filter by");
                            string fieldValue = InterfaceUtils.AskForFieldValue(field2);

                            sortedTrips = Trip.FilterByField(trips, fieldValue, field2);
                            break;
                    }

                    if (sortedTrips.Count == 0)
                    {
                        throw new ArgumentNullException("", "Your sorted json file is empty");
                    }

                    Console.WriteLine("Your data was successfully changed\n");
                    bool write = InterfaceUtils.AskAndWriteInConsole(sortedTrips);
                    string? newFilePath = InterfaceUtils.AskToSave();

                    if (!string.IsNullOrEmpty(newFilePath))
                    {
                        JsonParser.WriteJson(sortedTrips, false, newFilePath);
                    }
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }                
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
                finally
                {
                    Console.Write("Press ESC to exit program or any other key to restart\n>>> ");
                    repeatFlag = Console.ReadKey().Key != ConsoleKey.Escape;
                    Console.WriteLine();
                }
            }
        }
    }
}
