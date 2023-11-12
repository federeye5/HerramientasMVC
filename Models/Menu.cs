using Clase4.Utils;

namespace Clase4.Models;

public class Menu {
    public int id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public MenuType Type {get;set;}
    public bool IsVegetarian { get; set; }
    public int Calories { get; set; }
}