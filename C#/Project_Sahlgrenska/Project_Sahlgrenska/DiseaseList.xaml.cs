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
        }
        private void Button_ClickSearch(object sender, RoutedEventArgs e)
        {
            comboDiseases.Text = "";
            symptomResult = Bot.ReadOneColumn("SELECT * FROM bt0mlsay6vs1xbceqzzn.diagnosis where Symtoms like '%" + symptomSearch.Text + "%'");

            List<string> diseaseList = new List<string>();

            for (int i = 0; i < symptomResult.Count; i++)
            {
                diseaseList.Add(symptomResult[i]);
            }
            comboDiseases.ItemsSource = diseaseList;
            comboDiseases.SelectedIndex = 0;

            if (comboDiseases.SelectedIndex == -1)
            {
                diseaseTreatment.Text = "SYMPTOMET MATCHAR INGA REGISTRERADE SJUKDOMAR ";
            }
            else
            {
                diseaseTreatment.Text = Bot.ReadOneValue("SELECT Treatment FROM bt0mlsay6vs1xbceqzzn.diagnosis WHERE Name = '" + diseaseList[0] + "';");
            }
        }

        private void comboDiseases_DropDownClosed(object sender, System.EventArgs e)
        {
            diseaseTreatment.Text = Bot.ReadOneValue("SELECT Treatment FROM bt0mlsay6vs1xbceqzzn.diagnosis WHERE Name = '" + comboDiseases.SelectedItem + "';");
        }
    }
}
