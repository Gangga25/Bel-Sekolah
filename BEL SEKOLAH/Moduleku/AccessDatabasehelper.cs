using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class AccessDatabaseHelper
    {
        private OleDbConnection connection;
        private string connectionString;

        public AccessDatabaseHelper(string databasePath)
        {
            //connectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};";
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + databasePath + ";";
        }

        public AccessDatabaseHelper Connect()
        {
            connection = new OleDbConnection(connectionString);
            connection.Open();
            return this;
        }

        public AccessDatabaseHelper Disconnect()
        {
            connection.Close();
            return this;
        }

        public DataTable RunQuery(string query, params OleDbParameter[] parameters)
        {
            var dataTable = new DataTable();
            var command = new OleDbCommand(query, connection);

            command.Parameters.AddRange(parameters);

            var dataAdapter = new OleDbDataAdapter(command);
            dataAdapter.Fill(dataTable);

            return dataTable;
        }

        public int RunNonQuery(string query, params OleDbParameter[] parameters)
        {
            var command = new OleDbCommand(query, connection);
            command.Parameters.AddRange(parameters);
            return command.ExecuteNonQuery();
        }
    }

}
