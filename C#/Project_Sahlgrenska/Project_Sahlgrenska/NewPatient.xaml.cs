using MySql.Data.MySqlClient;
using MySqlConnector;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class NewPatient : Window
    {
        string PatientName = "";
        string PatientAdress = "";
        string PatientGender = "";
        string PatientDate = "";
        
        
        public NewPatient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientName = patientName.Text;
            PatientAdress = patientAdress.Text;
            PatientGender = patientGender.Text;
            PatientDate = patientDate.Text;
            Hem.conn.Open();
            string sql = "INSERT INTO patients(Patient_Name,Patient_Address, Patient_Gender, Patient_Admitted) VALUES('" + PatientName + "','" + PatientAdress + "','" + PatientGender + "','" + PatientDate + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            _ = cmd.ExecuteNonQuery();
            Hem.conn.Close();
        }


        private void patientId_GotFocus(object sender, RoutedEventArgs e)
        {
            patientId.Text = string.Empty;
        }

        private void patientGender_GotFocus(object sender, RoutedEventArgs e)
        {
            patientGender.Text = string.Empty;
        }


    }
}
