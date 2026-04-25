using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insert_Add_Data
{
    internal class Program
    {
        static string connectionString = "Server=.\\SQLEXPRESS;Database=ContactsDB;Trusted_Connection=True;";

        public struct stContact
        {
            public string FirstName {  get; set; }
            public string LastName {  get; set; }
            public string Email {  get; set; }
            public string Phone {  get; set; }
            public string Address {  get; set; }
            public int CountryID {  get; set; }
        }

        static void AddNewContact( stContact newContact)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = @"Insert Into Contacts (FirstName,LastName,Email,Phone,Address,CountryID)
            Values(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID)";

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

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record inserted successfully.");
                }
                else
                    Console.WriteLine("Record insertion failed.");

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
                FirstName="Ahmed",
                LastName="Mohammed",
                Email="ahmed@gmail.com",
                Phone="01029551696" ,
                Address="123 Main Street",
                CountryID=1
            };

            AddNewContact(contact);

            Console.ReadKey();
        }
    }
}
