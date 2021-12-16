using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for BookRoom.xaml
    /// </summary>
    public partial class BookAppointment : Window
    {
        List<string> roomsAvailable = new List<string>();
        List<string> patientsAvailable = new List<String>();
        List<string> doctorsAvailable = new List<String>();
        List<string> equipmentAvailable = new List<String>();
        List<string> medsAvailable = new List<string>();
        List<string> AppointmentsTime = new List<string>();
        List<DateTime> AppointmentsDate = new List<DateTime>();
        string time;
        int appointmentId;
        string patientId;
        string initDoctorId;
        int doctorId;
        string reason;
        int roomId;

        public BookAppointment()
        {
            InitializeComponent();
            PopulateBookingPatient();
            PopulateAvailableEquipment();
            PopulateAvailableMeds();
            PopulateAvailableRooms();
            bookingTime.Text = DateTime.Now.ToString().Split(' ')[1];

        }
        public void PopulateAvailableRooms()
        {
            roomsAvailable = Bot.ReadOneColumn("select id from rooms where vaccant = 'yes'; ");
            availableRooms.ItemsSource = roomsAvailable;

        }
        private void PopulateBookingPatient()
        {
            for (int i = 0; i < Bot.ReadOneColumn("select id from patients;").Count; i++)
            {
                patientsAvailable.Add(Bot.ReadOneColumn("select id from patients;")[i]);
                patientsAvailable[i] += " " + Bot.ReadOneColumn("select name from patients;")[i];
            }
            bookingPatient.ItemsSource = patientsAvailable;
        }
        private void PopulateAvailableEquipment()
        {
            for (int i = 0; i < Bot.ReadOneColumn("select name from equipment;").Count; i++)
            {
                equipmentAvailable.Add(Bot.ReadOneColumn("select name from equipment;")[i]);
                equipmentAvailable[i] += " -Lediga:" + Bot.ReadOneColumn("select quantity from equipment;")[i];
            }
            for (int i = 0; i < equipmentAvailable.Count; i++)
            {
                bookingEquipment.Children.Add(new CheckBox
                {
                    Name = equipmentAvailable[i].Split(' ')[0],
                    Content = equipmentAvailable[i]
                });
            }
        }
        private void PopulateAvailableMeds()
        {
            for (int i = 0; i < Bot.ReadOneColumn("select name from medication;").Count; i++)
            {
                medsAvailable.Add(Bot.ReadOneColumn("select name from medication;")[i]);
                medsAvailable[i] += " -Lagersaldo:" + Bot.ReadOneColumn("select quantity from medication;")[i];
            }
            for (int i = 0; i < medsAvailable.Count; i++)
            {
                bookingMeds.Children.Add(new CheckBox
                {
                    Name = medsAvailable[i].Split(' ')[0],
                    Content = medsAvailable[i]
                });
            }
        }



        public void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                appointmentId = Int32.Parse(Bot.ReadOneColumn("select max(id) from appointments;")[0]) + 1;
                patientId = bookingPatient.Text[..13];
                initDoctorId = Bot.ReadOneValue("select id from doctors where name like '" + Hem.user + "%';");
                doctorId = Int32.Parse(initDoctorId);
                reason = bookingReason.Text.ToString();
                time = bookingDate.SelectedDate.ToString()[..10] + " " + bookingTime.Text.ToString();
                try
                {
                    roomId = Convert.ToInt32(availableRooms.SelectedItem.ToString());
                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                }
                AppointmentsTime = Bot.ReadOneColumn("select tid from appointments_overview where doktor =" + doctorId + ";");
                CheckIfDoctorAvailable();
                Appointment appointment = new Appointment(appointmentId, patientId, doctorId, reason, time, roomId);
                EqAndMeds(appointmentId);
                PopulateAvailableRooms();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }

        }

        private void CheckIfDoctorAvailable()
        {

            AppointmentsTime = Bot.ReadOneColumn("select tid from appointments_overview where doktor =" + doctorId + ";");
            DateTime Time = Convert.ToDateTime(time);
            foreach (var item in AppointmentsTime)
            {
                AppointmentsDate.Add(Convert.ToDateTime(item));
            }

            foreach (DateTime item in AppointmentsDate)
            {
                TimeSpan end = item.AddMinutes(59).TimeOfDay;
                TimeSpan thisBooking = Time.TimeOfDay;

                if (thisBooking > end)
                {
                    Appointment appointment = new Appointment(appointmentId, patientId, doctorId, reason, time, roomId);
                    EqAndMeds(appointmentId);
                    PopulateAvailableRooms();
                    break;
                }
                else
                {
                    MessageBox.Show("Doktor upptagen vid tillfälle");
                }
            }
        }

        private void BookingTime_GotFocus(object sender, RoutedEventArgs e)
        {
            bookingTime.Text = string.Empty;
        }

        private void EqAndMeds(int appointmentId)
        {
            foreach (CheckBox item in bookingMeds.Children)
            {

                if (item.IsChecked == true)
                {
                    int quantity = Int32.Parse(Bot.ReadOneValue("select quantity from medication where name ='" + item.Name + "';"));
                    if (quantity == 0)
                    {
                        MessageBox.Show(item.Name + " är slut.");
                    }
                    else
                    {
                        Bot.Update("update medication set Quantity = Quantity - 1 where Name like '" + item.Name + "%';");
                        Bot.Update("insert into appointments_has_medication values(" + appointmentId + ",'" + item.Name + "');");
                    }

                }
            }
            foreach (CheckBox item in bookingEquipment.Children)
            {
                if (item.IsChecked == true)
                {
                    int quantity = Int32.Parse(Bot.ReadOneValue("select quantity from equipment where name ='" + item.Name + "';"));
                    if (quantity == 0)
                    {
                        MessageBox.Show(item.Name + " är upptagen.");
                    }
                    else
                    {
                        Bot.Update("update equipment set Quantity = Quantity - 1 where Name like '" + item.Name + "%';");
                        Bot.Update("insert into appointments_has_equipment values(" + appointmentId + ",'" + item.Name + "');");
                    }

                }

            }
        }
    }
}
