using PizzaAutomat.Models;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace PizzaAutomat.ViewModels
{
    public class PaymentViewModel : ObservableObject
    {
        private double _total;
        private double _inserted;
        private double _change;
        private double _bankTotal;

        public double Total
        {
            get => _total;
            set { _total = value; OnPropertyChanged("Total"); }
        }

        public double Inserted
        {
            get => _inserted;
            set { _inserted = value; OnPropertyChanged("Inserted"); }
        }

        public double Change
        {
            get => _change;
            set { _change = value; OnPropertyChanged("Change"); }
        }

        public double BankTotal
        {
            get => _bankTotal;
            set { _bankTotal = value; OnPropertyChanged("BankTotal"); }
        }

        public PaymentViewModel()
        {
            Total = 0;
            Inserted = 0;
            Change = 0;
            BankTotal = 0;
        }

        public void Insert(double value)
        {
            Inserted += value;
        }

        public void SelectedPrice(double value)
        {
            Total = value;
        }

        public bool Confirm()
        {
            return Inserted >= Total;
        }

        public void Pay()
        {
            Change = Inserted - Total;
            BankTotal += Total;
            Inserted = 0;
            Total = 0;
        }

        public void Collect()
        {
            string filePath = "earnings.json";
            var earningsData = new { Date = DateTime.Now, Earnings = BankTotal };

            List<object> existing = new();
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                existing = JsonConvert.DeserializeObject<List<object>>(json) ?? new();
            }

            existing.Add(earningsData);
            File.WriteAllText(filePath, JsonConvert.SerializeObject(existing, Formatting.Indented));

            Console.WriteLine("Collected Payments: $" + BankTotal);
            BankTotal = 0;
        }
    }
}
