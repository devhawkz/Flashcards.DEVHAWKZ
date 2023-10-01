using ConsoleTableExt;
using System.Data;
using Flashcards.DEVHAWKZ.Library.Model;


namespace Flashcards.DEVHAWKZ.Library.View;

internal static class TableVisualizationHelpers
{
    internal static DataTable PrintStacksDetails(List<Stacks> stacks)
    {
        DataTable stackTable = new DataTable();
        stackTable.Columns.Add("ID", typeof(int));
        stackTable.Columns.Add("Name", typeof(string));

        for (int i = 0; i < stacks.Count; i++)
        {
            stackTable.Rows.Add(stacks[i].Id, stacks[i].Name);
        }

        return stackTable;
    }

    internal static DataTable PrintFlashcardsDetails(List<Flashcard> flashcards)
    {
        DataTable flashcardsTable = new DataTable();
        flashcardsTable.Columns.Add("ID", typeof(int));
        flashcardsTable.Columns.Add("Question", typeof(string));
        flashcardsTable.Columns.Add("Answer", typeof(string));
        flashcardsTable.Columns.Add("Stack name", typeof(string));

        for (int i = 0; i < flashcards.Count; i++)
        {
            flashcardsTable.Rows.Add(flashcards[i].Id, flashcards[i].Question, flashcards[i].Answer, flashcards[i].StackName);
        }

        return flashcardsTable;
    }

    /* MENUES */

    internal static DataTable PrintDetails(Dictionary<string, string> menu)
    {
        DataTable menuTable = new DataTable();

        menuTable.Columns.Add("Command", typeof(string));
        menuTable.Columns.Add("Option", typeof(string));


        foreach (KeyValuePair<string, string> pair in menu)
        {
            menuTable.Rows.Add(pair.Key, pair.Value);
        }

        return menuTable;
    }

    internal static void PrintHelper(DataTable table)
    {
       
        ConsoleTableBuilder.From(table)
            .WithTextAlignment(new Dictionary<int, TextAligntment>
            {
                {0, TextAligntment.Center },
                {1, TextAligntment.Center }
            })
            .WithMinLength(new Dictionary<int, int>
            {
                {1, 75 },
                {2, 30 }
            })
            .WithCharMapDefinition(
                CharMapDefinition.FramePipDefinition,
                new Dictionary<HeaderCharMapPositions, char> {
                        {HeaderCharMapPositions.TopLeft, '╒' },
                        {HeaderCharMapPositions.TopCenter, '╤' },
                        {HeaderCharMapPositions.TopRight, '╕' },
                        {HeaderCharMapPositions.BottomLeft, '╞' },
                        {HeaderCharMapPositions.BottomCenter, '╪' },
                        {HeaderCharMapPositions.BottomRight, '╡' },
                        {HeaderCharMapPositions.BorderTop, '═' },
                        {HeaderCharMapPositions.BorderRight, '│' },
                        {HeaderCharMapPositions.BorderBottom, '═' },
                        {HeaderCharMapPositions.BorderLeft, '│' },
                        {HeaderCharMapPositions.Divider, '│' },
                })
            .ExportAndWriteLine(TableAligntment.Center);
    }

    
}
