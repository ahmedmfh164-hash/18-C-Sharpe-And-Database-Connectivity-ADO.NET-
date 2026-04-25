using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;


    public class Program
    {

    //static string connectionString = "Server=.;Database=ContactDB;User Id=sa;Password=123456;";
    static string connectionString = "Server=.\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;";

    static void PrintAllContactWithFirstName(string FirstName)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "Select * from Contacts Where FirstName=@FirstName";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue(@"FirstName", FirstName);

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
            Console.WriteLine("Error:"+ex.ToString());
        }
    }

    static void PrintAllContactWithFirstNameAndCountry(string FirstName,int CountryID)
    {
        SqlConnection connection = new SqlConnection(connectionString);

        string query = "Select * from Contacts Where FirstName=@FirstName and CountryID=@CountryID";

        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue(@"FirstName", FirstName);
        command.Parameters.AddWithValue(@"CountryID", CountryID);


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
            Console.WriteLine("Error:"+ex.ToString());
        }
    }

    public static void Main(string[] args)
            {
                //PrintAllContactWithFirstName("jane");
                PrintAllContactWithFirstNameAndCountry("jane",1);


                Console .ReadKey();
            }
        
    }

