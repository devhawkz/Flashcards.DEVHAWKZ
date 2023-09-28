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
}
