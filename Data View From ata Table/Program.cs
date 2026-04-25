using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_View_From_ata_Table
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataTable EmployeesDataTable = new DataTable();
             EmployeesDataTable.Columns.Add("ID", typeof(int));
             EmployeesDataTable.Columns.Add("Name",typeof(string));
             EmployeesDataTable.Columns.Add("Country",typeof(string));
             EmployeesDataTable.Columns.Add("Salary", typeof(Double));
             EmployeesDataTable.Columns.Add("Date",typeof(DateTime));

            EmployeesDataTable.Rows.Add (1,"Ahmed Mohammed","Egypt",10000,DateTime.Now);
            EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA", 14000, DateTime.Now);
            EmployeesDataTable.Rows.Add(3, "Mohammed Abu-Hadhoud", "Jordan", 15000, DateTime.Now);
            EmployeesDataTable.Rows.Add(4, "Lina Jameel", "Egypt", 45365.546, DateTime.Now);
            EmployeesDataTable.Rows.Add(5, "Omar Mohammed", "Lebanon", 5456.40, DateTime.Now);

            Console.WriteLine("\nEmployees List:\n");

            foreach(DataRow row in EmployeesDataTable.Rows)
            {
               
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", row["ID"],
                    row["Name"],row["Country"], row["Salary"], row["Date"]);
            }


            ///Display all records in the view
                    //Create Data View From DAta Table
            DataView EmployeesDataView1 = EmployeesDataTable.DefaultView;

            Console.WriteLine("\n\nEmployees List from data view:\n");
            for (int i = 0; i<EmployeesDataView1.Count; i++)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", EmployeesDataView1[i][0], EmployeesDataView1[i][1],
                    EmployeesDataView1[i][2], EmployeesDataView1[i][3]);
            }


            ////Filtering DAta in DataView
            EmployeesDataView1.RowFilter="Country='Jordan' or Country='Egypt'";

            Console.WriteLine("\n\nEmployees List from data view after filtering \" Jordan or Egypt \":\n"); 
            for (int i = 0; i<EmployeesDataView1.Count; i++)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", EmployeesDataView1[i][0], EmployeesDataView1[i][1],
                    EmployeesDataView1[i][2], EmployeesDataView1[i][3]);
            }


            ////Sorting Data in Dataview
            EmployeesDataView1.Sort="Name Asc";

            Console.WriteLine("\n\nEmployees List from data view after sorting by Name Asc:\n");
            for (int i = 0; i<EmployeesDataView1.Count; i++)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", EmployeesDataView1[i][0], EmployeesDataView1[i][1],
                    EmployeesDataView1[i][2], EmployeesDataView1[i][3]);
            }





            Console.ReadKey();
        }
    }
}
