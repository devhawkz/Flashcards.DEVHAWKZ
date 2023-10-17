using Dapper;
using Flashcards.DEVHAWKZ.Library.Model;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Flashcards.DEVHAWKZ.Library.Controller;

internal class FlashcardsQueries: Queries
{
    internal List<Flashcard> ViewFlashcards()
    { 
        using (IDbConnection connection = new SqlConnection(ConnectionString))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", Helpers.GetStackId());

            string storedProcedureName = "ViewFlashcards";

            List<Flashcard> flashcards = connection.Query<Flashcard>(storedProcedureName, commandType: CommandType.StoredProcedure).ToList();

            return flashcards;

        }
    }
}
