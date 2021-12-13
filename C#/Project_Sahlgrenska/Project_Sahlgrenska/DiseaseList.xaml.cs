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
            diseases.ItemsSource = diseaseList;

        }
    }
}
