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
        List<string> equipmentAvailable = new List<String>();
        List<string> medsAvailable = new List<string>();


        public BookRoom()
        {
            InitializeComponent();
            PopulateAvailableEquipment();
            PopulateAvailableMeds();
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
        private void PopulateBookingPatient()
        {

            Hem.conn.Open();
            string sql = "select id, name from patients;";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                patientsAvailable.Add(rdr.GetString(0) + ", " + rdr.GetString(1));
            }
            rdr.Close();
            Hem.conn.Close();
            bookingPatient.ItemsSource = patientsAvailable;

        }
        private void PopulateBookingDoctor()
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
        private void PopulateAvailableEquipment()
        {
            Hem.conn.Open();
            string sql = "select * from equipment;";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                try
                {
                    equipmentAvailable.Add(rdr.GetString(0) + ", (" + rdr.GetString(1) + ")");
                }
                catch (Exception) { }
            }
            rdr.Close();
            Hem.conn.Close();
            for (int i = 0; i < equipmentAvailable.Count; i++)
            {
                bookingEquipment.Children.Add(new CheckBox
                {
                    Name = equipmentAvailable[i].Substring(0, 4),
                    Content = equipmentAvailable[i]
                }
                );
            }

        }
        private void PopulateAvailableMeds()
        {
            Hem.conn.Open();
            string sql = "select * from medication;";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                try
                {


                    medsAvailable.Add(rdr.GetString(0) + ", (" + rdr.GetString(2) + ")");
                }
                catch (Exception)
                { }
            }
            rdr.Close();
            Hem.conn.Close();
            for (int i = 0; i < medsAvailable.Count; i++)
            {
                bookingMeds.Children.Add(new CheckBox
                {
                    Name = medsAvailable[i].Substring(0, 4),
                    Content = medsAvailable[i],
                }
                ); ;
            }

        }
        private void availableRooms_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulateAvailableRooms();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ///1

            pageInfo.Text = pageInfo.Text + bookingPatient.Text.Substring(0, 13) + ", ";
            pageInfo.Text = pageInfo.Text + (availableRooms.SelectedItem.ToString()) + ", ";
            pageInfo.Text = pageInfo.Text + bookingDate.SelectedDate.ToString().Substring(0, 10) + " "+ bookingTime.Text.ToString() + ", ";
            //pageInfo.Text = pageInfo.Text + doctorId.ToString() + ", ";


            foreach (CheckBox item in bookingMeds.Children)
            {
                if (item.IsChecked == true)
                {
                   ///2
                }
            }
            foreach (CheckBox item in bookingEquipment.Children)
            {
                if (item.IsChecked == true)
                {
                    ///3
                    pageInfo.Text = pageInfo.Text + item.Name + ", ";

                }
            }



        }

        private void bookingTime_GotFocus(object sender, RoutedEventArgs e)
        {
            bookingTime.Text = string.Empty;
        }

        private void bookingPatient_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulateBookingPatient();
        }

        private void bookingDoctor_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulateBookingDoctor();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Initialized(object sender, EventArgs e)
        {

        }
    }
}
