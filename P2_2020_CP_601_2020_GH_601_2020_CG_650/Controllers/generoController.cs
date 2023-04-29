using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P2_2020_CP_601_2020_GH_601_2020_CG_650.Models;

namespace P2_2020_CP_601_2020_GH_601_2020_CG_650.Controllers
{
    public class generoController : Controller
    {
        private readonly covidContext _context;

        public generoController(covidContext context)
        {
            _context = context;
        }

        // GET: genero
        public async Task<IActionResult> Index()
        {
              return _context.genero != null ? 
                          View(await _context.genero.ToListAsync()) :
                          Problem("Entity set 'covidContext.genero'  is null.");
        }

        // GET: genero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.genero == null)
            {
                return NotFound();
            }

            var genero = await _context.genero
                .FirstOrDefaultAsync(m => m.id_genero == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // GET: genero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: genero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_genero,nombre_genero")] genero genero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genero);
        }

        // GET: genero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.genero == null)
            {
                return NotFound();
            }

            var genero = await _context.genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound();
            }
            return View(genero);
        }

        // POST: genero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_genero,nombre_genero")] genero genero)
        {
            if (id != genero.id_genero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!generoExists(genero.id_genero))
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
            return View(genero);
        }

        // GET: genero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.genero == null)
            {
                return NotFound();
            }

            var genero = await _context.genero
                .FirstOrDefaultAsync(m => m.id_genero == id);
            if (genero == null)
            {
                return NotFound();
            }

            return View(genero);
        }

        // POST: genero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.genero == null)
            {
                return Problem("Entity set 'covidContext.genero'  is null.");
            }
            var genero = await _context.genero.FindAsync(id);
            if (genero != null)
            {
                _context.genero.Remove(genero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool generoExists(int id)
        {
          return (_context.genero?.Any(e => e.id_genero == id)).GetValueOrDefault();
        }
    }
}
