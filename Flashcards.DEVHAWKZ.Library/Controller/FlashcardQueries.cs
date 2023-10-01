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

            bool possible = PossibleQuery(id, "PossibleFlashcardUpdate");

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


        internal void DeleteFlashcard()
        {
            PrintFlashcards(ViewFlashcards());

            int id = Validations.GetValidInt("Enter a row you want to delete: ");

            bool possible = PossibleQuery(id, "PossibleFlashcardUpdate");

            if (possible)
            {
                using (IDbConnection connection = new SqlConnection(ConnectionString))
                {
                    string storedProcedureName = "DeleteFlashcard";

                    var parameters = new DynamicParameters();
                    parameters.Add("@Id", id);

                    int rows = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                    if (rows > 0)
                    {
                        Console.WriteLine("\nFlashcard deleted succesfully!");
                        Console.ReadKey();
                    }

                    else
                    {
                        Console.WriteLine("\nErasing the flashcard has failed.");
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


    }
}
