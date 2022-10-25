using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySQLConnectionExample
{
    class Program
    {
        static void Main(string[] args)
        {

            //callUpdateDepartmentNameStoredProcedure();
            bool runLoop = true;

            while (runLoop == true)
            {
                Console.WriteLine("What would you like to do? Type a number!");
                Console.WriteLine("1 : Create Department");
                Console.WriteLine("2 : Delete Department");
                Console.WriteLine("3 : Get All Departments");
                Console.WriteLine("4 : Get Number Of Employees Of Department");
                Console.WriteLine("5 : Upadte Department Manager");
                Console.WriteLine("6 : Update Department Name");


                var chosenProgram = Int32.Parse(Console.ReadLine()); 
                

                switch (chosenProgram)
                {
                    case 1:
                        callCreateDepartmentStoredProcedure();
                        break;
                    case 2:
                        callDeleteDepartmentStoredProcedure();
                        break;
                    case 3:
                        callGetAllDepartmentsStoredProcedure();
                        break;
                    case 4:
                        callNumberOfEmployeesFromDepartmentStoredProcedure();
                        break;
                    case 5:
                        callUpdateDepartmentManagerStoredProcedure();
                        break;
                    case 6:
                        callUpdateDepartmentNameStoredProcedure();
                        break;
                  
                }

                Console.WriteLine("Press any 'q' key to quit and any other to continue");
              
                if (Console.ReadLine().Equals("q"))
                {
                    runLoop = false;
                } 

            }
            

        }

        static void callCreateDepartmentStoredProcedure()
        {
            //your MySQL connection string
            string connStr = "server=192.168.5.114;user=root;database=Company2;password=password";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("You are creating a department right now");



                Console.WriteLine("Type in the department name: ");
                string departmentName = Console.ReadLine();
                Console.WriteLine("Type in the manager's SSN: ");
                string managerSSN = Console.ReadLine();
                Int32.Parse(managerSSN);



                string procedureName = "usp_CreateDepartment";      
                MySqlCommand cmd = new MySqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("DNameParam", departmentName ));
                cmd.Parameters.Add(new MySqlParameter("MgrSSNParam", managerSSN));



                cmd.ExecuteNonQuery();
               
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            Console.WriteLine("Operation successful");
            conn.Close();
        }

        static void callDeleteDepartmentStoredProcedure()
        {
            //your MySQL connection string
            string connStr = "server=192.168.5.114;user=root;database=Company2;password=password";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("You are deleting a department right now");



                Console.WriteLine("Type in the department DNumber: ");
              
                string departmentNumber = Console.ReadLine();
                Int32.Parse(departmentNumber);



                string procedureName = "usp_DeleteDepartment";
                MySqlCommand cmd = new MySqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("DNumberParam", departmentNumber));
    



                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            Console.WriteLine("Operation successful");

            conn.Close();
        }
        static void callGetAllDepartmentsStoredProcedure()
        {
            //your MySQL connection string
            string connStr = "server=192.168.5.114;user=root;database=Company2;password=password";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("You are getting all departments right now...");



                string procedureName = "usp_GetAllDepartments";
                MySqlCommand cmd = new MySqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;



                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            Console.WriteLine("Operation successful");

            conn.Close();

        }

        //This stored procedure has to be finished

        static void callNumberOfEmployeesFromDepartmentStoredProcedure()
        {
            //your MySQL connection string
            string connStr = "server=192.168.5.114;user=root;database=Company2;password=password";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("You are getting the number of employees in a department right now");



                Console.WriteLine("Type in the department DNumber: ");

                string departmentNumber = Console.ReadLine();
                Int32.Parse(departmentNumber);



                string procedureName = "usp_GetDepartment";
                MySqlCommand cmd = new MySqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("DNumberParam", departmentNumber));



                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0]);
                }
                rdr.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            Console.WriteLine("Operation successful");
            conn.Close();

        }
        static void callUpdateDepartmentManagerStoredProcedure()
        {
            //your MySQL connection string
            string connStr = "server=192.168.5.114;user=root;database=Company2;password=password";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("You are updating the department manager right now");



                Console.WriteLine("Type in the department DNumber: ");
                string DNumber = Console.ReadLine();
                Int32.Parse(DNumber);
                Console.WriteLine("Type in the manager's SSN: ");
                string managerSSN = Console.ReadLine();
                Int32.Parse(managerSSN);



                string procedureName = "usp_UpdateDepartmentManager";
                MySqlCommand cmd = new MySqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("DNumberParam", DNumber));
                cmd.Parameters.Add(new MySqlParameter("MgrSSNParam", managerSSN));



                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            Console.WriteLine("Operation successful");
            conn.Close();

        }
        static void callUpdateDepartmentNameStoredProcedure()
        {
            //your MySQL connection string
            string connStr = "server=192.168.5.114;user=root;database=Company2;password=password";

            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("You are updating the department name right now");

                Console.WriteLine("Type in the DNumber: ");
                string DNumber = Console.ReadLine();
                Int32.Parse(DNumber);

                Console.WriteLine("Type in the department DName: ");
                string DName = Console.ReadLine();
                
                



                string procedureName = "usp_UpdateDepartmentName";
                MySqlCommand cmd = new MySqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("DNumberParam", DNumber));
                cmd.Parameters.Add(new MySqlParameter("DNameParam", DName ));



                cmd.ExecuteNonQuery();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("Error " + ex.Number + " has occurred: " + ex.Message);
            }
            Console.WriteLine("Operation successful");


            conn.Close();
        }
    }
}