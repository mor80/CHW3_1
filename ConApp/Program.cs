using ClassLib;
using Microsoft.VisualBasic.CompilerServices;
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
                    int streamChoice = InputUtils.CorrectChoice(InputUtils.JsonOrConsole(), 1, 2);
                    string filePath = InputUtils.ValidPath();
                    JsonParser.ReadJson(streamChoice, filePath);

                    List<Trip> trips = new List<Trip>();
                        
                    int dataChange = InputUtils.CorrectChoice(InputUtils.Menu(), 1, 2);
                    switch (dataChange)
                    {
                        case 1:
                            string field1 = InputUtils.AskForField("to sort by");
                            
                            List<Trip> filteredList1 = Sortings.Sorting(trips, field1);
                            break;
                        case 2:
                            string field2 = InputUtils.AskForField("to filter by");
                            string fieldValue = InputUtils.AskForFieldValue(field2);

                            List<Trip> filteredList2 = Sortings.FilterByField(trips, fieldValue, field2);
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
                }
            }
        }
    }
}
// E:\Emre\HSE\C#\3Module\CHW3_1\data_18V.json