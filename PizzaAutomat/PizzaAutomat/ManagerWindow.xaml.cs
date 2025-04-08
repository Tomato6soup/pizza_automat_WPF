using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using Newtonsoft.Json;
using PizzaAutomat.ViewModels;

namespace PizzaAutomat
{
    public partial class ManagerWindow : Window
    {
        private MachineViewModel machine;

        public ManagerWindow(MachineViewModel sharedViewModel)
        {
            InitializeComponent();
            machine = sharedViewModel;
        }

        private void Refill_Click(object sender, RoutedEventArgs e)
        {
            machine.Refill();
            OutputBox.Text = "Machine refilled.";
        }

        private void Empty_Click(object sender, RoutedEventArgs e)
        {
            machine.Empty();
            OutputBox.Text = "Machine emptied.";
        }
        private void Withdraw_Click(object sender, RoutedEventArgs e)
        {
            machine.CollectPayments();
            OutputBox.Text = "Payment withdrawn.";
        }

        private void ViewEarnings_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("earnings.json"))
                OutputBox.Text = File.ReadAllText("earnings.json");
            else
                OutputBox.Text = "No earnings recorded.";
        }

        private void ViewHistory_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("history.json"))
                OutputBox.Text = File.ReadAllText("history.json");
            else
                OutputBox.Text = "No order history.";
        }
     
    }
}