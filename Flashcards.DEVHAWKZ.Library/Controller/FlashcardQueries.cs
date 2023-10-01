using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Flashcards.DEVHAWKZ.Library.Model;
using static Flashcards.DEVHAWKZ.Library.View.TableVisualizationEngine;

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
           bool possible = Helpers.GetStackID(out int id);

            if (possible)
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    string storedprocedureName = "InsertFlashcard";

                    var parameters = new DynamicParameters();
                    parameters.Add("@Question", Helpers.GetQuestionOrAnswer("question"));
                    parameters.Add("@Answer", Helpers.GetQuestionOrAnswer("answer"));
                    parameters.Add("@Stack_Id", id);

                    int rows = connection.Execute(storedprocedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (rows > 0)
                    {
                        Console.WriteLine("\nFlashcard inserted succesfully!");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("\nFlashcard insertion failed.");
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

        internal void UpdateFlashcard()
        {
            PrintFlashcards(ViewFlashcards());

            int id = Validations.GetValidInt("Enter a row you want to update: ");

            bool possible = PossibleQuery(id);

            if (possible)
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "UpdateFlashcards";

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);
                    parameters.Add("@Question", Helpers.GetQuestionOrAnswer("question"));
                    parameters.Add("@Answer", Helpers.GetQuestionOrAnswer("answer"));

                    int rows = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (rows > 0)
                    {
                        Console.WriteLine("\nFlashcard updated succesfully!");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("\nFlashcard update failed.");
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

        internal override bool PossibleQuery(int id)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string storedProcedureName = "PossibleFlashcardUpdate";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = connection.QueryFirstOrDefault(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                if (result != null)
                    return true;
                else
                    return false;
            }
        }
        /*
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
