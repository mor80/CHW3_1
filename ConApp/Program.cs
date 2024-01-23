using ClassLib;
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
                    string filePath = InterfaceUtils.ValidPath(true);
                    JsonParser.ReadJson(streamChoice, filePath);

                    List<Trip> trips = new List<Trip>();
                    
                    int dataChange = InterfaceUtils.CorrectChoice(InterfaceUtils.Menu(), 1, 2);
                    switch (dataChange)
                    {
                        case 1:
                            string field1 = InterfaceUtils.AskForField("to sort by");
                            
                            List<Trip> filteredList1 = Trip.Sorting(trips, field1);
                            break;
                        case 2:
                            string field2 = InterfaceUtils.AskForField("to filter by");
                            string fieldValue = InterfaceUtils.AskForFieldValue(field2);

                            List<Trip> filteredList2 = Trip.FilterByField(trips, fieldValue, field2);
                            break;
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
// E:\Emre\HSE\C#\3Module\CHW3_1\data_18V.json
// /Users/emreguuv/Documents/EMRE HSE/C# hse/CHW3_1/data_18V.json