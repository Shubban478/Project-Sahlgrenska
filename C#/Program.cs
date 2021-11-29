using System;
using MySql.Data.MySqlClient;

namespace MySQL_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = "server=localhost;user=root;database=facebookMessengerBot" +
                ";port=3306;password=Mysql4ever?";

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
                //string sql =  "use facebookMessengerBot; select * from Locations;";
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
