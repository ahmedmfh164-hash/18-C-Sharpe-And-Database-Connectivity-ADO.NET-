using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_Single_Contact
{
    internal class Program
    {

        static string connectionString = "Server=.\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;";

        static bool FindContactByID(int ContactID, ref stContact ContactInfo)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select * from Contacts where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ContactInfo.ID=(int)reader["ContactID"];
                    ContactInfo.FirstName=(string)reader["FirstName"];
                    ContactInfo.LastName=(string)reader["LastName"];
                    ContactInfo.Email=(string)reader["Email"];
                    ContactInfo.Phone=(string)reader["Phone"];
                    ContactInfo.Address=(string)reader["Address"];
                    ContactInfo.CountryID=(int)reader["CountryID"];

                }
                else
                    isFound = false;


                reader.Close();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
            }

            return isFound;
        }

        public struct stContact
        {
            public int ID;

            public string FirstName;

            public string LastName;
            public string Email;

            public string Phone;

            public string Address;

            public int CountryID;
        }

        static void Main(string[] args)
        {
            stContact ContactInfo = new stContact();

            if (FindContactByID(100, ref ContactInfo))
            {
                Console.WriteLine($"\nContact ID: {ContactInfo.ID}");
                Console.WriteLine($"Name: {ContactInfo.FirstName} {ContactInfo.LastName}");
                Console.WriteLine($"Email: {ContactInfo.Email}");
                Console.WriteLine($"Phone: {ContactInfo.Phone}");
                Console.WriteLine($"Address: {ContactInfo.Address}");
                Console.WriteLine($"Country ID: {ContactInfo.CountryID}");

            }
            else
            {
                Console.WriteLine("Contact is not found");
            }


            Console.ReadKey();
        }
    }
}
