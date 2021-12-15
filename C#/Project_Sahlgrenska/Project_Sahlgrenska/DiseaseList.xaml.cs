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
        private List<string> symptomResult;

        public DiseaseList()
        {
            InitializeComponent();
            //PopulateDiseaseList();
        }

        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            symptomResult = Bot.ReadOneColumn("SELECT * FROM bt0mlsay6vs1xbceqzzn.diagnosis where Symtoms like '%" + symptomSearch.Text + "%'");

            List<string> diseaseList = new List<string>();

            for (int i = 0; i < symptomResult.Count; i++)
            {
                diseaseList.Add(symptomResult[i]);
            }
            comboDiseases.ItemsSource = diseaseList;
            
        }

        private void comboDiseases_DropDownClosed(object sender, System.EventArgs e)
        {
            diseaseTreatment.Text = Bot.ReadOneValue("SELECT Treatment FROM bt0mlsay6vs1xbceqzzn.diagnosis WHERE Name = '" + comboDiseases.SelectedItem + "';");

        }

        //private void PopulateDiseaseList()
        //{
        //    List<string> diseaseList = new List<string>();

        //    for (int i = 0; i < Bot.ReadOneColumn("select name from diagnosis;").Count; i++)
        //    {
        //        diseaseList.Add(Bot.ReadOneColumn("select name from diagnosis;")[i]);
        //    }
        //    sjukdom.ItemsSource = diseaseList;

        //}

        //private void sjukdom_DropDownClosed(object sender, System.EventArgs e)
        //{
        //    Hem.conn.Open();

        //    string Query = "select symtoms, treatment from diagnosis where name ='" + sjukdom.Text + "' ";

        //    MySqlCommand cmd = new MySqlCommand(Query, Hem.conn);
        //    MySqlDataReader dr = cmd.ExecuteReader();

        //    while (dr.Read())
        //    {
        //        string symtoms = dr.GetString(0);
        //        string treatment = dr.GetString(1);

        //        tsymtom.Text = symtoms;
        //        tåtgärd.Text = treatment;
        //    }

        //    Hem.conn.Close();
        //}


    }
}
