using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Program
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;";


        static void SearchContactsStartsWith(string StartWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select *from Contacts where FirstName Like '' + @StartsWith + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@startsWith", StartWith);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID:{contactID}");
                    Console.WriteLine($"Name:{firstName} {lastName}");
                    Console.WriteLine($"Email:{email}");
                    Console.WriteLine($"Phone:{phone}");
                    Console.WriteLine($"Address:{address}");
                    Console.WriteLine($"Country ID:{countryID}\n");

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex) 
            {
                     Console.WriteLine("Error:"+ex.Message);
            
            }

        }

        static void SearchContactsEndsWith(string EndWith)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select *from Contacts where FirstName Like '' + '%'+ @EndWith +''";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@EndWith", EndWith);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID:{contactID}");
                    Console.WriteLine($"Name:{firstName} {lastName}");
                    Console.WriteLine($"Email:{email}");
                    Console.WriteLine($"Phone:{phone}");
                    Console.WriteLine($"Address:{address}");
                    Console.WriteLine($"Country ID:{countryID}\n");

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);

            }

        }

        static void SearchContactsContains(string Contains) 
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select *from Contacts where FirstName Like '' + '%'+ @Contains + '%'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contains);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int contactID = (int)reader["ContactID"];
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    string email = (string)reader["Email"];
                    string phone = (string)reader["Phone"];
                    string address = (string)reader["Address"];
                    int countryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID:{contactID}");
                    Console.WriteLine($"Name:{firstName} {lastName}");
                    Console.WriteLine($"Email:{email}");
                    Console.WriteLine($"Phone:{phone}");
                    Console.WriteLine($"Address:{address}");
                    Console.WriteLine($"Country ID:{countryID}\n");

                }
                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);

            }

        }


        static void Main(string[] args)
        {
            Console.WriteLine("--------Contacts starts with 'j'");

            SearchContactsStartsWith("j");

            Console.WriteLine("--------Contacts Ends with 'ne'");

            SearchContactsEndsWith("ne");

            Console.WriteLine("--------Contacts Contains with 'ae'");

            SearchContactsContains("ae");


        }
    }
}
