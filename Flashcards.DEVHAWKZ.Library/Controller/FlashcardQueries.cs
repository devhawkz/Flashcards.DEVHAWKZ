using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Flashcards.DEVHAWKZ.Library.Model;
using Flashcards.DEVHAWKZ.Library.View;

namespace Flashcards.DEVHAWKZ.Library.Controller
{
    internal class FlashcardQueries : Queries
    {


        internal List<Flashcard> ViewFlashcards()
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string storedProcedureName = "ViewFlashcards";

                List<Flashcard> flashcards = connection.Query<Flashcard>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();

                return flashcards;

            }
        }
        
        internal void InsertNewFlashcard()
        {
            

            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string storedprocedureName = "InsertFlashcard";

                var parameters = new DynamicParameters();
                parameters.Add("@Question", Helpers.GetStackName());
                parameters.Add("@Answer", Helpers.GetStackName());

                int rows = connection.Execute(storedprocedureName, parameters, commandType: CommandType.StoredProcedure);

                if (rows > 0)
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

        /*
        internal void UpdateStack()
        {
            TableVisualizationEngine.PrintStacks(ViewStacks());

            int id = Validations.GetValidInt();

            bool possible = possibleQuery(id);

            if (possible)
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    string name = Validations.GetValidString();
                    string storedProcedureName = "UpdateStack";

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);
                    parameters.Add("@Name", name);

                    int rows = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (rows > 0)
                    {
                        Console.WriteLine("\nStack updated succesfully!");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("\nStack update failed.");
                        Console.ReadKey();
                    }
                }
            }

            else
            {
                Console.WriteLine("\nThe id you have entered doesn't exist");
                Console.ReadKey();
            }
        }

        internal void DeleteStack()
        {
            TableVisualizationEngine.PrintStacks(ViewStacks());

            int id = Validations.GetValidInt();

            bool possible = possibleQuery(id);

            if (possible)
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "DeleteStack";

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    int rows = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (rows > 0)
                    {
                        Console.WriteLine("\nStack deleted succesfully!");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("\nErasing the stach has failed.");
                        Console.ReadKey();
                    }
                }
            }

            else
            {
                Console.WriteLine("\nThe id you have entered doesn't exist");
                Console.ReadKey();
            }
        }

        private bool possibleQuery(int id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string storedProcedureName = "PossibleStackUpdate";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = connection.QueryFirstOrDefault(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                if (result != null)
                    return true;
                else
                    return false;
            }
        }

        */
    }
}
