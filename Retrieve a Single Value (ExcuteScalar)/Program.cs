using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Retrieve_a_Single_Value__ExcuteScalar_
{

    internal class Program
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;";

        static string GetFirstName(int ContactID)
        {
            string FirstName = "";
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select FirstName from Contacts where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();

                Object result = command.ExecuteScalar();

                if (result != null)
                {

                    FirstName = result.ToString();
                }
                else
                {
                    FirstName="";
                }

                    connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
            }

            return FirstName;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(GetFirstName(1));

            Console.ReadKey();

        }
    }
}
