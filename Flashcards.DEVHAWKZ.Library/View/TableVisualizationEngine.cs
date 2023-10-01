using Flashcards.DEVHAWKZ.Library.Model;
using System.Data;
using static Flashcards.DEVHAWKZ.Library.View.TableVisualizationHelpers;

namespace Flashcards.DEVHAWKZ.Library.View
{
    internal static class TableVisualizationEngine
    {
        internal static void PrintMenu(Dictionary<string, string> menu)
        {
            Console.Clear();
            DataTable menuTable = PrintDetails(menu);
            PrintHelper(menuTable);
        }

        internal static int PrintStacks(List<Stacks> stacks)
        {
            Console.Clear();
            if(stacks.Count == 0) 
                Console.WriteLine("There is no stack created yet!");

            DataTable stackTable = PrintStacksDetails(stacks);
            PrintHelper(stackTable);

            return stacks.Count;
        }

        internal static void PrintFlashcards(List<Flashcard> flashcards)
        {
            Console.Clear();
            if (flashcards.Count > 0)
            {
                DataTable stackTable = PrintFlashcardsDetails(flashcards);
                PrintHelper(stackTable);
            }

            else
                Console.WriteLine("There is no flashcard created yet!");
        }
    }
}
