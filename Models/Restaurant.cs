using Clase4.Utils;

namespace Clase4.Models;

public class Restaurant { //Relacion N a NN con menues
    public int id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }

    public int MenuId { get; set; }
    public virtual Menu Menu {get; set;} //Virtual es para que se de cuenta cual es la relacion y no la traiga en la BD
}