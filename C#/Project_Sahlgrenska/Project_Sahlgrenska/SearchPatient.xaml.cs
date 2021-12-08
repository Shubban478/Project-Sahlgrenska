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
            var PatientData = Bot.ReadOneLine("select * from bjjyx4krtcspjgah0tay.patients where ID LIKE '" + searchPatient.Text + "'");

            patientId.Text = PatientData[0];
            //patientName.Text = PatientData[1];
            //patientAdress.Text = PatientData[2];
            //patientGender.Text = PatientData[3];
            //patientAdmitted.Text = PatientData[4];
            //patientDischarged.Text = PatientData[5];
            patientHistory.Text = PatientData[6];
        }
    }
}
