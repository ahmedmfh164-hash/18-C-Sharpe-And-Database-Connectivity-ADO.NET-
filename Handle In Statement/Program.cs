using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handle_In_Statement
{
    internal class Program
    {

        static string connectionString = "Server=.\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;";

        static void DeleteContact(string ContactIDs)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"Delete Contacts
                             where ContactID in ("+ ContactIDs +")";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Deleted successfully.");
                }
                else
                    Console.WriteLine("Record Delete failed.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
            }

        }


        static void Main(string[] args)
        {
            DeleteContact("8,9,10");

            Console.ReadKey();
        }
    }
}
