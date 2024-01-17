using ClassLib;
using Utilities;


namespace ConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                int stream_choice = InputUtils.CorrectChoice(InputUtils.JsonOrConsole(), 1, 2);
                
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
                reapetFlag = Console.ReadKey().Key != ConsoleKey.Escape;
            }
        }
    }
}
