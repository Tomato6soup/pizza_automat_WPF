using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaAutomat
{
    /// <summary>
    /// Interaction logic for ZamowPizzaWindow.xaml
    /// </summary>
    public partial class ZamowPizzaWindow : Window
    {
        public ZamowPizzaWindow()
        {
            InitializeComponent();

            PizzaList.Items.Add("1. Margaryta - 20 zł");
            PizzaList.Items.Add("2. Hawai - 25 zł");
            PizzaList.Items.Add("3. Meat Lover - 30 zł");
        }

        private void Zamow_Click(object sender, RoutedEventArgs e)
        {
            if (PizzaList.SelectedItem != null)
            {
                MessageBox.Show($"Zamówiono: {PizzaList.SelectedItem}");
                this.Close();
            }
            else
            {
                MessageBox.Show("Wybierz pizzę przed zamówieniem!");
            }
        }
    }
}
