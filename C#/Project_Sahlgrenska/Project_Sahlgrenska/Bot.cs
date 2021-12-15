using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace Project_Sahlgrenska
{
    public static class Bot
    {
        public static void Update(string Command)
        {
            try
            {
                string command = Command;
                Hem.conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, Hem.conn);
                _ = cmd.ExecuteNonQuery();
                Hem.conn.Close();
            }
            catch (Exception e)
            {
                Hem.conn.Close();
                MessageBox.Show(e.Message);
            }
        }
        public static string ReadOneValue(string Command)
        {
            string result = "";
            try
            {
                string command = Command;
                Hem.conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, Hem.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                result = rdr.GetString(0);
                rdr.Close();
                Hem.conn.Close();
            }
            catch (Exception e)
            {
                Hem.conn.Close();
                MessageBox.Show(e.Message);

            }
            return result;
        }

        public static List<string> ReadOneLine(string Command)
        {
            List<string> result = new List<string>();
            try
            {
                string command = Command;
                Hem.conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, Hem.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

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

            }

            catch (Exception e)
            {
                Hem.conn.Close();
                MessageBox.Show(e.Message);
            }
            return result;
        }

        public static List<string> ReadOneColumn(string Command)
        {

            List<string> result = new List<string>();
            try
            {
                string command = Command;
                Hem.conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, Hem.conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read() == true)
                {
//                    while (rdr.Read())
//                    {
                    result.Add(rdr.GetString(0));
//                    }
                }
                else 
                {
                    result.Add("INGET SYMPTOM ANGIVET");
                }
                rdr.Close();
                Hem.conn.Close();
            }
            catch (Exception e)
            {
                Hem.conn.Close();
                MessageBox.Show(e.Message);

            }

            return result;
        }
        public static DataGrid ReadAll(string Command, DataGrid Name)
        {
            try
            {
                string command = Command;
                Hem.conn.Open();
                MySqlCommand cmd = new MySqlCommand(command, Hem.conn);
                cmd.ExecuteNonQuery();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Name.ItemsSource = dt.DefaultView;
                adapter.Update(dt);
                Hem.conn.Close();
            }
            catch (Exception e)
            {
                Hem.conn.Close();
                MessageBox.Show(e.Message);
            }

            return Name;
        }
    }
}
