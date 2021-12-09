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

            
            for (int i = 0; i < Bot.ReadOneColumn("select appointments_id from doctors_has_appointments where doctors_id =" + Hem.doctorId + ";").Count; i++)
            {
                appointmentsAvailable.Add(Bot.ReadOneColumn("select appointments_id from doctors_has_appointments where doctors_id =" + Hem.doctorId + ";")[i]);
                //appointmentsAvailable[i] +=
            }
            for (int i = 0; i < appointmentsAvailable.Count; i++)
            {
                appointments.Children.Add(new CheckBox
                {
                    
                    Content = appointmentsAvailable[i]
                });
            }

        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            ExtinctAppointments();
            PopulateAppointments();
        }
        private void ExtinctAppointments()
        {
            appointmentsAvailable.Clear();
        }
    }
}
