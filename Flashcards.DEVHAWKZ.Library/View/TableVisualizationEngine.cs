using System.Data;
using static Flashcards.DEVHAWKZ.Library.View.TableVisualizationHelpers;

namespace Flashcards.DEVHAWKZ.Library.View
{
    internal class TableVisualizationEngine
    {
        internal void PrintMenu(Dictionary<string, string> menu)
        {
            Console.Clear();
            DataTable menuTable = PrintDetails(menu);
            PrintMenuHelper(menuTable);
        }
    }
}
