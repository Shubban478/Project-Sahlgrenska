using MySql.Data.MySqlClient;
using System.Data;
using System.Windows;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for OrderItems.xaml
    /// </summary>
    public partial class OrderItems : Window
    {

        public OrderItems()
        {
            InitializeComponent();
            PopulateAvailableMedsEqu();
        }

        private void PopulateAvailableMedsEqu()
        {
            Hem.conn.Open();

            string query = "SELECT * FROM medication";
            MySqlCommand cmd = new MySqlCommand(query, Hem.conn);
            cmd.ExecuteNonQuery();

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("medication");
            adapter.Fill(dt);
            AvlMeds.ItemsSource = dt.DefaultView;
            adapter.Update(dt);

            string query2 = "SELECT * FROM equipment";
            MySqlCommand cmd2 = new MySqlCommand(query2, Hem.conn);
            cmd2.ExecuteNonQuery();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable("equipment");
            adapter2.Fill(dt2);
            AvlEqu.ItemsSource = dt2.DefaultView;
            adapter2.Update(dt2);

            Hem.conn.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Cigaretter.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 10 where Name = 'Cigaretter';");
            }

            if (Fluoxetin.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Fluoxetin';");
            }

            if (Inderal.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Inderal';");
            }

            if (Julmust.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Julmust';");
            }

            if (Kokain.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Kokain';");
            }

            if (Snus.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Snus';");
            }

            if (Blodtrycksmaskin.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 5 where Name = 'Blodtrycksmaskin';");
            }

            if (Ultraljudsmaskin.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 5 where Name = 'Ultraljudsmaskin';");
            }

            if (Cigaretter.IsChecked == true || Fluoxetin.IsChecked == true || Inderal.IsChecked == true || Julmust.IsChecked == true || Kokain.IsChecked == true || Snus.IsChecked == true || Blodtrycksmaskin.IsChecked == true || Ultraljudsmaskin.IsChecked == true)
            {
                MessageBox.Show("Beställningen lyckades!");
            }

            else
            {
                MessageBox.Show("Dafuq, you did not order anything");
            }
        }
    }
}
