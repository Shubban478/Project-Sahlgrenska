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
            string query = "SELECT * FROM medication";
            string query1 = "SELECT * FROM equipment";
            Bot.ReadAll(query, AvlMeds);
            Bot.ReadAll(query1, AvlEqu);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Glukosamin.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 10 where Name = 'Glukosamin';");
            }

            if (Harpatinum.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Harpatinum';");
            }

            if (Ipren.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Ipren';");
            }

            if (Microlax.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Microlax';");
            }

            if (Nasonex.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Nasonex';");
            }

            if (Ormsalva.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Ormsalva';");
            }

            if (Treo_Citrus.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Treo Citrus';");
            }

            if (Voltarén.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Voltarén';");
            }

            if (Xylocain.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Xylocain';");
            }

            if (Xyloproct.IsChecked == true)
            {
                Bot.Update("update medication set Quantity = Quantity + 20 where Name = 'Xyloproct';");
            }

            if (Blodtrycksmaskin.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 5 where Name = 'Blodtrycksmaskin';");
            }

            if (EKG.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 2 where Name = 'EKG';");
            }

            if (Hjärtstartare.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 2 where Name = 'Hjärtstartare';");
            }

            if (Kateter.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 5 where Name = 'Kateter';");
            }

            if (Plasthandskar.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 2 where Name = 'Plasthandskar';");
            }

            if (Sängbäcken.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 2 where Name = 'Sängbäcken';");
            }

            if (Termometer.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 2 where Name = 'Termometer';");
            }

            if (Tops.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 5 where Name = 'Tops';");
            }

            if (Träspatel.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 5 where Name = 'Träspatel';");
            }

            if (Ultraljudsmaskin.IsChecked == true)
            {
                Bot.Update("update equipment set Quantity = Quantity + 5 where Name = 'Ultraljudsmaskin';");
            }

            if (Glukosamin.IsChecked == true || Harpatinum.IsChecked == true || Ipren.IsChecked == true || Microlax.IsChecked == true || Nasonex.IsChecked == true ||
                Ormsalva.IsChecked == true || Treo_Citrus.IsChecked == true || Voltarén.IsChecked == true || Xylocain.IsChecked == true || Xyloproct.IsChecked == true ||
                Blodtrycksmaskin.IsChecked == true || EKG.IsChecked == true || Hjärtstartare.IsChecked == true || Kateter.IsChecked == true || Plasthandskar.IsChecked == true ||
                Sängbäcken.IsChecked == true || Termometer.IsChecked == true || Tops.IsChecked == true || Träspatel.IsChecked == true || Ultraljudsmaskin.IsChecked == true)
            {
                MessageBox.Show("Beställningen lyckades!");
                PopulateAvailableMedsEqu();
            }

            else
            {
                MessageBox.Show("Ingen beställning gjord!");
            }
        }
    }
}