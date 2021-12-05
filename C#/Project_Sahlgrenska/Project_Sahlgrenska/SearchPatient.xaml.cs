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

            patientId.Text = "";
            patientGender.Text = "";
            patientName.Text = "";
            patientAdress.Text = "";
            patientAdmitted.Text = "";
            patientDischarged.Text = "";
            patientBooking.Text = "";
            patientReason.Text = "";
            patientHistory.Text = "";

            Hem.conn.Open();
            string sql = "select * from bjjyx4krtcspjgah0tay.patients where id = '" + searchPatient.Text + "'";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, Hem.conn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                patientId.AppendText(rdr.GetString(0));
                patientGender.AppendText(rdr.GetString(3));
                patientName.AppendText(rdr.GetString(1));
                patientAdress.AppendText(rdr.GetString(2));
                patientAdmitted.AppendText(rdr.GetString(4));

                if (rdr.IsDBNull(5)) { patientDischarged.Text = "SAKNAS"; }
                else { patientDischarged.AppendText(rdr.GetString(5)); }

                if (rdr.IsDBNull(8)) { patientBooking.Text = "SAKNAS"; }
                else { patientBooking.AppendText(rdr.GetString(8)); }

                if (rdr.IsDBNull(6)) { patientReason.Text = "SAKNAS"; }
                else { patientReason.AppendText(rdr.GetString(6)); ; }

                if (rdr.IsDBNull(7)) { patientHistory.Text = "SAKNAS"; }
                else { patientHistory.AppendText(rdr.GetString(7)); }
            }
            
            rdr.Close();
            Hem.conn.Close();
        }

    }
}
