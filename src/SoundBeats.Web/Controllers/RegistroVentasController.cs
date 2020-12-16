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
    public class RegistroVentasController : Controller
    {
        private readonly SoundBeatsDbContext _context;

        public RegistroVentasController(SoundBeatsDbContext context)
        {
            _context = context;
        }

        // GET: RegistroVentas
        public async Task<IActionResult> Index()
        {
            var soundBeatsDbContext = _context.RegistroVentas.Include(r => r.IdEmpleadoNavigation).Include(r => r.IdTerceroNavigation);
            return View(await soundBeatsDbContext.ToListAsync());
        }

        // GET: RegistroVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVentas = await _context.RegistroVentas
                .Include(r => r.IdEmpleadoNavigation)
                .Include(r => r.IdTerceroNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistroVenta == id);
            if (registroVentas == null)
            {
                return NotFound();
            }

            return View(registroVentas);
        }

        // GET: RegistroVentas/Create
        public IActionResult Create()
        {
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido1");
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "IdTercero", "Direccion");
            return View();
        }

        // POST: RegistroVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRegistroVenta,IdEmpleado,IdTercero,TipoComprobante,NumComprobante,Subtotal,Impuesto,Total")] RegistroVentas registroVentas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registroVentas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido1", registroVentas.IdEmpleado);
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "IdTercero", "Direccion", registroVentas.IdTercero);
            return View(registroVentas);
        }

        // GET: RegistroVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVentas = await _context.RegistroVentas.FindAsync(id);
            if (registroVentas == null)
            {
                return NotFound();
            }
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido1", registroVentas.IdEmpleado);
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "IdTercero", "Direccion", registroVentas.IdTercero);
            return View(registroVentas);
        }

        // POST: RegistroVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRegistroVenta,IdEmpleado,IdTercero,TipoComprobante,NumComprobante,Subtotal,Impuesto,Total")] RegistroVentas registroVentas)
        {
            if (id != registroVentas.IdRegistroVenta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registroVentas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroVentasExists(registroVentas.IdRegistroVenta))
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
            ViewData["IdEmpleado"] = new SelectList(_context.Empleados, "IdEmpleado", "Apellido1", registroVentas.IdEmpleado);
            ViewData["IdTercero"] = new SelectList(_context.Terceros, "IdTercero", "Direccion", registroVentas.IdTercero);
            return View(registroVentas);
        }

        // GET: RegistroVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registroVentas = await _context.RegistroVentas
                .Include(r => r.IdEmpleadoNavigation)
                .Include(r => r.IdTerceroNavigation)
                .FirstOrDefaultAsync(m => m.IdRegistroVenta == id);
            if (registroVentas == null)
            {
                return NotFound();
            }

            return View(registroVentas);
        }

        // POST: RegistroVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registroVentas = await _context.RegistroVentas.FindAsync(id);
            _context.RegistroVentas.Remove(registroVentas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroVentasExists(int id)
        {
            return _context.RegistroVentas.Any(e => e.IdRegistroVenta == id);
        }
    }
}
