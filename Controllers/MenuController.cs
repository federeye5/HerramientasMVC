using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clase4.Data;
using Clase4.Models;
using Clase4.ViewModels;

namespace Clase4.Controllers
{
    public class MenuController : Controller
    {
        private readonly MenuContext _context;

        public MenuController(MenuContext context)
        {
            _context = context;
        }

        // GET: Menu
        public async Task<IActionResult> Index(string nameFilter)
        {
            var query = from menu in _context.Menu select menu;//sentencia LinQ, Crea una Query pero no se ejecuta
            if (!string.IsNullOrEmpty(nameFilter))
            {
                query = query.Where(x => x.Name.Contains(nameFilter)); //sentencia LinQ forma metodo
            }

            var restaurants = query.Include(x => x.Restaurants).Select(x => x.Restaurants).ToList();

            var model = new MenuViewModel();
            model.Menus = await query.ToListAsync();

              return _context.Menu != null ? 
                          View(model) :
                          Problem("Entity set 'MenuContext.Menu'  is null.");
        }

        // GET: Menu/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.Include(x => x.Restaurants).FirstOrDefaultAsync(m => m.id == id);
            if (menu == null)
            {
                return NotFound();
            }
            var viewModel = new MenuDetailViewModel();
            viewModel.Name = menu.Name;
            viewModel.Type = menu.Type.ToString();//vuelve el valor de la propiedad y no la posicion
            viewModel.Calories = menu.Calories;
            viewModel.IsVegetarian = menu.IsVegetarian;
            viewModel.Restaurants = menu.Restaurants != null? menu.Restaurants : new List<Restaurant>(); //funcion ternaria explica si es null mande una lista vacia pero sino que mande los datos
            


            return View(viewModel);
        }

        // GET: Menu/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Name,Price,Type,IsVegetarian,Calories")] Menu menu)
        {
            //crear VM para que Restaurants sea valido
            if (ModelState.IsValid)
            {
                _context.Add(menu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu.FindAsync(id);
            if (menu == null)
            {
                return NotFound();
            }
            return View(menu);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Name,Price,Type,IsVegetarian,Calories")] Menu menu)
        {
            if (id != menu.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(menu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MenuExists(menu.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(menu);
        }

        // GET: Menu/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Menu == null)
            {
                return NotFound();
            }

            var menu = await _context.Menu
                .FirstOrDefaultAsync(m => m.id == id);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Menu == null)
            {
                return Problem("Entity set 'MenuContext.Menu'  is null.");
            }
            var menu = await _context.Menu.FindAsync(id);
            if (menu != null)
            {
                _context.Menu.Remove(menu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MenuExists(int id)
        {
          return (_context.Menu?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
