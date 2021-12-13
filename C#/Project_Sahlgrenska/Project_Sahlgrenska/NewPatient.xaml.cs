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
        string PatientId;
        string PatientName;
        string PatientAdress;
        string PatientGender;

        string PatientDate;
        


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

                /*
                if (patientId.Text != "xxxxxxxx-xxxx" || patientId.Text.Length != 13 || patientGender.Text.Length != 1)
                {
                    if (patientName.Text != string.Empty &&
                        patientAdress.Text != string.Empty &&
                        patientGender.Text != string.Empty)
                    {
                        if (patientGender.Text == "M" || patientGender.Text == "F")
                        {
                            PatientId = patientId.Text;
                            PatientName = patientName.Text;
                            PatientAdress = patientAdress.Text;
                            PatientGender = patientGender.Text;
                            PatientDate = patientDate.Text;


                            Bot.Update("INSERT INTO patients(ID,Name,Address,Gender,Admitted) VALUES('" + PatientId + "','" + PatientName + "','" + PatientAdress + "','" + PatientGender + "','" + PatientDate.Substring(0,10) + "')");
                            if (critical.IsChecked==true)
                            {
                                Bot.Update("update patients set critical = 'Yes' where id = '" + PatientId + "';");
                            }
                            patientAdded.Text = PatientName + " added to database.";
                            patientId.Text = string.Empty;
                            patientName.Text = string.Empty;
                            patientAdress.Text = string.Empty;
                            patientGender.Text = string.Empty;
                            patientDate.SelectedDate = null;

                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
                */
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
