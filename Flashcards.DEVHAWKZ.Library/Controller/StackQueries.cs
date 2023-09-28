using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Flashcards.DEVHAWKZ.Library.Model;

namespace Flashcards.DEVHAWKZ.Library.Controller;

internal class StackQueries : Queries
{
    internal  List<Stacks> View()
    {

        using (IDbConnection connection = new SqlConnection(ConnectionString))
        {
            string storedProcedureName = "ViewStacks";

            List<Stacks> stacks = connection.Query<Stacks>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();

            foreach (var stack in stacks) 
            {
                Console.WriteLine(stack.Id + " " + stack.Name);
            }

            return stacks;
        }
    }
}
