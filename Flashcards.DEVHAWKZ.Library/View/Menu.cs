using Flashcards.DEVHAWKZ.Library.Controller;
using static Flashcards.DEVHAWKZ.Library.View.TableVisualizationEngine;

namespace Flashcards.DEVHAWKZ.Library.View;

public class Menu
{
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

       PrintMenu(menu);

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
        PrintMenu(Helpers.GetMenuDetails("stack"));
        return Validations.GetValidString();
    }

    private static bool StackMenuOptions(string option)
    {
        StackQueries stackQueries = new();

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
                PrintStacks(stackQueries.View());
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

    private void StackMenu()
    {
        bool continueStackMenu = true;

        while (continueStackMenu)
        {
            string option = ShowStackMenu();
            continueStackMenu = StackMenuOptions(option);
        }
    }

    /* FLASHCARDS MENU */

    private string ShowFlashcardMenu()
    {
        PrintMenu(Helpers.GetMenuDetails("flashcard"));
        return Validations.GetValidString();
    }

    internal static bool FlashcardMenuOptions(string option)
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

    private void FlashcardMenu()
    {
        bool continueFlashcardMenu = true;

        while (continueFlashcardMenu)
        {
            string option = ShowFlashcardMenu();
            continueFlashcardMenu = FlashcardMenuOptions(option);
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

        PrintMenu(menu);

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