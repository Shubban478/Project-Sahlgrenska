using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_Sahlgrenska
{
    public static class Bot
    {
        public static void Update(string Command)
        {
            string command = Command;
            Hem.conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(command, Hem.conn);
            _ = cmd.ExecuteNonQuery();
            Hem.conn.Close();

        }
        public static string ReadOneValue(string Command)
        {
            string command = Command;

            Hem.conn.Open();
            MySqlCommand cmd = new MySqlCommand(command, Hem.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string result = rdr.GetString(0);
            rdr.Close();
            Hem.conn.Close();
            return result;
        }

        public static List<string> ReadOneLine(string Command)
        {
            
            List<string> result = new List<string>();
            string command = Command;
            Hem.conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(command, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read() == true)
            {            
                for (int i = 0; i < rdr.FieldCount; i++)
                {
                    result.Add(rdr[i].ToString());
                }
            }
            else
            {
                result.Add("INGEN PATIENT");
            }

            rdr.Close();
            Hem.conn.Close();
            return result;
        }

        public static List<string> ReadOneColumn(string Command)
        {
            List<string> result = new List<string>();
            string command = Command;
            Hem.conn.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(command, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                result.Add(rdr.GetString(0));
            }
            rdr.Close();
            Hem.conn.Close();
            return result;
        }
    }
}
