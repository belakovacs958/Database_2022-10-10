using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace MySQLConnectionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //your MySQL connection string
            string connStr = "server=192.168.5.114;user=root;database=Company2;password=password";

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                Console.WriteLine("selcect a stored procedure.");


                //SQL Query to execute
                //selecting only first 10 rows for demo
                string sql = "usp_CreateDepartment";      //"select * from Department.DName limit 0,10;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("DNameParam", "frontend"));
                cmd.Parameters.Add(new MySqlParameter("MgrSSNParam", 333445555));
                var resault = cmd.ExecuteNonQuery();


                MySqlDataReader rdr = cmd.ExecuteReader();

                //read the data
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1] + " -- " + rdr[2]);
                }
                rdr.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.ToString());
            }

            conn.Close();
            Console.WriteLine("Connection Closed. Press any key to exit...");
            Console.Read();
        }
    }
}