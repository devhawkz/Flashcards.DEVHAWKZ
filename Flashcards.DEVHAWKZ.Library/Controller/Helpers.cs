using Flashcards.DEVHAWKZ.Library.Model;

namespace Flashcards.DEVHAWKZ.Library.Controller;

internal class Helpers
{
   internal static Dictionary<string,string> GetMenuDetails(string s)
    {
        Dictionary<string, string> menu = new Dictionary<string, string>()
        {
            {"main menu", "Get back to main menu" },
            {"insert" , $"Insert new {s}"},
            {"view", $"View all {s}"},
            {"update" , $"Study {s}"},
            {"delete", $"Delete {s}" }
        };

        return menu;
    }

    internal static bool MenuOptions(string option)
    {
        switch (option)
        {
            case "main menu":
                return false;

            case "insert":
                Console.Clear();
                Console.WriteLine("insert");
                Console.ReadKey();
                break;

            case "view":
                Console.Clear();
                Console.WriteLine("view");
                Console.ReadKey();
                break;


            case "update":
                Console.Clear();
                Console.WriteLine("update");
                Console.ReadKey();
                break;

            case "delete":
                Console.Clear();
                Console.WriteLine("delete");
                Console.ReadKey();
                break;

            default:
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid option. Please try again.");
                Console.ReadKey();
                break;
        }

        return true;
    }

    internal static string GetStackName()
    {
        Console.Clear();
        Console.Write("Enter new stack name: ");
        string stackName = Console.ReadLine();

        while(string.IsNullOrEmpty(stackName))
        {
            Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid input.Please try again.");
            Console.Write("Enter new stack name: ");
            stackName = Console.ReadLine();
        }

        return stackName;
    }

}
