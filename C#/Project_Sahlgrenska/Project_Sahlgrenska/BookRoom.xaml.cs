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
        public BookRoom()
        {
            InitializeComponent();
        }
        private void PopulateComboBox()
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
        private void availableRooms_GotFocus(object sender, RoutedEventArgs e)
        {
            PopulateComboBox();
        }
        private void patientId_GotFocus(object sender, RoutedEventArgs e)
        {
            patientId.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bookingTime_GotFocus(object sender, RoutedEventArgs e)
        {
            bookingTime.Text = string.Empty;
        }
    }
}
