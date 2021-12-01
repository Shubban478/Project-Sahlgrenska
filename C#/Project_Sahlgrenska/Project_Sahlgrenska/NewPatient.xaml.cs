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
        string PatientId = "";
        string PatientName = "";
        string PatientAdress = "";
        string PatientGender = "";
        string PatientReason = "";
        string PatientDate = "";
        
        
        public NewPatient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientId = patientId.Text;
            PatientName = patientName.Text;
            PatientAdress = patientAdress.Text;
            PatientGender = patientGender.Text;
            PatientDate = patientDate.Text;
            PatientReason = patientReason.Text;
            Hem.conn.Open();
            string sql = "INSERT INTO patients(ID,Name,Address,Gender,Admitted,Reason) VALUES('" + PatientId + "','" + PatientName + "','" + PatientAdress + "','" + PatientGender + "','" + PatientDate + "','"+ PatientReason + "')";
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
