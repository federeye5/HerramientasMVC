using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Clase4.Models;

public class Car{
    public int id { get; set; }
    [Display(Name="Modelo")]
    public string Model { get; set; }
    [Display(Name="Año")]
    public int Year { get; set; }
    [Display(Name="Patente")]
    public string Plate { get; set; }
    [Display(Name="Marca")]
    public string Make { get; set; }
    public string? Color { get; set; } // ? = nulleable

}