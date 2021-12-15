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
    /// Interaction logic for SearchPatient.xaml
    /// </summary>
    public partial class SearchPatient : Window
    {
        List<string> patientsAvailable = new List<String>();
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
            List<string> list = new List<string>();

            list = Bot.ReadOneLine("select * from patients_all where ID LIKE '" + searchPatient.Text[..13] + "';");

            patientId.Text = list[0];
            if (list[0] != "INGEN PATIENT")
            {
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
                //patientDiagnosis.Text = list[8] +   "\r\n" + "Kommentar:\r\n" + list[9] +
                //                                    "\r\n" + "Symptom:\r\n" + list[10] + "\r\n" + "Behandling:\r\n" + list[11];
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

        }

        private void Button_UpdateJournal(object sender, RoutedEventArgs e)
        {
            try
            {
                Journal patient = new Journal(patientId.Text);
            }
            catch (Exception ex)
            {

                journalAdded.Text = "\nDu måste skriva in något:\n" +
                    "------------\n" +
                    "Error:\n" +
                    ex.Message;
                Hem.conn.Close();

            }
        }
        class Journal
        {
            string patientId;

            public Journal(string journalInput)
            {
                Bot.Update("UPDATE bt0mlsay6vs1xbceqzzn.patients SET History = CONCAT(NOW(), ' " + journalInput + "', COALESCE(CONCAT(CHAR(10), History), '')) WHERE ID = '" + patientId + "';");
                MessageBox.Show(journalInput + "\n added to database.");
            }
        }
    }
}
