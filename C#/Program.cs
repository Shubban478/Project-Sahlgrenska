using System;
using MySql.Data.MySqlClient;

namespace MySQL_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=SERVER;user=root;database=DATABASE" +
                ";port=3306;password=PASS";

            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();

                //Lägger till "black" under id "5" i min databas
                string sql = "INSERT INTO Politics VALUES ('5', 'black')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                ////Läser in data från min databas
                //string sql =  "use DATABASE; select * from TABLE;";
                //MySqlCommand cmd = new MySqlCommand(sql, conn);
                //MySqlDataReader rdr = cmd.ExecuteReader();

                ////read the data
                //while (rdr.Read())
                //{
                //    Console.WriteLine(rdr[0] + " " + rdr[1] + " " + rdr[2] + " " + rdr[3]);
                //}
                //rdr.Close();
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
