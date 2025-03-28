using PizzaAutomat.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                new ProductViewModel(3, "Pierogi", 3.75),
                new ProductViewModel(4, "Meat lover", 9.75),
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
                    Console.WriteLine("Enjoy your beverage!");
                }
            }
        }

        public void InsertChange(double value)
        {
            Bank.Insert(value);
        }

        public void CollectPayments()
        {
            Bank.Collect();
        }

        public void Refill()
        {
            foreach (var i in Items)
            {
                i.Refill();
            }
            Console.WriteLine("Machine has been refilled!");
        }

        public void Empty()
        {
            foreach (var i in Items)
            {
                i.Empty();
            }
            Console.WriteLine("Machine has been cleared!");
        }
    }
}