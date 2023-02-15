using System.Data;
using System.Data.SqlClient;

namespace connectingToDatabaseSample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void createDB()
            {
                String ConnectionString;
                SqlConnection connection = new SqlConnection(@"Data Source =.; Initial Catalog = BzAtmApp; Integrated Security = True");
                ConnectionString = "CREATE DATABASE NewBtmApp";

                SqlCommand myCommand = new SqlCommand(ConnectionString, connection);
                try
                {
                    connection.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("DataBase is Created Successfully");
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }

            }

            createDB();
        }
    }
}