using System;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace ContactsDataAccessLayer
{
    public class clsContactDataAccess
    {
        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName,
            ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth,
            ref int CountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "Select * from Contacts Where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound=true;
                    FirstName=(string)reader["FirstName"];
                    LastName=(string)reader["LastName"];
                    Email=(string)reader["Email"];
                    Phone=(string)reader["Phone"];
                    Address=(string)reader["Address"];
                    DateOfBirth=(DateTime)reader["DateOfBirth"];
                    CountryID=(int)reader["CountryID"];

                    if (reader["ImagePath"]!=DBNull.Value)
                    {
                        ImagePath=(string)reader["ImagePath"];
                    }
                    else
                        ImagePath="";

                }
                else
{
                    isFound = false;
}
                    reader.Close();

            }
            catch (Exception ex)
            {
               // Console.WriteLine("Error"+ex.ToString());
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }


        public static int AddNewContact( string FirstName, string LastName,string Email,
            string Phone, string Address, DateTime DateOfBirth,int CountryID, string ImagePath)
        {
            //this function will return the new contact id if succeeded and -1 if not.
            int ContactID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query=@"Insert Into Contacts (FirstName,LastName,Email,Phone,Address,DateOfBirth,CountryID,ImagePath)
           Values (@FirstName,@LastName,@Email,@Phone,@Address,@DateOfBirth,@CountryID,@ImagePath);
            Select SCOPE_IDENTITY();";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone",Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath!="")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result!=null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ContactID=insertedID;
                }
            }
            catch (Exception ex)
            {
             //Console.WriteLine("Error"+ex.ToString());
            }
            finally
            {
                connection.Close();
            }

            return ContactID;

        }

        public static bool UpdateContact(int ID,string FirstName, string LastName, string Email,
           string Phone, string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {

            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Update Contacts
                           set FirstName=@FirstName,
                             LastName=@LastName,
                             Email=@Email,
                             Phone=@Phone,
                             Address=@Address,
                             DateOfBirth=@DateOfBirth,
                             CountryID=@CountryID,
                             ImagePath=@ImagePath
                             where ContactID=@ContactID;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath!="")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);


            try
            {
                connection.Open();

               rowsAffected= command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }


            return (rowsAffected>0);
        }

        public static bool DeleteContact(int ID)
        {
            int rowsAffected = 0;

            SqlConnection connection=new SqlConnection(clsDataAccessSettings.connectionString);

            string query = @"Delete Contacts
                             where ContactID=@ContactID;";

            SqlCommand command= new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                rowsAffected=command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);

        }


        public static DataTable GetAllContacts()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "Select * from Contacts";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static bool IsContactExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.connectionString);

            string query = "Select Found=1 From Contacts Where ContactID=@ContactID";

            SqlCommand command=new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound=reader.HasRows;
                reader.Close();

            }
            catch (Exception ex)
            {

            }
finally
            {
                connection.Close();
            }

            return isFound;
        }
    }
}
