using EstefaniaVinueza_EjercicioCF.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstefaniaVinueza_EjercicioCF.Controllers
{
    public abstract class TemplateController<T> where T : PizzaController
    {
        protected readonly EstefaniaVinueza_EjercicioCFContext _context;
        private CancellationToken predicate;

        public object ModelState { get; private set; }

        public TemplateController(EstefaniaVinueza_EjercicioCFContext context) => _context = context;

        public virtual async Task<IActionResult> Index()
        {
            return View(await _context.Set<T>().ToListAsync());
        }

        private IActionResult View(List<T> ts)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var entity = await _context.Set<T>()
                .FirstOrDefaultAsync(predicate);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        private IActionResult NotFound()
        {
            throw new NotImplementedException();
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public virtual async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        private bool Exists(int id)
        {
            throw new NotImplementedException();
        }

        private IActionResult View(T entity)
        {
            throw new NotImplementedException();
        }

        private IActionResult RedirectToAction(string v)
        {
            throw new NotImplementedException();
        }
    }

}