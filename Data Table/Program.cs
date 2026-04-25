using System;
using System.Linq;
using System.Data;

namespace CreateOfflineDataTableAndListData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create offline DataTable and List Data

            DataTable EmployeesDataTable = new DataTable();
            /*
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
                //Using Index
               // Console.WriteLine("ID: {0}\tName: {1}\t  Country: {2}\tSalary:{3}\tDate:{4}", row[0],
               // row[1], row[2], row[3], row[4]);

                //Using Field Name
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", row["ID"],
                    row["Name"],row["Country"], row["Salary"], row["Date"]);
            }


            //Count,Sum,Avg,Min,Max

            int EmployeesCount = 0;
            double TotalSalaries = 0;
            double AvarageSalaries = 0;
            double MinSalary = 0;
            double MaxSalary = 0;

            EmployeesCount= EmployeesDataTable.Rows.Count;
            TotalSalaries=Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)",string.Empty));
            AvarageSalaries=Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", string.Empty));
            MinSalary=Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", string.Empty));
            MaxSalary=Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)", string.Empty));


            Console.WriteLine("\nCount of Employees= "+EmployeesCount);
            Console.WriteLine("Total Employees Salaries= "+TotalSalaries);
            Console.WriteLine("Avarage Employees Salaries= "+AvarageSalaries);
            Console.WriteLine("Minimum Employees Salaries= "+MinSalary);
            Console.WriteLine("Maximum Employees Salaries= "+MaxSalary);

            //Filter Data  by Country Egypt
            int ResultCount = 0;
            DataRow[] ResultRows;

            //filter only Egypt User
            ResultRows=EmployeesDataTable.Select("Country='Egypt'");

            Console.WriteLine("\n\nFilter \"Egypt\" Employees\n");

            foreach(DataRow ResultRow in ResultRows)
            {
                //Using Index
                // Console.WriteLine("ID: {0}\tName: {1}\t  Country: {2}\tSalary:{3}\tDate:{4}", ResultRow[0],
                // ResultRow[1], ResultRow[2], ResultRow[3], ResultRow[4]);

                //Using Field Name
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", ResultRow["ID"],
                    ResultRow["Name"], ResultRow["Country"], ResultRow["Salary"], ResultRow["Date"]);

            }

            ResultCount= ResultRows.Count();
            TotalSalaries=Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "Country='Egypt'"));
            AvarageSalaries=Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "Country='Egypt'"));
            MinSalary=Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", "Country='Egypt'"));
            MaxSalary=Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)", "Country='Egypt'"));

            Console.WriteLine("\nCount of Employees= "+ResultCount);
            Console.WriteLine("Total Employees Salaries= "+TotalSalaries);
            Console.WriteLine("Avarage Employees Salaries= "+AvarageSalaries);
            Console.WriteLine("Minimum Employees Salaries= "+MinSalary);
            Console.WriteLine("Maximum Employees Salaries= "+MaxSalary);



            Console.WriteLine("\n\nFilter \"Egypt\" or \"Jordan\" Employees\n");

            ResultRows=EmployeesDataTable.Select("Country='Egypt' or Country='Jordan'");

            foreach (DataRow ResultRow in ResultRows)
            {
                //Using Index
                // Console.WriteLine("ID: {0}\tName: {1}\t  Country: {2}\tSalary:{3}\tDate:{4}", ResultRow[0],
                // ResultRow[1], ResultRow[2], ResultRow[3], ResultRow[4]);

                //Using Field Name
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", ResultRow["ID"],
                    ResultRow["Name"], ResultRow["Country"], ResultRow["Salary"], ResultRow["Date"]);

            }

            ResultCount= ResultRows.Count();
            TotalSalaries=Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "Country='Egypt' or Country='Jordan'"));
            AvarageSalaries=Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "Country='Egypt' or Country='Jordan'"));
            MinSalary=Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", "Country='Egypt' or Country='Jordan'"));
            MaxSalary=Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)", "Country='Egypt' or Country='Jordan'"));

            Console.WriteLine("\nCount of Employees= "+ResultCount);
            Console.WriteLine("Total Employees Salaries= "+TotalSalaries);
            Console.WriteLine("Avarage Employees Salaries= "+AvarageSalaries);
            Console.WriteLine("Minimum Employees Salaries= "+MinSalary);
            Console.WriteLine("Maximum Employees Salaries= "+MaxSalary);




            ResultRows=EmployeesDataTable.Select("ID=1");

            Console.WriteLine("\n\nFilter Employees with ID=1 \n");

            foreach (DataRow ResultRow in ResultRows)
            {
                //Using Index
                // Console.WriteLine("ID: {0}\tName: {1}\t  Country: {2}\tSalary:{3}\tDate:{4}", ResultRow[0],
               //  ResultRow[1], ResultRow[2], ResultRow[3], ResultRow[4]);

                //Using Field Name
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", ResultRow["ID"],
                    ResultRow["Name"], ResultRow["Country"], ResultRow["Salary"], ResultRow["Date"]);

            }

            ResultCount= ResultRows.Count();
            TotalSalaries=Convert.ToDouble(EmployeesDataTable.Compute("SUM(Salary)", "ID=1"));
            AvarageSalaries=Convert.ToDouble(EmployeesDataTable.Compute("AVG(Salary)", "ID=1"));
            MinSalary=Convert.ToDouble(EmployeesDataTable.Compute("Min(Salary)", "ID=1"));
            MaxSalary=Convert.ToDouble(EmployeesDataTable.Compute("Max(Salary)", "ID=1"));

            Console.WriteLine("\nCount of Employees= "+ResultCount);
            Console.WriteLine("Total Employees Salaries= "+TotalSalaries);
            Console.WriteLine("Avarage Employees Salaries= "+AvarageSalaries);
            Console.WriteLine("Minimum Employees Salaries= "+MinSalary);
            Console.WriteLine("Maximum Employees Salaries= "+MaxSalary);


            ///Sorting
            //Sort by ID Desc
            EmployeesDataTable.DefaultView.Sort="ID desc";
            EmployeesDataTable=EmployeesDataTable.DefaultView.ToTable();

            Console.WriteLine("\n\nEmployees List Sorted By ID Desc:\n");

            foreach(DataRow Row in EmployeesDataTable.Rows)
            {
                //Using Index
                 //Console.WriteLine("ID: {0}\tName: {1}\t  Country: {2}\tSalary:{3}\tDate:{4}", Row[0],
                // Row[1], Row[2], Row[3], Row[4]);

                //Using Field Name
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", Row["ID"],
                    Row["Name"], Row["Country"], Row["Salary"], Row["Date"]);
            }


            ///Sort by Name Asc
            EmployeesDataTable.DefaultView.Sort="Name asc";
            EmployeesDataTable=EmployeesDataTable.DefaultView.ToTable();

            Console.WriteLine("\n\nEmployees List Sorted By Name Asc:\n");

            foreach (DataRow Row in EmployeesDataTable.Rows)
            {
                //Using Index
                // Console.WriteLine("ID: {0}\tName: {1}\t  Country: {2}\tSalary:{3}\tDate:{4}", Row[0],
                // Row[1], Row[2], Row[3], Row[4]);

                //Using Field Name
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", Row["ID"],
                    Row["Name"], Row["Country"], Row["Salary"], Row["Date"]);
            }


            ///Sort By ID Asc
            EmployeesDataTable.DefaultView.Sort="ID asc";
            EmployeesDataTable=EmployeesDataTable.DefaultView.ToTable();

            Console.WriteLine("\n\nEmployees List Sorted By ID Asc:\n");

            foreach (DataRow Row in EmployeesDataTable.Rows)
            {
                //Using Index
                 Console.WriteLine("ID: {0}\tName: {1}\t  Country: {2}\tSalary:{3}\tDate:{4}", Row[0],
                 Row[1], Row[2], Row[3], Row[4]);

                //Using Field Name
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", Row["ID"],
                    Row["Name"], Row["Country"], Row["Salary"], Row["Date"]);
            }


            ///Delete Row
            Console.WriteLine("\n\nEmployees List After Deleting ID=4:\n");

            DataRow[] Results = EmployeesDataTable.Select("ID=4");
            foreach(var RecordRow in Results)
            {
                RecordRow.Delete();
            }

            //EmployeesDataTable.AcceptChanges();

            foreach (DataRow Row in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", Row["ID"],
                    Row["Name"], Row["Country"], Row["Salary"], Row["Date"]);
            }


            ///Updating Rows
            Console.WriteLine("\n\nEmployees List After Updating ID=3:\n");

            Results = EmployeesDataTable.Select("ID=3");
            foreach (var RecordRow in Results)
            {
                RecordRow["Name"]="Maha Ahmed";
                RecordRow["Salary"]="900";
            }

            //EmployeesDataTable.AcceptChanges();

            foreach (DataRow Row in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", Row["ID"],
                    Row["Name"], Row["Country"], Row["Salary"], Row["Date"]);
            }


            ///Clear
           // EmployeesDataTable.Clear();

            ////Primary Key
            //Make ID the primary key column
            DataColumn[] PrimaryKeyColumn = new DataColumn[1];
            PrimaryKeyColumn[0]= EmployeesDataTable.Columns["ID"];
            EmployeesDataTable.PrimaryKey= PrimaryKeyColumn;
               */
             

            ///Autoincrement and Others
            DataColumn dtColumn;

            dtColumn=new DataColumn();
            dtColumn.DataType=typeof(int);
            dtColumn.ColumnName="ID";
            dtColumn.AutoIncrement=true;
            dtColumn.AutoIncrementSeed=1;
            dtColumn.AutoIncrementStep=1;
            dtColumn.Caption="Employee ID";
            dtColumn.ReadOnly=true;
            dtColumn.Unique=true;
            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn=new DataColumn();
            dtColumn.DataType=typeof(string);
            dtColumn.ColumnName="Name";
            dtColumn.AutoIncrement=false;
            dtColumn.Caption="Name";
            dtColumn.ReadOnly=false;
            dtColumn.Unique=false;
            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn=new DataColumn();
            dtColumn.DataType=typeof(string);
            dtColumn.ColumnName="Country";
            dtColumn.AutoIncrement=false;
            dtColumn.Caption="Country";
            dtColumn.ReadOnly=false;
            dtColumn.Unique=false;
            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn=new DataColumn();
            dtColumn.DataType=typeof(Double);
            dtColumn.ColumnName="Salary";
            dtColumn.AutoIncrement=false;
            dtColumn.Caption="Salary";
            dtColumn.ReadOnly=false;
            dtColumn.Unique=false;
            EmployeesDataTable.Columns.Add(dtColumn);

            dtColumn=new DataColumn();
            dtColumn.DataType=typeof(DateTime);
            dtColumn.ColumnName="Date";
            dtColumn.AutoIncrement=false;
            dtColumn.Caption="Date";
            dtColumn.ReadOnly=false;
            dtColumn.Unique=false;
            EmployeesDataTable.Columns.Add(dtColumn);

            DataColumn[] PrimaryKeyColumn = new DataColumn[1];
            PrimaryKeyColumn[0]= EmployeesDataTable.Columns["ID"];
            EmployeesDataTable.PrimaryKey= PrimaryKeyColumn;


            EmployeesDataTable.Rows.Add(null, "Ahmed Mohammed", "Egypt", 10000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Ali Maher", "KSA", 14000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Mohammed Abu-Hadhoud", "Jordan", 15000, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Lina Jameel", "Egypt", 45365.546, DateTime.Now);
            EmployeesDataTable.Rows.Add(null, "Omar Mohammed", "Lebanon", 5456.40, DateTime.Now);


            foreach (DataRow Row in EmployeesDataTable.Rows)
            {
                Console.WriteLine("ID: {0}\tName: {1}\tCountry: {2}\tSalary:{3}\tDate:{4}", Row["ID"],
                    Row["Name"], Row["Country"], Row["Salary"], Row["Date"]);
            }


            Console.ReadKey();
        }
    }
}
