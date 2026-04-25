using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Set
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DataTable EmployeesDataTable = new DataTable("EmployeesDataTable");
             EmployeesDataTable.Columns.Add("ID", typeof(int));
             EmployeesDataTable.Columns.Add("Name",typeof(string));
             EmployeesDataTable.Columns.Add("Country",typeof(string));
             EmployeesDataTable.Columns.Add("Salary", typeof(Double));
             EmployeesDataTable.Columns.Add("Date",typeof(DateTime));

            //Add rows
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


            DataTable DepartmentsDataTable = new DataTable("DepartmentsDataTable");
            DepartmentsDataTable.Columns.Add("DepartmentID", typeof(int));
            DepartmentsDataTable.Columns.Add("Name", typeof(string));

            DepartmentsDataTable.Rows.Add(1, "Marketing");
            DepartmentsDataTable.Rows.Add(2, "IT");
            DepartmentsDataTable.Rows.Add(3, "HR");
           
            Console.WriteLine("\nDepartments List:\n");
            foreach (DataRow row in DepartmentsDataTable.Rows)
            {
                Console.WriteLine("DepartmentID: {0}, Name: {1}", row["DepartmentID"],row["Name"]);
            }

            //Create DataSet
            DataSet dataSet1 = new DataSet();
            dataSet1.Tables.Add(EmployeesDataTable);
            dataSet1.Tables.Add(DepartmentsDataTable);

            Console.WriteLine("\nPrinting Employees Data from the Dataset:\n");
            foreach (DataRow row in dataSet1.Tables["EmployeesDataTable"].Rows)
            {
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", row["ID"],
                    row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            Console.WriteLine("\nPrinting Departments Data from the Dataset:\n");
            foreach (DataRow row in dataSet1.Tables["DepartmentsDataTable"].Rows)
            {
                Console.WriteLine("DepartmentID: {0}, Name: {1}", row["DepartmentID"], row["Name"]);
            }            





            Console.ReadKey();
        }
    }
}
