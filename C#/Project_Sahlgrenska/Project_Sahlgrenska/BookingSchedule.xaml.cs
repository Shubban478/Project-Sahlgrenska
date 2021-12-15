using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            PopulateAppointments();

            calendar.SelectedDate = DateTime.UtcNow;



        }
        public BookingSchedule(string PatientId)
        {
            InitializeComponent();
            calendar.Visibility = Visibility.Hidden;
            allDoctors.Visibility = Visibility.Hidden;
            string patientId = PatientId;
            Bot.ReadAll("SELECT * FROM appointments_overview where Personnummer = '" + patientId + "';", appointmentsTable);
        }

        private void PopulateAppointments()
        {
            string tid = calendar.SelectedDate.ToString().Substring(0);
            if (allDoctors.IsChecked == true)
            {
                Bot.ReadAll("SELECT * FROM appointments_overview where tid like '" + tid + "%';", appointmentsTable);
            }
            else
            {
                Bot.ReadAll("SELECT * FROM appointments_overview where doktor = '" + Hem.doctorId + "%';", appointmentsTable);
            }
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            PopulateAppointments();
        }

    }
}