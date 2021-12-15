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



        public BookAppointment()
        {
            InitializeComponent();
            PopulateBookingPatient();
            PopulateBookingDoctor();
            PopulateAvailableEquipment();
            PopulateAvailableMeds();
            PopulateAvailableRooms();
            bookingDate.Text = DateTime.UtcNow.ToString();

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
        private void PopulateBookingDoctor()
        {

            for (int i = 0; i < Bot.ReadOneColumn("select name from doctors;").Count; i++)
            {
                doctorsAvailable.Add(Bot.ReadOneColumn("select name from doctors;")[i]);
                doctorsAvailable[i] += " " + Bot.ReadOneColumn("select speciality from doctors;")[i];
            }
            bookingDoctor.ItemsSource = doctorsAvailable;

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
                int appointmentId = Int32.Parse(Bot.ReadOneColumn("select max(id) from appointments;")[0]) + 1;
                string patientId = bookingPatient.Text[..13];
                string initDoctorId = Bot.ReadOneValue("select id from doctors where name like '" + bookingDoctor.Text.Split(' ')[0] + "%';");
                int doctorId = Int32.Parse(initDoctorId);
                string reason = bookingReason.Text.ToString();
                string time = bookingDate.SelectedDate.ToString()[..10] + " " + bookingTime.Text.ToString();
                int roomId = Convert.ToInt32(availableRooms.SelectedItem.ToString());
                Appointment appointment = new Appointment(appointmentId, patientId, doctorId, reason, time, roomId);
                EqAndMeds(appointmentId);
                PopulateAvailableRooms();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.Message);
            }
            
        }

        private void bookingTime_GotFocus(object sender, RoutedEventArgs e)
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
