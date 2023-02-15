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
                ConnectionString = "CREATE DATABASE BzAtmmApp";

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

            //createDB();
            void CreateUserTable()
            {
                SqlConnection connection = new SqlConnection(@"Data Source=.; Initial Catalog= BzAtmApp; Integrated Security=True");
                string createQ = "CREATE TABLE Users( id INT UNIQUE IDENTITY(1,1) NOT NULL," +
                        "userId uniqueidentifier NOT NULL  DEFAULT newid()," +
                        "name VARCHAR(70) NOT NULL, " +
                        "cardNumber VARCHAR(15) NOT NULL UNIQUE, " +
                        "cardPin VARCHAR(4) NOT NULL, " +
                        "balance DECIMAL(38,2) NOT NULL, " +
                        "status BIT NOT NULL, " +
                        "PRIMARY KEY(Id))";

                SqlCommand myCommand = new SqlCommand(createQ, connection);
                try
                {
                    connection.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("User Table Created Successfully");
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
            CreateUserTable();
        }
    }
}