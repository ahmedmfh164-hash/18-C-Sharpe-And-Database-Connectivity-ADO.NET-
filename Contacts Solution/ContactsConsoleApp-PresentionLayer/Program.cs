using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBusinessLayer;
using CountriesBusinessLayer;

namespace ContactsConsoleApp_PresentionLayer
{
    internal class Program
    {

        static void testFindContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName+" "+Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else
            {
                Console.WriteLine("Contact ["+ ID +"] Not Found!");
            }
        }


        static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();

            Contact1.FirstName="Fadi";
            Contact1.LastName="Maher";
            Contact1.Email="A@s.com";
            Contact1.Phone="01930232";
            Contact1.Address="address1";
            Contact1.DateOfBirth=new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID=1;
            Contact1.ImagePath="";

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully with id=" +Contact1.ID);
            }
        }

        static void testUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Contact1.FirstName="Ahmed";
                Contact1.LastName="Mohammed";
                Contact1.Email="ahmed@s.com";
                Contact1.Phone="01345930232";
                Contact1.Address="2222";
                Contact1.DateOfBirth=new DateTime(1977, 11, 6, 10, 30, 0);
                Contact1.CountryID=1;
                Contact1.ImagePath="";

                if (Contact1.Save())
                {
                    Console.WriteLine("Contact Updated Successfully with id=" +ID);
                }
            }
            else
            {
                Console.WriteLine("Contact is Not Found");
            }

        }

        static void testDeleteContact(int ID)
        {
            if(clsContact.isContactExist(ID))
                if (clsContact.DeleteContact(ID))
                {
                    Console.WriteLine("Contact Deleted Successfully with id=" +ID);
                }
                else
                {
                    Console.WriteLine("Failed to delete contact");
                }
            else
               Console.WriteLine($"Contact with id: {ID} is not found");
        }

        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]} {row["LastName"]}");
            }

        }

        static void testIsContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
                Console.WriteLine($"Yes, Contact is there with id: {ID}.");
            else
                Console.WriteLine($"No, Contact is not there with id: {ID}.");

        }


        public static void FindCountryByID(int ID)
        {
            clsCountries Country = clsCountries.FindByID(ID);

            if (Country != null)
            {
                Console.WriteLine($"CountryID: {ID}");
                Console.WriteLine($"CountryName: {Country.CountryName}");
                Console.WriteLine($"CountryCode: {Country.CountryCode}");
                Console.WriteLine($"PhoneCode: {Country.PhoneCode}");

            }
            else
                Console.WriteLine($"Country with ID: {ID} is Not Found!");

        }

        public static void FindCountryByName(string CountryName)
        {
            clsCountries Country = clsCountries.FindByName(CountryName);

            if (Country != null)
            {
                Console.WriteLine($"CountryID: {Country.CountryID}");
                Console.WriteLine($"CountryName: {CountryName}");
                Console.WriteLine($"CountryCode: {Country.CountryCode}");
                Console.WriteLine($"PhoneCode: {Country.PhoneCode}");
            }
            else
                Console.WriteLine($"Country with Name: {CountryName} is Not Found!");

        }


        public static void AddNewCountry()
        {
            clsCountries Country = new clsCountries();

            Country.CountryName="Morocco";
            Country.ContinentName="Africa";
            Country.CountryCode="MAR";
            Country.PhoneCode="+212";

            if (Country.Save())
                Console.WriteLine($"Country Added Successfully with id={Country.CountryID}.");
            else
                Console.WriteLine("Failed Adding Country! ");

        }

        public static void UpdateCountry(int ID)
        {
            clsCountries Country = clsCountries.FindByID(ID);

            if (Country != null)
            {

                Country.CountryName="Holland";
                Country.ContinentName="Europe";
                Country.CountryCode="NLD";
                Country.PhoneCode="+31";

                if (Country.Save())
                    Console.WriteLine($"Country Updated Successfully with id={ID}.");
                else
                    Console.WriteLine("Failed Updating Country! ");
            }
            else
                Console.WriteLine($"Country with ID: {ID} is Not Found!");

        }

        public static void IsCountryExistByID(int ID)
        {

            if (clsCountries.isCountryExistByID(ID))
            {
                Console.WriteLine($"Country with ID: {ID} is Found!");
            }
            else
                Console.WriteLine($"Country with ID: {ID} is Not Found!");

        }

        public static void IsCountryExistByName(string CountryName)
        {

            if (clsCountries.isCountryExistByCountryName(CountryName))
            {
                Console.WriteLine($"Country with ID: {CountryName} is Found!");
            }
            else
                Console.WriteLine($"Country with ID: {CountryName} is Not Found!");

        }

        public static void DeleteCountry(int ID)
        {

            if (clsCountries.isCountryExistByID(ID))
            {

                if (clsCountries.DeleteCountry(ID))
                    Console.WriteLine($"Country Deleted Successfully with id={ID}.");
                else
                    Console.WriteLine("Failed Deleting Country! ");
            }
            else
                Console.WriteLine($"Country with ID: {ID} is Not Found!");

        }

        public static void ListCountries()
        {
            DataTable dt = clsCountries.GetAllCountries();

            Console.WriteLine("Countries Data:\n");

            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                    Console.WriteLine($"CountryID:{dr["CountryID"]}, CountryName:{dr["CountryName"]}");
            }

        }

        static void Main(string[] args)
        {
            //testFindContact(1);
            //testAddNewContact();
            //testUpdateContact(2);
            //testDeleteContact(4);
            //ListContacts();

            //testIsContactExist(1);
            //testIsContactExist(10);


            //FindCountryByID(5);

            // FindCountryByName("Jordan");

            //AddNewCountry();

            //UpdateCountry(3);

            //IsCountryExistByID(2);

            //IsCountryExistByName("Jordan");

            // DeleteCountry(3);

            // ListCountries();

            Console.ReadKey();
        }
    }
}
