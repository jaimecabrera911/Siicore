using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoundBeats.Core.Domain;
using SoundBeats.Infrastructure.Data;

namespace SoundBeats.Web.Controllers
{
    public class CategoriaTerceroesController : Controller
    {
        private readonly SoundBeatsDbContext _context;

        public CategoriaTerceroesController(SoundBeatsDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaTerceroes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaTercero.ToListAsync());
        }

        // GET: CategoriaTerceroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaTercero = await _context.CategoriaTercero
                .FirstOrDefaultAsync(m => m.IdCategoriaTercero == id);
            if (categoriaTercero == null)
            {
                return NotFound();
            }

            return View(categoriaTercero);
        }

        // GET: CategoriaTerceroes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaTerceroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCategoriaTercero,Nombre")] CategoriaTercero categoriaTercero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaTercero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaTercero);
        }

        // GET: CategoriaTerceroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaTercero = await _context.CategoriaTercero.FindAsync(id);
            if (categoriaTercero == null)
            {
                return NotFound();
            }
            return View(categoriaTercero);
        }

        // POST: CategoriaTerceroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoriaTercero,Nombre")] CategoriaTercero categoriaTercero)
        {
            if (id != categoriaTercero.IdCategoriaTercero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaTercero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaTerceroExists(categoriaTercero.IdCategoriaTercero))
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
            return View(categoriaTercero);
        }

        // GET: CategoriaTerceroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaTercero = await _context.CategoriaTercero
                .FirstOrDefaultAsync(m => m.IdCategoriaTercero == id);
            if (categoriaTercero == null)
            {
                return NotFound();
            }

            return View(categoriaTercero);
        }

        // POST: CategoriaTerceroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaTercero = await _context.CategoriaTercero.FindAsync(id);
            _context.CategoriaTercero.Remove(categoriaTercero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaTerceroExists(int id)
        {
            return _context.CategoriaTercero.Any(e => e.IdCategoriaTercero == id);
        }
    }
}
