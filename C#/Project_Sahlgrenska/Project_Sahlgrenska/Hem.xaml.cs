using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Hem : Window
    {
        /*  
         *  ----- testconsole. kan användas som vanlig console application.
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        */

        public static string connStr =
            "server=bt0mlsay6vs1xbceqzzn-mysql.services.clever-cloud.com;" +
            "user=ulhpxhgnf5tkywq2;" +
            "database=bt0mlsay6vs1xbceqzzn;" +
            "port=21191;" +
            "password=CE2AriOp5v9YqliNasMM";
        public static MySqlConnection conn = new MySqlConnection(connStr);
        public static string user = "";
        public static int doctorId;
        List<string> criticalPatients = new List<string>();



        public Hem()
        {
            InitializeComponent();
            pageInfo.Text += " " + user;
            PopulateCriticalPatients();


        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }

        private void NewPatient_Click(object sender, RoutedEventArgs e)
        {
            NewPatient newPatient = new NewPatient();
            newPatient.Show();
        }

        private void SearchPatient_Click(object sender, RoutedEventArgs e)
        {
            SearchPatient searchPatient = new SearchPatient();
            searchPatient.Show();
        }

        private void BookAppointment_Click(object sender, RoutedEventArgs e)
        {
            BookAppointment bookAppointment = new BookAppointment();
            bookAppointment.Show();
        }

        private void BookingSchedule_Click(object sender, RoutedEventArgs e)
        {
            BookingSchedule bookingSchedule = new BookingSchedule();
            bookingSchedule.Show();
        }

        private void OrderItems_Click(object sender, RoutedEventArgs e)
        {
            OrderItems orderItems = new OrderItems();
            orderItems.Show();
        }

        private void DiseaseList_Click(object sender, RoutedEventArgs e)
        {
            DiseaseList diseaseList = new DiseaseList();
            diseaseList.Show();
        }
        private void AppointCritical_Click(object sender, RoutedEventArgs e)
        {
            BookAppointment criticalAppointment = new BookAppointment();

            try
            {
                foreach (RadioButton item in critical.Children)
                {

                    try
                    {
                        if (item.IsChecked == true)
                        {
                            string patientId = Bot.ReadOneValue("select id from patients where name ='" + item.Content + "';");
                            criticalAppointment.bookingPatient.Text = patientId;

                        }
                    }
                    catch (Exception)
                    { continue; }

                }
            }
            catch (Exception)
            { }
            criticalAppointment.availableRooms.SelectedItem = criticalAppointment.availableRooms.Items[0];
            criticalAppointment.bookingReason.Text = "AKUT: ";
            criticalAppointment.bookingTime.Text = DateTime.UtcNow.ToString().Split(' ')[1];
            criticalAppointment.Show();
        }

        private void Window_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void PopulateCriticalPatients()
        {

            criticalPatients = Bot.ReadOneColumn("select name from patients where critical ='Yes';");
            for (int i = 0; i < criticalPatients.Count; i++)
            {

                critical.Children.Add(new RadioButton
                {
                    Name = criticalPatients[i].Split(' ')[0],
                    Content = criticalPatients[i]
                });


            }
            if (criticalPatients.Count > 0)
            {
                appointCritical.Visibility = Visibility.Visible;
                alert.Visibility = Visibility.Visible;

            }

        }
        private void ExtinctCriticalPatients()
        {
            critical.Children.Clear();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Activated(object sender, EventArgs e)
        {
            PopulateCriticalPatients();
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            ExtinctCriticalPatients();
        }

        private void CriticalFinished_Click(object sender, RoutedEventArgs e)
        {
            string donePatientId = "";
            foreach (RadioButton item in critical.Children)
            {

                try
                {
                    if (item.IsChecked == true)
                    {
                        donePatientId = Bot.ReadOneValue("select id from patients where name ='" + item.Content + "';");

                    }
                }
                catch (Exception)
                { continue; }

            }
            Bot.Update("update patients set critical = 'No' where id = '" + donePatientId + "';");
            ExtinctCriticalPatients();
            PopulateCriticalPatients();
        }

        private void Critical_GotFocus(object sender, RoutedEventArgs e)
        {
            criticalFinished.Visibility = Visibility.Visible;
            updateInfo.Visibility = Visibility.Visible;
            appointmentInfo.Visibility = Visibility.Visible;
        }

        private void UpdateInfo_Click(object sender, RoutedEventArgs e)
        {
            string patientId = "";
            foreach (RadioButton item in critical.Children)
            {

                try
                {
                    if (item.IsChecked == true)
                    {
                        patientId = Bot.ReadOneValue("select id from patients where name ='" + item.Content + "';");

                    }
                }
                catch (Exception)
                { continue; }

            }
            Bot.ReadAll("select * from appointments_overview where personnummer ='" + patientId + "';", appointmentInfo);
        }
    }
}
