using System.Windows;
using System.Windows.Input;

namespace Project_Sahlgrenska
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void update_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Bot.Update(update.Text);
            }
        }

        private void select_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Bot.ReadAll(select.Text, output);
            }
        }
    }
}
