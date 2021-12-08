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
            PopulateAvailableEquipment();
            PopulateAvailableMeds();
            PopulateAvailableRooms();
            bookingDate.Text = DateTime.UtcNow.ToString();
        }
        private void PopulateAvailableRooms()
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
            int initAppointmentId = Int32.Parse(Bot.ReadOneColumn("select max(id) from appointments;")[0])+1;
            int appointmentId = initAppointmentId;
            string patientId = bookingPatient.Text.Substring(0, 13);
            string initDoctorId = Bot.ReadOneValue("select id from doctors where name like '" + bookingDoctor.Text.Split(' ')[0] + "%';");
            int doctorId = Int32.Parse(initDoctorId);
            string meds = "";
            string eq = "";
            string reason = bookingReason.Text.ToString();
            string time = bookingDate.SelectedDate.ToString().Substring(0, 10) + " " + bookingTime.Text.ToString();
            int roomId = Convert.ToInt32(availableRooms.SelectedItem.ToString());

            Bot.Update("insert into appointments values (" + initAppointmentId + ", '" + time + "', '" + reason + "');");
            Bot.Update("insert into appointments_has_rooms values (" + appointmentId + ", " + roomId + ");");
            Bot.Update("insert into patients_has_appointments values('" + patientId + "', " + appointmentId + ");");
            Bot.Update("insert into doctors_has_appointments values(" + doctorId + ", " + appointmentId + ");");

            foreach (CheckBox item in bookingMeds.Children)
            {

                if (item.IsChecked == true)
                {
                    int quantity = Int32.Parse(Bot.ReadOneValue("select quantity from medication where name ='" + item.Name + "';"));
                    if (quantity == 0)
                    {
                        meds += item.Name + " är slut.";
                    }
                    else
                    {
                        Bot.Update("update medication set Quantity = Quantity - 1 where Name like '" + item.Name + "%';");
                        meds += item.Name;
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
                        eq += item.Name + " är upptagen.";
                    }
                    else
                    {
                        Bot.Update("update equipment set Quantity = Quantity - 1 where Name like '" + item.Name + "%';");
                        eq += item.Name;
                        Bot.Update("insert into appointments_has_equipment values(" + appointmentId + ",'" + item.Name + "');");
                    }

                }
            }
            pageInfo.Text = "Bokning gjord för: " + patientId +
                "\n i rum " + roomId +
                "\n med medicin: " + meds +
                "\n med utrustning: " + eq +
                "\n vid tillfälle: " + time + " med doktor " + doctorId +
                "\n med anledning: " + reason;





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

    }
}
