using Newtonsoft.Json;
using System;
using System.IO;
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
using PizzaAutomat;

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
        //metoda dodaj nowa pizze

        // Metoda pokazująca historię zamówień, dodac wpis zamowien iz ZamowPizze
//        ///         private void InicjalizujPizze() ---> kod iz ZamowPizzaWindow
//        {
//            pizze = new List<Pizza>
//            {
//                new Pizza("1. Margaryta", 20.0, new Dictionary<string, int> { {"Mozzarella", 100}, {"Pomidory", 80}, {"Ketchup", 50} }),
//                new Pizza("2. Hawai", 25.0, new Dictionary<string, int> { {"Mozzarella", 100}, { "Pomidory", 80}, { "Ketchup", 50}, { "Ananas", 70} }),
//                new Pizza("3. Meat lover", 30.0, new Dictionary<string, int> { { "Mozzarella", 150 }, { "Pomidory", 100 }, { "Ketchup", 60 }, { "Kielbasa", 120 }, { "Boczek", 100 } }),
//                new Pizza("4. Vege", 25.0, new Dictionary<string, int> { { "Pomidory", 70 }, { "Ketchup", 50 }, { "Bazylia", 30 }, { "Cukinia", 50 } }),
//                new Pizza("5. Pepperoni", 28.0, new Dictionary<string, int> { { "Mozzarella", 120 }, { "Pomidory", 90 }, { "Ketchup", 50 }, { "Salami", 100 } }),
//                new Pizza("6. Capricciosa", 27.0, new Dictionary<string, int> { { "Mozzarella", 130 }, { "Pomidory", 100 }, { "Szynka", 110 }, { "Pieczarki", 80 } }),
//                new Pizza("7. Quattro Formaggi", 32.0, new Dictionary<string, int> { { "Mozzarella", 100 }, { "Gorgonzola", 50 }, { "Parmezan", 50 }, { "Ricotta", 50 } }),
//                new Pizza("8. Diavola", 29.0, new Dictionary<string, int> { { "Mozzarella", 100 }, { "Pomidory", 90 }, { "Salami", 100 }, { "Papryczki chili", 40 } }),
//                new Pizza("9. Frutti di Mare", 35.0, new Dictionary<string, int> { { "Mozzarella", 120 }, { "Pomidory", 100 }, { "Krewetki", 70 }, { "Malze", 70 }, { "Oliwki", 50 } }),
//                new Pizza("10. Polska", 30.0, new Dictionary<string, int> { { "Mozzarella", 100 }, { "Pomidory", 90 }, { "Ketchup", 50 }, { "Kielbasa", 100 }, { "Ogorki kiszone", 60 } })
//            };

//foreach (var pizza in pizze)
//{
//    PizzaListBox.Items.Add(pizza);
//}
//        }

//        private void Zamow_Click(object sender, RoutedEventArgs e)
//{
//    if (PizzaListBox.SelectedItems.Count > 0)
//    {
//        List<string> zamowionePizze = PizzaListBox.SelectedItems.Cast<Pizza>().Select(p => p.Nazwa).ToList();
//        MessageBox.Show($"Zamówiono: {string.Join(", ", zamowionePizze)}", "Potwierdzenie Zamówienia");
//        this.Close();
//    }
//    else
//    {
//        MessageBox.Show("Wybierz przynajmniej jedną pizzę!");
//    }
//}
private void PokazHistorie_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "historia_zamowien.json";

            if (File.Exists(filePath))
            {
                string jsonText = File.ReadAllText(filePath);
                var historia = JsonConvert.DeserializeObject<List<string>>(jsonText);

                string wynik = "Historia zamówień:\n";
                foreach (var zamowienie in historia)
                {
                    wynik += $"{zamowienie}\n";
                }

                MessageBox.Show(wynik, "Historia Zamówień");
            }
            else
            {
                MessageBox.Show("Brak historii zamówień.", "Błąd");
            }
        }
    }
}
