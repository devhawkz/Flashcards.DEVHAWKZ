﻿using ConsoleTableExt;
using System.Data;

namespace Flashcards.DEVHAWKZ.Library.View;

internal static class TableVisualizationHelpers
{
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

    internal static void PrintMenuHelper(DataTable menuTable)
    {
       

        ConsoleTableBuilder.From(menuTable)
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