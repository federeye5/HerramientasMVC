using Clase4.Utils;

namespace Clase4.Models;

public class MenuDetailViewModel {

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Type {get;set;}
    public bool IsVegetarian { get; set; } = false;
    public int Calories { get; set; }

    public virtual List<Restaurant> Restaurants { get; set; }
}