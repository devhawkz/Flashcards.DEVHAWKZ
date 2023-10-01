using static Flashcards.DEVHAWKZ.Library.View.TableVisualizationEngine;

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

    internal static string GetStackName()
    {
        Console.Clear();
        Console.Write("");
        string stackName = Console.ReadLine();

        while(string.IsNullOrEmpty(stackName))
        {
            Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid input.Please try again.");
            Console.Write("Enter new stack name: ");
            stackName = Console.ReadLine();
        }

        return stackName;
    }

    internal static bool GetStackID(out int id)
    {
        StackQueries stackQueries = new();
        int idRange = PrintStacks(stackQueries.ViewStacks());

        id = Validations.GetValidInt("\nEnter id of a row in which you want to insert a flashcard: ");

        if(idRange >= id && id > 0) 
        {
            return true;    
        }

        return false;
    }

    internal static string GetQuestionOrAnswer(string msg)
    {
        string question = Validations.GetValidString($"Enter a {msg} for flashcard: ");
        return question;
    }

}
