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
            Hem.conn.Open();
            string command = Command;
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(command, Hem.conn);
            _ = cmd.ExecuteNonQuery();
            Hem.conn.Close();
        }
        public static string ReadOne(string Command)
        {
            Hem.conn.Open();
            string command = Command;
            MySqlCommand cmd = new MySqlCommand(command, Hem.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            string result = rdr[0].ToString();
            rdr.Close();
            Hem.conn.Close();
            return result;


        }


        /* 
            Bot.Read(patients where id like 19%;)    -select
            Bot.Update(medication, set quantity -1 where name = Kåvepenin)
            Bot.????????????
        
        */

    }
    

}
