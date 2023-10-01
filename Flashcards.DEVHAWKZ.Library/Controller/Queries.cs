using Dapper;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Flashcards.DEVHAWKZ.Library.Controller;

internal abstract class Queries
{
    private string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

    internal string ConnectionString { get { return _connectionString; } }

    internal bool PossibleQuery(int id, string storedProcedureName)
    {
        using (IDbConnection connection = new SqlConnection(ConnectionString))
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);

            var result = connection.QueryFirstOrDefault(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

            if (result != null)
                return true;
            else
                return false;
        }
    }
}
