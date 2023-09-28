namespace Flashcards.DEVHAWKZ.Library.Controller
{
    internal static class Validations
    {
        internal static string GetValidString(string s)
        {
            while(string.IsNullOrEmpty(s)) 
            {
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid input.Please try again.");
                Console.Write("Your option: ");
                s = Console.ReadLine();
            }

            return s.ToLower().Trim();
        }

        internal static string GetValidOption(string option)
        {
            string[] options = new string[] {"main menu", "view", "insert", "update", "delete"};

            while(!options.Contains(option)) 
            {
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid option. Please try again.");
                Console.Write("Your option: ");
                option = Console.ReadLine();
            }

            return option.ToLower().Trim();
        }
    }
}
