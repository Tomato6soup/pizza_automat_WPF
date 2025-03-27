using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAutomat
{
    
        public class Pizza
        {
            public string Nazwa { get; set; }
            public double Cena { get; set; }
            public Dictionary<string, int> Skladniki { get; set; }

            public Pizza(string nazwa, double cena, Dictionary<string, int> skladniki)
            {
                Nazwa = nazwa;
                Cena = cena;
                Skladniki = skladniki;
            }

            public override string ToString()
            {
                string skladnikiText = string.Join(", ", Skladniki.Select(s => $"{s.Key} ({s.Value}g)"));
                return $"{Nazwa} - {Cena} zł | Składniki: {skladnikiText}";
            }
        }
    
}
