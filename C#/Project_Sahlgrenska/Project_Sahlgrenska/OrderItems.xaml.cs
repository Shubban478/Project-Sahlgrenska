﻿using MySql.Data.MySqlClient;
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

        }
    }
}
