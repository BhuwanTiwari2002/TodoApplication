using Microsoft.Data.SqlClient;
using System.Data;

namespace BT.TodoListApplication.DB.Helper
{
    public class DatabaseHelper
    {
        public DataTable data { get; set; }
        public DataTable sendSQLCommand(string command)
        {
            try
            {
                string connectionString = "Data Source=GBT-120402-L;Initial Catalog=TodoApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
                //string connectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=TodoApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

                SqlConnection sqlConnection = new SqlConnection(connectionString);
                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                // Keeps track of the different SQL Data (Like changes in the tables) -- Opens the sqlConnection
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                // DataTable is the same as Table (Stored of the data and its stucture)
                DataTable todoTable = new DataTable();
                sqlDataAdapter.Fill(todoTable); // This returns a table
                return todoTable;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       
        public DatabaseHelper(string command)
        {
            data = sendSQLCommand(command);
        }
        public DatabaseHelper() { }
    }
}