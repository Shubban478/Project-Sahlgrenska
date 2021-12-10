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
    /// Interaction logic for BookingSchedule.xaml
    /// </summary>
    public partial class BookingSchedule : Window
    {
        List<string> appointmentsAvailable = new List<string>();
        public BookingSchedule()
        {
            InitializeComponent();
            
            calendar.SelectedDate = DateTime.UtcNow;



        }

        private void PopulateAppointments()
        {

            Bot.ReadAll("SELECT * FROM appointments_overview where doktor = " + Hem.doctorId + ";", appointmentsTable);
            /*
            Hem.conn.Open();
            string query = "SELECT * FROM appointments_overview where doktor = "+Hem.doctorId+";";
            MySqlCommand cmd = new MySqlCommand(query, Hem.conn);
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("appointments");
            adapter.Fill(dt);
            appointmentsTable.ItemsSource = dt.DefaultView;
            adapter.Update(dt);
            Hem.conn.Close();

            */

        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateAppointments();
        }

    }
}