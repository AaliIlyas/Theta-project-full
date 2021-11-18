using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Theta.Helper
{
    public static class DatabaseHelper
    {
        public static bool CheckDatabaseExistsAndSeeded(string connectionString, string databaseName)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand($"SELECT db_id('{databaseName}')", connection))
                {
                    connection.Open();

                    var customer = new SqlCommand("SELECT * FROM Customer", connection);
                    var databaseExists = command.ExecuteScalar() != DBNull.Value;
                    var dataSeeded = customer.ExecuteReader().HasRows; 

                    return databaseExists && dataSeeded;
                }
            }
        }
    }
}
