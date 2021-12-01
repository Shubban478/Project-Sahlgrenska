using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        string username = "";
        string password = "";
        string auth = "";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            username = loginName.Text;
            password = loginPassword.Password;

            Hem.conn.Open();
            string sql = "select password from doctors where name = '" + username + "';";
            MySqlCommand cmd = new MySqlCommand(sql, Hem.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            try
            {
                auth = rdr[0].ToString();
            }
            catch (Exception)
            {
                errormessage.Text = "Användare ej hittad";
            }
            rdr.Close();
            Hem.conn.Close();
            if (password == auth)
            {
                Hem hem = new Hem();
                this.Close();
                hem.Show();
            }
            else
            {
                errormessage.Text = "Användare ej hittad";
            }

        }
    }
}
