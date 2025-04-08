using PizzaAutomat.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Newtonsoft.Json;

namespace PizzaAutomat.ViewModels
{
    public class MachineViewModel : ObservableObject
    {
        public ObservableCollection<ProductViewModel> Items { get; private set; }
        public PaymentViewModel Bank { get; private set; }

        public MachineViewModel()
        {
            Bank = new PaymentViewModel();
            Items = new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel(1, "Pepperoni", 5.50),
                new ProductViewModel(2, "Margerhita", 6.50),
                new ProductViewModel(3, "Hawai", 10.75),
                new ProductViewModel(4, "Vege", 4.75),
                new ProductViewModel(5, "Pierogi", 3.75),
                new ProductViewModel(6, "Meat lover", 9.75),
            };
        }

        public void Purchase(object item)
        {
            var requestedItem = item as ProductViewModel;
            Bank.SelectedPrice(requestedItem.Information.Price);

            if (Bank.Confirm())
            {
                if (requestedItem.Dispense())
                {
                    Bank.Pay();
                    LogOrder(requestedItem);
                    Console.WriteLine("Enjoy your pizza!");
                }
            }
        }

        private void LogOrder(ProductViewModel item)
        {
            string path = "history.json";
            var order = new
            {
                Time = DateTime.Now,
                Product = item.Information.Name,
                Price = item.Information.Price
            };

            List<object> orders = new();
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                orders = JsonConvert.DeserializeObject<List<object>>(json) ?? new();
            }

            orders.Add(order);
            File.WriteAllText(path, JsonConvert.SerializeObject(orders, Formatting.Indented));
        }

        public void InsertChange(double value) => Bank.Insert(value);
        public void CollectPayments() => Bank.Collect();
        public void Refill()
        {
            foreach (var i in Items) i.Refill();
            Console.WriteLine("Machine has been refilled!");
        }

        public void Empty()
        {
            foreach (var i in Items) i.Empty();
            Console.WriteLine("Machine has been cleared!");
        }
    }
}
