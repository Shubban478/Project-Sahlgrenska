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
            string patientDate = DateTime.Now.ToString();
            string criticalValue = "no";
            if (critical.IsChecked == true)
            {
                criticalValue = "yes";
            }
            try
            {
                Patient patient = new Patient(patientId.Text, patientName.Text, patientAdress.Text, patientGender.Text, patientDate, criticalValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
