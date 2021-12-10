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
        public SearchPatient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<string> list = new List<string>();
            list = Bot.ReadOneLine("select * from patients_all where ID LIKE '" + searchPatient.Text + "';");

            patientId.Text = list[0];
            if (list[0] != "INGEN PATIENT")
            {
                patientName.Text = list[1];
                patientAdress.Text = list[2];
                patientGender.Text = list[3];
                patientAdmitted.Text = list[4];
                patientDischarged.Text = list[5];
                patientHistory.Text = list[6];
                patientDiagnosis.Text = list[8] +   "\r\n" + "Kommentar:\r\n" + list[9] +
                                                    "\r\n" + "Symptom:\r\n" + list[10] + "\r\n" + "Behandling:\r\n" + list[11];
            }
            else
            {
                patientName.Text = "INGEN PATIENT";
                patientAdress.Text = "INGEN PATIENT";
                patientGender.Text = "INGEN PATIENT";
                patientAdmitted.Text = "INGEN PATIENT";
                patientDischarged.Text = "INGEN PATIENT";
                patientHistory.Text = "INGEN PATIENT";
                patientDiagnosis.Text = "INGEN PATIENT";
            }
            
        }
    }
}
