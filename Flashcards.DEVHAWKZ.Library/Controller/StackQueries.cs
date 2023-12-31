﻿using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Flashcards.DEVHAWKZ.Library.Model;
using Flashcards.DEVHAWKZ.Library.View;


namespace Flashcards.DEVHAWKZ.Library.Controller;

internal class StackQueries : Queries
{
    internal List<Stacks> ViewStacks()
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
            parameters.Add("@Name", Validations.GetValidString("Enter new stack name: "));

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

    internal void UpdateStack()
    {
        TableVisualizationEngine.PrintStacks(ViewStacks());

        int id = Validations.GetValidInt("Enter a row you want to update: ");

        bool possible = PossibleQuery(id, "PossibleStackUpdate");

        if(possible) 
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString)) 
            {
                string name = Validations.GetValidString("Enter new name of the stack: ");
                string storedProcedureName = "UpdateStack";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                parameters.Add("@Name", name);

                int rows = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                if(rows > 0) 
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

        int idToDelete = Validations.GetValidInt("\nEnter an id of a row you want to delete: ");

        bool possible = PossibleQuery(idToDelete, "PossibleStackUpdate");

        if (possible)
        {
            using (IDbConnection connection = new SqlConnection(ConnectionString))
            {
                string storedProcedureName = "DeleteStack";

                var parameters = new DynamicParameters();
                parameters.Add("@Id", idToDelete);

                int rows = connection.Execute(storedProcedureName, parameters, commandType: CommandType.StoredProcedure);

                if (rows > 0)
                {
                    Console.WriteLine("\nStack deleted succesfully!");
                    Console.ReadKey();
                }

                else
                {
                    Console.WriteLine("\nErasing the stack has failed.");
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
