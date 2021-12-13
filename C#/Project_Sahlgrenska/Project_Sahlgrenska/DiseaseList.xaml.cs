using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for DiseaseList.xaml
    /// </summary>
    public partial class DiseaseList : Window
    {
        public DiseaseList()
        {
            InitializeComponent();
            PopulateDiseaseList();
        }

        private void PopulateDiseaseList()
        {
            List<string> diseaseList = new List<string>();

            for (int i = 0; i < Bot.ReadOneColumn("select name from diagnosis;").Count; i++)
            {
                diseaseList.Add(Bot.ReadOneColumn("select name from diagnosis;")[i]);
            }
            sjukdom.ItemsSource = diseaseList;

        }

        private void sjukdom_DropDownClosed(object sender, System.EventArgs e)
        {
            Hem.conn.Open();

            string Query = "select symtoms, treatment from diagnosis where name ='" + sjukdom.Text + "' ";

            MySqlCommand cmd = new MySqlCommand(Query, Hem.conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string symtoms = dr.GetString(0);
                string treatment = dr.GetString(1);

                tsymtom.Text = symtoms;
                tåtgärd.Text = treatment;
            }

            Hem.conn.Close();
        }
    }
}
