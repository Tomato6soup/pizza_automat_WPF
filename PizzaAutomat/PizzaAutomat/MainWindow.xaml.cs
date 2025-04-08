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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PizzaAutomat.ViewModels;

namespace PizzaAutomat
{
    public partial class MainWindow : Window
    {
        public MachineViewModel _machine { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            _machine = new MachineViewModel();
            DataContext = _machine;
        }

        private void Purchase_Clicked(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _machine.Purchase(button.DataContext);
        }

        private void Insert25_Clicked(object sender, RoutedEventArgs e)
        {
            _machine.InsertChange(1.25);
        }

        private void Insert50_Clicked(object sender, RoutedEventArgs e)
        {
            _machine.InsertChange(1.50);
        }

        private void Insert75_Clicked(object sender, RoutedEventArgs e)
        {
            _machine.InsertChange(1.75);
        }

        //private void Refill_Clicked(object sender, RoutedEventArgs e)
        //{
        //    _machine.Refill();
        //}

        //private void Empty_Clicked(object sender, RoutedEventArgs e)
        //{
        //    _machine.Empty();
        //}

        //private void Withdraw_Clicked(object sender, RoutedEventArgs e)
        //{
        //    _machine.CollectPayments();
        //}
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text == "admin" && PasswordBox.Password == "1234abcd")
            {
                ManagerWindow manager = new ManagerWindow(_machine);
                manager.Show();
            }
            else
            {
                MessageBox.Show("Invalid credentials");
            }
        }
    }
}