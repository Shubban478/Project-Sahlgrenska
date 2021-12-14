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
            if (patientLogin.IsChecked == true)
            {
                BookingSchedule patientSchedule = new BookingSchedule(loginName.Text);
                patientSchedule.Show();
            }
            if (loginName.Text == "admin")
            {
                Admin admin = new Admin();
                this.Close();
                admin.Show();
            }
            else
            {
                if (patientLogin.IsChecked == false)
                {
                    Hem.user = "Tom Johansson";
                    Hem.doctorId = Int32.Parse(Bot.ReadOneValue("select id from doctors where name ='" + Hem.user + "';"));
                    Hem hem = new Hem();
                    this.Close();
                    hem.Show();
                }
            }
            /*
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
            
            if (password == auth && password != string.Empty)
            {
                Hem.user = username;
                Hem hem = new Hem();
                this.Close();
                hem.Show();
            }
            else
            {
                errormessage.Text = "Användare ej hittad";
            }
            */
            
            
            
        }


        private void patientLogin_Checked(object sender, RoutedEventArgs e)
        {
            nameLabel.Text = "ID";
            loginName.Text = "ÅÅÅÅMMDD-XXXX";
            button1.Content = "Visa möten";
            passwordLabel.Visibility = Visibility.Hidden;
            loginPassword.Visibility = Visibility.Hidden;
        }

        private void patientLogin_Unchecked(object sender, RoutedEventArgs e)
        {
            nameLabel.Text = "Namn";
            loginName.Text = string.Empty;
            passwordLabel.Visibility = Visibility.Visible;
            loginPassword.Visibility = Visibility.Visible;
            button1.Content = "Logga in";

        }

        private void loginName_GotFocus(object sender, RoutedEventArgs e)
        {
            loginName.Text = string.Empty;
        }
    }
}
