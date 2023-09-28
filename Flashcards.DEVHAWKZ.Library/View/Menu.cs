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

        return Validations.GetValidString();
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
                FlashcardMenu();
                break;


            case "study":
                Console.Clear();
                StudyMenu();
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
        return Validations.GetValidString();
    }

    private void StackMenu()
    {
        bool continueStackMenu = true;

        while (continueStackMenu)
        {
            string option = ShowStackMenu();
            continueStackMenu = Helpers.MenuOptions(option);
        }
    }

    /* FLASHCARDS MENU */

    private string ShowFlashcardMenu()
    {
        viewEngine.PrintMenu(Helpers.GetMenuDetails("flashcard"));
        return Validations.GetValidString();
    }

    private void FlashcardMenu()
    {
        bool continueFlashcardMenu = true;

        while (continueFlashcardMenu)
        {
            string option = ShowFlashcardMenu();
            continueFlashcardMenu = Helpers.MenuOptions(option);
        }
    }

    /* STUDY MENU */

    private string ShowStudyMenu()
    {
        Dictionary<string, string> menu = new Dictionary<string, string>()
        {
            {"main menu", "Get back to main menu" },
            {"start" , "Start new study session"},
            {"view", "View all study sessions"},
        };

        viewEngine.PrintMenu(menu);

        return Validations.GetValidString();
    }

    private bool StudyMenuOptions(string option)
    {
        switch (option)
        {
            case "main menu":
                return false;

            case "start":
                Console.Clear();
                Console.WriteLine("start");
                Console.ReadKey();
                break;

            case "view":
                Console.Clear();
                Console.WriteLine("view");
                Console.ReadKey();
                break;

            default:
                Console.WriteLine("\n----------------------------------------------------------------------------\nInvalid option. Please try again.");
                Console.ReadKey();
                break;
        }

        return true;
    }

    public void StudyMenu()
    {
        bool continueStudyApp = true;

        while (continueStudyApp)
        {
            string option = ShowStudyMenu();
            continueStudyApp = StudyMenuOptions(option);
        }
    }
}