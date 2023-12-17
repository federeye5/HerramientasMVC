using Clase4.Models;

namespace Clase4.ViewModels;

public class RestaurantCreateViewModel {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }

    public List<int> MenuIds { get; set; }

}