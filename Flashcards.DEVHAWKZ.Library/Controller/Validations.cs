using System.Diagnostics;

namespace Flashcards.DEVHAWKZ.Library.Controller
{
    internal static class Validations
    {
        internal static string GetValidString()
        {
            Console.Write("Your option: ");
            string option = Console.ReadLine();

            while (string.IsNullOrEmpty(option)) 
            {
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid input.Please try again.");
                Console.Write("Your option: ");
                option = Console.ReadLine();
            }

            return option;
        }

        internal static int GetValidInt() 
        {
            Console.Write("Enter id of a row you wish to update: ");
            string idText = Console.ReadLine();

            int id;
            
            while (!int.TryParse(idText, out id))
            {
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid input.Please try again.");
                Console.Write("Enter id of a stack you want to update: ");
                idText = Console.ReadLine();
            }

            return id;
        }
    }
}
