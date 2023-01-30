
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EstefaniaVinueza_EjercicioCF.Data;
using EstefaniaVinueza_EjercicioCF.Models;

namespace EstefaniaVinueza_EjercicioCF.Controllers
{
    public class PizzaController : Controller
        
        
    {
        private readonly EstefaniaVinueza_EjercicioCFContext _context;
        internal readonly int? id;

        public PizzaController(EstefaniaVinueza_EjercicioCFContext context)
        {
            _context = context;
        }
        
     
        public async Task<IActionResult> Index()
        {
              return View(await _context.Pizza.ToListAsync());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

       
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PizzaId,Name,WithCheese,WithTomatoes,Price")] Pizza pizza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pizza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pizza);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }

            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza == null)
            {
                return NotFound();
            }
            return View(pizza);
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PizzaId,Name,WithCheese,WithTomatoes,Price")] Pizza pizza)
        {
            if (id != pizza.PizzaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pizza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PizzaExists(pizza.PizzaId))
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
            return View(pizza);
        }

    
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pizza == null)
            {
                return NotFound();
            }
            
            var pizza = await _context.Pizza
                .FirstOrDefaultAsync(m => m.PizzaId == id);
            if (pizza == null)
            {
                return NotFound();
            }

            return View(pizza);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pizza == null)
            {
                return Problem("Entity set 'EstefaniaVinueza_EjercicioCFContext.Pizza'  is null.");
            }
            var pizza = await _context.Pizza.FindAsync(id);
            if (pizza != null)
            {
                _context.Pizza.Remove(pizza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PizzaExists(int id)
        {
          return _context.Pizza.Any(e => e.PizzaId == id);
        }
    }
}
