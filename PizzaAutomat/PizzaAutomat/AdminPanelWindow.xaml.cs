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
    /// Interaction logic for AdminPanelWindow.xaml
    /// </summary>
    public partial class AdminPanelWindow : Window
    {
        public AdminPanelWindow()
        {
            InitializeComponent();
        }

        private void SprawdzSkladniki_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mozzarella: 100, Pomidory: 80, Ketchup: 50");
        }

        private void PokazHistorie_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Klient: Jan Kowalski, Pizza: Margaryta");
        }
    }
}
