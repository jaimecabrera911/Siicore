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
    public class DetalleRegistroVentasController : Controller
    {
        private readonly SoundBeatsDbContext _context;

        public DetalleRegistroVentasController(SoundBeatsDbContext context)
        {
            _context = context;
        }

        // GET: DetalleRegistroVentas
        public async Task<IActionResult> Index()
        {
            var soundBeatsDbContext = _context.DetalleRegistroVentas.Include(d => d.IdProductoNavigation).Include(d => d.IdRegistroVentaNavigation);
            return View(await soundBeatsDbContext.ToListAsync());
        }

        // GET: DetalleRegistroVentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleRegistroVentas = await _context.DetalleRegistroVentas
                .Include(d => d.IdProductoNavigation)
                .Include(d => d.IdRegistroVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleRegistroVentas == id);
            if (detalleRegistroVentas == null)
            {
                return NotFound();
            }

            return View(detalleRegistroVentas);
        }

        // GET: DetalleRegistroVentas/Create
        public IActionResult Create()
        {
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Codigo");
            ViewData["IdRegistroVenta"] = new SelectList(_context.RegistroVentas, "IdRegistroVenta", "NumComprobante");
            return View();
        }

        // POST: DetalleRegistroVentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDetalleRegistroVentas,IdRegistroVenta,IdProducto,Cantidad,Precio,Descuento")] DetalleRegistroVentas detalleRegistroVentas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleRegistroVentas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Codigo", detalleRegistroVentas.IdProducto);
            ViewData["IdRegistroVenta"] = new SelectList(_context.RegistroVentas, "IdRegistroVenta", "NumComprobante", detalleRegistroVentas.IdRegistroVenta);
            return View(detalleRegistroVentas);
        }

        // GET: DetalleRegistroVentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleRegistroVentas = await _context.DetalleRegistroVentas.FindAsync(id);
            if (detalleRegistroVentas == null)
            {
                return NotFound();
            }
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Codigo", detalleRegistroVentas.IdProducto);
            ViewData["IdRegistroVenta"] = new SelectList(_context.RegistroVentas, "IdRegistroVenta", "NumComprobante", detalleRegistroVentas.IdRegistroVenta);
            return View(detalleRegistroVentas);
        }

        // POST: DetalleRegistroVentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDetalleRegistroVentas,IdRegistroVenta,IdProducto,Cantidad,Precio,Descuento")] DetalleRegistroVentas detalleRegistroVentas)
        {
            if (id != detalleRegistroVentas.IdDetalleRegistroVentas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleRegistroVentas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleRegistroVentasExists(detalleRegistroVentas.IdDetalleRegistroVentas))
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
            ViewData["IdProducto"] = new SelectList(_context.Productos, "IdProducto", "Codigo", detalleRegistroVentas.IdProducto);
            ViewData["IdRegistroVenta"] = new SelectList(_context.RegistroVentas, "IdRegistroVenta", "NumComprobante", detalleRegistroVentas.IdRegistroVenta);
            return View(detalleRegistroVentas);
        }

        // GET: DetalleRegistroVentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detalleRegistroVentas = await _context.DetalleRegistroVentas
                .Include(d => d.IdProductoNavigation)
                .Include(d => d.IdRegistroVentaNavigation)
                .FirstOrDefaultAsync(m => m.IdDetalleRegistroVentas == id);
            if (detalleRegistroVentas == null)
            {
                return NotFound();
            }

            return View(detalleRegistroVentas);
        }

        // POST: DetalleRegistroVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detalleRegistroVentas = await _context.DetalleRegistroVentas.FindAsync(id);
            _context.DetalleRegistroVentas.Remove(detalleRegistroVentas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleRegistroVentasExists(int id)
        {
            return _context.DetalleRegistroVentas.Any(e => e.IdDetalleRegistroVentas == id);
        }
    }
}
