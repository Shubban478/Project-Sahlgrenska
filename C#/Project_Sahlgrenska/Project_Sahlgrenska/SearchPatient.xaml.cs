using System;
using System.Collections.Generic;
using System.Windows;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for SearchPatient.xaml
    /// </summary>
    public partial class SearchPatient : Window
    {
        List<string> patientsAvailable = new List<String>();
        string oldName;
        string oldAdress;
        public SearchPatient()
        {
            InitializeComponent();
            PopulatePatients();
        }

        private void PopulatePatients()
        {
            for (int i = 0; i < Bot.ReadOneColumn("select id from patients;").Count; i++)
            {
                patientsAvailable.Add(Bot.ReadOneColumn("select id from patients;")[i]);
                patientsAvailable[i] += " " + Bot.ReadOneColumn("select name from patients;")[i];
            }
            searchPatient.ItemsSource = patientsAvailable;
        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            UpdateSearch();
        }

        private void patientHistory_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {

        }

        private void Button_Booking(object sender, RoutedEventArgs e)
        {
            BookingSchedule patientSchedule = new BookingSchedule(searchPatient.Text[..13]);
            patientSchedule.Show();
        }

        private void Button_UpdatePatient(object sender, RoutedEventArgs e)
        {
            if (oldName != patientName.Text || oldAdress != patientAdress.Text)
            {
                if (oldName != patientName.Text)
                {
                    Bot.Update("UPDATE bt0mlsay6vs1xbceqzzn.patients SET History = CONCAT(NOW(), ' -- " + oldName + " ++ " + patientName.Text + " \n\', COALESCE(CONCAT(CHAR(10), History), '')), Name = '" + patientName.Text + "' WHERE ID = '" + patientId.Text + "';");
                }

                if (oldAdress != patientAdress.Text)
                {
                    Bot.Update("UPDATE bt0mlsay6vs1xbceqzzn.patients SET History = CONCAT(NOW(), ' -- " + oldAdress + " ++ " + patientAdress.Text + " \n\', COALESCE(CONCAT(CHAR(10), History), '')), Address = '" + patientAdress.Text + "' WHERE ID = '" + patientId.Text + "';");
                }
                
            }
            UpdateSearch();
        }
        private void Button_UpdateJournal(object sender, RoutedEventArgs e)
        {
            Bot.Update("UPDATE bt0mlsay6vs1xbceqzzn.patients SET History = CONCAT(NOW(), ' ++ " + updateJournal.Text + " \n\', COALESCE(CONCAT(CHAR(10), History), '')) WHERE ID = '" + patientId.Text + "';");            
            UpdateSearch();
        }
        private void UpdateSearch()
        {
            List<string> list = new List<string>();

            list = Bot.ReadOneLine("select * from patients_all where ID LIKE '" + searchPatient.Text[..13] + "';");

            patientId.Text = list[0];
            if (list[0] != "INGEN PATIENT")
            {
                oldName = Convert.ToString(list[1]);
                oldAdress = Convert.ToString(list[2]);

                patientName.Text = list[1];
                patientAdress.Text = list[2];
                patientGender.Text = list[3];
                patientAdmitted.Text = list[4];
                patientSymptoms.Text = list[9];
                patientTretment.Text = list[10];
                patientMedication.Text = list[15];
                patientRoom.Text = list[11];
                patientEquipment.Text = list[17];
                patientHistory.Text = list[6];
            }
            else
            {
                patientName.Text = "INGEN PATIENT";
                patientAdress.Text = "INGEN PATIENT";
                patientGender.Text = "INGEN PATIENT";
                patientAdmitted.Text = "INGEN PATIENT";
                patientMedication.Text = "INGEN PATIENT";
                patientRoom.Text = "INGEN PATIENT";
                patientEquipment.Text = "INGEN PATIENT";
                patientHistory.Text = "INGEN PATIENT";
            }
        }

        private void Button_SentHome(object sender, RoutedEventArgs e)
        {
            Bot.Update("UPDATE bt0mlsay6vs1xbceqzzn.patients SET History = CONCAT(NOW(), ' ++ Patienten utskriven \n\', COALESCE(CONCAT(CHAR(10), History), '')), SentHome = NOW() WHERE ID = '" + patientId.Text + "';");
            UpdateSearch();
        }

        private void updateJournal_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
