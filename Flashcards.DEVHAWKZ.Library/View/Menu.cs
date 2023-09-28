using Flashcards.DEVHAWKZ.Library.Controller;

namespace Flashcards.DEVHAWKZ.Library.View;

public class Menu
{
    TableVisualizationEngine viewEngine = new();

    private string ShowMainMenu()
    {
        Dictionary<string, string> menu = new Dictionary<string, string>()
        {
            {"exit", "Exit Flashcards app" },
            {"stack" , "Manage stacks"},
            {"flashcard", "Manage flashcards"},
            {"study" , "Study sessions info"},
            {"reports", "Various reports about study sessions" }
        };

        viewEngine.PrintMenu(menu);

        Console.Write("Your option: ");
        string option = Validations.GetValidString(Console.ReadLine());

        return option;
    }

    private bool MainMenuOptions(string option)
    {
        switch (option.ToLower().Trim()) 
        {
            case "exit":
                return false;

            case "stack":
                Console.Clear();
                Console.WriteLine("stacks");
                Console.ReadKey();
                break;

            case "flashcard":
                Console.Clear();
                Console.WriteLine("flashcard");
                Console.ReadKey();
                break;


            case "study":
                Console.Clear();
                Console.WriteLine("study");
                Console.ReadKey();
                break;

            case "reports":
                Console.Clear();
                Console.WriteLine("reports");
                Console.ReadKey();
                break;

            default:
                Console.Clear();
                Console.WriteLine("Invalid input. Please try again.");
                Console.ReadKey();
                break;
        }

        return true;
    }

    public void MainMenu()
    {
        bool continueApp = true;

        while(continueApp)
        {
            string option = ShowMainMenu();
            continueApp = MainMenuOptions(option);
        }

        Console.Clear();
        Console.WriteLine("Thank you for using our app!\n\nPress any key to exit...");
        Console.ReadKey();
    }
}