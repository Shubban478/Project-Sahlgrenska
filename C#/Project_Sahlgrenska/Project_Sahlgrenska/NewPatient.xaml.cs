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
        public NewPatient()
        {
            InitializeComponent();
            patientDate.Text = DateTime.UtcNow.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                Patient patient = new Patient(patientId.Text,patientName.Text, patientAdress.Text, patientGender.Text, patientDate.Text);
            }
            catch (Exception ex)
            {

                patientAdded.Text = "\nKontrollera följande:\n" +
                    "Personnummer 12 siffror med bindestreck. \n" +
                    "Hela namnet.\n" +
                    "Hela adressen.\n" +
                    "Kön anges i 'M' eller 'F.'\n" +
                    "Datum får ej lämnas blank.\n" +
                    "------------\n" +
                    "Error:\n" +
                    ex.Message;
                Hem.conn.Close();

            }





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
