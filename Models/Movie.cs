
using System.ComponentModel.DataAnnotations;

namespace Clase4.Models;

public class Movie{
    public string Code{ get; set;}

    [Display(Name ="Nombre")]
    [Required]
    public string Name{ get; set;}
    [Range(5,100)]
    public int Minutes{ get; set;}
    public string Category{ get; set;}
    

}