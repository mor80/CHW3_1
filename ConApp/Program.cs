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
                    int stream_choice = InputUtils.CorrectChoice(InputUtils.JsonOrConsole(), 1, 2);
                    string filePath = InputUtils.ValidPath();
                    JsonParser.ReadJson(stream_choice, filePath);
                    
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
