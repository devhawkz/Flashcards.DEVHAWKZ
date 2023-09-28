using System.Data;
using static Flashcards.DEVHAWKZ.Library.View.TableVisualizationHelpers;
using Flashcards.DEVHAWKZ.Library.Model;

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

        internal static void PrintStacks(List<Stacks> stacks)
        {
            Console.Clear();
            DataTable stackTable = PrintStacksDetails(stacks);
            PrintHelper(stackTable);
           
        }
    }
}
