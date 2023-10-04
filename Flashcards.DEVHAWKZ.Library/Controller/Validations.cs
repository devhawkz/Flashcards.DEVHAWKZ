using System.Diagnostics;

namespace Flashcards.DEVHAWKZ.Library.Controller
{
    internal static class Validations
    {
        internal static string GetValidString(string message = "Your option: ")
        {
            Console.Write($"{message}");
            string option = Console.ReadLine();

            while (string.IsNullOrEmpty(option)) 
            {
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid input.Please try again.");
                Console.Write($"{message}");
                option = Console.ReadLine();
            }

            return option;
        }

        internal static int GetValidInt(string message) 
        {
            Console.Write($"{message}");
            string idText = Console.ReadLine();

            int id = 0;
            
            while (!int.TryParse(idText, out id))
            {
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid input.Please try again.");
                Console.Write($"{message}");
                idText = Console.ReadLine();
            }

            return id;
        }
    }
}
