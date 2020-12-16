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
    public class TercerosController : Controller
    {
        private readonly SoundBeatsDbContext _context;

        public TercerosController(SoundBeatsDbContext context)
        {
            _context = context;
        }

        // GET: Terceros
        public async Task<IActionResult> Index()
        {
            var soundBeatsDbContext = _context.Terceros.Include(t => t.IdCategoriaTerceroNavigation);
            return View(await soundBeatsDbContext.ToListAsync());
        }

        // GET: Terceros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terceros = await _context.Terceros
                .Include(t => t.IdCategoriaTerceroNavigation)
                .FirstOrDefaultAsync(m => m.IdTercero == id);
            if (terceros == null)
            {
                return NotFound();
            }

            return View(terceros);
        }

        // GET: Terceros/Create
        public IActionResult Create()
        {
            ViewData["IdCategoriaTercero"] = new SelectList(_context.CategoriaTercero, "IdCategoriaTercero", "IdCategoriaTercero");
            return View();
        }

        // POST: Terceros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTercero,IdCategoriaTercero,TipoDocumento,NumDocumento,RazonSocial,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Direccion,Ciudad,Email,PersonaContacto,TelefonContacto,Estado")] Terceros terceros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terceros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCategoriaTercero"] = new SelectList(_context.CategoriaTercero, "IdCategoriaTercero", "IdCategoriaTercero", terceros.IdCategoriaTercero);
            return View(terceros);
        }

        // GET: Terceros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terceros = await _context.Terceros.FindAsync(id);
            if (terceros == null)
            {
                return NotFound();
            }
            ViewData["IdCategoriaTercero"] = new SelectList(_context.CategoriaTercero, "IdCategoriaTercero", "IdCategoriaTercero", terceros.IdCategoriaTercero);
            return View(terceros);
        }

        // POST: Terceros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTercero,IdCategoriaTercero,TipoDocumento,NumDocumento,RazonSocial,Nombre1,Nombre2,Apellido1,Apellido2,Telefono,Direccion,Ciudad,Email,PersonaContacto,TelefonContacto,Estado")] Terceros terceros)
        {
            if (id != terceros.IdTercero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terceros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TercerosExists(terceros.IdTercero))
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
            ViewData["IdCategoriaTercero"] = new SelectList(_context.CategoriaTercero, "IdCategoriaTercero", "IdCategoriaTercero", terceros.IdCategoriaTercero);
            return View(terceros);
        }

        // GET: Terceros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terceros = await _context.Terceros
                .Include(t => t.IdCategoriaTerceroNavigation)
                .FirstOrDefaultAsync(m => m.IdTercero == id);
            if (terceros == null)
            {
                return NotFound();
            }

            return View(terceros);
        }

        // POST: Terceros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terceros = await _context.Terceros.FindAsync(id);
            _context.Terceros.Remove(terceros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TercerosExists(int id)
        {
            return _context.Terceros.Any(e => e.IdTercero == id);
        }
    }
}
