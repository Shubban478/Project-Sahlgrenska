using MySql.Data.MySqlClient;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Hem : Window
    {
        public static string connStr =
            "server=bjjyx4krtcspjgah0tay-mysql.services.clever-cloud.com;" +
            "user=ulhpxhgnf5tkywq2;" +
            "database=bjjyx4krtcspjgah0tay;" +
            "port=3306;" +
            "password=CE2AriOp5v9YqliNasMM";
        public static MySqlConnection conn = new MySqlConnection(connStr);

        public Hem()
        {
            InitializeComponent();
        }

        private void logOutButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void newPatient_Click(object sender, RoutedEventArgs e)
        {
            NewPatient newPatient = new NewPatient();
            newPatient.Show();
        }

        private void searchPatient_Click(object sender, RoutedEventArgs e)
        {
            SearchPatient searchPatient = new SearchPatient();
            searchPatient.Show();
        }

        private void bookRoom_Click(object sender, RoutedEventArgs e)
        {
            BookRoom bookRoom = new BookRoom();
            bookRoom.Show();
        }

        private void bookingSchedule_Click(object sender, RoutedEventArgs e)
        {
            BookingSchedule bookingSchedule = new BookingSchedule();
            bookingSchedule.Show();
        }

        private void orderItems_Click(object sender, RoutedEventArgs e)
        {
            OrderItems orderItems = new OrderItems();
            orderItems.Show();
        }

        private void diseaseList_Click(object sender, RoutedEventArgs e)
        {
            DiseaseList diseaseList = new DiseaseList();
            diseaseList.Show();
        }
    }
}
