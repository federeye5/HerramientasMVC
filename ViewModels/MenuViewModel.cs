using Clase4.Models;

namespace Clase4.ViewModels;

public class MenuViewModel {
    public List<Menu> Menus { get; set; } = new List<Menu>();

    public string? NameFilter { get; set; }
}