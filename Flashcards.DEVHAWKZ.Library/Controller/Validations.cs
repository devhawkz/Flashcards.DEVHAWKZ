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
    }
}
