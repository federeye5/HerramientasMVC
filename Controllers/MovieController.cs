using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Clase4.Models;
using Clase4.Services;

namespace Clase4.Controllers;

public class MovieController : Controller
{
    public MovieController(){

    }

    public IActionResult Index()
    {
        var model = new List<Movie>();
        model =MovieService.GetAll();
        return View(model);
    }
    public IActionResult Detail(string Id){
        var model = new Movie();
        model =  MovieService.Get(Id);
        return View(model);
    }

    public IActionResult Create(){
        return View();
    }

    [HttpPost]
    public IActionResult Create(Movie movie){
        if(!ModelState.IsValid){
            return RedirectToAction("Create");
        }
        MovieService.Add(movie);
        return RedirectToAction("Index");

    }

   //para que el delete funcione hay que crear una vista primero que muestre un  formulario y que le pasemos el codigo de la pelicula y luego ahi se lo pasamos al otro codigo

    [HttpPost]
    public IActionResult Delete(string code){
        if(!ModelState.IsValid){
            return RedirectToAction("Delete");
        }
        MovieService.Delete(code);
        return RedirectToAction("Index");

    }

    
}
