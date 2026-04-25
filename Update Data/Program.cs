using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update_Data
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

        static void UpdateContact(int ContactID,stContact ContactInfo)
        {

            SqlConnection connection = new SqlConnection(connectionString);

            string query = @"Update Contacts 
                                set FirstName=@FirstName,
                                    LastName=@LastName,
                                    Email=@Email,
                                    Phone=@Phone,
                                    Address=@Address,
                                    CountryID=@CountryID
                                    where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            command.Parameters.AddWithValue("@FirstName", ContactInfo.FirstName);
            command.Parameters.AddWithValue("@LastName", ContactInfo.LastName);
            command.Parameters.AddWithValue("@Email", ContactInfo.Email);
            command.Parameters.AddWithValue("@Phone", ContactInfo.Phone);
            command.Parameters.AddWithValue("@Address", ContactInfo.Address);
            command.Parameters.AddWithValue("@CountryID", ContactInfo.CountryID);


            try
            {
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Record Updated successfully.");
                }
                else
                    Console.WriteLine("Record Update failed.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:"+ex.Message);
            }

        }



        static void Main(string[] args)
        {
            stContact contactInfo = new stContact
            {
                FirstName="Ahmed",
                LastName="Mohammed",
                Email="ahmed@gmail.com",
                Phone="01029551696",
                Address="123 Main Street",
                CountryID=1
            };

            UpdateContact(1,contactInfo);

            Console.ReadKey();
        }
    }
}
