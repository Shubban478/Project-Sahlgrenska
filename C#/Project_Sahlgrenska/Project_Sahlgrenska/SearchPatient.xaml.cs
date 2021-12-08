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
            list = Bot.ReadOneLine("select * from bjjyx4krtcspjgah0tay.patients where ID LIKE '" + searchPatient.Text + "';");

            patientId.Text = list[0];
            patientName.Text = list[1];
            patientAdress.Text = list[2];
            patientGender.Text = list[3];
            patientAdmitted.Text = list[4];
            patientDischarged.Text = list[5];
            patientReason.Text = list[6];
        }

    }
}
