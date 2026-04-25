using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve_Auto_Number_after_Inserting_Adding_Data
{
    internal class Program
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;";

        public struct stContact
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public int CountryID { get; set; }
        }

        static void AddNewContactAndGetID(stContact newContact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Insert Into Contacts (FirstName,LastName,Email,Phone,Address,CountryID)
            Values(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID);
            Select SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", newContact.FirstName);
            command.Parameters.AddWithValue("@LastName", newContact.LastName);
            command.Parameters.AddWithValue("@Email", newContact.Email);
            command.Parameters.AddWithValue("@Phone", newContact.Phone);
            command.Parameters.AddWithValue("@Address", newContact.Address);
            command.Parameters.AddWithValue("@CountryID", newContact.CountryID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result!=null&&int.TryParse(result.ToString(),out int insertedID))
                {
                    Console.WriteLine($"Newly inserted ID: {insertedID}");
                }
                else
                    Console.WriteLine("Failed to retrieve the inserted ID.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
            }

        }



        static void Main(string[] args)
        {
            stContact contact = new stContact
            {
                FirstName="Laila",
                LastName="Maher",
                Email="m@example.com",
                Phone="0346547657",
                Address="123 Main Street",
                CountryID=1
            };

            AddNewContactAndGetID(contact);

            Console.ReadKey();
        }
    }
}
