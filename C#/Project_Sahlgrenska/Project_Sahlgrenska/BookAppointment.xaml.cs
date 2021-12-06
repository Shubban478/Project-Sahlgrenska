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
                    Name = equipmentAvailable[i].Substring(0, 4),
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
                    Name = medsAvailable[i].Substring(0, 4),
                    Content = medsAvailable[i]
                });
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
            pageInfo.Text = pageInfo.Text + bookingDate.SelectedDate.ToString().Substring(0, 10) + " " + bookingTime.Text.ToString() + ", ";
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
