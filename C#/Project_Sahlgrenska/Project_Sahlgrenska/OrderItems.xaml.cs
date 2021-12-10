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

            Hem.conn.Open();

            string query = "SELECT * FROM medication";
            MySqlCommand cmd = new MySqlCommand(query, Hem.conn);
            cmd.ExecuteNonQuery();

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("medication");
            adapter.Fill(dt);
            AvlMeds.ItemsSource = dt.DefaultView;
            adapter.Update(dt);

            Hem.conn.Close();
        }

        private void AvlMeds_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void AvlEqu_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            Hem.conn.Open();

            string query = "SELECT * FROM equipment";
            MySqlCommand cmd = new MySqlCommand(query, Hem.conn);
            cmd.ExecuteNonQuery();

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("equipment");
            adapter.Fill(dt);
            AvlEqu.ItemsSource = dt.DefaultView;
            adapter.Update(dt);

            Hem.conn.Close();
        }
    }
}
