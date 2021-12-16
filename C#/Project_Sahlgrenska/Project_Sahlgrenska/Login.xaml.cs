using MySql.Data.MySqlClient;
using System;
using System.Windows;
using System.Windows.Input;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ActuallyLogin();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }

        }

        private void ActuallyLogin()
        {
            string auth = "";
            if (patientLogin.IsChecked == true)
            {
                BookingSchedule patientSchedule = new BookingSchedule(loginName.Text);
                errormessage.Text = loginName.Text;
                patientSchedule.Show();
            }
            if (loginName.Text == "admin")
            {
                Admin admin = new Admin();
                errormessage.Text = "Admin login successful";
                admin.Show();
            }
            else
            {
                auth = Bot.ReadOneValue("select password from doctors where name ='" + loginName.Text + "';");
                if (auth == loginPassword.Password && auth != string.Empty)
                {
                    Hem.user = loginName.Text;
                    Hem hem = new Hem();
                    this.Close();
                    hem.Show();
                }
                else
                {
                    errormessage.Text = "Användare ej hittad";
                }
            }


            
            
        }

        private void PatientLogin_Checked(object sender, RoutedEventArgs e)
        {
            nameLabel.Text = "ID";
            loginName.Text = "ÅÅÅÅMMDD-XXXX";
            button1.Content = "Visa möten";
            passwordLabel.Visibility = Visibility.Hidden;
            loginPassword.Visibility = Visibility.Hidden;
        }

        private void PatientLogin_Unchecked(object sender, RoutedEventArgs e)
        {
            nameLabel.Text = "Namn";
            loginName.Text = string.Empty;
            passwordLabel.Visibility = Visibility.Visible;
            loginPassword.Visibility = Visibility.Visible;
            button1.Content = "Logga in";

        }

        private void LoginName_GotFocus(object sender, RoutedEventArgs e)
        {
            loginName.Text = string.Empty;
        }

        private void Update_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                ActuallyLogin();
            }
        }
    }
}
