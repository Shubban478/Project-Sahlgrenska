using System;
using System.Collections.Generic;
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
    /// Interaction logic for BookRoom.xaml
    /// </summary>
    public partial class BookRoom : Window
    {
        List<string> roomsAvailable = new List<string>();
        List<string> patientsAvailable = new List<String>();
        List<string> doctorsAvailable = new List<String>();
        public BookRoom()
        {
            InitializeComponent();
        }
        private void PopulateAvailableRooms()
        {

            Hem.conn.Open();
            string sql = "select id from rooms where vaccant = 'yes'; ";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                roomsAvailable.Add(rdr.GetString(0));
            }
            rdr.Close();
            Hem.conn.Close();
            availableRooms.ItemsSource = roomsAvailable;

        }
        private void PopulatePatientsAvailable()
        {

            Hem.conn.Open();
            string sql = "select id, name from patients;";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                patientsAvailable.Add(rdr.GetString(0)+", "+rdr.GetString(1));
            }
            rdr.Close();
            Hem.conn.Close();
            bookingPatient.ItemsSource = patientsAvailable;

        }
        private void PopulateDoctorsAvailable()
        {

            Hem.conn.Open();
            string sql = "select name, speciality from doctors;";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                try
                {


                    doctorsAvailable.Add(rdr.GetString(0) + ", " + rdr.GetString(1));
                }
                catch (Exception)
                {

                }
            }
            rdr.Close();
            Hem.conn.Close();
            bookingDoctor.ItemsSource = doctorsAvailable;

        }
        private void availableRooms_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulateAvailableRooms();
        }
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bookingTime_GotFocus(object sender, RoutedEventArgs e)
        {
            bookingTime.Text = string.Empty;
        }

        private void bookingPatient_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulatePatientsAvailable();
        }

        private void bookingDoctor_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulateDoctorsAvailable();
        }
    }
}
