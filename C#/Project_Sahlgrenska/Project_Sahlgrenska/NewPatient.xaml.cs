using System;
using System.Windows;

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

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string patientDate = DateTime.UtcNow.ToString();
            try
            {
                Patient patient = new Patient(patientId.Text, patientName.Text, patientAdress.Text, patientGender.Text, patientDate);
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
