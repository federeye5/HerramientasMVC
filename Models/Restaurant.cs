using Clase4.Utils;

namespace Clase4.Models;

public class Restaurant { //Relacion NN a NN con menues

    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public virtual List<Menu> Menus {get; set;} //Virtual es para que se de cuenta cual es la relacion y no la traiga en la BD, cambiamos la relacion de muchos a muchos

}
