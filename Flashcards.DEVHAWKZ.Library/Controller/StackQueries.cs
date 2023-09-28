using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Flashcards.DEVHAWKZ.Library.Model;
using System.Net.WebSockets;

namespace Flashcards.DEVHAWKZ.Library.Controller;

internal class StackQueries : Queries
{
    internal  List<Stacks> ViewStacks()
    {

        using (IDbConnection connection = new SqlConnection(ConnectionString))
        {
            
            string storedProcedureName = "ViewStacks";

            List<Stacks> stacks = connection.Query<Stacks>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();

            return stacks;

        }
    }

    internal void InsertNewStack()
    {
        using(IDbConnection connection = new SqlConnection(ConnectionString)) 
        {
            string storedprocedureName = "InsertNewStack";

            var parameters = new DynamicParameters();
            parameters.Add("@Name", Helpers.GetStackName());

            int rows = connection.Execute(storedprocedureName, parameters, commandType: CommandType.StoredProcedure);

            if(rows > 0) 
            {
                Console.WriteLine("\nStack inserted succesfully!");
                Console.ReadKey();
            }

            else
            {
                Console.WriteLine("\nStack insertion failed.");
                Console.ReadKey();
            }
        }
    }
}
