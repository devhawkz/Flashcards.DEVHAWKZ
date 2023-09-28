namespace Flashcards.DEVHAWKZ.Library.Controller
{
    internal static class Validations
    {
        internal static string GetValidString(string s)
        {
            while(string.IsNullOrEmpty(s)) 
            {
                Console.WriteLine("\nInvalid input.Please try again.");
                Console.Write("Your option: ");
                s = Console.ReadLine();
            }

            return s;
        }
    }
}
