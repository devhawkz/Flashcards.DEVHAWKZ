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
        switch (option) 
        {
            case "exit":
                return false;

            case "stack":
                Console.Clear();
                StackMenu();
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

    /* STACK MENU */

    private string ShowStackMenu()
    {
        viewEngine.PrintMenu(Helpers.GetMenuDetails("stack"));
        
        Console.Write("Your option: ");
        string option = Validations.GetValidOption(Console.ReadLine());

        return option;
    }

    private bool StackMenuOptions(string option)
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
        }

        return true;
    }

    private void StackMenu()
    {
        bool continueStackMenu = true;

        while (continueStackMenu)
        {
            string option = ShowStackMenu();
            continueStackMenu = StackMenuOptions(option);
        }
    }
}