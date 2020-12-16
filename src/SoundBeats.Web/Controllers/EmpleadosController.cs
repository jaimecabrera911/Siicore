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
    public class EmpleadosController : Controller
    {
        private readonly SoundBeatsDbContext _context;

        public EmpleadosController(SoundBeatsDbContext context)
        {
            _context = context;
        }

        // GET: Empleados
        public async Task<IActionResult> Index()
        {
            var soundBeatsDbContext = _context.Empleados.Include(e => e.IdCargoNavigation).Include(e => e.IdUsuarioNavigation);
            return View(await soundBeatsDbContext.ToListAsync());
        }

        // GET: Empleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.IdCargoNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // GET: Empleados/Create
        public IActionResult Create()
        {
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "NombreCargo");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Clave");
            return View();
        }

        // POST: Empleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,IdUsuario,IdCargo,TipoDocumento,NumDocumento,Nombre1,Nombre2,Apellido1,Apellido2,Direccion,Telefono,Email,Estado")] Empleados empleados)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleados);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "NombreCargo", empleados.IdCargo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Clave", empleados.IdUsuario);
            return View(empleados);
        }

        // GET: Empleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados.FindAsync(id);
            if (empleados == null)
            {
                return NotFound();
            }
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "NombreCargo", empleados.IdCargo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Clave", empleados.IdUsuario);
            return View(empleados);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,IdUsuario,IdCargo,TipoDocumento,NumDocumento,Nombre1,Nombre2,Apellido1,Apellido2,Direccion,Telefono,Email,Estado")] Empleados empleados)
        {
            if (id != empleados.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadosExists(empleados.IdEmpleado))
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
            ViewData["IdCargo"] = new SelectList(_context.Cargos, "IdCargo", "NombreCargo", empleados.IdCargo);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "Clave", empleados.IdUsuario);
            return View(empleados);
        }

        // GET: Empleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empleados = await _context.Empleados
                .Include(e => e.IdCargoNavigation)
                .Include(e => e.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (empleados == null)
            {
                return NotFound();
            }

            return View(empleados);
        }

        // POST: Empleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empleados = await _context.Empleados.FindAsync(id);
            _context.Empleados.Remove(empleados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadosExists(int id)
        {
            return _context.Empleados.Any(e => e.IdEmpleado == id);
        }
    }
}
