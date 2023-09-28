using System.Configuration;

namespace Flashcards.DEVHAWKZ.Library.Controller;

internal abstract class Queries
{
    private string _connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");

    internal string ConnectionString { get { return _connectionString; } }
}
